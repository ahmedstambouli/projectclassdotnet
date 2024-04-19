using Microsoft.AspNetCore.Mvc;
using seance2.Models;
using System.Diagnostics.CodeAnalysis;

namespace seance2.Controllers
{
    public class MovieController : Controller
    {

        private readonly AppDbContext _db;

        public MovieController(AppDbContext _db) { this._db = _db; }
        //Get 
        public IActionResult Index()
        {


            /*  List<Movie> ListMovie = new List<Movie>();

              ListMovie.Add(new Movie(1, "The100"));
              ListMovie.Add(new Movie(2, "choufli 7al"));
              ListMovie.Add(new Movie(3, "nsibti la3ziza"));
              ListMovie.Add(new Movie(4, "peaky blinders"));
              Console.WriteLine(ListMovie);*/


            var ListMovie = _db.movies.ToList();
            return View(ListMovie);
        }

        public IActionResult Index2()
        {

            var ListMovie = _db.movies.ToList();
            return View(ListMovie);
        }

       

        public IActionResult Create()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            _db.Add(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


		public IActionResult Edit(int id)

		{
			var m = _db.movies.FirstOrDefault(c=>c.Id==id);

			return View(m);
		}

        [HttpPatch]
        [ValidateAntiForgeryToken]
		public IActionResult Edit(Movie movieup)

		{

            var movie = new Movie
            {
                name = movieup.name,
                relatedate = movieup.relatedate,
                withsubtitels = movieup.withsubtitels,


            };

                _db.movies.Update(movie);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index2));


			
           
            

		}

		public IActionResult Delete(int id)
        {
            return View();
        }






	}



}
