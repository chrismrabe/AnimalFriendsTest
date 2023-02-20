using AnimalFriendsTest.Core.Interfaces;
using AnimalFriendsTest.Core.Services;
using AnimalFriendsTest.Domain.Interfaces.Context;
using AnimalFriendsTest.Domain.Interfaces.Repository;
using AnimalFriendsTest.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

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

		public static readonly object[][] CorrectData = {
			new object[] { validName, validSurname, validPolicyReference, goodDateOfBirth, "" },
			new object[] { validName, validSurname, validPolicyReference, nullDateOfBirth, validEmailAddressCom },
			new object[] { validName, validSurname, validPolicyReference, nullDateOfBirth, validEmailAddressCoUk },
		};

		[Theory, MemberData(nameof(CorrectData))]
		public void UserService_SavesCorrectly(string firstName, string Surname, string policyReference, DateTime? dateOfBirth, string Email)
		{
			//Assign
			var addedUser = new User { FirstName = firstName, Surname = Surname, PolicyReference = policyReference, DateOfBirth = dateOfBirth, Email = Email };

			//Act
			int savedUserId = userService.AddUser(addedUser);

			//Assert
			mockUserRepository.Received().Add(addedUser);

		}

		public static readonly object[][] IncorrectData =
{
			new object[] { "", validSurname, validPolicyReference, goodDateOfBirth, ""}, //no first name
			new object[] { "jo", validSurname, "D-345432", nullDateOfBirth, validEmailAddressCom}, //bad first name
			new object[] { validName, "", validPolicyReference, goodDateOfBirth, ""}, //no last name
			new object[] { validName, "Sm", "D-345432", nullDateOfBirth, validEmailAddressCom}, //Bad last name
			new object[] { validName, validSurname, validPolicyReference, badDateOfBirth, ""}, //invalid date of birth
			new object[] { validName, validSurname, validPolicyReference, goodDateOfBirth, validEmailAddressCom}, //only dob or email
			new object[] { validName, validSurname, "DD-345432", nullDateOfBirth, "john@smith.eu"}, //Bad email
			new object[] { validName, validSurname, "DD-345432", nullDateOfBirth, "jo@smith.com"}, //Bad email
			new object[] { validName, validSurname, "DD-345432", nullDateOfBirth, "john@s.com"}, //Bad email
			new object[] { validName, validSurname, "DD-345432", nullDateOfBirth, "johns.com"}, //Bad email
			new object[] { validName, validSurname, "3D-345432", nullDateOfBirth, validEmailAddressCom}, //Bad policy
			new object[] { validName, validSurname, "DD-345D32", nullDateOfBirth, validEmailAddressCom}, //Bad policy
			new object[] { validName, validSurname, "DD345432", nullDateOfBirth, validEmailAddressCom}, //Bad policy
			new object[] { validName, validSurname, "DD-34543", nullDateOfBirth, validEmailAddressCom}, //Bad policy
			new object[] { validName, validSurname, "D-345432", nullDateOfBirth, validEmailAddressCom}, //Bad policy
		};
		[Theory, MemberData(nameof(IncorrectData))]
		public void UserService_AddUser_Fails(string firstName, string Surname, string policyReference, DateTime dateOfBirth, string Email)
		{
			//Assign

			var addedUser = new User { FirstName = firstName, Surname = Surname, PolicyReference = policyReference, DateOfBirth = dateOfBirth, Email = Email };

			//Assert
			Assert.Throws<InvalidDataException>(() => userService.AddUser(addedUser));

		}
	}
}