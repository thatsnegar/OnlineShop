using System.ComponentModel.DataAnnotations;

namespace ViewModels.Questions
{
	public class SkinQuizeViewModel : object
	{
		public SkinQuizeViewModel() : base()
		{
		}

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Question),
			Name = nameof(Resources.Tables.Question.Title))]
		[MaxLength(length: 250,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? QuestionTitle { get; set; }
		//**********

		//**********
		[Display(
		 ResourceType = typeof(Resources.Tables.Question),
		 Name = nameof(Resources.Tables.Question.Text))]
		public string? QuestionText { get; set; }
		//**********

		//**********
		public List<Models.Answer>? Answers { get; set; }
		//**********
	}
}


