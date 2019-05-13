using MvcUserRoles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcUserRoles.ViewModels
{
    public enum ItemsPerPage
    {
        [Display(Name = "6")]
        p05 = 6,
        [Display(Name = "12")]
        p10 = 12,
        [Display(Name = "18")]
        p15 = 18
    }

    public class SearchPropertyViewModel
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; } 
        [Display(Name = "Products per Page")]
        public ItemsPerPage ItemsPerPage { get; set; } = ItemsPerPage.p05;
        
        public IEnumerable<Property> Properties { get; set; }
        public string SearchText { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public Category Category { get; set; }

    }
}