using System.ComponentModel.DataAnnotations;
using BookMark.Domain.Models;

namespace BookMark.Client.Models {
	public class UserViewModel {
		[Required]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public UserViewModel(User user) {
			Name = user.Name;
			Password = user.Password;
		}
		public UserViewModel() {
			
		}
	}
}