using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Models;
using umbraco.interfaces;
using umbraco.NodeFactory;
using UmbCodeGen.TypeLib;

using MoviesRazor.Models;

namespace MoviesRazor.Controllers
{
    public class NewsItemController : BaseController
    {
        //
        // GET: /Movies/

        public override ActionResult Index(RenderModel model)
        {
             INode currentNode = Node.GetCurrent();
            var newsItem = ModelFactory.CreateModel<MoviesRazor.Models.NewsItem>(currentNode);
            newsItem.DisplayDate = newsItem.Date.ToString("dd MMMM yyyy");
            return CurrentTemplate(newsItem);
        }
    }
}
