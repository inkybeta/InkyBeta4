using System.ComponentModel.DataAnnotations;

namespace InkyBeta.Models
{
	public class UserModel
	{
		[Required(ErrorMessage = "You need to enter a username")]
		[MaxLength(50)]
		[Display(Name="Username")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Please enter your email address")]
		[MaxLength(200, ErrorMessage = "Sorry, your email can only be 200 character long.")]
		[DataType(DataType.EmailAddress)]
		[Display(Name="Email")]
		public string Email { get; set; }

		[MaxLength(20, ErrorMessage = "This is a phone number. Are you asleep on your keyboard?")]
		[DataType(DataType.PhoneNumber, ErrorMessage = "The field is not a valid phone number")]
		[Display(Name="Phone Number")]
		public string PhoneNumber { get; set; }

		[Required(ErrorMessage = "You need to enter a password")]
		[MinLength(6, ErrorMessage = "Passwords must be 6 characters long.")]
		[MaxLength(50, ErrorMessage = "I am sorry for all the crazy folks out there who have more than 50 character passwords. But seriously, this isn't your bank account. Keep it secure but not under lock and bolt. :|")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Please enter your password for your account again.")]
		[MaxLength(50, ErrorMessage = "This field can only be 50 characters long.")]
		[Display(Name="Confirm password")]
		[Compare("Password", ErrorMessage = "Passwords must be the same")]
		public string ConfirmPassword { get; set; }
		
		[Required(ErrorMessage = "You need to enter your first name.")]
		[MaxLength(50, ErrorMessage = "Sorry, there is a maximum length of 50 characters available for your last name. If you need more, contact support.")]
		[Display(Name="First Name")]
		public string FirstName { get; set; }

		[MaxLength(50, ErrorMessage = "There is a maximum length of 50 characters for your middle name.")]
		[Display(Name="Middle Name")]
		public string MiddleName { get; set; }

		[Required]
		[MaxLength(50, ErrorMessage = "Sorry, there is a maximum length of 50 characters available for your last name. If you need more, contact support.")]
		[Display(Name="Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "You need a hint for your password in case you want to reset it.")]
		[MaxLength(100, ErrorMessage = "Your password hint can only be 100 characters long. Sorry")]
		[Display(Name="Password Hint")]
		public string PasswordHint { get; set; }

		[Required(ErrorMessage = "You need a motto to sign in. Even if it's just 'hi'")]
		[MaxLength(500, ErrorMessage = "Sorry, your motto is too long")]
		[DataType(DataType.MultilineText)]
		[Display(Name="Motto")]
		public string Motto { get; set; }
	}
}
