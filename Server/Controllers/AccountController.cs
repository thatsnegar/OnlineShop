using Models;
using Shared;
using ViewModels.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace Commercial_Application.Controllers
{
	public class AccountController : Infrastructure.BaseControllerWithDatabase
	{
		public AccountController(DAL.IUnitOfwork unitOfWork) : base(unitOfWork: unitOfWork)
		{
		}

		// **************************************************
		// **************************************************

		#region Login
		[HttpGet]
		public IActionResult Login(string? returnUrl = "/")
		{
			var viewModel = new ViewModels.Accounts.LoginViewModel
			{
				ReturnUrl = returnUrl,
			};

			return View(model: viewModel);
		}
        #endregion

        //Account/Login/Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ViewModels.Accounts.LoginViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedUser =
                    await UnitOfWork.Users.GetUserByUsernameAsync(username: viewModel.UserName);

                if (foundedUser is null)
                {
                    AddMessage(type: Infrastructure.Messages.MessageType.ToastError, message: Resources.Messages.ErrorMessages.ErrorMessage3020_3030);

                    return View(model: viewModel);
                }

                var hashedPassword =
                   viewModel.Password!.Encode();

                if (!foundedUser.IsActive || (string.Compare(foundedUser.Password, hashedPassword, ignoreCase: false) != 0))
                {
                    if (!foundedUser.IsActive)
                    {
                        AddMessage(type: Infrastructure.Messages.MessageType.ToastError, message: Resources.Messages.ErrorMessages.ErrorMessage3050);

                        return View(model: viewModel);
                    }

                    if ((string.Compare(foundedUser.Password, hashedPassword, ignoreCase: false) != 0))
                    {
                        AddMessage(type: Infrastructure.Messages.MessageType.ToastError, message: Resources.Messages.ErrorMessages.ErrorMessage3020_3030);

                        return View(model: viewModel);
                    }
                }

                // Add Claims For Personel
                var claims =
                    new System.Collections.Generic.List<System.Security.Claims.Claim>();

                System.Security.Claims.Claim claim;

                // **************************************************
                //claim =
                //    new System.Security.Claims.Claim
                //    (type: System.Security.Claims.ClaimTypes.Role, value: foundedUser.Role);

                //claims.Add(item: claim);
                // **************************************************

                // **************************************************
                claim =
                    new System.Security.Claims.Claim
                    (type: System.Security.Claims.ClaimTypes.Name, value: foundedUser.Username!);

                claims.Add(item: claim);
                // **************************************************

                // **************************************************
                claim =
                    new System.Security.Claims.Claim
                    (type: System.Security.Claims.ClaimTypes.NameIdentifier, value: foundedUser.Id.ToString()!);

                claims.Add(item: claim);
                // **************************************************

                // **************************************************
                // **************************************************
                var claimsIdentity =
                    new System.Security.Claims.ClaimsIdentity(claims: claims,
                    authenticationType: Infrastructure.Security.Utility.AuthenticationScheme);
                // **************************************************
                // **************************************************

                // **************************************************
                var claimsPrincipal =
                    new System.Security.Claims.ClaimsPrincipal(identity: claimsIdentity);
                // **************************************************

                // **************************************************
                var authenticationProperties =
                    new Microsoft.AspNetCore.Authentication.AuthenticationProperties
                    {
                        IsPersistent = viewModel.RememberMe,
                    };
                // **************************************************

                // **************************************************
                // SignInAsync -> using Microsoft.AspNetCore.Authentication;
                await HttpContext.SignInAsync
                    (scheme: Infrastructure.Security.Utility.AuthenticationScheme,
                    principal: claimsPrincipal, properties: authenticationProperties);
                // **************************************************

                if (string.IsNullOrWhiteSpace(viewModel.ReturnUrl))
                {
                    AddMessage(type: Infrastructure.Messages.MessageType.ToastSuccess, message: "ورود با موفقیت انجام شد!");

                    return RedirectToAction(actionName: "Index", controllerName: "Home");
                }
                else
                {
                    AddMessage(type: Infrastructure.Messages.MessageType.ToastSuccess, message: "ورود با موفقیت انجام شد!");

                    return Redirect(url: viewModel.ReturnUrl);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        // **************************************************
        // **************************************************

        #region LogOut
        [HttpGet]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync
				(scheme: Infrastructure.Security.Utility.AuthenticationScheme);

			AddMessage(type: Infrastructure.Messages.MessageType.ToastSuccess, message: "خروج با موفقیت انجام شد!");

			return Redirect("/Home/Index");
		}
		#endregion

		// **************************************************
		// **************************************************
	}
}
