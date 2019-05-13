using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcUserRoles.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required]
        public int Guests { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser Traveler { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }

        
    }
}