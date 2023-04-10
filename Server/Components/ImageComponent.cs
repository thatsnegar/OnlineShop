//using DAL;
//using Microsoft.AspNetCore.Mvc;
//using ViewModels.Image;

//namespace Server.Components
//{
//	public class ImageComponent : ViewComponent
//	{
//		private const string ImageViewName = "~/Views/Navbars/Image.cshtml";

//		public ImageComponent(IUnitOfwork unitOfWork) : base()
//		{
//			UnitOfWork = unitOfWork;
//		}

//		protected DAL.IUnitOfwork UnitOfWork { get; }

//		// **************************************************
//		// **************************************************

//		public async Task<IViewComponentResult> InvokeAsync()
//		{
//			try
//			{
//				var foundedImage =
//					await UnitOfWork.Images.GetImageByImageTitleAsync(imageTitle: ImageTitle);


//				if (foundedImage is not null)
//				{
//					var viewModel = new ImageNavbarViewModel()
//					{
//						NavbarImageName = foundedImage.File?.Name,
//					};

//					return View(viewName: ImageViewName, model: viewModel);
//				}
//				else
//				{
//					ImageNavbarViewModel viewModel = null;

//					return View(viewName: ImageViewName, model: viewModel);
//				}
//			}
//			catch (Exception)
//			{
//				// Logger
//				throw;
//			}
//		}
//	}
//}
