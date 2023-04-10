using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Question : Entity
	{
		public Question()
		{
		}

		//**********
		public int DisplayOrder { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Question),
			Name = nameof(Resources.Tables.Question.Title))]
		[MaxLength(length: 250,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? Title { get; set; }
		//**********

		//**********
		[Display(
		 ResourceType = typeof(Resources.Tables.Question),
		 Name = nameof(Resources.Tables.Question.Text))]
		public string? Text { get; set; }
		//**********



		#region Relation One To many with Answer
		//**********
		public virtual List<Answer>? Answers { get; set; }
		//**********
		#endregion
	}
}
