using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Abouts
{
	public class CreateViewModel : object
	{
		public CreateViewModel() : base()
		{
		}

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.Title))]
		[MaxLength(length: 100,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Title { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.Text))]
		public string? Text { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.SubTitle))]
		[MaxLength(length: 100,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? SubTitle { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.Slogan))]
		[MaxLength(length: 100,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? Slogan { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.GoalTitle))]
		[MaxLength(length: 20,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? GoalTitle { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.GoalDescription))]
		[MaxLength(length: 300,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? GoalDescription { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.MissionTitle))]
		[MaxLength(length: 20,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? MissionTitle { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.MissionDescription))]
		[MaxLength(length: 300,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? MissionDescription { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.VisionTitle))]
		[MaxLength(length: 20,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? VisionTitle { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.VisionDescription))]
		[MaxLength(length: 300,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? VisionDescription { get; set; }
		// **********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.About),
			Name = nameof(Resources.Tables.About.AboutImage))]
		public Microsoft.AspNetCore.Http.IFormFile? AboutImage { get; set; }
		//**********
	}
}
