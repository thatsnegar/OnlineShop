using System.ComponentModel.DataAnnotations;

namespace ViewModels.Products
{
	public class ProductsNavbarViewModel : object
	{
		public ProductsNavbarViewModel() : base()
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
	}
}
