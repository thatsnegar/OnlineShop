using DAL;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared;
using ViewModels.ProfileDetails;

namespace Server.Controllers
{
    public class ChangePasswordForCurrentUserController : BaseControllerWithDatabase
    {
		public ChangePasswordForCurrentUserController(ILogger<ChangePasswordForCurrentUserController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<ChangePasswordForCurrentUserController> Logger { get; }

		// **************************************************
		// **************************************************


		#region ChangePassword
		//Get/Change Password
		[HttpGet]
		public IActionResult ChangePassword()
		{
			try
			{
				var foundedUser =
					  GetCurrentUser();

				ViewData["foundedOnlineUser"] = foundedUser;

				if (foundedUser is not null)
				{
					var viewModel = new ChangePasswordViewModel()
					{
						NewPassword = "",
					};
					return View(model: viewModel);
				}
				else
				{
					return NotFound();
				}
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}

		//Post//Change Password
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return View(model: viewModel);
				}
				var foundedUser =
					await UnitOfWork.Users.GetUserByIdAsync(id: GetCurrentUser()!.Id);

				if (foundedUser is null)
					return View(model: viewModel);

				foundedUser.Password = viewModel.NewPassword?.Encode();

				UnitOfWork.Users.Update(entity: foundedUser);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "Profiledetails");
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion


	}
}
