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
    public class HomePageController : BaseController
    {
        //public override ActionResult Index(RenderModel model)
        //{
        //    //Do some stuff here, then return the base method
        //    HomeModel customModel = new HomeModel(model);
        //    customModel.PageTitle = "Home @" + DateTime.Now.ToString("ss.fff");
        //    return CurrentTemplate(customModel);
        //    //return base.Index(model);
        //}


        public override ActionResult Index(RenderModel model)
        {
            INode currentNode = Node.GetCurrent();
            var homePage = ModelFactory.CreateModel<MoviesRazor.Models.HomePage>(currentNode);

            INode moviesNode = Node.GetNodeByXpath("//HomePage/Movies");
            foreach (INode movieNode in moviesNode.ChildrenAsList.Take(3))
            {
                homePage.TopMovies.Add(ModelFactory.CreateModel<MovieListItem>(movieNode));
            }

            INode newsNode = Node.GetNodeByXpath("//HomePage/NewsPage");
            foreach (INode newsItemNode in newsNode.ChildrenAsList.Take(3))
            {
                homePage.NewsListItems.Add(ModelFactory.CreateModel<NewsListItem>(newsItemNode));
            }
            FormatDates(homePage.NewsListItems);

            //homePage.Menu = base.Navigation();

            return CurrentTemplate(homePage);
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
