using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public partial class MovieProgram
    {
        public MovieProgramInfo MovieInfo { get; set; }
        public List<MovieTime> MovieTimes { get; set; }
    }

    public class MovieTime
    {
        public string DisplayDate { get; set; }
        public string DisplayTimes { get; set; }
    }

    public class MovieProgramInfo
    {
        [Property("movieImage")]
        public MediaInfo Image { get; set; }
    }

}