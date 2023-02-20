using AnimalFriendsTest.Core.Interfaces;
using AnimalFriendsTest.Core.Validation;
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
			var detailsValid = user.UserDetailsValid();
			if(detailsValid)
			{
				return UserRepository.Add(user);
			}
			else
			{
				throw new InvalidDataException("There was adding the user to the system");
			}
			
		}
	}
}
