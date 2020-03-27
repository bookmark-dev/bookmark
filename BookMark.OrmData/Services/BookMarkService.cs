using System;
using System.Collections.Generic;
using BCrypt.Net;
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
		public bool PostUser(string name, string submitted_password) {
			string password = BCrypt.Net.BCrypt.HashPassword(submitted_password);
			User user = new User() { 
				Name = name,
				Password = password
			};
			return _ur.Post(user);
		}
		// PUT
		public bool PutUser(User user) {
			user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
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
		public bool CheckUserCredentials(string name, string submitted_password) {
			User user = this.FindUserByName(name);
			if (user != null) {
				return BCrypt.Net.BCrypt.Verify(submitted_password, user.Password);
			}
			return false;
		}
	}
}