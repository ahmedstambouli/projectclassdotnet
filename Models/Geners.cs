using System.ComponentModel.DataAnnotations;

namespace seance2.Models
{
	public class Geners
	{

		[Key]
		public int Id { get; set; }

		[Required]
		public string GenerName { get; set; }

		public List<Movie> Movies { get; set; }
		
	}
}
