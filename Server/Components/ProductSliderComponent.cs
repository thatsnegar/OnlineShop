using DAL;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ProductSlider;

namespace Server.Components
{
    public class ProductSliderComponent : ViewComponent
    {
        public ProductSliderComponent(IUnitOfwork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
        }

        private const string productSliderVeiwName = "~/Views/ProductSlider/Index.cshtml";

        protected DAL.IUnitOfwork UnitOfWork { get; }

        // **************************************************
        // **************************************************

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var foundedProducts =
                    await UnitOfWork.Products.GetAllShowIndexProductsAsync();

                if (foundedProducts.Any())
                {
                    List<IndexViewModel> indexViewModel = new();

                    indexViewModel.AddRange(collection: foundedProducts.Select(item => new IndexViewModel
                    {
                        ProductId = item.Id,
                        Price = item.Price,
                        Title = item.Title,
                        HasDiscount = item.HasDiscount,
                        DiscountedPrice = item.DiscountedPrice,
                        DiscountPercentage = item.DiscountPercentage,
                        ImageProductName = item.Files?.Where(current => current.IsMainFile.Equals(true)).FirstOrDefault()?.Name,
                    }));

                    return View(viewName: productSliderVeiwName, model: indexViewModel);
                }
                else
                {
                    List<IndexViewModel> indexViewModels = null;
                    return View(viewName: productSliderVeiwName, model: indexViewModels);
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
