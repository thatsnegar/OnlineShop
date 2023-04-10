using DAL;
using Shared;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class AboutController : BaseControllerWithDatabase
    {
        public AboutController(ILogger<AboutController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
            Logger = logger;
        }
        public ILogger<AboutController> Logger { get; }

        // **************************************************
        // **************************************************

        public async Task<IActionResult> Index(Guid id)
        {
            try
            {
                var foundedUser = GetCurrentUser();

                ViewData["foundedOnlineUser"] = foundedUser;

                var foundedAbouts =
                    await UnitOfWork.Abouts.GetActiveAboutAsync(id: id);

                if (foundedAbouts is not null)
                {
                    var viewModels = new ViewModels.About.IndexViewModel()

                    {
                        AboutImageName = foundedAbouts.File?.Name,
                        GoalDescription = foundedAbouts.GoalDescription,
                        GoalTitle = foundedAbouts.GoalTitle,
                        MissionDescription = foundedAbouts.MissionDescription,
                        MissionTitle = foundedAbouts.MissionTitle,
                        VisionDescription = foundedAbouts.VisionDescription,
                        Slogan = foundedAbouts.Slogan,
                        SubTitle = foundedAbouts.SubTitle,
                        Text = foundedAbouts.Text,
                        Title = foundedAbouts.Title,
                        VisionTitle = foundedAbouts.VisionTitle,
                    };
                    return View(model: viewModels);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
    }
}
