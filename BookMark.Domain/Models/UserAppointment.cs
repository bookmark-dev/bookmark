using System;

namespace BookMark.Domain.Models {
	public class UserAppointment {
		public long UserAppointmentID { get; set; }
		public long UserID { get; set; }
		public long AppointmentID { get; set; }
		#region NAVIGATION PROPERTIES
		public User User { get; set; }
		public Appointment Appointment { get; set; }
		#endregion
		public UserAppointment() {
			UserAppointmentID = DateTime.Now.Ticks;
		}
	}
}