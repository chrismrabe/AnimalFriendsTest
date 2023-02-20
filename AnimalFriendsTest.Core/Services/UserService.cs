﻿using AnimalFriendsTest.Core.Interfaces;
using AnimalFriendsTest.Domain.Interfaces.Repository;
using AnimalFriendsTest.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Core.Services
{
	public class UserService : IUserService
	{
		public IUserRepository UserRepository { get; }

		public UserService(IUserRepository userRepository)
		{
			UserRepository = userRepository;
		}

		public int AddUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}