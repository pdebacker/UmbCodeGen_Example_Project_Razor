using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;

using MoviesRazor.Models;
using umbraco.interfaces;
using umbraco.NodeFactory;

namespace MoviesRazor.Classes
{
    public class ShowDictionary
    {
        #region Public

        public static MovieDictionaryItem MovieShowingAt(Movie movie)
        {
            var dictionary = new ShowDictionary();
            return dictionary.GetMovieShowingAt(movie);
        }

        public class MovieDictionaryItem
        {
            public int MovieNodeId { get; set; }
            public List<CityDictionaryItem> Cities { get; set; }
        }
        public class CityDictionaryItem
        {
            public string CityName { get; set; }
            public List<CinemaDictionaryItem> Cinemas { get; set; }
        }

        #endregion
        #region Private Methods

        private MovieDictionaryItem GetMovieShowingAt(Movie movie)
        {
            List<MovieDictionaryItem> moviesDictionary = GetDictionary();
            return moviesDictionary.First(m => m.MovieNodeId == movie.NodeId);
        }

        private List<MovieDictionaryItem> GetDictionary()
        {
            List<MovieDictionaryItem> data = System.Web.HttpContext.Current.Cache[CacheKey] as List<MovieDictionaryItem>;
            if (data == null)
            {
                data = Initialize();

                string configFile = System.Web.HttpContext.Current.Server.MapPath("/App_Data/umbraco.config");
                if (File.Exists(configFile))
                {
                    CacheDependency dependency = new CacheDependency(configFile);
                    System.Web.HttpContext.Current.Cache.Add(
                        CacheKey,
                        data,
                        dependency,
                        DateTime.MaxValue,
                        Cache.NoSlidingExpiration,
                        CacheItemPriority.Normal,
                        null);
                }

            }
            return data;
        }
        private List<MovieDictionaryItem> Initialize()
        {
            INode cinemasNode = Node.GetNodeByXpath("//HomePage/Cinemas");
            INode moviesNode = Node.GetNodeByXpath("//HomePage/Movies");

            var moviesDictionary = new List<MovieDictionaryItem>();
            foreach (INode movieNode in moviesNode.ChildrenAsList)
            {
                var movieItem = new MovieDictionaryItem();
                movieItem.MovieNodeId = movieNode.Id;
                LookupMovieAtCinemas(cinemasNode, movieItem);
                moviesDictionary.Add(movieItem);
            }
            return moviesDictionary;
        }


        //private List<MovieDictionaryItem> MoviesDictionary { get; set; }

        private void LookupMovieAtCinemas(INode cinemasNode, MovieDictionaryItem movieDictionaryItem)
        {
            foreach (INode cityNode in cinemasNode.ChildrenAsList)
            {
                var cityDictionary = new CityDictionaryItem();
                cityDictionary.Cinemas = new List<CinemaDictionaryItem>();
                cityDictionary.CityName = cityNode.Name;

                foreach (INode cinemaNode in cityNode.ChildrenAsList)
                {
                    var cinema = ModelFactory.CreateModel<Cinema>(cinemaNode);
                    foreach (var program in cinema.MoviePrograms)
                    {
                        if (program.MovieLink.NodeId == movieDictionaryItem.MovieNodeId)
                        {
                            cityDictionary.Cinemas.Add(new CinemaDictionaryItem() { Name = cinema.Name, NodeUrl = cinema.NodeUrl });
                            break;
                        }
                    }
                }
                if (cityDictionary.Cinemas.Count > 0)
                {
                    if (movieDictionaryItem.Cities == null)
                        movieDictionaryItem.Cities = new List<CityDictionaryItem>();
                    movieDictionaryItem.Cities.Add(cityDictionary);
                }
            }
        }

        private const string CacheKey = "ShowDictionary";
        #endregion
    }
}