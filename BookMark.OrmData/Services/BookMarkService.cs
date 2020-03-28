using System.Collections.Generic;
using BookMark.Domain.Models;
using BookMark.OrmData.Databases;
using BookMark.OrmData.Repositories;

namespace BookMark.OrmData.Services {
	public class BookMarkService {
		private UserRepository _ur;
		public BookMarkService(BookMarkDbContext ctx) {
			_ur = new UserRepository(ctx);
		}
		// ALL
		public List<User> AllUsers() {
			return _ur.All();
		}
		// GET
		public User GetUser(long ID) {
			return _ur.Get(ID);
		}
		// POST
		public bool PostUser(User user) {
			return _ur.Post(user);
		}
		// PUT
		public bool PutUser(User user) {
			return _ur.Put(user);
		}
		// DELETE
		public bool DeleteUser(User user) {
			return _ur.Delete(user);
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