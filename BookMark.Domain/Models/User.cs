using System;
using BookMark.Domain.Abstracts;

namespace BookMark.Domain.Models {
	public class User : AModel {
		public long UserID { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public User() {
			UserID = DateTime.Now.Ticks;
		}
		public override long GetID() {
			return UserID;
		}
	}
}