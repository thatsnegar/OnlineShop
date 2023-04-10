using DAL;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ProductCategorySlider;

namespace Server.Components
{
    public class ProductCategorySliderComponent : ViewComponent
    {
        private const string ProductCategorySliderViewName = "~/Views/ProductCategorySlider/Index.cshtml";

        public ProductCategorySliderComponent(IUnitOfwork unitOfWork) : base()
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
                var foundedProductCategory =
                    await UnitOfWork.ProductCategories.GetAllSlidersAsync();

                if (foundedProductCategory.Any())
                {
                    List<IndexViewModel> indexViewModel = new();

                    indexViewModel.AddRange(collection: foundedProductCategory.Select(item => new IndexViewModel
                    {
                        ImageProductCategorySliderName = item.File.Name,
                        Url = item.Url,
                    }));

                    return View(viewName: ProductCategorySliderViewName, model: indexViewModel);
                }
                else
                {
                    List<IndexViewModel> indexViewModels = null;

                    return View(viewName: ProductCategorySliderViewName, model: indexViewModels);
                }
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
    }
}
