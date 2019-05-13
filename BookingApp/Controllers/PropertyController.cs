using MvcUserRoles.Models;
using Microsoft.AspNet.Identity;
using MvcUserRoles.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace MvcUserRoles.Controllers
{
    public class PropertyController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PropertyController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public ActionResult Search(SearchPropertyViewModel viewModel, int page = 1)
        {

            if (page <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Parameter 'page' must be positive.");
            }

            int productsPerPage = (int)viewModel.ItemsPerPage;


            var filters = _context.Properties
                .Include(a => a.Bookings)
                .Where(a => String.IsNullOrEmpty(viewModel.SearchText) || a.City.ToLower().Contains(viewModel.SearchText.ToLower()) || a.Country.Contains(viewModel.SearchText.ToLower()))
                .Where(a => viewModel.Guests == 0 || a.Guests >= viewModel.Guests)
                .Where(a => viewModel.Category == Category.All || viewModel.Category == a.Category)
                .Where(a => !a.Bookings.Any() || a.Bookings.All(b => !(
                     (DateTime.Compare(viewModel.CheckIn, b.StartDate) >= 0 && DateTime.Compare(viewModel.CheckOut, b.EndDate) <= 0) ||
                     (DateTime.Compare(viewModel.CheckIn, b.StartDate) < 0 && DateTime.Compare(viewModel.CheckOut, b.EndDate) > 0) ||
                     (DateTime.Compare(viewModel.CheckIn, b.StartDate) >= 0 && DateTime.Compare(viewModel.CheckIn, b.EndDate) < 0) ||
                     (DateTime.Compare(viewModel.CheckOut, b.StartDate) > 0 && DateTime.Compare(viewModel.CheckOut, b.EndDate) <= 0)
                 )));






            int totalPages = (int)Math.Ceiling(filters.Count() / (double)productsPerPage);

            var filteredProperties = filters.OrderBy(a => a.Id)
                                .Skip((page - 1) * productsPerPage)
                                .Take(productsPerPage)
                                .ToList();

            viewModel = new SearchPropertyViewModel()
            {
                Properties = filteredProperties,
                SearchText = viewModel.SearchText,
                CurrentPage = page,
                TotalPages = totalPages,
                ItemsPerPage = viewModel.ItemsPerPage,
                Category = viewModel.Category,
                CheckIn = viewModel.CheckIn,
                Guests = viewModel.Guests,
                CheckOut = viewModel.CheckOut
            };

            return View("SearchProperty", viewModel);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deletedProperty=_context.Properties.Find(id);

            _context.Properties.Remove(deletedProperty);
            _context.SaveChanges();
            return RedirectToAction("Mine");
        }

        public ActionResult Edit(int id)
        {
            var property = _context.Properties.Find(id);

            var propertyviewmodel = new PropertyViewModel()
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description,
                City = property.City,
                Country = property.Country,
                PricePerNight = property.PricePerNight,
                Guests = property.Guests,
                Beds = property.Beds,
                Rooms = property.Rooms,
                Image = property.Image

            };

            return View("EditProperty", propertyviewmodel);

        }
        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public ActionResult Edit(PropertyViewModel propertyViewModel, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProperty", propertyViewModel);
            }

            string path = string.Empty;
            if (image != null)
            {
                path = Path.Combine(Server.MapPath("~/Data"), $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}");
                image.SaveAs(path);
            }

            var property = _context.Properties.Find(propertyViewModel.Id);


            property.Name = propertyViewModel.Name;
            property.Description = propertyViewModel.Description;
            property.City = propertyViewModel.City;
            property.Country = propertyViewModel.Country;
            property.PricePerNight = propertyViewModel.PricePerNight;
            property.Guests = propertyViewModel.Guests;
            property.Beds = propertyViewModel.Beds;
            property.Rooms = propertyViewModel.Rooms;

            if (image!=null)
            {
                property.Image = Path.GetFileName(path);
            }
            

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var properties = _context.Properties.Where(a => a.ApplicationUserId == userId).ToList();
            
            if (properties.Count==0)
            {
                ViewBag.Message="You have not submitted any properties yet.";
            }

            return View("MyProperties",properties);
        }
        public ActionResult Details(PropertyViewModel property)
        {
            var master=new MasterViewModel() {
                PropertyViewModel=property
            };
            var propertyid = master.PropertyViewModel.Id;
            var owner = _context.Properties.Find(propertyid).ApplicationUserId;
           
            master.PropertyViewModel.ownerid = owner;

            return View("PropertyDetails", master);
        }

        public ActionResult Create()
        {
            PropertyViewModel propertyviewmodel = new PropertyViewModel();

            return View("CreateProperty", propertyviewmodel);
        }

        [HttpPost]
        public ActionResult Create(PropertyViewModel property, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View("AddProperty", property);
            }
            string path = string.Empty;
            if (image != null)
            {
                path = Path.Combine(Server.MapPath("~/Data"), $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}");
                image.SaveAs(path);
            }



            Property AddedProperty = new Property()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                Name = property.Name,
                Description = property.Description,
                City = property.City,
                Country = property.Country,
                PricePerNight = property.PricePerNight,
                Guests = property.Guests,
                Beds = property.Beds,
                Rooms = property.Rooms,
                Image = Path.GetFileName(path)


            };




            _context.Properties.Add(AddedProperty);
            _context.SaveChanges();

            //ViewBag.FileStatus = "File uploaded successfully.";


            return RedirectToAction("Index","Home");
        }


    }
}