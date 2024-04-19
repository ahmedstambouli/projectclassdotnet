using seance2.Models;
using seance2.repos.Interfaces;

namespace seance2.repos.classes
{
	public class RepoMovies : IRepoMovies
	{
		private readonly AppDbContext _db;

		public RepoMovies(AppDbContext db)
		{  _db = db; }

		public List<Movie> getAllMovie()
		{
			var listmovie =_db.movies.ToList();
			return listmovie;
		}
	}
}
