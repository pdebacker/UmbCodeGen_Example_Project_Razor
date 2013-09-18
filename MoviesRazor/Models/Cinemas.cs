using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public partial class Cinemas
    {
        [Children("City", false)]
        public List<City> Cities { get; set; }
    }
}