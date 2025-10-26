using System;

namespace Generics
{
	public interface IRepository<T>
	{
		void Add(T model);

		IEnumerable<T> GetAll();


	}
}

