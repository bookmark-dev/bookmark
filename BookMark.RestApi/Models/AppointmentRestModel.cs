using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookMark.Domain.Models;

namespace BookMark.RestApi.Models {
	public class AppointmentRestModel {
		[Required]
		public DateTime DateTime { get; set; }
		public List<User> Users { get; set; }
	}
}