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
                Genres = genres,
                PageName = "New Movie"
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AddMovieViewModel()
                {
                    Movie = movie,
                    Genres = _dbContext.Genres.ToList(),
                    PageName = "New Movie"

                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _dbContext.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _dbContext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            

            
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movieInDb = _dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return HttpNotFound();
            }

            var genres = _dbContext.Genres.ToList();
            var viewModel = new AddMovieViewModel()
            {
                Movie = movieInDb,
                Genres = genres,
                PageName = "Edit Movie"
            };
            return View("MovieForm", viewModel);
        }
    }
}