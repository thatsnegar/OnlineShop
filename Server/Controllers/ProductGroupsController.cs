using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class ProductGroupsController : Controller
	{
		public IActionResult Index(System.Guid productCategoryId)
		{
			return View();
		}
	}
}
