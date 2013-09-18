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
    public class CinemaController : BaseController
    {

        public override ActionResult Index(RenderModel model)
        {
            INode currentNode = Node.GetCurrent();
            var cinema = ModelFactory.CreateModel<Cinema>(currentNode);
            GetMovieImages(cinema);
            SetMovieTimes(cinema);

            return CurrentTemplate(cinema);
        }

        private void GetMovieImages(Cinema model)
        {
            foreach (var program in model.MoviePrograms)
            {
                Node movieNode = new Node(program.MovieLink.NodeId);
                program.MovieInfo = new MovieProgramInfo();
                ModelFactory.FillModel(program.MovieInfo, movieNode);
            }
        }

        private void SetMovieTimes(Cinema model)
        {
            foreach (var program in model.MoviePrograms)
            {
                MovieTime movieTime = null;
                program.MovieTimes = new List<MovieTime>();

                DateTime currentDateTime = DateTime.MinValue;
                foreach (DateTime dt in program.Showtimes.OrderBy(d => d))
                {
                    if (dt.Date != currentDateTime.Date)
                    {
                        currentDateTime = dt;
                        if (movieTime != null)
                            program.MovieTimes.Add(movieTime);

                        movieTime = new MovieTime();
                        movieTime.DisplayDate = dt.ToString("ddd dd MMM");
                        movieTime.DisplayTimes = dt.ToString("HH:mm");
                    }
                    else
                    {
                        movieTime.DisplayTimes += dt.ToString(" & HH:mm");
                    }
                }
                if (movieTime != null)
                    program.MovieTimes.Add(movieTime);
            }
        }

       
    }
}
