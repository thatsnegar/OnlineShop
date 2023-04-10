using DAL;
using ViewModels.Comparison;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class ComparisonComponent : ViewComponent
    {
        private const string ComparisonViewName = "~/Views/Comparison/Index.cshtml";

        public ComparisonComponent(IUnitOfwork unitOfWork) : base()
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
                var foundedComparisonProduct = 
                    await UnitOfWork.ComparisonProducts.GetAllComparisonProduct();

                var indexViewModels = new List<IndexViewModel>();

                if(foundedComparisonProduct.Any())
                {
                    indexViewModels.AddRange(collection: foundedComparisonProduct.Select(item => new IndexViewModel
                    {
                        HrefId = item.Id,
                        Title = item.Title,
                        Description = item.Description,
                        AfterImageName = item.Files?.Where(current => current.IsAfterImage.Equals(true)).FirstOrDefault()?.Name,
                        BeforeImageName = item.Files?.Where(current => current.IsBeforeImage.Equals(true)).FirstOrDefault()?.Name,
                        ThumbNailImageName = item.Files?.Where(current => current.IsThumbnailImage.Equals(true)).FirstOrDefault()?.Name,

                    }));

                    return View(viewName: ComparisonViewName, model:indexViewModels);
                }
                else
                {
                    
                    return View(viewName: ComparisonViewName, model: indexViewModels);
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
