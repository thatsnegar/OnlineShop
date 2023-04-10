using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels.AdminViewModels.Comparisons;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

	public class ComparisonProductController : Infrastructure.BaseControllerWithDataBase
	{

		public ComparisonProductController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
		{
			FilesService = filesService;
		}

		protected Services.IFilesService FilesService { get; }

		// **************************************************
		// **************************************************

		// GET: Admin/GetAllComparisionProducts

		#region GetAllComparisionProducts
		[HttpGet]
		public async Task<IActionResult> GetAllComparisionProducts()
		{
			try
			{
				var viewModels = new List<ComparisonProductViewModel>();


				var foundedComparisonProduct =
					await UnitOfWork.ComparisonProducts.GetAllComparisonProduct();

				if (foundedComparisonProduct.Any())
				{
					viewModels.AddRange(collection: foundedComparisonProduct.Select(item => new ComparisonProductViewModel
					{
						Id = item.Id,
						Title = item.Title,
					}));

					return View(model: viewModels);
				}
				else
				{
					// Logger
					return View(model: viewModels);
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}

		}
		#endregion


		// GET: Admin/ComprisonProduct/CreateComparisonProduct
		#region CreateComparisonProduct
		[HttpGet]
		public IActionResult CreateComparisonProduct()
		{
			try
			{
				var CreateViewModel = new CreateComparisonProductViewModel();

				return View(model: CreateViewModel);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion


		// POST: Admin/ComprisonProduct/CreateComparisonProduct
		#region  CreateComparisonProduct
		[HttpPost]
		public async Task<IActionResult> CreateComparisonProduct(CreateComparisonProductViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);


				var model = new ComparisonProduct
				{
					Title = viewModel.Title,
					Description = viewModel.Description,
				};

				await UnitOfWork.ComparisonProducts.InsertAsync(entity: model);


				// Thumbnail Image Comparison
				#region Thumbnail
				if (viewModel.ThumbnailImageProduct is null)
					return View(model: viewModel);
				else
				{
					Models.File uploadThumbnailFile =
						await FilesService.UploadFileAsync(file: viewModel.ThumbnailImageProduct!, folder: "ComparisonProduct");

					if (uploadThumbnailFile is not null)
					{
						//Insert File 

						uploadThumbnailFile.ComParisonProductId = model.Id;
						uploadThumbnailFile.IsThumbnailImage = true;
						await UnitOfWork.Files.InsertAsync(entity: uploadThumbnailFile);
					}
					else
					{
						// Logger
						return View(model: viewModel);
					}
				}
				#endregion

				// Before Image Comparison
				#region Before
				if (viewModel.BeforeImageProduct is null)
					return View(model: viewModel);
				else
				{
					Models.File uploadBeforFile =
						await FilesService.UploadFileAsync(file: viewModel.BeforeImageProduct, folder: "ComparisonProduct");

					if (uploadBeforFile is not null)
					{
						//Insert File 
						uploadBeforFile.ComParisonProductId = model.Id;
						uploadBeforFile.IsBeforeImage = true;
						await UnitOfWork.Files.InsertAsync(entity: uploadBeforFile);
					}
					else
					{
						// Logger
						return View(model: viewModel);
					}
				}
				#endregion

				// After Image Comparison
				#region After
				if (viewModel.AfterImageProduct is null)
					return View(model: viewModel);
				else
				{
					Models.File uploadAfterFile =
						await FilesService.UploadFileAsync(file: viewModel.AfterImageProduct!, folder: "ComparisonProduct");

					if (uploadAfterFile is not null)
					{
						//Insert File 
						uploadAfterFile.ComParisonProductId = model.Id;
						uploadAfterFile.IsAfterImage = true;
						await UnitOfWork.Files.InsertAsync(entity: uploadAfterFile);
					}
					else
					{
						// Logger
						return View(model: viewModel);
					}
				}
				#endregion

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "GetAllComparisionProducts", controllerName: "ComparisonProduct");
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// GET: Admin/Products/CreateComparisonProduct
		#region EditComparisonProduct
		[HttpGet]
		public async Task<IActionResult> EditComparisonProduct(Guid id)
		{
			try
			{
				if (id.Equals(Guid.Empty))
					return NotFound();

				var foundedComparisonProducut =
					await UnitOfWork.ComparisonProducts.GetComparisonProductByIdAsync(id: id);

				List<Models.File>? images = foundedComparisonProducut.Files?
				.Where(current =>
					current.IsThumbnailImage.Equals(true)
					||
					current.IsBeforeImage.Equals(true)
					||
					current.IsAfterImage.Equals(true))
					.ToList()
					;

				var viewModel = new EditComparisonProductViewModel()
				{
					ComparisonProductId = id,
					Title = foundedComparisonProducut.Title,
					Description = foundedComparisonProducut.Description,
					ThumbNailImage = images?.Where(current => current.IsThumbnailImage.Equals(true)).FirstOrDefault(),
					BeforeImage = images?.Where(current => current.IsBeforeImage.Equals(true)).FirstOrDefault(),
					AfterImage = images?.Where(current => current.IsAfterImage.Equals(true)).FirstOrDefault(),
				};

				return View(model: viewModel);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion


		// POST: Admin/ComparisonProduct/EditComparisonProduct
		#region EditComparisonProduct
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditComparisonProduct(EditComparisonProductViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedComparisonProduct =
					await UnitOfWork.ComparisonProducts.GetComparisonProductByIdAsync(id: viewModel.ComparisonProductId);

				if (foundedComparisonProduct is null)
					return View(model: viewModel);

				// ThumbNail File
				#region ThumbNail File
				if (viewModel.ThumbnailImageProduct?.Length > 0)
				{
					Models.File? thumbnailImage =
						foundedComparisonProduct.Files?.Where(current => current.IsThumbnailImage.Equals(true)).FirstOrDefault();

					if (thumbnailImage is null) // No Image in wwwroot
					{
						#region Add File
						if (viewModel.ThumbnailImageProduct is null)
							return View(model: viewModel);

						Models.File uploadFile =
							await FilesService.UploadFileAsync(file: viewModel.ThumbnailImageProduct, folder: "ComparisonProduct");
						#endregion

						if (uploadFile is not null)
						{
							// Insert File
							uploadFile.IsThumbnailImage = true;
							uploadFile.ComParisonProductId = foundedComparisonProduct.Id;
							await UnitOfWork.Files.InsertAsync(entity: uploadFile);
						}
						else
						{
							// Log
							return NotFound(value: "Problem is about Upload New File");
						}
					}
					else // Has Image in wwwroot
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: thumbnailImage!);

						if (isDeleteFile)
						{
							#region Add File
							if (viewModel.ThumbnailImageProduct is null)
								return View(model: viewModel);

							Models.File uploadFile =
								await FilesService.UploadFileAsync(file: viewModel.ThumbnailImageProduct, folder: "ComparisonProduct");
							#endregion

							if (uploadFile is not null)
							{
								// Update File
								thumbnailImage!.Name = uploadFile.Name;
								thumbnailImage.ContentType = uploadFile.ContentType;
								thumbnailImage.Path = uploadFile.Path;
								thumbnailImage.Size = uploadFile.Size;
								thumbnailImage.Alt = uploadFile.Alt;

								UnitOfWork.Files.Update(entity: thumbnailImage);
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

				// Before File
				#region Before File
				if (viewModel.BeforeImageProduct?.Length > 0)
				{
					Models.File? beforeImage =
						foundedComparisonProduct.Files?.Where(current => current.IsBeforeImage.Equals(true)).FirstOrDefault();

					if (beforeImage is null) // No Image in wwwroot
					{
						#region Add File
						if (viewModel.BeforeImageProduct is null)
							return View(model: viewModel);

						Models.File uploadFile =
							await FilesService.UploadFileAsync(file: viewModel.BeforeImageProduct, folder: "ComparisonProduct");
						#endregion

						if (uploadFile is not null)
						{
							// Insert File
							uploadFile.IsBeforeImage = true;
							uploadFile.ComParisonProductId = foundedComparisonProduct.Id;
							await UnitOfWork.Files.InsertAsync(entity: uploadFile);
						}
						else
						{
							// Log
							return NotFound(value: "Problem is about Upload New File");
						}
					}
					else // Has Image in wwwroot
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: beforeImage!);

						if (isDeleteFile)
						{
							#region Add File
							if (viewModel.BeforeImageProduct is null)
								return View(model: viewModel);

							Models.File uploadFile =
								await FilesService.UploadFileAsync(file: viewModel.BeforeImageProduct, folder: "ComparisonProduct");
							#endregion

							if (uploadFile is not null)
							{
								// Update File
								beforeImage!.Name = uploadFile.Name;
								beforeImage.ContentType = uploadFile.ContentType;
								beforeImage.Path = uploadFile.Path;
								beforeImage.Size = uploadFile.Size;
								beforeImage.Alt = uploadFile.Alt;

								UnitOfWork.Files.Update(entity: beforeImage);
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

				// After File
				#region After File
				if (viewModel.AfterImageProduct?.Length > 0)
				{
					Models.File? afterImage =
						foundedComparisonProduct.Files?.Where(current => current.IsAfterImage.Equals(true)).FirstOrDefault();

					if (afterImage is null) // No Image in wwwroot
					{
						#region Add File
						if (viewModel.AfterImageProduct is null)
							return View(model: viewModel);

						Models.File uploadFile =
							await FilesService.UploadFileAsync(file: viewModel.AfterImageProduct, folder: "ComparisonProduct");
						#endregion

						if (uploadFile is not null)
						{
							// Insert File
							uploadFile.IsAfterImage = true;
							uploadFile.ComParisonProductId = foundedComparisonProduct.Id;
							await UnitOfWork.Files.InsertAsync(entity: uploadFile);
						}
						else
						{
							// Log
							return NotFound(value: "Problem is about Upload New File");
						}
					}
					else // Has Image in wwwroot
					{
						var isDeleteFile =
							FilesService.DeleteFile(file: afterImage!);

						if (isDeleteFile)
						{
							#region Add File
							if (viewModel.AfterImageProduct is null)
								return View(model: viewModel);

							Models.File uploadFile =
								await FilesService.UploadFileAsync(file: viewModel.AfterImageProduct, folder: "ComparisonProduct");
							#endregion

							if (uploadFile is not null)
							{
								// Update File
								afterImage!.Name = uploadFile.Name;
								afterImage.ContentType = uploadFile.ContentType;
								afterImage.Path = uploadFile.Path;
								afterImage.Size = uploadFile.Size;
								afterImage.Alt = uploadFile.Alt;

								UnitOfWork.Files.Update(entity: afterImage);
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

				// Update Product

				foundedComparisonProduct.Title = viewModel.Title;
				foundedComparisonProduct.Description = viewModel.Description;
				UnitOfWork.ComparisonProducts.Update(entity: foundedComparisonProduct);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "GetAllComparisionProducts", controllerName: "ComparisonProduct");
			}
			catch (Exception)
			{
				// Log
				throw;
			}
		}
		#endregion

		// POST: Admin/ComparisonProduct/DeletComparisonProduct
		[HttpPost]
		public async Task<JsonResult> DeleteComparisonProduct(string id)
		{
			try
			{
				bool result = false;

				var foundedComparisonProduct =
					await UnitOfWork.ComparisonProducts.GetComparisonProductByIdAsync(id: Guid.Parse(id));

				if (foundedComparisonProduct is not null)
				{
					if (foundedComparisonProduct.Files is not null)
					{
						var isDeleteFile =
							FilesService.DeleteFiles(files: foundedComparisonProduct.Files);

						if (isDeleteFile)
						{
							foreach (var item in foundedComparisonProduct.Files)
							{
								UnitOfWork.Files.Delete(entity: item);
							}
						}
					}

					UnitOfWork.ComparisonProducts.Delete(entity: foundedComparisonProduct);

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

				throw;
			}
		}

	}
}
