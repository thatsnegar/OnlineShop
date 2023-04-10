using System.ComponentModel.DataAnnotations;

namespace ViewModels.ScientificInfo
{
	public class IndexViewModel : object
	{
		public IndexViewModel() : base()
		{
		}

		//**********
		public Guid ScientificInfoId { get; set; }
		//**********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.Title))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Title { get; set; }
		// **********

		// **********
		[Display(
		ResourceType = typeof(Resources.Tables.ScientificInfo),
		Name = nameof(Resources.Tables.ScientificInfo.Text))]
		public string? Text { get; set; }
		// **********

		// **********
		public Models.File File { get; set; }
		// **********
	}
}
