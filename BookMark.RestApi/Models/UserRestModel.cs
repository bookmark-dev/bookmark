using System.ComponentModel.DataAnnotations;

namespace BookMark.RestApi.Models {
	public class UserRestModel {
		[Required]
		public string Name { get; set; }
		[Required]
		public string Password { get; set; }
	}
}