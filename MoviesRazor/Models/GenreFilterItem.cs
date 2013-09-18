using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public class GenreFilterItem : Genre
    {
        public bool Active { get; set; }
        public string FilterUrl { get; set; }
    }
}