using System;
using System.Collections.Generic;
using BCrypt.Net;
using BookMark.Domain.Abstracts;

namespace BookMark.Domain.Models {
	public class User : AModel {
		public long UserID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		#region NAVIGATION PROPERTIES
		public List<UserAppointment> UserAppointments { get; set; }
		#endregion
		public User() {
			UserID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return UserID;
		}
		public bool CheckCredentials(string password) {
			return BCrypt.Net.BCrypt.Verify(password, this.Password);
		}
	}
}