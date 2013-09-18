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
    public class NewsPageController : BaseController
    {
        //
        // GET: /Movies/

        public override ActionResult Index(RenderModel model)
        {
            INode currentNode = Node.GetCurrent();
            var news = ModelFactory.CreateModel<MoviesRazor.Models.NewsPage>(currentNode);
            FormatDates(news.NewsListItems);
            return CurrentTemplate(news);
        }

        private void FormatDates(List<NewsListItem> items)
        {
            foreach (NewsListItem item in items)
            {
                item.DisplayDate = item.Date.ToString("dd MMMM yyyy");
            }
        }
    }
}
