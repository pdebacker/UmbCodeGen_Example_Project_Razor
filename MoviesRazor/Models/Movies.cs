using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MoviesRazor.Models
{
    public partial class Movies
    {
        [ScriptIgnore()]
        public string DonNotSerializeThis { get; set; }

        [Children("Movie")]
        public List<MovieListItem> MovieListItems { get; set; }
    }
}