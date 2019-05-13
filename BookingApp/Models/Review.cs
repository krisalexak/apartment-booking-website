using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcUserRoles.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        public string ApplicationUserId {get;set;}
        public ApplicationUser Traveler { get; set; }

        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}