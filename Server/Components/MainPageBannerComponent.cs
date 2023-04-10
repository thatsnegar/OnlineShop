using DAL;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Image;

namespace Server.Components
{
	public class MainPageBannerComponent : ViewComponent
	{
		private const string ImageViewName = "~/Views/MainPageBanner/Index.cshtml";
		private const string ImageTitle = "تصویر بنر صفحه اصلی";
		public MainPageBannerComponent(IUnitOfwork unitOfWork) : base()
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
				var foundedImage =
					await UnitOfWork.Images.GetImageByImageTitleAsync(imageTitle: ImageTitle);

				if (foundedImage is not null)
				{
					var viewModel = new MainPageBannerViewMode()
					{
						MainPageBannerName = foundedImage.File?.Name,
						FirstSlogan = foundedImage.FirstSlogan,
						SecondSlogan = foundedImage.SecondSlogan,
						ThirdSlogan = foundedImage.ThirdSlogan,
					};

					return View(viewName: ImageViewName, model: viewModel);
				}
				else
				{
					var viewModel = new MainPageBannerViewMode();
					return View(viewName: ImageViewName, model: viewModel);
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
	}
}
