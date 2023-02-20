using AnimalFriendsTest.Domain.Interfaces.Context;
using AnimalFriendsTest.Domain.Interfaces.Repository;
using AnimalFriendsTest.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Domain.Repository
{
    internal class UserRepository : IUserRepository
	{
		private readonly IUserContext _userContext;

		public UserRepository(IUserContext userContext)
		{ 
			_userContext = userContext;
		}

		public int Add(User Entity)
		{
			_userContext.User.Add(Entity);
			_userContext.SaveChanges();
			return Entity.Id;
		}
	}
}
