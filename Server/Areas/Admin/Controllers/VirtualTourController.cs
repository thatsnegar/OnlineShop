using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels.AdminViewModels.VirtualTours;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

	public class VirtualTourController : Infrastructure.BaseControllerWithDataBase
	{

		public VirtualTourController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
		{
		}

		// **************************************************
		// **************************************************

		// GET: Admin/VirtualTour
		#region Index
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var indexViewModel = new List<IndexViewModel>();


				var foundedVirtualTours =
					await UnitOfWork.VirtualTours.GetAllVirtualToursAsync();

				if (foundedVirtualTours.Any())
				{
					indexViewModel.AddRange(collection: foundedVirtualTours.Select(item => new IndexViewModel
					{
						Id = item.Id,
						IsEditted = item.IsEdited,
						InsertDateTime = DateTime.Now,
						UpdateDateTime = item.UpdateDateTime,
						Title = item.Title,
					}));
					return View(model: indexViewModel);
				}
				else
				{
					return View(model: indexViewModel);
				}
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/VirtualTour/Create
		#region Create
		public IActionResult Create()
		{
			try
			{
				return View(model: new CreateViewModel());
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/VirtualTour/Create
		#region Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return RedirectToAction(actionName: "Index", controllerName: "VirtualTour");
				}

				var model = new VirtualTour
				{
					VideoId = viewModel.VideoId,
					Link = viewModel.Link,
					Title = viewModel.Title,
					Description = viewModel.Description,
				};
				await UnitOfWork.VirtualTours.InsertAsync(entity: model);
				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "VirtualTour");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/VirtualTour/Edit
		#region Edit
		[HttpGet]
		public async Task<ActionResult> Edit(Guid id)
		{
			try
			{
				var foundedVirtualTour =
					await UnitOfWork.VirtualTours.GetVirtualTourByIdAsync(id: id);

				if (foundedVirtualTour is null)
				{
					// Logger
					return NotFound();
				}

				var viewModel = new ViewModels.AdminViewModels.VirtualTours.EditViewModel
				{
					Id = foundedVirtualTour.Id,
					VideoId = foundedVirtualTour.VideoId,
					Title = foundedVirtualTour.Title,
					Link = foundedVirtualTour.Link,
					Description = foundedVirtualTour.Description,
				};

				return View(model: viewModel);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/‌VirtualTour/Edit
		#region Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedVirtualTour =
					await UnitOfWork.VirtualTours.GetVirtualTourByIdAsync(id: viewModel.Id);

				if (foundedVirtualTour is null)
					return View(model: viewModel);

				//Update Virtual Video
				foundedVirtualTour.VideoId = viewModel.VideoId;
				foundedVirtualTour.Title = viewModel.Title;
				foundedVirtualTour.Link = viewModel.Link;
				foundedVirtualTour.Description = viewModel.Description;

				UnitOfWork.VirtualTours.Update(entity: foundedVirtualTour);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "VirtualTour");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/VirtualTour/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				var foundedVirtualTour =
					await UnitOfWork.VirtualTours.GetVirtualTourByIdAsync(id: Guid.Parse(id));

				if (foundedVirtualTour is not null)
				{

					UnitOfWork.VirtualTours.Delete(entity: foundedVirtualTour);

					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
				{
					//Logger
					return Json(data: result);
				}
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion
	}
}
