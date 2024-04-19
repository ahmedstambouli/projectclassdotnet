using Microsoft.EntityFrameworkCore;
using seance2.Models;

namespace seance2.Models
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions options):
						base(options)
		{

		}


		public DbSet<Movie> movies { get; set; }
		public DbSet<Customer> customers { get; set; }

		public DbSet<MemberShipt> memberShipts { get; set; }

		public DbSet<seance2.Models.Geners>? Geners { get; set; }


	}
}
