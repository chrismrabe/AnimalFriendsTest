using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnimalFriendsTest.Domain.Models.User;
using AnimalFriendsTest.Domain.Interfaces.Context;

namespace AnimalFriendsTest.Api.Data
{
	public class UserContext : DbContext, IUserContext
	{
		public UserContext(DbContextOptions<UserContext> options)
			: base(options)
		{
		}
		public DbSet<User> User { get; } = default!;
	}
}