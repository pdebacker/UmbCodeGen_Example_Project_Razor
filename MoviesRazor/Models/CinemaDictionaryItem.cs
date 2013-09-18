using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public class CinemaDictionaryItem
    {
        [Property("cinemaName")]
        public string Name { get; set; }

        [Property("NodeUrl")]
        public string NodeUrl { get; set; }
    }
}