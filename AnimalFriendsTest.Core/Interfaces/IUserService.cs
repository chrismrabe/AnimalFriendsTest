using AnimalFriendsTest.Domain.Interfaces.Repository;
using AnimalFriendsTest.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Core.Interfaces
{
	public interface IUserService
	{

		IUserRepository UserRepository { get; }

		int AddUser(User user);
	}
}
