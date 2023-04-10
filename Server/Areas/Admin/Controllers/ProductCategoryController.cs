using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.ProductCategories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize]

	public class ProductCategoryController : Infrastructure.BaseControllerWithDataBase
	{
		public ProductCategoryController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
		{
			FilesService = filesService;
		}

		protected Services.IFilesService FilesService { get; }

		// **************************************************
		// **************************************************

		// GET: Admin/ProductCategory
		#region Index
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var indexViewModels = new List<IndexViewModel>();

				var foundedProductCategories =
					await UnitOfWork.ProductCategories.GetAllProductCategoriesAsync();

				if (foundedProductCategories.Any())
				{
					indexViewModels.AddRange(collection: foundedProductCategories.Select(item => new IndexViewModel()
					{
						Id = item.Id,
						HasSlider = item.HasSlider,
						IsEditted = item.IsEdited,
						InsertDateTime = item.InsertDateTime,
						UpdateDateTime = item.UpdateDateTime,
						Title = item.Title,
					}));

					return View(model: indexViewModels);
				}
				else
				{
					List<IndexViewModel> model = null;

					model ??= new List<IndexViewModel>();

					return View(model: model);
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/ProductCategory/Create
		#region Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CreateViewModel vieModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return RedirectToAction(actionName: "Index", controllerName: "ProductCategory");

				var model = new ProductCategory
				{
					Title = vieModel.Title,
				};

				await UnitOfWork.ProductCategories.InsertAsync(entity: model);
				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "ProductCategory");
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion

		// Get: Admin/ProductCategory/Edit
		#region Edit
		[HttpGet]
		public async Task<JsonResult> Edit(string id)
		{
			try
			{
				string result = System.String.Empty;

				if (string.IsNullOrEmpty(value: id))
					return Json(result);

				var foundedProductCategories =
					 await UnitOfWork.ProductCategories.GetProductCategoryByIdAsync(id: Guid.Parse(input: id));

				if (foundedProductCategories != null)
				{
					var viewModel = new EditViewModel()
					{
						Id = foundedProductCategories.Id,
						Title = foundedProductCategories.Title,
					};

					result = System.Text.Json.JsonSerializer.Serialize(value: viewModel);

					return Json(data: result);
				}
				else
					return Json(data: result);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/ProductCategory/Edit
		#region Edit
		[HttpPost]
		public async Task<JsonResult> Edit(string id, string title)
		{
			try
			{
				bool result = false;
				if (!ModelState.IsValid)
					return Json(data: result);


				var foundedProductCategory =
					await UnitOfWork.ProductCategories.GetByIdAsync(id: System.Guid.Parse(input: id));

				if (foundedProductCategory is not null)
				{
					foundedProductCategory.Title = title;

					UnitOfWork.ProductCategories.Update(entity: foundedProductCategory);

					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
					return Json(data: result);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/ProductCategory/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				if (string.IsNullOrEmpty(value: id))
					return Json(data: result);

				var guid = Guid.Parse(input: id);

				var foundedProductCategory =
					await UnitOfWork.ProductCategories.GetProductCategoryByIdAsync(id: guid);

				if (foundedProductCategory is not null)
				{
					if (foundedProductCategory.File is not null)
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: foundedProductCategory.File);

						if (isDeleteFile)
							UnitOfWork.Files.Delete(entity: foundedProductCategory.File);
					}

					UnitOfWork.ProductCategories.Delete(entity: foundedProductCategory);
					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
				{
					return Json(data: result);
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}

		#endregion

		// GET: Admin/ProductCategorySlider/GetAllProductCategorySliders
		#region ProductCategorySlider
		[HttpGet]
		public async Task<IActionResult> GetAllSliders()
		{
			try

			{
				var getSliderViewModel = new List<GetSliderViewModel>();

				var foundedSliders =
					await UnitOfWork.ProductCategories.GetAllSlidersAsync();

				if (foundedSliders.Any())
				{
					getSliderViewModel.AddRange(collection: foundedSliders.Select(item => new GetSliderViewModel
					{
						Id = item.Id,
						InsertDateTime = item.InsertDateTime,
						IsEditted = item.IsEdited,
						ProductCategoryTitle = item.Title,
						UpdateDateTime = item.UpdateDateTime,
						Url = item.Url
					}));

					return View(model: getSliderViewModel);
				}

				else
				{
					// Logger
					return View(model: getSliderViewModel);
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}

		#endregion

		// GET: Admin/ProductCategorySlider/Create
		#region CreateProductCategorySlider
		[HttpGet]
		public async Task<IActionResult> CreateSlider()
		{
			try
			{
				var createViewModel = new CreateSliderViewModel();

				var foundedProductCategories =
					await UnitOfWork.ProductCategories.GetAllAsync();

				ViewBag.ProductCategories =
					new SelectList(items: foundedProductCategories, dataValueField: "Id", dataTextField: "Title", selectedValue: null);


				return View(model: createViewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// POST: Admin/ProductCategorySlider/Create
		#region CreateProductCategorySlider
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> CreateSlider(CreateSliderViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				if (viewModel.ProductCategoryId.Equals(System.Guid.Empty))
					return View(model: viewModel);

				var foundedProductCategory =
					await UnitOfWork.ProductCategories.GetByIdAsync(viewModel.ProductCategoryId);

				if (foundedProductCategory is null)
				{
					//Logger
					return View(model: viewModel);
				}

				// Update ProductCategory
				foundedProductCategory.Url = viewModel.Url;
				foundedProductCategory.HasSlider = true;

				UnitOfWork.ProductCategories.Update(entity: foundedProductCategory);

				#region Add File
				if (viewModel.File is not null)
				{
					Models.File uploadFile =
						await FilesService.UploadFileAsync(file: viewModel.File, folder: "ProductCategorySliders");

					if (uploadFile is not null)
					{
						//Insert File 
						uploadFile.IsMainFile = true;
						uploadFile.ProductCategoryId = foundedProductCategory.Id;
						await UnitOfWork.Files.InsertAsync(entity: uploadFile);
					}
					else
					{
						// Logger
						return View(model: viewModel);
					}
				}
				else
				{
					// Logger
					return View(model: viewModel);
				}
				#endregion

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "GetAllSliders", controllerName: "ProductCategory");
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/ProductCategorySlider/Edit
		#region EditProductCategorySlider
		[HttpGet]
		public async Task<IActionResult> EditSlider(Guid id)
		{
			try
			{
				var foundedProductCategorySlider =
					await UnitOfWork.ProductCategories.GetProductCategoryByIdAsync(id: id);

				var viewModel = new EditSliderViewModel
				{
					Id = foundedProductCategorySlider.Id,
					Url = foundedProductCategorySlider.Url,
					ImageProductCategorySliderName = foundedProductCategorySlider.File?.Name,
					
				};

				if (foundedProductCategorySlider is not null)
					return View(model: viewModel);

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

		// POST: Admin/ProductCategorySlider/Edit
		#region EditProductCategorySlider
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditSlider(EditSliderViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedProductCategorySlider =
					await UnitOfWork.ProductCategories.GetProductCategoryByIdAsync(id: viewModel.Id);

				if (foundedProductCategorySlider is null)
					return View(model: viewModel);

				#region Add File
				if (viewModel.ImageProductCategorySlider?.Length > 0)
				{
					if (foundedProductCategorySlider.File is null)
					{
						#region Add File
						Models.File uploadFile =
							await FilesService.UploadFileAsync(file: viewModel.ImageProductCategorySlider, folder: "ProductCategorySliders");
						#endregion

						if (uploadFile is not null)
						{
							//Insert File 
							uploadFile.IsMainFile = true;
							uploadFile.ProductCategoryId = foundedProductCategorySlider.Id;
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
							FilesService.DeleteFile(file: foundedProductCategorySlider.File);

						if (isDeleteFile)
						{
							#region Add File
							Models.File uploadFile =
								await FilesService.UploadFileAsync(file: viewModel.ImageProductCategorySlider, folder: "ProductCategorySliders");
							#endregion

							if (uploadFile is not null)
							{
								// Update File
								foundedProductCategorySlider.File.Name = uploadFile.Name;
								foundedProductCategorySlider.File.ContentType = uploadFile.ContentType;
								foundedProductCategorySlider.File.Path = uploadFile.Path;
								foundedProductCategorySlider.File.Size = uploadFile.Size;
								foundedProductCategorySlider.File.Alt = uploadFile.Alt;
								UnitOfWork.Files.Update(entity: foundedProductCategorySlider.File);
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
				#endregion

				// Update ProductCategotySlider
				foundedProductCategorySlider.Url = viewModel.Url;

				UnitOfWork.ProductCategories.Update(entity: foundedProductCategorySlider);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "GetAllSliders", controllerName: "ProductCategory");

			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}

		#endregion

		// POST: Admin/ProductCategorySlider/Delete
		#region DelteProductCategorySlider
		[HttpPost]
		public async Task<IActionResult> DeleteSlider(string id)
		{
			try
			{
				bool result = false;

				var foundedProductCategorySlider =
					await UnitOfWork.ProductCategories.GetProductCategoryByIdAsync(id: Guid.Parse(id));

				if (foundedProductCategorySlider is not null)
				{
					if (foundedProductCategorySlider.File is not null)
					{
						var isDeleteFile = FilesService.DeleteFile(file: foundedProductCategorySlider.File);

						if (isDeleteFile)
							UnitOfWork.Files.Delete(entity: foundedProductCategorySlider.File);
					}

					foundedProductCategorySlider.HasSlider = false;

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

		// POST: Admin/Products/GetProductCategoriesForSlider
		#region GetProductCategories
		[HttpPost]
		public async Task<JsonResult> GetProductCategoriesForSlider()
		{
			try
			{
				string result = System.String.Empty;

				var foundedProductCategories = 
					await UnitOfWork.ProductCategories.GetAllAsync();

				if (foundedProductCategories is not null && foundedProductCategories.Any())
				{
					var viewModels = new List<ProductCategoryViewModel>();

					viewModels.AddRange(collection: foundedProductCategories.Select(item => new ProductCategoryViewModel
					{
						Id = item.Id,
						Title = item.Title,
					}));

					result = System.Text.Json.JsonSerializer.Serialize(value: viewModels);

					return Json(data: result);
				}
				else
					return Json(data: result);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion
	}
}
