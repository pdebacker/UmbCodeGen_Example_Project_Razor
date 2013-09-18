using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Web.Models;

namespace MoviesRazor.Models
{
    public class HomeModel : RenderModel
    {
        public HomeModel(RenderModel model)
            : base(model.Content, model.CurrentCulture)
        { }
        public string PageTitle { get; set; }
    }
}