using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class ShowRateOfProducstInIndexComponent : ViewComponent
    {
        private const string RateViewName = "~/Views/ProductSlider/ShowRateofProductsInIndex.cshtml";

        public ShowRateOfProducstInIndexComponent(IUnitOfwork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
        }

        protected DAL.IUnitOfwork UnitOfWork { get; }

        // **************************************************
        // **************************************************

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            try
            {
                var foundedProduct =
                    await UnitOfWork.Products.GetProductByIdAsync(id: productId);

                #region Calculate Rate
                int rate = 0;
                int averageRate = 0;

                if (foundedProduct.Comments is not null && foundedProduct.Comments.Any())
                {

                    foreach (var list in foundedProduct.Comments)
                    {
                        rate += list.Rate;
                    }

                    averageRate = (rate / foundedProduct.Comments.Count);
                }
                else
                {
                    averageRate = 1;
                }
                #endregion

                var indexViewModel = new ViewModels.Products.DetailViewModel
                {
                    Rate = averageRate,
                };

                return View(viewName: RateViewName, model: indexViewModel);
            }
            catch (Exception)
            {
                // Logger
                throw;
            }
        }
    }
}
