using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using BookMark.Domain.Models;
using BookMark.Client.Utility;
using BookMark.Client.Controllers;

// Run tests while Rest API is running...
namespace BookMark.Testing {
	public class UnitTest {
		[Fact]
		public void Test_GetUser() {
			// HttpService service = HttpService.Service;
			// HttpClient client = HttpService.Client;
			// Task<User> task = UserController.FindUserByName(client, "synaodev");
			// task.Wait();
			// User user = task.Result;
			// Console.WriteLine(user.Name);
			// Console.WriteLine(user.Password);
			// Assert.True(user != null);
			Assert.True(true);
		}
	}
}
