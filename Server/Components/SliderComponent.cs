using DAL;
using ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class SliderComponent : ViewComponent
    {
        private const string SliderViewName = "~/Views/Slider/Index.cshtml";

        public SliderComponent(IUnitOfwork unitOfWork) : base()
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
                var foundedSlider =
                    await UnitOfWork.Sliders.GetAllSlidersAsync();

                var indexViewModels = new List<IndexViewModel>();

                if (foundedSlider.Any())
                {
                    indexViewModels.AddRange(collection: foundedSlider.Select(item => new IndexViewModel
                    {
                        Description = item.Description,
                        ImageSliderName = item.File.Name,
                    }));

                    return View(viewName: SliderViewName, model: indexViewModels);   
                }
                else
                    return View(viewName: SliderViewName, model: indexViewModels);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
    }

        
}
