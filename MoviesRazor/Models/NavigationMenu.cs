using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public class NavigationMenu
    {
        [Children("MenuItem")]
        public List<MenuItem> MenuItems { get; set; }
    }
}