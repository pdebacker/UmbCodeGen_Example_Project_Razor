using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public class MoviesPage 
    {
        public Movies Movies { get; set; }
        public Genres Genres { get; set; }
    }
}