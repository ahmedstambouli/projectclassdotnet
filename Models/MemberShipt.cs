using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace seance2.Models
{
	public class MemberShipt
	{

		[Key]
		public int Id { get; set; }

		[Required]
		public string SignUpFree { get; set; }

		[Required]
		public DateTime DurationInMonth { get; set; }

		[Required]
		public string DiscountRate { get; set; }


		public Customer Customer { get; set; }



		public  MemberShipt () { }


	}
}
