using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public class MovieListItem : ModelBase
    {
        [Property("movieTitle")]
        public string Title { get; set; }

        [Property("movieGenre")]
        public Genre Genre { get; set; }

        [Property("movieImage")]
        public MediaInfo Image { get; set; }

    }
}