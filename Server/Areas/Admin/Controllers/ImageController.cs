using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels.AdminViewModels.Image;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize]

	public class ImageController : Infrastructure.BaseControllerWithDataBase
	{
		public ImageController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
		{
			FilesService = filesService;
		}

		protected Services.IFilesService FilesService { get; }

		// **************************************************
		// **************************************************


		// GET: Admin/Image
		#region Index
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var indexViewModel = new List<IndexViewModel>();

				var foundedImages =
					await UnitOfWork.Images.GetAllImagesAsync();

				if (foundedImages.Any())
				{
					indexViewModel.AddRange(collection: foundedImages.Select(item => new IndexViewModel
					{
						Id = item.Id,
						IsEditted = item.IsEdited,
						InsertDateTime = item.InsertDateTime,
						UpdateDateTime = item.UpdateDateTime,
						ImageTitle = item.ImageTitle,
					}));

					return View(model: indexViewModel);
				}
				else
					return View(model: indexViewModel);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/Image/Create
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

		// POST: Admin/Image/Create
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
				if (viewModel.Image is null)
					return View(model: viewModel);

				Models.File uploadFile =
					await FilesService.UploadFileAsync(file: viewModel.Image, folder: "Images");
				#endregion

				if (uploadFile is not null)
				{
					// Insert Image
					var model = new Image
					{
						ImageTitle = viewModel.ImageTitle,
						FirstSlogan = viewModel.FirstSlogan,
						SecondSlogan = viewModel.SecondSlogan,
						ThirdSlogan = viewModel.ThirdSlogan,
						File = uploadFile,
					};

					await UnitOfWork.Images.InsertAsync(entity: model);

					//Insert File 
					uploadFile.Image = model;
					uploadFile.ImageId = model.Id;
					await UnitOfWork.Files.InsertAsync(entity: uploadFile);

					await UnitOfWork.SaveAsync();

					return RedirectToAction(actionName: "Index", controllerName: "Image");
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

		// GET: Admin/Image/Edit
		#region Edit
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{
				var foundedImage =
					await UnitOfWork.Images.GetImageByIdAsync(id: id);

				if (foundedImage is null)
				{
					// Logger
					return NotFound();
				}

				var viewModel = new EditViewModel
				{
					Id = foundedImage.Id,
					ImageTitle = foundedImage.ImageTitle,
					ImageName = foundedImage.File?.Name,
					FirstSlogan = foundedImage.FirstSlogan,
					SecondSlogan = foundedImage.SecondSlogan,
					ThirdSlogan = foundedImage.ThirdSlogan,
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

		// POST: Admin/‌Image/Edit
		#region Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedImage =
					await UnitOfWork.Images.GetImageByIdAsync(id: viewModel.Id);

				if (foundedImage is null)
					return View(model: viewModel);

				if (viewModel.Image?.Length > 0)
				{
					if (foundedImage.File is null)
					{
						#region Add File
						Models.File uploadFile =
							await FilesService.UploadFileAsync(file: viewModel.Image, folder: "Images");
						#endregion

						if (uploadFile is not null)
						{
							//Insert File 
							uploadFile.ImageId = foundedImage.Id;
							await UnitOfWork.Files.InsertAsync(entity: uploadFile);
						}
						else
						{
							// Log
							return NotFound(value: "Problem is about Upload New File");
						}
					}
					else
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: foundedImage.File);

						if (isDeleteFile)
						{
							#region Add File
							Models.File uploadFile =
								await FilesService.UploadFileAsync(file: viewModel.Image, folder: "Images");
							#endregion

							if (uploadFile is not null)
							{
								// Update File
								foundedImage.File.Name = uploadFile.Name;
								foundedImage.File.ContentType = uploadFile.ContentType;
								foundedImage.File.Path = uploadFile.Path;
								foundedImage.File.Size = uploadFile.Size;
								foundedImage.File.Alt = uploadFile.Alt;
								UnitOfWork.Files.Update(entity: foundedImage.File);
							}
							else
							{
								// Log
								return NotFound(value: "Problem is about Upload New File");
							}
						}
						else
						{
							// Log
							return NotFound(value: "Problem is about Delete Old File");
						}
					}
				}

				//Update Image
				foundedImage.ImageTitle = viewModel.ImageTitle;
				foundedImage.FirstSlogan = viewModel.FirstSlogan;
				foundedImage.SecondSlogan = viewModel.SecondSlogan;
				foundedImage.ThirdSlogan = viewModel.ThirdSlogan;
				UnitOfWork.Images.Update(entity: foundedImage);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "Image");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/Image/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				var foundedImage =
					await UnitOfWork.Images.GetImageByIdAsync(id: Guid.Parse(id));

				if (foundedImage is not null)
				{
					if (foundedImage.File is not null)
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: foundedImage.File);

						if (isDeleteFile)
							UnitOfWork.Files.Delete(entity: foundedImage.File);
					}

					UnitOfWork.Images.Delete(entity: foundedImage);

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
