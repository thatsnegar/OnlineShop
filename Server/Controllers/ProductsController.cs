using DAL;
using Models;
using Shared;
using Ganss.XSS;
using Infrastructure;
using ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class ProductsController : BaseControllerWithDatabase
	{
		public ProductsController(ILogger<ProductsController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<ProductsController> Logger { get; }

		// **************************************************
		// **************************************************

		#region ProductList
		public async Task<IActionResult> ProductList(Guid productCategoryId, int pageNumber = 1)
		{
			try
			{
				var foundedUser =
					GetCurrentUser();

				ViewData["foundedOnlineUser"] = foundedUser;

				var foundedProducts =
					await UnitOfWork.Products.GetProductByProductCategoryIdAsync(id: productCategoryId);

				var viewModels = new List<ViewModels.Products.ProductViewModel>();

				if (foundedProducts.Any())
				{
					// Page Number
					ViewBag.PageNumber = pageNumber;

					var pageViewModel =
						new ViewModels.Paginations.PageViewModel(pageNumber: pageNumber);

					var totalPages =
						((double)foundedProducts.Count / (double)pageViewModel.PageSize);

					int roundedTotalPages =
						Convert.ToInt32(Math.Ceiling(a: totalPages));

					// Total Pages
					ViewBag.TotalPages =
						roundedTotalPages;

					foundedProducts =
						foundedProducts
						.Skip(count: (pageViewModel.PageNumber - 1) * pageViewModel.PageSize)
						.Take(count: pageViewModel.PageSize)
						.ToList()
						;

					viewModels.AddRange(collection: foundedProducts.Select(item => new ViewModels.Products.ProductViewModel
					{
						ProductId = item.Id,
						HasDiscount = item.HasDiscount,
						DiscountedPrice = item.DiscountedPrice,
						DiscountPercentage = item.DiscountPercentage,
						Price = item.Price,
						Rate = item.Rate,
						Title = item.Title,
						ImageProductName = item.Files?.Where(current => current.IsMainFile.Equals(true)).FirstOrDefault()?.Name,
						Description = item.Description,
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
				//Logger
				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************
		#region ProductDetails
		[HttpGet]
		[Route("ProductDetails")]
		public async Task<IActionResult> ProductDetails(Guid id)
		{
			try
			{
				var foundedUser =
					GetCurrentUser();

				ViewData["foundedOnlineUser"] = foundedUser;

				var foundedProduct =
					await UnitOfWork.Products.GetProductByIdAsync(id: id);

				var foundedCurrentUser = GetCurrentUser();


				bool isInWishList = false;

				if (foundedCurrentUser is not null)
				{
					isInWishList =
						await
						UnitOfWork.WishListProducts
						.IsExsistProductInWishListCurrentUserAsync(userId: foundedCurrentUser.Id, productId: foundedProduct.Id)
						;
				}

				#region Calculate Rate
				int rate = 0;
				int averageRate = 0;

				if (foundedProduct.Comments.Where(curent => curent.Isconfirm.Equals(true)).Any()) 
				{
					if (foundedProduct.Comments is not null && foundedProduct.Comments.Any())
					{

						foreach (var list in foundedProduct.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProduct.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}

				}
				#endregion

				var viewModel = new ViewModels.Products.DetailViewModel()
				{
					Title = foundedProduct.Title,
					Description = foundedProduct.Description,
					DiscountedPrice = foundedProduct.DiscountedPrice,
					Price = foundedProduct.Price,
					ProductCategoryTitle = foundedProduct.ProductCategory?.Title,
					Rate = averageRate,
					Specification = foundedProduct.Specification,
					ProductImages = foundedProduct.Files,
					ProductId = foundedProduct.Id,
					UserId = foundedCurrentUser?.Id,
					IsInWishList = isInWishList,
					HasDiscount = foundedProduct.HasDiscount,
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

		// **************************************************
		// **************************************************
		#region AddToWishList
		[HttpPost]
		public async Task<JsonResult> AddToWishList(string id)
		{
			try
			{
				bool result = false;

				if (string.IsNullOrEmpty(value: id))
					return Json(data: result);

				var foundedCurrentUser = GetCurrentUser();

				if (foundedCurrentUser is null)
					return Json(data: result);

				var foundedProduct =
					await UnitOfWork.Products.GetByIdAsync(id: Guid.Parse(id));

				if (foundedProduct is null)
					return Json(data: result);

				var foundedWishListId =
					await UnitOfWork.WishListProducts.GetProductWishListAsync(productId: foundedProduct.Id, userId: foundedCurrentUser.Id);

				if (foundedWishListId != Guid.Empty)
				{
					UnitOfWork.WishListProducts.DeleteById(id: foundedWishListId);

					List<WishListProduct> wishListProducts =
						HttpContext.Session.GetJson<List<WishListProduct>>("WishListProduct") ?? new List<WishListProduct>();

					var x = wishListProducts.Count;

					x--;

					HttpContext.Session.SetJson("WishListProduct", x);
				}
				else
				{
					var model = new Models.WishListProduct()
					{
						ProductId = foundedProduct.Id,
						UserId = foundedCurrentUser.Id,
					};

					await UnitOfWork.WishListProducts.InsertAsync(entity: model);
				}

				await UnitOfWork.SaveAsync();

				result = true;

				return Json(data: result);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}

		#endregion

		// **************************************************
		// **************************************************
		#region AddComment
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddComment(CommentsViewModel vieModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: vieModel);

				var foundedCurrentUser = GetCurrentUser();

				ViewData["foundedOnlineUser"] = foundedCurrentUser;

				if (foundedCurrentUser is not null)
				{
					var sanitize = new HtmlSanitizer();

					var model = new Comment
					{
						Text = sanitize.Sanitize(vieModel.Text),
						Rate = vieModel.Rate,
						ProductId = vieModel.ProductId,
						UserId = foundedCurrentUser.Id,
					};

					await UnitOfWork.Comments.InsertAsync(entity: model);
					await UnitOfWork.SaveAsync();

					return RedirectToAction(controllerName: "Products", actionName: "ProductDetails", routeValues: new { id = model.ProductId });
				}
				else
					return RedirectToAction(controllerName: "Account", actionName: "Login");
			}
			catch (Exception)
			{
				Logger.LogCritical("No comments were found!");

				//Logger    
				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************
		#region Increase Like number 
		[HttpPost]
		public JsonResult IncreaseLikenumber(string commentId)
		{
			try
			{
				int result = 0;

				var foundedComment =
					 UnitOfWork.Comments.GetById(id: System.Guid.Parse(commentId));

				if (foundedComment is null)
					return Json(data: result);
				else
				{
					foundedComment.LikeNumbers += 1;

					UnitOfWork.Comments.Update(entity: foundedComment);
					UnitOfWork.Save();

					result = foundedComment.LikeNumbers;

					return Json(data: result);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// **************************************************
		// **************************************************
		#region DisLike Number
		[HttpPost]
		public JsonResult IncreaseDisLikenumber(string commentId)
		{
			try
			{
				int result = 0;

				var foundedComment =
					 UnitOfWork.Comments.GetById(id: System.Guid.Parse(commentId));

				if (foundedComment is null)
					return Json(data: result);
				else
				{
					foundedComment.DisLikeNumbers += 1;

					UnitOfWork.Comments.Update(entity: foundedComment);
					UnitOfWork.Save();

					result = foundedComment.DisLikeNumbers;

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
#endregion