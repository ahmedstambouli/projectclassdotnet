using System.ComponentModel.DataAnnotations;

namespace seance2.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="name is required ")]
		public string Name { get; set; }


		public List<MemberShipt> memberShipts { get; set; }

		public List<Movie> movie { get; set; }

		public Customer() { }
		public Customer(int id ,string name) {
		this.Id = id;
		this.Name = name;
		}

	}
}
