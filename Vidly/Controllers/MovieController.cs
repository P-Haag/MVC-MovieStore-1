using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>()
            {
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer2"}
            };
            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }


        public ActionResult Index()
        {
            var customer = _context.Movies.Include(c => c.Genre).ToList();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }
        //    return Content(string.Format("pageIndex = {0} und sortBy = {1}",pageIndex,sortBy));
        //}

        //public ViewResult Index()
        //{
        //    var movies = GetMovies();
        //    return View(movies);
        //}

        private IEnumerable<Movie> GetMovies() => new List<Movie> { new Movie { Name = "Shrek!", Id = 1 }, new Movie { Name = "Wall-E", Id = 2 } };


        [Route("Movie/ByReleaseDate/{Year}/{Month:regex(\\d{2}):range(1,12)}")]
        public  ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Red(string name)
        {
            return RedirectToAction("Index", name);
        }



    }
}