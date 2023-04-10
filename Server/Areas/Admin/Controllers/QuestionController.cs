using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels.AdminViewModels.Questions;

namespace Server.Areas.Admin.Controllers
{
	[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

	public class QuestionController : Infrastructure.BaseControllerWithDataBase
	{
		public QuestionController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
		{
		}

		// GET: Admin/Question
		#region Index
		public async Task<IActionResult> Index()

		{
			try
			{
				var indexViewModels = new List<IndexViewModel>();

				var foundedQuestion =
					await UnitOfWork.Questions.GetAllQuestionsAsync();

				if (foundedQuestion.Any())
				{
					indexViewModels.AddRange(foundedQuestion.Select(item => new IndexViewModel()
					{
						Id = item.Id,
						IsEditted = item.IsEdited,
						InsertDateTime = item.InsertDateTime,
						UpdateDateTime = item.UpdateDateTime,
						QuestionTitle = item.Title,
						DisplayOrder = item.DisplayOrder,
					}));

					var foundedProductCategories =
						await UnitOfWork.ProductCategories.GetAllAsync();

					ViewBag.ProductCategories =
						new SelectList(items: foundedProductCategories, dataValueField: "Id", dataTextField: "Title", selectedValue: null);

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
				//Logger
				throw;
			}
		}
		#endregion

		// GET: Admin/Question/Create
		#region Create
		[HttpGet]
		public IActionResult Create()
		{
			try
			{
				var createViewModel =
					new ViewModels.AdminViewModels.Questions.CreateViewModel();

				return View(model: createViewModel);
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// POST: Admin/Question/Create
		#region Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateViewModel viewModel)
		{
			try
			{
				if (!ModelState.IsValid)
					return View(model: viewModel);

				// Insert Consultation
				var model = new Models.Question
				{
					DisplayOrder = viewModel.DisplayOrder,
					Title = viewModel.Title,
					Text = viewModel.Text,
				};

				await UnitOfWork.Questions.InsertAsync(entity: model);

				await UnitOfWork.SaveAsync();

				return RedirectToAction(actionName: "Index", controllerName: "Question");
			}
			catch (Exception)
			{
				//Logger
				throw;
			}
		}
		#endregion

		// Get: Admin/Question/Edit
		#region Edit
		[HttpGet]
		public async Task<ActionResult> Edit(string id)
		{
			try
			{
				var foundedQuestions =
					await UnitOfWork.Questions.GetQuestionByIdAsync(id: Guid.Parse(input: id));

				if (foundedQuestions is not null)
				{
					var viewModel = new EditViewModel()
					{
						Id = foundedQuestions.Id,
						DisplayOrder = foundedQuestions.DisplayOrder,
						Title = foundedQuestions.Title,
						Text = foundedQuestions.Text,
					};

					return View(model: viewModel);
				}
				else
				{
					var viewModel = new EditViewModel();

					return View(model: viewModel);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		#endregion

		// POST: Admin/Question/Edit
		#region Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(EditViewModel viewModel)
		{
			try
			{
				var foundedQuestion =
					await UnitOfWork.Questions.GetByIdAsync(id: viewModel.Id);

				if (foundedQuestion is not null)
				{
					foundedQuestion.DisplayOrder = viewModel.DisplayOrder;
					foundedQuestion.Title = viewModel.Title;
					foundedQuestion.Text = viewModel.Text;

					UnitOfWork.Questions.Update(entity: foundedQuestion);

					await UnitOfWork.SaveAsync();

					return RedirectToAction(actionName: "Index", controllerName: "Question");
				}
				else
				{
					return RedirectToAction(actionName: "Index", controllerName: "Question");
				}
			}
			catch (Exception)
			{
				//Log
				throw;
			}
		}
		#endregion

		// POST: Admin/Question/Delete
		#region Delete
		[HttpPost]
		public async Task<JsonResult> Delete(string id)
		{
			try
			{
				bool result = false;

				if (string.IsNullOrEmpty(value: id))
					return Json(data: result);

				var foundedQuestion = await UnitOfWork.Questions.GetByIdAsync(id: Guid.Parse(input: id));

				if (foundedQuestion is not null)
				{
					UnitOfWork.Questions.Delete(entity: foundedQuestion);

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

				throw;
			}
		}
		#endregion

		// POST: Admin/Question/GetAllProductsByProductCategoryId
		#region GetAllProductsByProductCategoryId
		[HttpPost]
		public async Task<JsonResult> GetAllProductsByProductCategoryId(string productCategoryId)
		{
			try
			{
				string result = System.String.Empty;

				if (string.IsNullOrEmpty(value: productCategoryId))
					return Json(data: result);

				var foundedProducts =
					await
					UnitOfWork
					.Products
					.GetProductByProductCategoryIdAsync(id: Guid.Parse(input: productCategoryId))
					;

				if (foundedProducts is not null && foundedProducts.Any())
				{
					var viewModels = new List<ViewModels.AdminViewModels.Products.ProductViewModel>();

					viewModels.AddRange(collection: foundedProducts.Select(item => new ViewModels.AdminViewModels.Products.ProductViewModel
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

		// POST: Answer/Create
		#region Create
		[HttpPost]
		public async Task<JsonResult> SaveAnswerResult(Guid questionId, Guid? productId, string answerText, int displayOrder)
		{
			try
			{
				bool result = false;

				if (!productId.HasValue)
				{
					var answerCurrent = new Models.Answer
					{
						QuestionId = questionId,
						Text = answerText,
						ProductId = productId,
						DisplayOrder = displayOrder
					};

					await UnitOfWork.Answers.InsertAsync(entity: answerCurrent);

					await UnitOfWork.SaveAsync();

					result = true;

					return Json(data: result);
				}
				else
				{
					var foundedProduct =
						await UnitOfWork.Products.GetProductByIdAsync(id: productId.Value);

					var foundedAnswer =
						await UnitOfWork.Answers.GetAllAnswerByQuestionIdAsync(questionId: questionId);

					//if (foundedAnswer is null)
					//	return Json(data: result);

					var answerCurrent = new Models.Answer
					{
						QuestionId = questionId,
						Text = answerText,
						ProductId = productId,
						DisplayOrder = displayOrder,
					};

					await UnitOfWork.Answers.InsertAsync(entity: answerCurrent);

					await UnitOfWork.SaveAsync();

					result = true;

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

		// POST: Admin/Question/ShowAnswersList
		#region ShowAnswersList
		[HttpPost]
		public async Task<JsonResult> ShowAnswersList(Guid questionId)
		{
			try
			{
				string result = System.String.Empty;

				var foundedQuestion =
					await UnitOfWork.Questions.GetQuestionByIdAsync(id: questionId);

				var foundedProductCategories =
					await UnitOfWork.ProductCategories.GetAllAsync();

				ViewBag.ProductCategories =
					new SelectList(items: foundedProductCategories, dataValueField: "Id", dataTextField: "Title", selectedValue: null);


				if (foundedQuestion is null)
					return Json(data: result);
				else
				{
					var viewModels = new List<ViewModels.AdminViewModels.Questions.QuestionViewModel>();

					if(foundedQuestion.Answers is not null && foundedQuestion.Answers.Any())
					{
						foreach (var item in foundedQuestion.Answers)
						{
							var viewModel = new QuestionViewModel
							{
								QuestionId = foundedQuestion.Id,
								AnswerId = item.Id,
								ProductTitle = (item.Product?.Title is not null) ? item.Product.Title : "بدون محصول",
								AnswerText = item.Text,
								ProductCategoryId = item?.Product?.ProductCategoryId,
								ProductCategoryTitle = item?.Product?.Title,
								DisplayOrder = item.DisplayOrder,
							};

							viewModels.Add(item: viewModel);
						};


						result =
							System.Text.Json.JsonSerializer.Serialize(value: viewModels.OrderBy(current => current.DisplayOrder));

						return Json(data: result);
					}
					else
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

		// POST: Admin/Question/DeleteAnswer
		#region DeleteAnswer
		[HttpPost]
		public async Task<JsonResult> DeleteAnswer(Guid answerId, Guid questionId)
		{
			try
			{
				string result = System.String.Empty;

				var foundedAnswer = await UnitOfWork.Answers.GetByIdAsync(id: answerId);

				if (foundedAnswer is not null)
				{
					UnitOfWork.Answers.Delete(entity: foundedAnswer);

					await UnitOfWork.SaveAsync();
				}

				var foundedQuestion =
					await UnitOfWork.Questions.GetQuestionByIdAsync(id: questionId);

				if (foundedQuestion is null)
					return Json(data: result);
				else
				{
					var viewModels = new List<ViewModels.AdminViewModels.Questions.QuestionViewModel>();

					if (foundedQuestion.Answers is not null && foundedQuestion.Answers.Any())
					{
						foreach (var item in foundedQuestion.Answers)
						{
							var viewModel = new QuestionViewModel
							{
								QuestionId = foundedQuestion.Id,
								AnswerId = item.Id,
								ProductTitle = item.Product?.Title,
								AnswerText = item.Text,
								DisplayOrder = item.DisplayOrder,
							};

							viewModels.Add(item: viewModel);
						};


						result =
							System.Text.Json.JsonSerializer.Serialize(value: viewModels);

						return Json(data: result);
					}
					else
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
