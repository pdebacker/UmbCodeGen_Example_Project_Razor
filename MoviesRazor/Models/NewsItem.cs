using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesRazor.Models
{
    public partial class NewsItem
    {
        [Children("Paragraph", true)]
        public List<Paragraph> Paragraphs { get; set; }

        public string DisplayDate { get; set; }
    }
}