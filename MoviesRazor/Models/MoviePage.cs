using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MoviesRazor.Classes;

namespace MoviesRazor.Models
{
    public class MoviePage 
    {
        public Movie Movie { get; set; }
        public ShowDictionary.MovieDictionaryItem MovieDictionaryItem { get; set; }
    }
}