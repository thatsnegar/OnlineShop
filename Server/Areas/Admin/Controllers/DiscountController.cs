using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels.AdminViewModels.Discounts;
using Shared;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

	public class DiscountController : Infrastructure.BaseControllerWithDataBase
	{

		public DiscountController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
		{
		}

		// **************************************************
		// **************************************************

		// GET: Admin/Discount
		#region Index
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var foundedDiscounts =
					await UnitOfWork.Discounts.GetAllDiscountsAsync();

				return View(model: foundedDiscounts);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/Discount/Create
		#region Create
		[HttpGet]
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

		// POST: Admin/Discount/Create
		#region Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var model = new Discount
				{
					Text = viewModel.Text,
					Title = viewModel.Title,
					DiscountPercentage = viewModel.DiscountPercentage,
					StartDate = viewModel.StartDate.ToMiladi(),
					EndDate = viewModel.EndDate.ToMiladi(),
				};

				await UnitOfWork.Discounts.InsertAsync(entity: model);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(controllerName: "Discount", actionName: "Index");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/Discount/Edit
		#region Edit
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{

				var foundedDiscount =
					await UnitOfWork.Discounts.GetDiscountByIdAsync(id: id);

				if (foundedDiscount is not null)
				{
					var viewModel = new EditViewModel
					{
						Id = foundedDiscount.Id,
						DiscountPercentage = foundedDiscount.DiscountPercentage,
						EndDate = foundedDiscount.EndDate.ToShamsiWithoutTime(),
						StartDate = foundedDiscount.StartDate.ToShamsiWithoutTime(),
						Text = foundedDiscount.Text,
						Title = foundedDiscount.Title,
					};
					return View(viewModel);
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
		#endregion

		// POST: Admin/Discount/Edit
		#region Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedDiscount =
					await UnitOfWork.Discounts.GetDiscountByIdAsync(id: viewModel.Id);

				if (foundedDiscount is not null)
				{
					foundedDiscount.Title = viewModel.Title;
					foundedDiscount.Text = viewModel.Text;
					foundedDiscount.StartDate = viewModel.StartDate.ToMiladi();
					foundedDiscount.EndDate = viewModel.EndDate.ToMiladi();
					foundedDiscount.DiscountPercentage = viewModel.DiscountPercentage;

					UnitOfWork.Discounts.Update(entity: foundedDiscount);

					await UnitOfWork.SaveAsync();

					return RedirectToAction(actionName: "Index", controllerName: "Discount");
				}
				else
					return View(model: viewModel);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/Discount/ConfirmIsActive
		#region ConfirmShowIndex
		[HttpPost]
		public async Task<JsonResult> ConfirmIsActive(string id)
		{
			try
			{
				bool result = false;

				if (string.IsNullOrEmpty(value: id))
					return Json(data: result);

				var guid = Guid.Parse(input: id);

				var foundedDiscount =
					await UnitOfWork.Discounts.GetByIdAsync(id: guid);

				if (foundedDiscount is not null)
				{
					var serverDate = DateTime.Now;

					var compareEndDate = DateTime.Compare(t1: foundedDiscount.EndDate, t2: serverDate);

					if(compareEndDate <= 0)
						return Json(data: result);

					//Compare 
					if (foundedDiscount.IsActive == false)
						foundedDiscount.IsActive = true;
					else
						foundedDiscount.IsActive = false;

					UnitOfWork.Discounts.Update(entity: foundedDiscount);
					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
					return Json(data: result);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/Discount/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				var foundedDiscount =
					await UnitOfWork.Discounts.GetDiscountByIdAsync(id: Guid.Parse(id));

				if (foundedDiscount is not null)
				{
					UnitOfWork.Discounts.Delete(entity: foundedDiscount);

					await UnitOfWork.SaveAsync();

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
