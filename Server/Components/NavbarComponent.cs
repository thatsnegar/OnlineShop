using DAL;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ProductCategories;

namespace Server.Components
{
	public class NavbarComponent : ViewComponent
	{
		private const string ImageTitle = "تصویر منو اصلی";
		private const string NavbarViewName = "~/Views/Navbars/Navbar.cshtml";

		public NavbarComponent(IUnitOfwork unitOfWork) : base()
		{
			UnitOfWork = unitOfWork;
		}

		protected DAL.IUnitOfwork UnitOfWork { get; }

		// **************************************************
		// **************************************************


		public async Task<IViewComponentResult> InvokeAsync()
		{
			try
			{
				var foundedProductCategories =
					await UnitOfWork.ProductCategories.GetAllProductCategoriesAsync();

				if (foundedProductCategories.Any())
				{
					var viewModels = new List<ProductCategoriesNavbarViewModel>();

					viewModels.AddRange(collection: foundedProductCategories.Select(item => new ProductCategoriesNavbarViewModel
					{
						Id = item.Id,
						Title = item.Title,
						ProductsNavbarViewModel = item.Products?.Select(item => new ViewModels.Products.ProductsNavbarViewModel
						{
							ProductId = item.Id,
							Title = item.Title
						}).ToList(),
					}));

					var foundedImage =
						 await UnitOfWork.Images.GetImageByImageTitleAsync(imageTitle: ImageTitle);

					if (foundedImage is not null)
					{
						ViewBag.ImageName = foundedImage.File?.Name;
					}

					return View(viewName: NavbarViewName, model: viewModels);
				}
				else
				{
					var viewModels =
						new List<ProductCategoriesNavbarViewModel>();

					return View(viewName: NavbarViewName, model: viewModels);
				};
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
