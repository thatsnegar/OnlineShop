using DAL;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Products;

namespace Server.Components
{
	public class RelatedProductComponent : ViewComponent
	{
		private const string RelatedProductViewName = "~/Views/Products/RelatedProducts.cshtml";

		public RelatedProductComponent(IUnitOfwork unitOfWork) : base()
		{
			UnitOfWork = unitOfWork;
		}

		protected DAL.IUnitOfwork UnitOfWork { get; }

		// **************************************************
		// **************************************************

		public async Task<IViewComponentResult> InvokeAsync(string productCategoryTitle)
		{
			try
			{
				var foundedProducts =
					await UnitOfWork.Products.GetAllProductsAsync();

				var viewModels = new List<ViewModels.Products.RelatedProductViewModel>();

				if (foundedProducts.Any())
				{
					viewModels.AddRange(collection: foundedProducts.Where(current => current?.ProductCategory?.Title == productCategoryTitle).Select(item => new RelatedProductViewModel
					{
						ProductId = item.Id,
						ProductCategoryId = item.ProductCategoryId,
						Description = item.Description,
						DiscountedPrice = item.DiscountedPrice,
						HasDiscount = item.HasDiscount,
						ImageProductName = item.Files?.Where(current => current.IsMainFile.Equals(true)).FirstOrDefault()?.Name,
						Price = item.Price,
						Title = item.Title,
						DiscountPercentage = item.DiscountPercentage,
					}));

					return View(viewName: RelatedProductViewName, model: viewModels);
				}
				else
					return View(viewName: RelatedProductViewName, model: viewModels);
			}

			catch (Exception)
			{
				//Logger
				throw;
			}
		}
	}
}
