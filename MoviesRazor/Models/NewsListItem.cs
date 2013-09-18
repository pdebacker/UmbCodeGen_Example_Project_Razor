using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public class NewsListItem : ModelBase
    {
        [Property("newsItemTitle")]
        public string Title { get; set; }

        [Property("newsItemIntroShort")]
        public string IntroShort { get; set; }

        [Property("newsItemDate")]
        public DateTime Date { get; set; }

        public string DisplayDate { get; set; }

    }
}