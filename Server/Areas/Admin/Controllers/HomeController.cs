using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize]
	public class HomeController : Infrastructure.BaseControllerWithDataBase
	{
		public HomeController(DAL.IUnitOfwork unitOfwork/* ILogger logger*/) : base(unitOfwork)
		{
			//Logger = logger;
		}

		//public Microsoft.Extensions.Logging.ILogger Logger { get; set; }

		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}
	}
}
