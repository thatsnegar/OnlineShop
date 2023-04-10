using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Questions
{
	public class EditViewModel : object
	{
		public EditViewModel() : base()
		{
		}

		//**********
		public Guid Id { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Product),
			Name = nameof(Resources.Tables.Product.DisplayOrder))]
		public int DisplayOrder { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Question),
			Name = nameof(Resources.Tables.Question.Text))]
		[MaxLength(length: 250,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Title { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Question),
			Name = nameof(Resources.Tables.Question.Text))]
		[MaxLength(length: 250,
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Text { get; set; }
		//**********
	}
}
