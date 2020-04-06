using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var Movie = new Movie() {Name = "Shrek!"};
            var custumers = new List<Customer>()
            {
                new Customer {Name = "Custumer 1"},
                new Customer {Name = "Custumer 2"}

            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = Movie,
                Custumer = custumers
            };
            return View(viewModel);
        }

        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie(){Id = 1, Name = "Movie 1"},
                new Movie(){Id = 2, Name = "Movie 2"}

            };

            MovieViewModel viewModel = new MovieViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        
    }
}