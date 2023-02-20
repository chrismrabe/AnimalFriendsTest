using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Domain.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		int Add(T Entity);
	}
}
