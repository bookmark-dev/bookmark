using System.Collections.Generic;
using BookMark.Domain.Interfaces;

namespace BookMark.OrmData.Repositories {
	public interface IRepository<T> where T : IModel {
		List<T> All();
		T Get(long ID);
		bool Post(T model);
		bool Put(T model);
		bool Delete(T model);
	}
}