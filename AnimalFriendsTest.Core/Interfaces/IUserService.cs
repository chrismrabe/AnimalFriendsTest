using AnimalFriendsTest.Domain.Interfaces.Context;
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
		int AddUser(User user);
	}
}
