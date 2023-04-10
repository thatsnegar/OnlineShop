using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ScientificInfo
{
	public class IndexViewModel : object
	{
		public IndexViewModel() : base()
		{
		}

		//**********
		public Guid Id { get; set; }
		//**********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.Title))]
		public string? Title { get; set; }
		// **********

		// **********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.Text))]
		public string? Text { get; set; }
		// **********

		//**********
		[Display(
		  ResourceType = typeof(Resources.Tables.General),
		  Name = nameof(Resources.Tables.General.IsEdited))]
		public bool IsEditted { get; set; }
		//**********

		//**********
		[Display(ResourceType = typeof(Resources.Tables.General),
		  Name = nameof(Resources.Tables.General.InsertDateTime))]
		public DateTime InsertDateTime { get; set; }
		//**********

		//**********
		[Display(ResourceType = typeof(Resources.Tables.General),
			Name = nameof(Resources.Tables.General.UpdateDateTime))]
		public DateTime UpdateDateTime { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.ScientificInfo),
			Name = nameof(Resources.Tables.ScientificInfo.ScientificInfoFile))]
		public Models.File? File { get; set; }
		//**********

	}
}
