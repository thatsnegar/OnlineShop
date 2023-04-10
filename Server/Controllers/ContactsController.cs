using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class ContactsController : Infrastructure.BaseControllerWithDatabase
	{
		public ContactsController(DAL.IUnitOfwork unitOfwork, Services.IEmailService emailService) : base(unitOfwork)
		{
			EmailService = emailService;
		}

		public Services.IEmailService EmailService { get; set; }

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ViewModels.Contacts.IndexViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					AddMessage(type: Infrastructure.Messages.MessageType.ToastWarning, message: "کاربر گرامی لطفا اطلاعات را به درستی وارد نمایید!");

					return View(model: viewModel);
				}

				var sanitizer = new HtmlSanitizer();

				var contact = new Models.Contact
				{
					FullName = sanitizer.Sanitize((viewModel.FullName is not null) ? viewModel.FullName : ""),
					Email = sanitizer.Sanitize((viewModel.Email is not null) ? viewModel.Email : ""),
					PhoneNumber = sanitizer.Sanitize((viewModel.PhoneNumber is not null) ? viewModel.PhoneNumber : ""),
					Issue = sanitizer.Sanitize((viewModel.Issue is not null) ? viewModel.Issue : ""),
					Message = sanitizer.Sanitize((viewModel.Message is not null) ? viewModel.Message : ""),
				};

				var foundedCurrentUser = GetCurrentUser();

				var email = new Models.Email
				{
					Username = "info@emonicosmetic.com",
					OutgoingHost = "emonicosmetic.com",
					Password = "Emoni@321",
					ToEmail = "info@emonicosmetic.com",
					Subject = sanitizer.Sanitize((viewModel.Issue is not null) ? viewModel.Issue : ""),
					Body = sanitizer.Sanitize((viewModel.Message is not null) ? viewModel.Message : ""),
					From = sanitizer.Sanitize((viewModel.Email is not null) ? viewModel.Email : ""),
				};

				var resultSendEmail = 
					EmailService.SendEmailWithPlainText(email: email);

				if(resultSendEmail)
				{
					AddMessage(type: Infrastructure.Messages.MessageType.ToastSuccess, message: "کاربر گرامی پیغام شما با موفقیت ثبت گردید!");

					contact.SendEmail = true;

					await UnitOfWork.Contacts.InsertAsync(entity: contact);

					await UnitOfWork.SaveAsync();

					return RedirectToAction(actionName: "Index", controllerName: "Contacts");
				}
				else
				{
					AddMessage(type: Infrastructure.Messages.MessageType.ToastWarning, message: "کاربر گرامی متاسفانه در شبکه ارسال پیام اختلالی به وجود آمده است!");

					contact.SendEmail = false;

					await UnitOfWork.Contacts.InsertAsync(entity: contact);

					await UnitOfWork.SaveAsync();

					return RedirectToAction(actionName: "Index", controllerName: "Contacts");
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
	}
}
