using System.Collections.Generic;
using BookMark.Domain.Models;
using BookMark.OrmData.Databases;
using BookMark.OrmData.Repositories;

namespace BookMark.OrmData.Services {
	public class BookMarkService {
		private UserRepository _ur;
		private AppointmentRepository _ar;
		public BookMarkService(BookMarkDbContext ctx) {
			_ur = new UserRepository(ctx);
			_ar = new AppointmentRepository(ctx);
		}
		// ALL
		public List<User> AllUsers() {
			return _ur.All();
		}
		public List<Appointment> AllAppointments() {
			return _ar.All();
		}
		// GET
		public User GetUser(long ID) {
			return _ur.Get(ID);
		}
		public Appointment GetAppointment(long ID) {
			return _ar.Get(ID);
		}
		// POST
		public bool PostUser(User user) {
			return _ur.Post(user);
		}
		public bool PostAppointment(Appointment appt) {
			return _ar.Post(appt);
		}
		// PUT
		public bool PutUser(User user) {
			return _ur.Put(user);
		}
		public bool PutAppointment(Appointment appt) {
			return _ar.Put(appt);
		}
		// DELETE
		public bool DeleteUser(User user) {
			return _ur.Delete(user);
		}
		public bool DeleteAppointment(Appointment appt) {
			return _ar.Delete(appt);
		}
		// EXTRA
		public User FindUserByName(string name) {
			return _ur.FindByName(name);
		}
		public bool CheckUserExists(string name) {
			User user = this.FindUserByName(name);
			return user != null;
		}
		public bool CheckUserCredentials(string name, string password) {
			return _ur.CheckCredentials(name, password);
		}
	}
}