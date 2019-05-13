using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcUserRoles.Models
{
    public enum Category{All=0,Apartment,House,Villa}

    public class Property
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        public string Country { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal PricePerNight { get; set; }

        [Required]
        [StringLength(1000)]
        public string Image { get; set; }

        [Required]
        [Range(1, 100)]
        public int Guests { get; set; }

        [Required]
        [Range(1, 100)]
        public int Beds { get; set; }

        [Required]
        [Range(1, 100)]
        public int Rooms { get; set; }

        [Required]
        public Category Category { get; set; }

        public ICollection<Booking> Bookings { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser Owner { get; set; }

    }

}