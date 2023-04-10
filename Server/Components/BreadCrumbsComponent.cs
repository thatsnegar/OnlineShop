using DAL;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Image;

namespace Server.Components
{
    public class BreadCrumbsComponent : ViewComponent
    {
        private const string ImageViewName = "~/Views/BreadCrumbsImage/Image.cshtml";
        private const string ImageTitle = "تصویر برد کرامبز";
        public BreadCrumbsComponent(IUnitOfwork unitOfWork) : base()
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
                    var viewModel = new BreadCrumbsViewModel()
                    {
                        BreadCrumbsImageName = foundedImage.File?.Name,
                    };

                    return View(viewName: ImageViewName, model: viewModel);
                }
                else
                {
                    var viewModel = new BreadCrumbsViewModel();
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
