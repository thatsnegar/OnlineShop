using Microsoft.AspNetCore.Mvc;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class CupponBuilderController : Infrastructure.BaseControllerWithDataBase
    {
        public CupponBuilderController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }
        // **************************************************
        // **************************************************
        public IActionResult Index()
        {
            return View();
        }
    }
}
