using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BookMark.RestApi.Models;
using BookMark.Domain.Models;
using BookMark.OrmData.Services;

namespace BookMark.RestApi.Controllers {
	[ApiController]
	[Route("/api/users")]
	[EnableCors()]
	public class UserRestController : ControllerBase {
		private BookMarkService _srv;
		public UserRestController(BookMarkService srv) {
			_srv = srv;
		}
		[HttpGet]
		public IActionResult Get() {
			List<User> users = _srv.AllUsers();
			if (users.Count > 0) {
				return Ok(users);
			}
			return NotFound("No users exist!");
		}
		[HttpGet("{id}")]
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
		[HttpPost]
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
		[HttpPut]
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
		[HttpDelete("{id}")]
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
