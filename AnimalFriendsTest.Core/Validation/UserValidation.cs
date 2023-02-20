using AnimalFriendsTest.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Core.Validation
{
	public static class UserValidation
	{

		private static Regex nameLengthValidation = new Regex(@"^(?=.{3,50}$).*");

		public static bool UserDetailsValid(this User user)
		{
			if (!ValidateNameLength(user.FirstName) || !ValidateNameLength(user.Surname))
			{
				return false;
			}

			return true;
		}

		public static bool ValidateNameLength(string name)
		{
			return nameLengthValidation.IsMatch(name);
		}
	}
}
