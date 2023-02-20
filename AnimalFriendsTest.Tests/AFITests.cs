using AnimalFriendsTest.Core.Interfaces;
using AnimalFriendsTest.Core.Services;
using AnimalFriendsTest.Domain.Interfaces.Context;
using AnimalFriendsTest.Domain.Interfaces.Repository;
using AnimalFriendsTest.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace AnimalFriendsTest.Tests
{
	public class UnitTest1
	{

		readonly IUserService userService;
		private static readonly DateTime goodDateOfBirth = new DateTime(1988, 12, 12);
		private static readonly DateTime badDateOfBirth = new DateTime(2008, 12, 12);
		private static readonly DateTime nullDateOfBirth = default(DateTime);
		private static readonly string validName = "John";
		private static readonly string validSurname = "Smith";
		private static readonly string validPolicyReference = "DD-123456";
		private static readonly string validEmailAddressCom = "john@smith.com";
		private static readonly string validEmailAddressCoUk = "john@smith.co.uk";

		readonly IQueryable mockUsers;
		private readonly DbSet<User> userMockSet;
		private readonly IUserRepository mockUserRepository;

		public UnitTest1()
		{
			mockUsers = new List<User>().AsQueryable();

			userMockSet = Substitute.For<DbSet<User>, IQueryable<User>>();

			((IQueryable<User>)userMockSet).Provider.Returns(mockUsers.Provider);
			((IQueryable<User>)userMockSet).Expression.Returns(mockUsers.Expression);
			((IQueryable<User>)userMockSet).ElementType.Returns(mockUsers.ElementType);
			((IQueryable<User>)userMockSet).GetEnumerator().Returns(mockUsers.GetEnumerator());

			var ContextMock = Substitute.For<IUserContext>();
			ContextMock.User.Returns(userMockSet);

			mockUserRepository = Substitute.For<IUserRepository>();

			userService = new UserService(mockUserRepository);
		}

		[Fact]
		public void UserService_SavesCorrectly()
		{


		}

		[Fact]
		public void USerService_SaveFails()
		{

		}
	}
}