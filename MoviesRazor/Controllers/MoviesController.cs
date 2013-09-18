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
using System.Web.Script.Serialization;

namespace MoviesRazor.Controllers
{
    public class MoviesController : BaseController
    {
        //
        // Note: 
        //  the Index method handles the inital page GET request and the Ajax POST request 
        //  on which a filtered result is returned. It is a simple approach to handle an Ajax
        //  request with little effort. A better option might be to use a SurfaceController.
        //  However, this example is about to show the Umbraco Code Generation possibilities 
        //  and is not about showing the best practices using Umbraco MVC.
        //


        public override ActionResult Index(RenderModel model)
        {
            if (Request.HttpMethod.Equals("GET"))
            {
                INode currentNode = Node.GetCurrent();
                var moviesPage = new MoviesPage();

                moviesPage.Movies = ModelFactory.CreateModel<MoviesRazor.Models.Movies>(currentNode);

                INode genresNode = Node.GetNodeByXpath("//Genres");
                moviesPage.Genres = ModelFactory.CreateModel<Genres>(genresNode);

                return CurrentTemplate(moviesPage);
            }
            else
            {
                int genreId = int.Parse(Request.QueryString["genreId"]);
                INode currentNode = Node.GetCurrent();
                var movies = ModelFactory.CreateModel<MoviesRazor.Models.Movies>(currentNode);

                movies.MovieListItems = movies.MovieListItems.Where(l => l.Genre.NodeId == genreId).ToList();

                return PartialView("MoviesList", movies);
            }
        }
    }
}
