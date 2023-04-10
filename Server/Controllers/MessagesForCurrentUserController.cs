using DAL;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class MessagesForCurrentUserController : BaseControllerWithDatabase
	{
		public MessagesForCurrentUserController(ILogger<MessagesForCurrentUserController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<MessagesForCurrentUserController> Logger { get; }

		// **************************************************
		// **************************************************

		#region UserNotifications
		[HttpGet]
		public async Task<IActionResult> UserNotifications()
		{
			try
			{
				var foundedCurrentUser = GetCurrentUser();

				if (foundedCurrentUser is not null)
				{
					var foundedUserNotifications =
						await UnitOfWork.Messages.GetAllMessageIndexViewAsync();

					var foundedDiscount =
						await UnitOfWork.Discounts.GetDiscountInTiemRegisterAsync(userId: foundedCurrentUser.Id);

					if (foundedDiscount is not null)
					{
						var message = new Models.Message()
						{
							IsShow = true,
							Title = foundedDiscount.Title,
							Summary = $"کد تخفیف: {foundedDiscount.Text}",
							Text = "کاربر گرامی از کد مورد نظر تنها می توانید ظرف مدت 10 روز از زمان ثبت نام استفاده نمایید!",
						};

						foundedUserNotifications.Add(item: message);

						if (foundedUserNotifications.Any())
							return View(model: foundedUserNotifications);
						else
							return View(model: foundedUserNotifications);
					}
					else
					{
						if (foundedUserNotifications.Any())
							return View(model: foundedUserNotifications);
						else
							return View(model: foundedUserNotifications);
					}
				}
				else
				{
					// Logger

					return NotFound();
				}
			}
			catch (Exception e)
			{
				string message =
					$"message: {e.Message} - Description: {e.InnerException}";

				Logger.LogCritical(message);
				//Logger.LogDebug(exception, "Error while processing request from {Address}", address)
				throw;
			}
		}

		#endregion

		// **************************************************
		// **************************************************

		#region DeleteMessage

		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				var foundedMessage =
					await UnitOfWork.Messages.GetMessageByIdAsync(id: Guid.Parse(id));

				if (foundedMessage is not null)
				{

					UnitOfWork.Messages.Delete(entity: foundedMessage);

					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
				{
					//Logger
					return Json(data: result);
				}
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

	}
}
