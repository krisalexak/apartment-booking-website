using Microsoft.AspNet.Identity;
using MvcUserRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MvcUserRoles.ViewModels;

namespace MvcUserRoles.Controllers
{

    public class ReviewController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ReviewController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<Review> GetReviews(int id)
        {
            var reviews = _context.Reviews.Include(r=>r.Traveler).Where(r => r.PropertyId == id).ToList();
            return reviews;
        }

        [HttpPost]
        public IHttpActionResult CreateReview(Review review)
        {
            review.ApplicationUserId = User.Identity.GetUserId();
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok();
        }

    }

}
