using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.ScientificInfo;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

	public class ScientificInfosController : Infrastructure.BaseControllerWithDataBase
	{

		public ScientificInfosController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
		{
			FilesService = filesService;
		}

		protected Services.IFilesService FilesService { get; }

		// **************************************************
		// **************************************************

		// GET: Admin/ScientificInfos
		#region Index
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var foundedScientificInfos = await UnitOfWork.ScientificInfos.GetAllScientificInfosAsync();

				return View(model: foundedScientificInfos);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/Consultation/Create
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

		// POST: Admin/ScientificInfos/Create
		#region Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				#region Add File
				if (viewModel.ScientificInfoFile is null)
					return View(model: viewModel);

				Models.File uploadFile =
					await FilesService.UploadFileAsync(file: viewModel.ScientificInfoFile, folder: "ScientificInfos");
				#endregion

				if (uploadFile is not null)
				{
					// Insert ScientificInfo
					var model = new ScientificInfo
					{
						Title = viewModel.Title,
						Text = viewModel.Text,
						File = uploadFile,
					};

					await UnitOfWork.ScientificInfos.InsertAsync(entity: model);

					//Insert File 
					uploadFile.ScientificInfo = model;
					uploadFile.ScientificInfoId = model.Id;
					await UnitOfWork.Files.InsertAsync(entity: uploadFile);

					await UnitOfWork.SaveAsync();

					return RedirectToAction(actionName: "Index", controllerName: "ScientificInfos");
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

		// POST: Admin/Banners/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				var foundedScientificInfo =
					await UnitOfWork.ScientificInfos.GetScientificInfoByIdAsync(id: Guid.Parse(id));

				if (foundedScientificInfo is not null)
				{
					if (foundedScientificInfo.File is not null)
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: foundedScientificInfo.File);

						if (isDeleteFile)
							UnitOfWork.Files.Delete(entity: foundedScientificInfo.File);
					}

					UnitOfWork.ScientificInfos.Delete(entity: foundedScientificInfo);

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
