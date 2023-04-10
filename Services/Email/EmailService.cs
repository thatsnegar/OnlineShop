using Models;
using MailKit.Net.Smtp;
using ViewModels.Emails;

namespace Services
{
	public class EmailService : IEmailService
	{
		public EmailService(IFilesService filesService, Microsoft.Extensions.Hosting.IHostEnvironment hostEnvironment) : base()
		{
			FilesService = filesService;
			HostEnvironment = hostEnvironment;

			PhysicalRootPath =
				$"{HostEnvironment.ContentRootPath}wwwroot";
		}

		public string PhysicalRootPath { get; }

		public IFilesService FilesService { get; set; }

		public Microsoft.Extensions.Hosting.IHostEnvironment HostEnvironment { get; }

		// **************************************************
		// **************************************************
		public IEnumerable<MimeKit.MimeEntity> ReceiveAttachments(int emailId)
		{
			var attachments = new List<MimeKit.MimeEntity>();

			using (var client = new MailKit.Net.Pop3.Pop3Client())
			{
				client.Connect(host: "ahangarynovin.ir", port: 995, useSsl: true);

				client.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

				var message =
					client.GetMessage(emailId);

				attachments =
					message.Attachments.ToList();
			}

			return attachments;
		}
		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		#region Recieve Email With Pop3(One)
		public DetailsViewModel ReceiveEmailWithPop3(int emailId)
		{
			try
			{
				var email = new ViewModels.Emails.DetailsViewModel();

				using var client = new MailKit.Net.Pop3.Pop3Client();

				client.Connect(host: "ahangarynovin.ir", port: 995, useSsl: true);

				client.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

				MimeKit.MimeMessage message = client.GetMessage(emailId);

				email.EmailId = emailId;
				email.InsertDateTime = message.Date.UtcDateTime;
				email.Subject = message.Subject;
				email.Body = message.HtmlBody;
				email.From =
					string.Format("<a href = 'mailto:{1}'>{0}</a>",
						(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Address).FirstOrDefault() : "",
						(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Domain).FirstOrDefault() : "");

				return email;
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		#region Recieve Email With Imap(One)
		public DetailsViewModel ReceiveEmailWithImap(int emailId)
		{
			try
			{
				var email = new ViewModels.Emails.DetailsViewModel();

				using var client = new MailKit.Net.Imap.ImapClient();

				client.Connect(host: "ahangarynovin.ir", port: 995, useSsl: true);

				client.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

				var inbox = client.Inbox;

				inbox.Open(access: MailKit.FolderAccess.ReadOnly);

				MimeKit.MimeMessage message = inbox.GetMessage(emailId);

				email.EmailId = emailId;
				email.InsertDateTime = message.Date.UtcDateTime;
				email.Subject = message.Subject;
				email.Body = message.HtmlBody;
				email.From =
					string.Format("<a href = 'mailto:{1}'>{0}</a>",
						(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Address).FirstOrDefault() : "",
						(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Domain).FirstOrDefault() : "");

				return email;
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		#region Recieve Emails With Pop3(All)
		public List<ViewModels.Emails.IndexViewModel> ReceiveEmailsWithPop3()
		{
			try
			{
				var emails = new List<ViewModels.Emails.IndexViewModel>();

				using var client = new MailKit.Net.Pop3.Pop3Client();

				client.Connect(host: "ahangarynovin.ir", port: 995, useSsl: true);

				client.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

				var countEmail =
					client.GetMessageCount();

				int counter = 0;

				for (int i = countEmail - 1; i >= 1; i--)
				{
					MimeKit.MimeMessage message = client.GetMessage(i);

					var email = new ViewModels.Emails.IndexViewModel
					{
						EmailId = i,
						InsertDateTime = message.Date.UtcDateTime,
						Subject = message.Subject,
						From =
						string.Format("<a href = 'mailto:{1}'>{0}</a>",
							(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Address).FirstOrDefault() : "",
							(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Domain).FirstOrDefault() : "")
					};
					if (message.Attachments.Any())
						email.IsAttachment = true;
					else
						email.IsAttachment = false;

					emails.Add(item: email);

					counter++;

					//if (counter > 20)
					//{
					//    break;
					//}
				}

				return emails;
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		#region Recieve Emails With Imap(All)
		public List<ViewModels.Emails.IndexViewModel> ReceiveEmailsWithImap()
		{
			try
			{
				var emails = new List<ViewModels.Emails.IndexViewModel>();

				using var client = new MailKit.Net.Imap.ImapClient();

				client.Connect(host: "ahangarynovin.ir", port: 995, useSsl: true);

				client.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

				var inbox = client.Inbox;

				inbox.Open(access: MailKit.FolderAccess.ReadOnly);

				int counter = 0;

				for (int i = 0; i < inbox.Count; i++)
				{
					var message = inbox.GetMessage(i);

					var email = new ViewModels.Emails.IndexViewModel
					{
						EmailId = i,
						InsertDateTime = message.Date.UtcDateTime,
						Subject = message.Subject,
						From =
						string.Format("<a href = 'mailto:{1}'>{0}</a>",
							(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Address).FirstOrDefault() : "",
							(message.From.Mailboxes is not null && message.From.Mailboxes.Any()) ? message.From.Mailboxes.Select(c => c.Domain).FirstOrDefault() : "")
					};

					if (message.Attachments.Any())
						email.IsAttachment = true;
					else
						email.IsAttachment = false;

					emails.Add(item: email);

					counter++;

					if (counter > 20)
					{
						break;
					}
				}

				return emails;
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		#region Send Email With Smtp
		public async Task<bool> SendEmailWithSmtp(Models.Email email)
		{
			try
			{
				if (email is null || email.Username is null || email.OutgoingHost is null || email.ToEmail is null)
					return false;

				var message = new MimeKit.MimeMessage();

				// **********
				// From
				message.From.Add(MimeKit.MailboxAddress.Parse(text: email.From));
				// **********

				// **********
				// To
				message.To.Add(MimeKit.MailboxAddress.Parse(text: email.ToEmail));
				// **********

				// **********
				// CC(s)
				if (email.EmailCC is not null && email.EmailCC.Any())
				{
					foreach (var item in email.EmailCC)
					{
						message.Cc.Add(new MimeKit.MailboxAddress(name: "", address: item));
					}
				}
				// **********

				// **********
				// BCC(s)
				if (email.EmailBCC is not null && email.EmailBCC.Any())
				{
					foreach (var item in email.EmailBCC)
					{
						message.Bcc.Add(new MimeKit.MailboxAddress(name: "", address: item));
					}
				}
				// **********

				// **********
				// Subject
				message.Subject = email.Subject;
				// **********

				// **********
				// Body
				var doc = new HtmlAgilityPack.HtmlDocument();

				doc.LoadHtml(email.Body);

				var imageNodes = doc.DocumentNode.SelectNodes("//img");

				var builder = new MimeKit.BodyBuilder();

				if (imageNodes is not null)
				{
					foreach (var item in imageNodes)
					{
						var addressImage = item.Attributes["Src"].Value;

						email.Body = email.Body!.Replace(oldValue: addressImage, newValue: "cid:{0}");

						var newLink = addressImage.Replace("https://localhost:7082/", "");

						string physicalPathFolder =
							System.IO.Path.Combine(path1: PhysicalRootPath, path2: newLink);

						var image = builder.LinkedResources.Add(physicalPathFolder);

						image.ContentId = MimeKit.Utils.MimeUtils.GenerateMessageId();

						email.Body = String.Format(email.Body, image.ContentId);
					}
				}

				builder.HtmlBody = email.Body;

				message.Body = builder.ToMessageBody();
				// **********

				// **********
				// Attachment(s)
				if (email.Attachments is not null && email.Attachments.Any())
				{
					foreach (var item in email.Attachments)
					{
						var uploadFile =
							await FilesService.UploadFileAsync(file: item, folder: "Attachments");

						builder.Attachments.Add(fileName: uploadFile.Path);
					}
				}
				// **********

				// **********
				// Save Message to Sent Box
				using var client = new MailKit.Net.Imap.ImapClient();

				try
				{

					client.Connect(host: "ahangarynovin.ir", port: 993, useSsl: true);

					client.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

					var inbox = client.Inbox;

					inbox.Open(MailKit.FolderAccess.ReadWrite);

					MailKit.IMailFolder? sent = null;

					MailKit.IAppendRequest appendRequest =
						new MailKit.AppendRequest(message: message, flags: MailKit.MessageFlags.Seen);

					if (client.Capabilities.HasFlag(MailKit.Net.Imap.ImapCapabilities.SpecialUse))
					{
						sent = client.GetFolder(MailKit.SpecialFolder.Sent);
					}
					else
					{
						var personal = client.GetFolder(client.PersonalNamespaces[0]);

						sent = await personal.GetSubfolderAsync("Sent Items").ConfigureAwait(false);
					}

					await sent.AppendAsync(request: appendRequest).ConfigureAwait(false);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					client.Disconnect(quit: true);
				}
				// **********

				// **********
				// Send Message
				using var smtp = new SmtpClient();

				try
				{
					smtp.Connect(host: "ahangarynovin.ir", port: 465, useSsl: true);

					smtp.Authenticate(userName: "moghadasian@ahangarynovin.ir", password: "Fidar321");

					smtp.Send(message: message);
				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					smtp.Disconnect(quit: true);
				}
				// **********

				return true;
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************

		// **************************************************
		// **************************************************

		#region Send Automate Email With Plain Text
		public bool SendEmailWithPlainText(Models.Email email)
		{
			var message = new MimeKit.MimeMessage();

			message.From.Add(MimeKit.MailboxAddress.Parse(text: email.From));

			message.To.Add(MimeKit.MailboxAddress.Parse(text: email.ToEmail));

			message.Subject = email.Subject;

			message.Body =
				new MimeKit.TextPart(MimeKit.Text.TextFormat.Plain)
				{
					Text = email.Body
				};

			using var smtp = new SmtpClient();

			smtp.Connect(host: email.OutgoingHost, port: 465, useSsl: true);

			smtp.Authenticate(userName: email.Username, password: email.Password);

			smtp.Send(message: message);

			smtp.Disconnect(true);

			return true;
		}
		#endregion
	}
}
