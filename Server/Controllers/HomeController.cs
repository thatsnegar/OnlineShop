using Microsoft.AspNetCore.Mvc;
using Parbad;
using Parbad.Abstraction;
using Parbad.AspNetCore;
using System.Diagnostics;
using ViewModels.Parbad;

namespace Server.Controllers
{
	public class HomeController : Infrastructure.BaseControllerWithDatabase
	{

		public HomeController(ILogger<HomeController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<HomeController> Logger { get; }

		// **************************************************
		// **************************************************

		[HttpGet]
		public IActionResult Index()
		{
			var foundedUser =
				GetCurrentUser();

			ViewData["foundedOnlineUser"] = foundedUser;

			return View();
		}
		// **************************************************
		// **************************************************

		[HttpGet]
		public IActionResult Error()
		{
			return View();
		}
		// **************************************************
		// **************************************************




		[HttpGet]
		public IActionResult Test()
		{
			return View();
		}




	}
}