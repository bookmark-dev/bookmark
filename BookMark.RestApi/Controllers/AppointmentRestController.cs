using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using BookMark.RestApi.Models;
using BookMark.Domain.Models;
using BookMark.OrmData.Services;

namespace BookMark.RestApi.Controllers {
	[ApiController]
	[EnableCors()]
	public class AppointmentRestController : ControllerBase {
		private BookMarkService _srv;
		public AppointmentRestController(BookMarkService srv) {
			_srv = srv;
		}
		[HttpGet("/api/appt")]
		public IActionResult Get() {
			List<Appointment> appts = _srv.AllAppointments();
			if (appts.Count > 0) {
				return Ok(appts);
			}
			return NotFound("No appts exist!");
		}
		[HttpGet("/api/appt/{id}")]
		public IActionResult Get(string id) {
			long ID = 0;
			if (long.TryParse(id, out ID)) {
				Appointment appt = _srv.GetAppointment(ID);
				if (appt != null) {
					return Ok(appt);
				}
				return NotFound($"Couldn't find appt with ID: {ID}!");
			}
			return BadRequest("Couldn't parse appt ID!");
		}
		[HttpPost("/api/appt")]
		public IActionResult Post(AppointmentRestModel model) {
			if (ModelState.IsValid) {
				Appointment appt = new Appointment() {
					DateTime = model.DateTime
				};
				if (_srv.PostAppointment(appt)) {
					return Ok();
				}
				return BadRequest("Posting appt failed!");
			}
			return BadRequest("Appointment model is invalid!");
		}
		[HttpPut("/api/appt")]
		public IActionResult Put(AppointmentRestModel model) {
			if (ModelState.IsValid) {
				Appointment appt = new Appointment() {
					DateTime = model.DateTime
				};
				if (_srv.PutAppointment(appt)) {
					return Ok();
				}
				return BadRequest("Putting appt failed!");
			}
			return BadRequest("Appointment model is invalid!");
		}
		[HttpDelete("/api/appt/{id}")]
		public IActionResult Delete(string id) {
			long ID = 0;
			if (long.TryParse(id, out ID)) {
				Appointment appt = _srv.GetAppointment(ID);
				if (appt != null) {
					if (_srv.DeleteAppointment(appt)) {
						return Ok();
					}
					return BadRequest("Deleting appt failed!");
				}
				return NotFound($"Couldn't find appt with ID: {ID}!");
			}
			return BadRequest("Couldn't parse appt ID!");
		}
	}
}
