using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using InkyBeta.Business.UserManager;
using InkyBeta.Core;
using InkyBeta.Models;
using Microsoft.AspNet.Identity;

namespace InkyBeta.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _manager;

		public AccountController(UserManager<User> manager)
		{
			_manager = manager;
			_manager.EmailService = new MessageService();
		}

		//
		// GET: /Account/

		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(UserModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			Guid privateGuid = Guid.NewGuid();
			Guid publicGuid = Guid.NewGuid();
			var user = new User()
			{
				UserName = model.UserName,
				Email = model.Email,
				FirstName = model.FirstName,
				MiddleName = model.MiddleName,
				LastName = model.LastName,
				PasswordHint = model.PasswordHint,
				Motto = model.Motto,
				PhoneNumber = model.PhoneNumber,
				PrivateKey = privateGuid.ToString(),
				PublicKey = publicGuid.ToString(),
				TimeCreated = DateTime.UtcNow
			};
			IdentityResult result = await _manager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{
				ModelState.AddModelError("UserName", "This username has already been taken");
				return View(model);
			}
			var code = await _manager.GenerateEmailConfirmationTokenAsync(user.Id);
			var callback = Url.Action("Verify", "Account", new { userId = user.Id, code = code});
			var html = String.Format("Click this <a href='{0}'>link</a> to activate your account.", callback);
			html += String.Format("Or enter your username and this code: {0}", code);
			await _manager.SendEmailAsync(user.Id, "Verifying your account", html);
			return
				Redirect(String.Format("~/Account/Verify?message={0}",
					Uri.EscapeDataString("Please check your email for the activation code.")));
		}

		public ActionResult Verify(string message)
		{
			ViewBag.Message = message;
			return View();
		}

		public async Task<ActionResult> Verify(string userId, string code)
		{
			if (String.IsNullOrWhiteSpace(userId) || String.IsNullOrWhiteSpace(code))
			{
				return View(model: "An error has occurred. Try entering your username and ID manually");
			}
			return View();
		}
	}
}
