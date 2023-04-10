using System.ComponentModel.DataAnnotations;

namespace ViewModels.Products
{
	public class RelatedProductViewModel : object
	{
		public RelatedProductViewModel() : base()
		{
		}

		//**********
		public Guid ProductId { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Product),
			Name = nameof(Resources.Tables.Product.Title))]
		public string? Title { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Product),
			Name = nameof(Resources.Tables.Product.Description))]
		public string? Description { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Product),
			Name = nameof(Resources.Tables.Product.Rate))]
		public int Rate { get; set; }
		//**********

		//**********
		[Display(
		 ResourceType = typeof(Resources.Tables.Product),
		 Name = nameof(Resources.Tables.Product.HasDiscount))]
		public bool HasDiscount { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.Product),
		Name = nameof(Resources.Tables.Product.DiscountPercentage))]
		public double DiscountPercentage { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.Product),
		Name = nameof(Resources.Tables.Product.Price))]
		public double Price { get; set; }
		//**********

		//**********
		[Display(
		 ResourceType = typeof(Resources.Tables.Product),
		 Name = nameof(Resources.Tables.Product.DiscountedPrice))]
		public double DiscountedPrice { get; set; }
		//**********

		public System.Guid ProductCategoryId { get; set; }

		//**********
		public string? ImageProductName { get; set; }
		//**********



	}
}
