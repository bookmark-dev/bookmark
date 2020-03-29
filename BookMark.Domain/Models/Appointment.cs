using System;
using System.Collections.Generic;
using BookMark.Domain.Abstracts;
using BookMark.Domain.Models;

namespace BookMark.Domain.Models {
	public class Appointment : AModel {
		public long AppointmentID { get; set; }
		public DateTime DateTime { get; set; }
		#region NAVIGATION PROPERTIES
		public List<UserAppointment> UserAppointments { get; set; }
		#endregion
		public override long GetID() {
			return AppointmentID;
		}
		public Appointment() {
			AppointmentID = DateTime.Now.Ticks;
		}
	}
}