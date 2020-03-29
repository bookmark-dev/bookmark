using System.ComponentModel.DataAnnotations;
using BookMark.Domain.Models;

namespace BookMark.Client.Models {
	public class UserViewModel {
		[Required]
		public string Name;
		[Required]
		public string Password;
		public UserViewModel(User user) {
			Name = user.Name;
			Password = user.Password;
		}
		public UserViewModel() {
			
		}
	}
}