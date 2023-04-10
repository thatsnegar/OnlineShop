using DAL;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared;
using ViewModels.ProfileDetails;
using ViewModels.Users;

namespace Server.Controllers
{
	public class ProfileDetailsController : BaseControllerWithDatabase
	{

		public ProfileDetailsController(ILogger<ProfileDetailsController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<ProfileDetailsController> Logger { get; }

		// **************************************************
		// **************************************************

		#region Index
		[HttpGet]
		public async Task<IActionResult> Index(Guid id)
		{
			try
			{
				var foundedCurrentUser = GetCurrentUser();
				if (foundedCurrentUser is null)
				{
					return RedirectToAction(controllerName: "Account", actionName: "Login");
				}
				var foundeduser =
					await UnitOfWork.Users.GetUserByIdAsync(id: foundedCurrentUser!.Id);

				ViewData["foundedOnlineUser"] = foundedCurrentUser;

				if (foundeduser is not null)
				{
					var viewModel = new UserViewModel()
					{
						FullName = foundeduser.FullName,
						Gender = foundeduser.Gender,
						CellPhoneNumber = foundeduser.CellPhoneNumber,
						PhoneNumber = foundeduser.PhoneNumber,
						EmailAddress = foundeduser.EmailAddress,
						BirthDate = foundeduser.BirthDate,
						NationalCode = foundeduser.NationalCode,
						MENumber = foundeduser.MENumber,
						OfficeAddress = foundeduser.OfficeAddress,
						Especialty = foundeduser.Especialty,
					};

					return View(model: viewModel);
				}
				else
					return RedirectToAction(controllerName: "Account", actionName: "Login");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Index(UserViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedCurrentUser = GetCurrentUser();

				var foundedUser =
					await UnitOfWork.Users.GetUserByIdAsync(id: foundedCurrentUser.Id);

				if (foundedUser is null)
					return View(model: viewModel);

				foundedUser.FullName = viewModel.FullName;
				foundedUser.PhoneNumber = viewModel.PhoneNumber;
				foundedUser.CellPhoneNumber = viewModel.CellPhoneNumber;
				foundedUser.EmailAddress = viewModel.EmailAddress;
				foundedUser.BirthDate = viewModel.BirthDate;
				foundedUser.NationalCode = viewModel.NationalCode;
				foundedUser.MENumber = viewModel.MENumber;
				foundedUser.OfficeAddress = viewModel.OfficeAddress;
				foundedUser.Especialty = viewModel.Especialty;
				foundedUser.Gender = viewModel.Gender;

				UnitOfWork.Users.Update(entity: foundedUser);

				await UnitOfWork.SaveAsync();

				AddMessage(type: Infrastructure.Messages.MessageType.ToastSuccess, message: "تغییرات با موفقیت انجام گرفت!");

				return RedirectToAction(actionName: "Index", controllerName: "ProfileDetails");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************
	}
}
