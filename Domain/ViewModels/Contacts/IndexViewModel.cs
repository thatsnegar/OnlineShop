using System.ComponentModel.DataAnnotations;

namespace ViewModels.Contacts
{
	public class IndexViewModel : object
	{
		public IndexViewModel() : base()
		{
		}

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Contact),
			Name = nameof(Resources.Tables.Contact.FullName))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		[MaxLength(length: 500,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? FullName { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Contact),
			Name = nameof(Resources.Tables.Contact.Email))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		[MaxLength(length: 500,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		[EmailAddress(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.EmailAddress))]
		public string? Email { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Contact),
			Name = nameof(Resources.Tables.Contact.PhoneNumber))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		[MaxLength(length: 11,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? PhoneNumber { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Contact),
			Name = nameof(Resources.Tables.Contact.Issue))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Issue { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Contact),
			Name = nameof(Resources.Tables.Contact.Message))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Message { get; set; }
		//**********
	}
}
