using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Discounts
{
	public class CreateViewModel : object
	{
		public CreateViewModel() : base()
		{
		}

		// **********
		[Display(
		ResourceType = typeof(Resources.Tables.Discount),
		Name = nameof(Resources.Tables.Discount.Title))]
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
		ResourceType = typeof(Resources.Tables.Discount),
		Name = nameof(Resources.Tables.Discount.Text))]
		public string? Text { get; set; }
		// **********

		//**********
		[Display(
		 ResourceType = typeof(Resources.Tables.Discount),
		 Name = nameof(Resources.Tables.Discount.DiscountPercentage))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		[Range(
			minimum: 1, maximum: 100,
			 ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			 ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Range))]
		public double DiscountPercentage { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.Discount),
		Name = nameof(Resources.Tables.Discount.StartDate))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string StartDate { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.Discount),
		Name = nameof(Resources.Tables.Discount.EndDate))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string EndDate { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.General),
		Name = nameof(Resources.Tables.General.IsActive))]
		public bool IsActive { get; set; }
		//**********

	}
}
