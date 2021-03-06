using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BookMark.RestApi.Models;
using BookMark.Domain.Models;
using BookMark.OrmData.Services;

namespace BookMark.RestApi.Controllers {
	[ApiController]
	[EnableCors()]
	public class UserRestController : ControllerBase {
		private BookMarkService _srv;
		public UserRestController(BookMarkService srv) {
			_srv = srv;
		}
		[HttpGet("/api/user")]
		public IActionResult Get() {
			List<User> users = _srv.AllUsers();
			if (users.Count > 0) {
				return Ok(users);
			}
			return NotFound("No users exist!");
		}
		[HttpGet("/api/user/{id}")]
		public IActionResult Get(string id) {
			long ID = 0;
			if (long.TryParse(id, out ID)) {
				User user = _srv.GetUser(ID);
				if (user != null) {
					return Ok(user);
				}
				return NotFound($"Couldn't find user with ID: {ID}!");
			}
			return BadRequest("Couldn't parse user ID!");
		}
		[HttpGet("/api/user/name/{name}")]
		public IActionResult GetName(string name) {
			if (name.Length == 0) {
				return BadRequest("Name is invalid!");
			}
			User user = _srv.FindUserByName(name);
			if (user == null) {
				return NotFound($"Couldn't find user with name: {name}");
			}
			return Ok(user);
		}
		[HttpPost("/api/user")]
		public IActionResult Post(UserRestModel model) {
			if (ModelState.IsValid) {
				if (!_srv.CheckUserExists(model.Name)) {
					User user = new User() {
						Name = model.Name,
						Password = model.Password
					};
					if (_srv.PostUser(user)) {
						return Ok();
					}
					return BadRequest("Posting user failed!");
				}
				return BadRequest($"User with name \"{model.Name}\" already exists!");
			}
			return BadRequest("User model is invalid!");
		}
		[HttpPut("/api/user")]
		public IActionResult Put(UserRestModel model) {
			if (ModelState.IsValid) {
				if (_srv.CheckUserExists(model.Name)) {
					User user = new User() {
						Name = model.Name,
						Password = model.Password
					};
					if (_srv.PutUser(user)) {
						return Ok();
					}
					return BadRequest("Putting user failed!");
				}
				return NotFound($"Couldn't find user with name: \"{model.Name}\"!");
			}
			return BadRequest("User model is invalid!");
		}
		[HttpDelete("/api/user/{id}")]
		public IActionResult Delete(string id) {
			long ID = 0;
			if (long.TryParse(id, out ID)) {
				User user = _srv.GetUser(ID);
				if (user != null) {
					if (_srv.DeleteUser(user)) {
						return Ok();
					}
					return BadRequest("Deleting user failed!");
				}
				return NotFound($"Couldn't find user with ID: {ID}!");
			}
			return BadRequest("Couldn't parse user ID!");
		}
	}
}
