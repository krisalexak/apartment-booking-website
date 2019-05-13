using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUserRoles.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime DateOfMessage { get; set; }

        public string OwnerOrTraveler { get; set; }



        public string ApplicationUserId { get; set; }

        public string ReceiverId { get; set; }



        public ApplicationUser User { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}