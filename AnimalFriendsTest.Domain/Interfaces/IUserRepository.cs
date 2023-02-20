using AnimalFriendsTest.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Domain.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
	{
	}
}
