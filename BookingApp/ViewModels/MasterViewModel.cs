using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUserRoles.ViewModels
{
    public class MasterViewModel
    {
        public PropertyViewModel PropertyViewModel { get; set; }
        public ReviewViewModel ReviewViewModel { get; set; }

        public MasterViewModel()
        {
            PropertyViewModel = new PropertyViewModel();
            ReviewViewModel = new ReviewViewModel();

        }
    }
}