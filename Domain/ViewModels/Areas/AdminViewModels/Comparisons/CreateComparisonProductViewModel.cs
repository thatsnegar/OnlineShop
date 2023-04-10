using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Comparisons
{
	public class CreateComparisonProductViewModel : object
	{
		public CreateComparisonProductViewModel() : base()
		{
		}


		//**********
		[Display(
		   ResourceType = typeof(Resources.Tables.ProductComparison),
		   Name = nameof(Resources.Tables.ProductComparison.Title))]
		public string? Title { get; set; }
		//**********

		//**********
		[Display(
		   ResourceType = typeof(Resources.Tables.ProductComparison),
		   Name = nameof(Resources.Tables.ProductComparison.Description))]
		public string? Description { get; set; }
		//**********

		//**********
		public Microsoft.AspNetCore.Http.IFormFile? ThumbnailImageProduct { get; set; }
		//**********

		//**********
		public Microsoft.AspNetCore.Http.IFormFile? BeforeImageProduct { get; set; }
		//**********

		//**********
		public Microsoft.AspNetCore.Http.IFormFile? AfterImageProduct { get; set; }
		//**********
	}
}
