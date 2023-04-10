using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class InfoController : Infrastructure.BaseControllerWithDatabase
    {
        public InfoController(ILogger<HomeController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
            Logger = logger;
        }

        public ILogger<HomeController> Logger { get; }

        // **************************************************
        // **************************************************

        public async Task<IActionResult> Index(int pageNumber = 1)
        {
			try
			{
				var foundedUser =
					GetCurrentUser();

				if(foundedUser?.Role != "Doctor")
				{
					return NotFound();
				}

				ViewData["foundedOnlineUser"] = foundedUser;

				var foundedScientificInfos =
					await UnitOfWork.ScientificInfos.GetAllScientificInfosAsync();

				var viewModels = new List<ViewModels.ScientificInfo.IndexViewModel>();

				if (foundedScientificInfos.Any())
				{
					// Page Number
					ViewBag.PageNumber = pageNumber;

					var pageViewModel =
						new ViewModels.Paginations.PageViewModel(pageNumber: pageNumber);

					var totalPages =
						((double)foundedScientificInfos.Count / (double)pageViewModel.PageSize);

					int roundedTotalPages =
						Convert.ToInt32(Math.Ceiling(a: totalPages));

					// Total Pages
					ViewBag.TotalPages =
						roundedTotalPages;

					foundedScientificInfos =
						foundedScientificInfos
						.Skip(count: (pageViewModel.PageNumber - 1) * pageViewModel.PageSize)
						.Take(count: pageViewModel.PageSize)
						.ToList()
						;

					viewModels.AddRange(collection: foundedScientificInfos.Select(item => new ViewModels.ScientificInfo.IndexViewModel
					{
						ScientificInfoId = item.Id,
						Title = item.Title,
						Text = item.Text,
						File = item.File!,
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
				//Logger
				throw;
			}
		}
    }
}
