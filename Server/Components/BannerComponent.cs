using DAL;
using ViewModels.Banner;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class BannerComponent : ViewComponent
    {
        private const string BannerViewName = "~/Views/Banner/Index.cshtml";

        public BannerComponent(IUnitOfwork unitOfWork) : base()
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
                var foundedBanners =
                    await UnitOfWork.Banners.GetAllBannersAsync();

                var indexViewModels = new List<IndexViewModel>();

                if (foundedBanners.Any())
                {
                    indexViewModels.AddRange(collection: foundedBanners.Select(item => new IndexViewModel
                    {
                        ImageBannerName = item.File?.Name,
                        Url = item.Url,
                        
                    }));

                    return View(viewName: BannerViewName, model: indexViewModels);
                }
                else
                    return View(viewName: BannerViewName, model: indexViewModels);
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
