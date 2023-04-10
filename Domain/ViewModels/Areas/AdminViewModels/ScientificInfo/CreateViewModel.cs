using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ScientificInfo
{
	public class CreateViewModel : object
	{
		public CreateViewModel() : base()
		{
		}

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.Title))]
		[MaxLength(length: 50,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Title { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.Text))]
		[MaxLength(length: 100,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? Text { get; set; }
		// **********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.ScientificInfoFile))]
		public Microsoft.AspNetCore.Http.IFormFile? ScientificInfoFile { get; set; }
		//**********
	}
}
