using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BookMark.Domain.Abstracts;
using BookMark.OrmData.Databases;

namespace BookMark.OrmData.Repositories {
	public abstract class ARepository<T> : IRepository<T> where T : AModel {
		protected BookMarkDbContext _ctx;
		public ARepository(BookMarkDbContext ctx) {
			_ctx = ctx;
		}
		public abstract List<T> All();
		public abstract T Get(long ID);
		public bool Post(T model) {
			DbSet<T> table = _ctx.Set<T>();
			table.Add(model);
			return _ctx.SaveChanges() >= 1;
		}
		public bool Put(T model) {
			T found = this.Get(model.GetID());
			if (found != null) {
				found = model;
				return _ctx.SaveChanges() >= 1;
			}
			return false;
		}
		public bool Delete(T model) {
			DbSet<T> table = _ctx.Set<T>();
			table.Remove(model);
			return _ctx.SaveChanges() >= 1;
		}
	}
}