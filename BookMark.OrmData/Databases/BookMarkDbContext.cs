using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookMark.Domain.Models;

namespace BookMark.OrmData.Databases {
	public class BookMarkDbContext : DbContext {
		private DbSet<User> Users { get; set; }
		public BookMarkDbContext(DbContextOptions options) : base(options) {

		}
		protected override void OnModelCreating(ModelBuilder builder) {
			// Setup Primary Keys
			builder.Entity<User>().HasKey(u => u.UserID);
			builder.Entity<User>().Property(u => u.UserID).ValueGeneratedNever();
			// Seed Data
			User[] users = new User[] {
				new User() { UserID = 1, Name = "synaodev", Password = "tylercadena" }
			};
			builder.Entity<User>().HasData(users);
		}
	}
}