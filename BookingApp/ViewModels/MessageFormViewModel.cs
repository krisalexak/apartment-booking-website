using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUserRoles.ViewModels
{
    public class MessageFormViewModel
    {

        public string body { get; set; }

        public DateTime dateofmessage { get; set; }

        public string ownerortraveler { get; set; }

        public string userid { get; set; }

        public string receiverid { get; set; }

        public int propertyid { get; set; }

    }
}