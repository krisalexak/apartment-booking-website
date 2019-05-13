
using Microsoft.AspNet.Identity;
using MvcUserRoles.Models;
using MvcUserRoles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcUserRoles.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Messages(string senderid)
        {
            string userid = User.Identity.GetUserId();
            ViewBag.userid = userid;


            string logged_in_user_role;
            if (User.IsInRole("Owner"))
            {
                logged_in_user_role = "Owner";
            }
            else
            {
                logged_in_user_role = "Traveler";
            }

            MessageFormViewModel messagemodel = new MessageFormViewModel()
            {
                receiverid = userid,
                userid = senderid

            };

            ViewBag.UserRole = logged_in_user_role;

            return View(messagemodel);
        }




        public ActionResult AllMessagesGrouped()
        {
            string userid = User.Identity.GetUserId();
            ViewBag.userid = userid;

            var allmessages = _context.Messages.Where(a => a.ReceiverId == userid).ToList();

            var distinct_senderid = allmessages.Select(a => a.ApplicationUserId).Distinct();

            List<ApplicationUser> list = new List<ApplicationUser>();

            foreach (var item in distinct_senderid)
            {
                var user = _context.Users.Find(item);
                list.Add(user);
            }

            return View(list);
        }

        public ActionResult CreateMessage(string owner)
        {
            var prop = _context.Properties.Where(a => a.ApplicationUserId == owner).FirstOrDefault();
            var propid = prop.Id;



            MessageFormViewModel messageformviewmodel = new MessageFormViewModel()
            {
                userid = User.Identity.GetUserId(),
                dateofmessage = DateTime.Now,
                receiverid = owner,
                propertyid = propid

            };



            return View(messageformviewmodel);
        }
        public ActionResult SaveMessage(MessageFormViewModel messageFormViewModel)
        {
            var UserId = User.Identity.GetUserId();

            Message message = new Message()
            {
                Body = messageFormViewModel.body,
                DateOfMessage = messageFormViewModel.dateofmessage,
                OwnerOrTraveler = "Traveler",
                ApplicationUserId = UserId,
                ReceiverId = messageFormViewModel.receiverid,
                PropertyId = messageFormViewModel.propertyid

            };

            _context.Messages.Add(message);
            _context.SaveChanges();
            return View("CreateMessage");
        }
    }


}