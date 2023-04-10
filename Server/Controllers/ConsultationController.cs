using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class ConsultationController : Infrastructure.BaseControllerWithDatabase
	{
		public ConsultationController(ILogger<HomeController> logger, DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
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

		[HttpGet]
		public async Task<IActionResult> SkinQuiz()
		{
			try
			{
				var foundedUser =
						GetCurrentUser();

				ViewData["foundedOnlineUser"] = foundedUser;

				var foundedQuestions = 
					await UnitOfWork.Questions.GetAllQuestionsAsync();

				var viewModels = 
					new List<ViewModels.Questions.SkinQuizeViewModel>();

				viewModels.AddRange(collection: foundedQuestions.Select(item => new ViewModels.Questions.SkinQuizeViewModel
				{
					QuestionTitle = item.Title,
					QuestionText = item.Text,
					Answers = (item.Answers is not null) ? item.Answers.OrderBy(current => current.DisplayOrder).ToList(): new List<Models.Answer>(),
				}));

				return View(model: viewModels);
			}
			catch (Exception)
			{
				// Logger
				throw;
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Calculate(string age, string item1, string item2, string item3, string item4, string item5, string item6, string item7, string item8, string item9,string item10)
		{
			var viewModels = new List<ViewModels.Products.ProductViewModel>();

			//1
			if (item1 != "on" && item1 != null)
			{
				var foundedProductItem1 = 
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item1));

				if(foundedProductItem1 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem1.Comments is not null && foundedProductItem1.Comments.Any())
					{

						foreach (var list in foundedProductItem1.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem1.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion
					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem1.Id,
						HasDiscount = foundedProductItem1.HasDiscount,
						DiscountedPrice = foundedProductItem1.DiscountedPrice,
						DiscountPercentage = foundedProductItem1.DiscountPercentage,
						Price = foundedProductItem1.Price,
						Title = foundedProductItem1.Title,
						ImageProductName = foundedProductItem1.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem1.Description,
						Rate = averageRate,
					});
				}
			}

			//2
			if (item2 != "on" && item2 != null)
			{
				var foundedProductItem2 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item2));

				if (foundedProductItem2 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem2.Comments is not null && foundedProductItem2.Comments.Any())
					{

						foreach (var list in foundedProductItem2.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem2.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion
					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem2.Id,
						HasDiscount = foundedProductItem2.HasDiscount,
						DiscountedPrice = foundedProductItem2.DiscountedPrice,
						DiscountPercentage = foundedProductItem2.DiscountPercentage,
						Price = foundedProductItem2.Price,
						Rate = averageRate,
						Title = foundedProductItem2.Title,
						ImageProductName = foundedProductItem2.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem2.Description,
					});
				}
			}

			//3
			if (item3 != "on" && item3 != null)
			{
				var foundedProductItem3 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item3));

				if (foundedProductItem3 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem3.Comments is not null && foundedProductItem3.Comments.Any())
					{

						foreach (var list in foundedProductItem3.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem3.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion

					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem3.Id,
						HasDiscount = foundedProductItem3.HasDiscount,
						DiscountedPrice = foundedProductItem3.DiscountedPrice,
						DiscountPercentage = foundedProductItem3.DiscountPercentage,
						Price = foundedProductItem3.Price,
						Rate = averageRate,
						Title = foundedProductItem3.Title,
						ImageProductName = foundedProductItem3.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem3.Description,
					});
				}
			}

			//4
			if (item4 != "on" && item4 != null)
			{
				var foundedProductItem4 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item4));

				if (foundedProductItem4 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem4.Comments is not null && foundedProductItem4.Comments.Any())
					{

						foreach (var list in foundedProductItem4.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem4.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion
					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem4.Id,
						HasDiscount = foundedProductItem4.HasDiscount,
						DiscountedPrice = foundedProductItem4.DiscountedPrice,
						DiscountPercentage = foundedProductItem4.DiscountPercentage,
						Price = foundedProductItem4.Price,
						Rate = averageRate,
						Title = foundedProductItem4.Title,
						ImageProductName = foundedProductItem4.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem4.Description,
					});
				}
			}

			//5
			if (item5 != "on" && item5 != null)
			{
				var foundedProductItem5 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item5));

				if (foundedProductItem5 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem5.Comments is not null && foundedProductItem5.Comments.Any())
					{

						foreach (var list in foundedProductItem5.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem5.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion

					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem5.Id,
						HasDiscount = foundedProductItem5.HasDiscount,
						DiscountedPrice = foundedProductItem5.DiscountedPrice,
						DiscountPercentage = foundedProductItem5.DiscountPercentage,
						Price = foundedProductItem5.Price,
						Rate = averageRate,
						Title = foundedProductItem5.Title,
						ImageProductName = foundedProductItem5.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem5.Description,
					});
				}
			}

			//6
			if (item6 != "on" && item6 != null)
			{
				var foundedProductItem6 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item6));

				if (foundedProductItem6 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem6.Comments is not null && foundedProductItem6.Comments.Any())
					{

						foreach (var list in foundedProductItem6.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem6.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion

					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem6.Id,
						HasDiscount = foundedProductItem6.HasDiscount,
						DiscountedPrice = foundedProductItem6.DiscountedPrice,
						DiscountPercentage = foundedProductItem6.DiscountPercentage,
						Price = foundedProductItem6.Price,
						Rate = averageRate,
						Title = foundedProductItem6.Title,
						ImageProductName = foundedProductItem6.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem6.Description,
					});
				}
			}

			//7
			if (item7 != "on" && item7 != null)
			{
				var foundedProductItem7 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item7));

				if (foundedProductItem7 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem7.Comments is not null && foundedProductItem7.Comments.Any())
					{

						foreach (var list in foundedProductItem7.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem7.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion

					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem7.Id,
						HasDiscount = foundedProductItem7.HasDiscount,
						DiscountedPrice = foundedProductItem7.DiscountedPrice,
						DiscountPercentage = foundedProductItem7.DiscountPercentage,
						Price = foundedProductItem7.Price,
						Rate = averageRate,
						Title = foundedProductItem7.Title,
						ImageProductName = foundedProductItem7.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem7.Description,
					});
				}
			}

			//8
			if (item8 != "on" && item8 != null)
			{
				var foundedProductItem8 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item8));

				if (foundedProductItem8 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem8.Comments is not null && foundedProductItem8.Comments.Any())
					{

						foreach (var list in foundedProductItem8.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem8.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion

					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem8.Id,
						HasDiscount = foundedProductItem8.HasDiscount,
						DiscountedPrice = foundedProductItem8.DiscountedPrice,
						DiscountPercentage = foundedProductItem8.DiscountPercentage,
						Price = foundedProductItem8.Price,
						Rate = averageRate,
						Title = foundedProductItem8.Title,
						ImageProductName = foundedProductItem8.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem8.Description,
					});
				}
			}

			//9
			if (item9 != "on" && item9 != null)
			{
				var foundedProductItem9 =
					await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(input: item9));

				if (foundedProductItem9 is not null)
				{
					#region Calculate Rate
					int rate = 0;
					int averageRate = 0;

					if (foundedProductItem9.Comments is not null && foundedProductItem9.Comments.Any())
					{

						foreach (var list in foundedProductItem9.Comments)
						{
							rate += list.Rate;
						}

						averageRate = (rate / foundedProductItem9.Comments.Count);
					}
					else
					{
						averageRate = 1;
					}
					#endregion

					viewModels.Add(item: new ViewModels.Products.ProductViewModel
					{
						ProductId = foundedProductItem9.Id,
						HasDiscount = foundedProductItem9.HasDiscount,
						DiscountedPrice = foundedProductItem9.DiscountedPrice,
						DiscountPercentage = foundedProductItem9.DiscountPercentage,
						Price = foundedProductItem9.Price,
						Rate = averageRate,
						Title = foundedProductItem9.Title,
						ImageProductName = foundedProductItem9.Files?.Where(current => current.IsMainFile.Equals(true)).Select(current => current.Name).FirstOrDefault(),
						Description = foundedProductItem9.Description,
					});
				}
			}

			return View(viewName: "/Views/Products/ProductList.cshtml", model: viewModels);
		}
	}
}
