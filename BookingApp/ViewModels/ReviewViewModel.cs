using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUserRoles.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        //public string ApplicationUserId { get; set; }
        public int PropertyId { get; set; }
    }
}