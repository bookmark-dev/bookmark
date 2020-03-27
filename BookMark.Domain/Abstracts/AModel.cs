using BookMark.Domain.Interfaces;

namespace BookMark.Domain.Abstracts {
	public abstract class AModel : IModel {
		public abstract long GetID();
	}
}