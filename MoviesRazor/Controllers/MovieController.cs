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
using MoviesRazor.Classes;

namespace MoviesRazor.Controllers
{
    public class MovieController : BaseController
    {
        //
        // GET: /Movies/

        public override ActionResult Index(RenderModel model)
        {
            INode currentNode = Node.GetCurrent();

            var pageModel = new MoviePage();
            pageModel.Movie = ModelFactory.CreateModel<Movie>(currentNode);
            FormatCast(pageModel.Movie);

            pageModel.MovieDictionaryItem = ShowDictionary.MovieShowingAt(pageModel.Movie);
            
            return CurrentTemplate(pageModel);

        }

        private void FormatCast(Movie movie)
        {
            movie.Cast = movie.Cast.Replace("\n", ", ");
        }
    }
}
