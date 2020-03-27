using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookMark.OrmData.Databases;
using BookMark.Domain.Models;

namespace BookMark.OrmData.Repositories {
	public class UserRepository : ARepository<User> {
		public UserRepository(BookMarkDbContext ctx) : base(ctx) {

		}
		public override List<User> All() {
			DbSet<User> table = _ctx.Set<User>();
			return table.ToList();
		}
		public override User Get(long ID) {
			DbSet<User> table = _ctx.Set<User>();
			return table.SingleOrDefault(u => u.UserID == ID);
		}
		public User FindByName(string name) {
			DbSet<User> table = _ctx.Set<User>();
			return table.Where(u => u.Name == name).First();
		}
	}
}