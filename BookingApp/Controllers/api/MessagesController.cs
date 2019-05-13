using Microsoft.AspNet.Identity;
using MvcUserRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcUserRoles.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MessagesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Message> GetAllMessages()
        {
            var userid = User.Identity.GetUserId();
            var messages = _context.Messages.Where(a => a.ApplicationUserId == userid || a.ReceiverId == userid).OrderBy(d => d.DateOfMessage);

            return messages;
        }

        public IHttpActionResult GetMessage(int id)
        {
            var message = _context.Messages.FirstOrDefault((p) => p.Id == id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpPost]
        public IHttpActionResult AddMessageToDB(Message message)
        {
            message.DateOfMessage = DateTime.Now;

            _context.Messages.Add(message);
            _context.SaveChanges();

            return Ok(message);


        }
    }
}
