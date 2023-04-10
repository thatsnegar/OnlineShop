using Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure
{
	public class BaseController : Controller, Messages.IMessageHandler
	{
		public BaseController() : base()
		{
		}

		public bool AddPageError(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageError, message: message);
		}

		public bool AddPageWarning(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageWarning, message: message);
		}

		public bool AddPageSuccess(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.PageSuccess, message: message);
		}

		public bool AddToastError(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastError, message: message);
		}

		public bool AddToastWarning(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastWarning, message: message);
		}

		public bool AddToastSuccess(string? message)
		{
			return AddMessage
				(type: Messages.MessageType.ToastSuccess, message: message);
		}

		public bool AddMessage(Messages.MessageType type, string? message)
		{
			return Messages.Utility.AddMessage
				(tempData: TempData, type: type, message: message);
		}

		public  ViewModels.AdminViewModels.Users.UserViewModel? GetCurrentUser()
		{
			ViewModels.AdminViewModels.Users.UserViewModel user = null;

			if (User!.Identity!.IsAuthenticated)
            {
				user = new ViewModels.AdminViewModels.Users.UserViewModel()
				{
					Id =
						System.Guid.Parse(input: User?.Identity?.GetUserClaimValue(claimType: System.Security.Claims.ClaimTypes.NameIdentifier)!),
					Role =
						User?.Identity?.GetUserClaimValue(claimType: System.Security.Claims.ClaimTypes.Role),
					Username =
						User?.Identity?.GetUserClaimValue(claimType: System.Security.Claims.ClaimTypes.Name)
				};
			}

			return user;
		}
	}
}