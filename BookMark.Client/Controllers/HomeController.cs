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
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _http;
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
            _http = HttpService.Client;
        }
        public IActionResult Index() {
            Task<User> user_task = UserController.GetCurrentUser(HttpContext, _http);
            user_task.Wait();
            User result = user_task.Result;
            if (result == null) {
                return View();
            }
            return Redirect($"/users/{result.UserID}");
        }
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
