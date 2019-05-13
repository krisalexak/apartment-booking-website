using Microsoft.AspNet.Identity;
using MvcUserRoles.Models;
using MvcUserRoles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcUserRoles.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var bookings = _context.Bookings.Include(b=>b.Property).Where(a => a.ApplicationUserId == userId).ToList();

            if (bookings.Count == 0)
            {
                ViewBag.message = "You have not made any bookings yet.";
            }

            return View("MyBookings", bookings);
        }

        public ActionResult GetHostings()
        {
            var userId = User.Identity.GetUserId();
            var properties = _context.Properties.Where(p => p.ApplicationUserId == userId).Select(i=>i.Id).ToList();

            var bookings = _context.Bookings.Include(b => b.Property).Where(b=> properties.Contains(b.PropertyId)).ToList();

            if (bookings.Count == 0)
            {
                ViewBag.message = "You have not hosted any guests yet.";
            }

            return View("MyBookings", bookings);
        }
        public ActionResult GetUpcomingHostings()
        {
            var userId = User.Identity.GetUserId();
            var properties = _context.Properties.Where(p => p.ApplicationUserId == userId).Select(i => i.Id).ToList();

            var bookings = _context.Bookings.Include(b => b.Property).Where(b => properties.Contains(b.PropertyId) && (DateTime.Compare(b.StartDate, DateTime.Now) > 0)).ToList();

            if (bookings.Count == 0)
            {
                ViewBag.message = "You have no upcoming hostings yet.";
            }

            return View("MyBookings", bookings);
        }
        public ActionResult MineUpcoming()
        {
            var userId = User.Identity.GetUserId();
            var bookings = _context.Bookings.Include(b => b.Property).Where(b => b.ApplicationUserId == userId && (DateTime.Compare(b.StartDate, DateTime.Now)>0 )).ToList();

            if (bookings.Count == 0)
            {
                ViewBag.message = "You have no upcoming bookings.";
            }

            return View("MyBookings", bookings);
        }

        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        [HttpPost]
        [Authorize(Roles = "Admin,Traveler")]
        public ActionResult Create(MasterViewModel masterVM)
        {
            Booking newBooking = new Booking()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                PropertyId = masterVM.PropertyViewModel.Id,
                StartDate = masterVM.PropertyViewModel.CheckIn,
                EndDate = masterVM.PropertyViewModel.CheckOut,
                Guests = masterVM.PropertyViewModel.Guests,
                Price= masterVM.PropertyViewModel.CheckOut.Date.Subtract(masterVM.PropertyViewModel.CheckIn.Date).Days* masterVM.PropertyViewModel.PricePerNight
                
            };

            Session["booking"] = newBooking;

            _context.Bookings.Add(newBooking);


            _context.SaveChanges();

            //return View("SuccessBook");
            return RedirectToAction("PaymentWithPaypal","Payment");
        }
     
     
        
    }
}
