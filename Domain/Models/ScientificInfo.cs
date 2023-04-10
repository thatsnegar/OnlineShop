using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class ScientificInfo : Entity
	{
		public ScientificInfo()
		{
		}

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

		#region Relation One To One With File
		//**********
		public virtual Models.File? File { get; set; }
		//**********
		#endregion
	}
}
