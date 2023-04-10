using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class ErrorPageController : Infrastructure.BaseControllerWithDatabase
    {
        public ErrorPageController(ILogger<ErrorPageController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
            Logger = logger;
        }

        public ILogger<ErrorPageController> Logger { get; }

        // **************************************************
        // **************************************************
        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult SuccessfullyPaid()
        {
            return View();
        }
    }
}
