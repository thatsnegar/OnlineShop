using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Questions
{
	public class QuestionViewModel : object
	{
		public QuestionViewModel() : base()
		{
		}

		//**********
		public Guid QuestionId { get; set; }
		//**********

		//**********
		public Guid AnswerId { get; set; }
		//**********

		//**********
		public string? ProductTitle { get; set; }
		//**********

		//**********
		public string? AnswerText { get; set; }
		//**********

		//**********
		public System.Guid? ProductCategoryId { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.ProductCategory),
			Name = nameof(Resources.Tables.ProductCategory.Title))]
		public string? ProductCategoryTitle { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Answer),
			Name = nameof(Resources.Tables.Answer.Text))]
		public int DisplayOrder { get; set; }
		//**********


	}
}
