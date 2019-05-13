using MvcUserRoles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcUserRoles.ViewModels
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        public string ownerid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal PricePerNight { get; set; }
        public int Guests { get; set; }
        public int Beds { get; set; }
        public int Rooms { get; set; }
        public Category Category { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int BookGuests { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Property Photo")]
        public string Image { get; set; }
    }
}