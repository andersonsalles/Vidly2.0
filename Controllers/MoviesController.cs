using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

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
            //var movies = new List<Movie>()
            //{
            //    new Movie(){Id = 1, Name = "Movie 1"},
            //    new Movie(){Id = 2, Name = "Movie 2"}
            //
            //};

            var movies = _dbContext.Movies.Include(x => x.Genre).ToList();
            MovieViewModel viewModel = new MovieViewModel()
            {
                Movies = movies
            };
            return View(viewModel);
        }

        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
            var movie = _dbContext.Movies.Include(x => x.Genre).SingleOrDefault(c => c.Id == id);

            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var genres = _dbContext.Genres.ToList();
            var viewModel = new AddMovieViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }
    }
}