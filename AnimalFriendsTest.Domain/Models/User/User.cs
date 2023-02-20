using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsTest.Domain.Models.User
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		[Column(TypeName = "nvarchar(50)")]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(50)]
		[Column(TypeName = "nvarchar(50)")]
		public string Surname { get; set; } = null!;

		//Not adding a referenced policy model as assuming it is living on external system
		[Required]
		[MaxLength(9)]
		[Column(TypeName = "nvarchar(9)")]
		public string PolicyReference { get; set; } = null!;

		[Column(TypeName ="date")]
		public DateTime? DateOfBirth { get; set; }

		[MaxLength(254)]
		[Column(TypeName = "varchar(254)")]
		public string? Email { get; set; }
	}
}
