using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class VirtualToursController : Infrastructure.BaseControllerWithDatabase
    {
        public VirtualToursController(ILogger<HomeController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
            Logger = logger;
        }

        public ILogger<HomeController> Logger { get; }

        // **************************************************
        // *************************************************

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            try
            {
                var foundedUser = GetCurrentUser();

                ViewData["foundedOnlineUser"] = foundedUser;

                var foundedVideos =
                   await UnitOfWork.VirtualTours.GetAllVirtualToursAsync();

                var viewModels = new List<ViewModels.VirtualTour.IndexViewModel>();

                if (foundedVideos.Any())
                {
                    ViewBag.PageNumber = pageNumber;

                    var pageViewModel =
                        new ViewModels.Paginations.PageViewModel(pageNumber: pageNumber);

                    var totalPages =
                        ((double)foundedVideos.Count / (double)pageViewModel.PageSize);

                    int roundedTotalPages =
                        Convert.ToInt32(Math.Ceiling(a: totalPages));

                    //Total Pages 
                    ViewBag.TotalPages =
                        roundedTotalPages;

                    foundedVideos =
                        foundedVideos
                       .Skip(count: (pageViewModel.PageNumber - 1) * pageViewModel.PageSize)
                       .Take(count: pageViewModel.PageSize)
                       .ToList()
                       ;

                    viewModels.AddRange(collection: foundedVideos.Select(item => new ViewModels.VirtualTour.IndexViewModel
                    {
                        Link = item.Link,
                        VideoId = item.VideoId,
                        Description = item.Description,

                    }));

                    return View(model: viewModels);
                }
                else
                {
                    // Logger
                    return View(model: viewModels);
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
