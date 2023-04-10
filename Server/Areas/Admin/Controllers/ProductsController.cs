using Models;
using Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.AdminViewModels.Products;
using ViewModels.AdminViewModels.Comparisons;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

	public class ProductsController : Infrastructure.BaseControllerWithDataBase
	{
		public ProductsController(DAL.IUnitOfwork unitOfwork, Services.IFilesService filesService) : base(unitOfwork)
		{
			FilesService = filesService;
		}

		protected Services.IFilesService FilesService { get; }

		// **************************************************
		// **************************************************

		// GET: Admin/Products
		#region Index
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			try
			{
				var indexViewModels = new List<IndexViewModel>();

				var foundedProducts =
					await UnitOfWork.Products.GetAllProductsAsync();

				if (foundedProducts.Any())
				{
					// ToDo: Ordering Properties
					// First Solution
					indexViewModels.AddRange(collection: foundedProducts.Select(item => new IndexViewModel
					{
						Id = item.Id,
						IsEditted = item.IsEdited,
						HasDiscount = item.HasDiscount,
						IsInStock = item.IsInStock,
						DiscountedPrice = item.DiscountedPrice,
						DiscountPercentage = item.DiscountPercentage,
						InsertDateTime = item.InsertDateTime,
						Price = item.Price,
						Title = item.Title,
						UpdateDateTime = item.UpdateDateTime,
						ProductCategoryTitle = item.ProductCategory?.Title,
						ShowInIndex = item.ShowInIndex,
					}));

					return View(model: indexViewModels);
				}
				else
				{
					// Logger
					return View(model: indexViewModels);
				}
			}
			catch (Exception)
			{
				// Logger
				throw;
			}

		}
		#endregion

		// GET: Admin/Products/Create
		#region Create
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			try
			{
				var createViewModel = new CreateViewModel();

				var foundedProductCategories =
					await UnitOfWork.ProductCategories.GetAllAsync();

				ViewBag.ProductCategories =
					new SelectList(items: foundedProductCategories, dataValueField: "Id", dataTextField: "Title", selectedValue: null);

				return View(model: createViewModel);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}

		}
		#endregion

		// POST: Admin/Products/Create
		#region Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				if (viewModel.ProductCategoryId.Equals(System.Guid.Empty))
					return View(model: viewModel);

				var foundedProductCategory =
					await UnitOfWork.ProductCategories.GetByIdAsync(id: viewModel.ProductCategoryId);

				if (foundedProductCategory is null)
				{
					// Logger
					return View(model: viewModel);
				}

				var model = new Product
				{
					Title = viewModel.Title,
					HasDiscount = viewModel.HasDiscount,
					Price = viewModel.Price,
					DiscountPercentage = viewModel.DiscountPercentage,
					DiscountedPrice = viewModel.DiscountedPrice,
					Description = viewModel.Description,
					Specification = viewModel.Specification,
					Rate = viewModel.Rate,
					IsInStock = viewModel.IsInStock,
					ProductCategoryId = foundedProductCategory.Id,
					ProductCategoryTitle = foundedProductCategory.Title,
				};

				switch (model.Title)
				{
					case "کرم روز مناسب پوست دارای لک":
						{
							model.Id = 
								System.Guid.Parse("d58cfbd1-066d-470e-8e4f-10c18ccf60e9");

							break;
						}
                    case "کرم شب مناسب پوست دارای لک":
                        {
                            model.Id =
                                System.Guid.Parse("60e2eeaf-a7e5-4fb5-a8b9-4acf3b190817");

                            break;
                        }
                    case "کرم مناسب پوست دارای چروک دور چشم":
                        {
                            model.Id =
                                System.Guid.Parse("09479e2e-8f93-4914-97dc-534d54e91eec");

                            break;
                        }
                    case "کرم روشن کننده دور چشم":
                        {
                            model.Id =
                                System.Guid.Parse("fdbfd5f0-bcc7-4576-9f85-86e266d0963c");

                            break;
                        }
                    case "کرم مرطوب کننده پوست چرب و مختلط":
                        {
                            model.Id =
                                System.Guid.Parse("24efcd15-3ecd-4029-a82d-8ac75ff3ea8f");

                            break;
                        }
                    case "کرم روشن کننده پوست بدن":
                        {
                            model.Id =
                                System.Guid.Parse("64e0100b-e0e1-4eb7-81fb-d306e665242d");

                            break;
                        }
                    default:
						break;
				}

				await UnitOfWork.Products.InsertAsync(entity: model);

				#region Add File
				if (viewModel.File is null)
					return View(model: viewModel);

				Models.File uploadFile =
					await FilesService.UploadFileAsync(file: viewModel.File, folder: "Products");

				if (uploadFile is not null)
				{
					//Insert File 
					uploadFile.IsMainFile = true;
					uploadFile.ProductId = model.Id;
					await UnitOfWork.Files.InsertAsync(entity: uploadFile);
				}
				else
				{
					// Logger
					return View(model: viewModel);
				}
				#endregion

				#region Add Files
				if (viewModel.Files is null)
					return View(model: viewModel);

				if (!viewModel.Files.Any())
					return View(model: viewModel);

				List<Models.File> uploadFiles =
					await FilesService.UploadFilesAsync(files: viewModel.Files, folder: "Products");

				if (uploadFiles.Any())
				{
					foreach (var item in uploadFiles)
					{
						//Insert File 
						item.ProductId = model.Id;
						await UnitOfWork.Files.InsertAsync(entity: item);
					}
				}
				else
				{
					// Logger
					return View(model: viewModel);
				}
				#endregion

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "Products");
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/Products/Edit
		#region Edit
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{
				if (id.Equals(Guid.Empty))
					return NotFound();

				var foundedProduct =
					await UnitOfWork.Products.GetProductByIdAsync(id: id);

				var foundedProductCategories =
					await UnitOfWork.ProductCategories.GetAllAsync();

				ViewBag.ProductCategories =
					new SelectList(items: foundedProductCategories, dataValueField: "Id", dataTextField: "Title", selectedValue: null);

				Models.File? mainImage =
					foundedProduct.Files?.Where(current => current.IsMainFile == true).FirstOrDefault();

				List<Models.File>? images =
					foundedProduct.Files?.Where(current => current.IsMainFile == false && current.IsAfterImage == false && current.IsBeforeImage == false).ToList();

				var viewModel = new EditViewModel()
				{
					Id = id,
					Title = foundedProduct.Title,
					Description = foundedProduct.Description,
					Specification = foundedProduct.Specification,
					Price = foundedProduct.Price,
					HasDiscount = foundedProduct.HasDiscount,
					DiscountPercentage = foundedProduct.DiscountPercentage,
					DiscountedPrice = foundedProduct.DiscountedPrice,
					Image = mainImage,
					Images = images,
					ProductCategoryTitle = foundedProduct.ProductCategory?.Title,
					ProductCategoryId = foundedProduct.ProductCategoryId,
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

		// POST: Admin/Products/Edit
		#region Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				var foundedProduct =
					await UnitOfWork.Products.GetProductByIdAsync(id: viewModel.Id);

				if (foundedProduct is null)
					return View(model: viewModel);

				var foundedProductCategory =
					await UnitOfWork.ProductCategories.GetByIdAsync(id: viewModel.ProductCategoryId);

				// File
				#region File
				if (viewModel.File?.Length > 0)
				{
					Models.File? mainImage =
						foundedProduct.Files?.Where(current => current.IsMainFile == true).FirstOrDefault();


					if (mainImage is null) // No Image in wwwroot
					{
						#region Add File
						Models.File uploadFile =
							await FilesService.UploadFileAsync(file: viewModel.File, folder: "Products");
						#endregion

						if (uploadFile is not null)
						{
							//Insert File 
							uploadFile.IsMainFile = true;
							uploadFile.ProductId = foundedProduct.Id;
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
							FilesService.DeleteFile(file: mainImage!);

						if (isDeleteFile)
						{
							#region Add File
							Models.File uploadFile =
								await FilesService.UploadFileAsync(file: viewModel.File, folder: "Products");
							#endregion

							if (uploadFile is not null)
							{
								// Update File
								mainImage.Name = uploadFile.Name;
								mainImage.ContentType = uploadFile.ContentType;
								mainImage.Path = uploadFile.Path;
								mainImage.Size = uploadFile.Size;
								mainImage.Alt = uploadFile.Alt;

								UnitOfWork.Files.Update(entity: mainImage);
							}
							else
							{
								// Logger
								return NotFound(value: "Problem is about Upload New File");
							}
						}
						else
						{
							// Logger
							return NotFound(value: "Problem is about Delete Old File");
						}
					}
				}
				#endregion

				// Files
				#region Files
				if (viewModel.Files is not null && viewModel.Files.Any())
				{
					#region Add Files
					if (viewModel.Files is null)
						return View(model: viewModel);

					if (!viewModel.Files.Any())
						return View(model: viewModel);

					List<Models.File> uploadFiles =
						await FilesService.UploadFilesAsync(files: viewModel.Files, folder: "Products");
					#endregion

					if (uploadFiles.Any())
					{
						foreach (var item in uploadFiles)
						{
							//Insert File 
							item.ProductId = foundedProduct.Id;
							await UnitOfWork.Files.InsertAsync(entity: item);
						}
					}
					else
					{
						// Logger
						return NotFound(value: "Problem is about Upload New Files");
					}
				}
				#endregion

				// Update Product
				foundedProduct.Title = viewModel.Title;
				foundedProduct.Description = viewModel.Description;
				foundedProduct.Specification = viewModel.Specification;
				foundedProduct.Price = viewModel.Price;
				foundedProduct.HasDiscount = viewModel.HasDiscount;
				foundedProduct.DiscountPercentage = viewModel.DiscountPercentage;
				foundedProduct.DiscountedPrice = viewModel.DiscountedPrice;
				foundedProduct.ProductCategoryId = foundedProductCategory.Id;
				foundedProduct.ProductCategoryTitle = foundedProductCategory.Title;
				UnitOfWork.Products.Update(entity: foundedProduct);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "Products");
			}
			catch (Exception)
			{
				// Log
				throw;
			}
		}
		#endregion

		// POST: Admin/Products/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				var foundedProduct =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(id));

				if (foundedProduct is not null)
				{
					if (foundedProduct.Files is not null)
					{
						var isDeleteFile =
							FilesService.DeleteFiles(files: foundedProduct.Files);

						if (isDeleteFile)
						{
							foreach (var item in foundedProduct.Files)
							{
								UnitOfWork.Files.Delete(entity: item);
							}
						}
					}

					UnitOfWork.Products.Delete(entity: foundedProduct);

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
				// Logger
				throw;
			}
		}


		#endregion
	
		// POST: Admin/Products/DeleteFileFromProductEditView
		#region DeleteFile
		[HttpPost]
		public async Task<JsonResult> DeleteFileFromProductEditView(string fileId)
		{
			try
			{
				var result = false;

				var foundedFile =
					await UnitOfWork.Files.GetByIdAsync(id: Guid.Parse(input: fileId));

				if (foundedFile is null)
				{
					// Logger
					return Json(data: result);
				}

				var isDeletedFile =
					FilesService.DeleteFile(file: foundedFile);

				if (isDeletedFile)
				{
					UnitOfWork.Files.Delete(entity: foundedFile);

					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
				{
					// Logger
					return Json(data: result);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		#endregion

		// POST: Admin/Products/ConfirmShowInIndex
		#region ConfirmShowIndex
		[HttpPost]
		public async Task<JsonResult> ConfirmShowInIndex(string id)
		{
			try
			{
				bool result = false;

				if (string.IsNullOrEmpty(value: id))
					return Json(data: result);

				var guid = Guid.Parse(input: id);

				var foundedProduct =
					await UnitOfWork.Products.GetByIdAsync(id: guid);

				if (foundedProduct is not null)
				{
					if (foundedProduct.ShowInIndex == false)
						foundedProduct.ShowInIndex = true;
					else
						foundedProduct.ShowInIndex = false;

					UnitOfWork.Products.Update(entity: foundedProduct);
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

		// POST: Admin/Products/ConfirmIsInStock
		#region ConfirmIsInStock
		public async Task<JsonResult> ConfirmIsInStock(string id)
		{
			try
			{
				bool result = false;

				if (string.IsNullOrEmpty(value: id))
					return Json(data: result);

				var guid = Guid.Parse(input: id);

				var foundedProduct =
					await UnitOfWork.Products.GetByIdAsync(id: guid);

				if (foundedProduct is not null)
				{
					if (foundedProduct.IsInStock == false)
						foundedProduct.IsInStock = true;
					else
						foundedProduct.IsInStock = false;

					UnitOfWork.Products.Update(entity: foundedProduct);
					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
					return Json(data: result);
			}
			catch (Exception)
			{

				throw;
			}
		}

		#endregion

		// POST: Admin/Products/Details
		#region Details
		[HttpGet]
		public async Task<JsonResult> Details(string id)
		{
			try
			{
				string result = System.String.Empty;

				var foundedProduct =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(id));

				if (foundedProduct is not null)
				{
					var viewModel = new DetailsViewModel()
					{
						DiscountedPrice = foundedProduct.DiscountedPrice,
						DiscountPercentage = foundedProduct.DiscountPercentage,
						InsertDateTime = foundedProduct.InsertDateTime.ToShamsiWithoutTime(),
						UpdateDateTime = foundedProduct.UpdateDateTime.ToShamsiWithoutTime(),
					};

					result = System.Text.Json.JsonSerializer.Serialize(value: viewModel);

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
				// Logger
				throw;
			}
		}


		#endregion
	}
}
