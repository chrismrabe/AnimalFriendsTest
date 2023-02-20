using AnimalFriendsTest.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Domain.Interfaces.Context
{
	public interface IUserContext
	{
		DbSet<User> User { get; }

		int SaveChanges();
	}
}
