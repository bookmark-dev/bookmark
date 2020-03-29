using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BookMark.Domain.Models;
using BookMark.Client.Models;
using BookMark.Client.Utility;

namespace BookMark.Client.Controllers {
	public class UserController : Controller {
		private readonly HttpClient _http;
		public UserController() {
			_http = HttpService.Client;
		}
		static public async Task<User> GetCurrentUser(HttpContext context, HttpClient http) {
			string acct_id = context.Session.GetString("AcctID");
			if (acct_id == null) {
				return null;
			}
			if (acct_id.Length == 0) {
				return null;
			}
			long ID = 0;
			if (!long.TryParse(acct_id, out ID)) {
				return null;
			}
			HttpResponseMessage response = await http.GetAsync($"https://127.0.0.1:5001/api/user/name/{acct_id}");
			if (!response.IsSuccessStatusCode) {
				return null;
			}
			User user = await response.Content.ReadAsAsync<User>();
			return user;
		}
		public async Task<User> FindUserByName(string name) {
			HttpResponseMessage response = await _http.GetAsync($"https://127.0.0.1:5001/api/user/name/{name}");
			if (!response.IsSuccessStatusCode) {
				return null;
			}
			User user = await response.Content.ReadAsAsync<User>();
			return user;
		}
		[HttpGet]
		public IActionResult Index() {
			Task<User> user_task = GetCurrentUser(HttpContext, _http);
			user_task.Wait();
			User user = user_task.Result;
			if (user == null) {
				return Redirect("/home/index");
			}
			UserViewModel uvm = new UserViewModel(user);
			return View(uvm);
		}
		[HttpGet]
		public IActionResult Login() {
			return View(new UserViewModel());
		}
		[HttpPost]
		public IActionResult Login(UserViewModel uvm) {
			if (!ModelState.IsValid) {
				return View(uvm);
			}
			
			Task<User> task_user = FindUserByName(uvm.Name);
			User user = task_user.Result;
			if (user == null) {
				return View(uvm);
			}
			if (!user.CheckCredentials(uvm.Password)) {
				return View(uvm);
			}
			HttpContext.Session.SetString("AcctID", user.UserID.ToString());
			return Redirect("/user/index");
		}
	}
}