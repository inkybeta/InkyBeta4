using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InkyBeta.Core
{
	public class User : IdentityUser
	{
		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; }

		[MaxLength(50)]
		public string MiddleName { get; set; }

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; }

		[Required]
		[MaxLength(100)]
		public string PasswordHint { get; set; }

		[Required]
		[MaxLength(500)]
		[DataType(DataType.MultilineText)]
		public string Motto { get; set; }

		[Required]
		[MaxLength(200)]
		public string PublicKey { get; set; }

		[Required]
		[MaxLength(200)]
		public string PrivateKey { get; set; }

		[Required]
		[DefaultValue(0)]
		public int Coins { get; set; }

		[Required]
		public DateTime TimeCreated { get; set; }
	}
}
