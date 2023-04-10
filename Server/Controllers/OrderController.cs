using DAL;
using Models;
using Shared;
using Infrastructure;
using ViewModels.Order;
using Microsoft.AspNetCore.Mvc;
using Parbad;
using Parbad.AspNetCore;

namespace Server.Controllers
{
	public class OrderController : BaseControllerWithDatabase
	{


		public OrderController(ILogger<HomeController> logger, IUnitOfwork unitOfwork, IOnlinePayment onlinePayment) : base(unitOfwork)
		{
			Logger = logger;

			OnlinePayment = onlinePayment;
		}

		public ILogger<HomeController> Logger { get; }

		protected IOnlinePayment OnlinePayment { get; }

		// **************************************************
		// **************************************************


		#region Order Details
		[HttpGet]
		public IActionResult OrderDetails()
		{
			var foundedUser =
				  GetCurrentUser();

			ViewData["foundedOnlineUser"] = foundedUser;

			if (foundedUser is not null)
			{
				List<OrderDetail> OrderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail") ?? new List<OrderDetail>();

				OrderDetailsViewModel viewModel = new()
				{
					OrderDetails = OrderDetails,
					Total = OrderDetails.Sum(current => current.Count * current.ProductPrice),
					UserId = foundedUser!.Id,
				};
				return View(model: viewModel);
			}
			else
				return RedirectToAction(controllerName: "Account", actionName: "Login");
		}
		#endregion

		// **************************************************
		// **************************************************

		#region Add To Shopping Cart
		[HttpGet]
		public async Task<IActionResult> AddToShoppingCart(Guid id)
		{
			var foundedProduct =
				 await UnitOfWork.Products.GetProductByIdAsync(id: id);

			if (foundedProduct.IsInStock.Equals(true))
			{
				List<OrderDetail> orderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail") ?? new List<OrderDetail>();

				var orderItem = orderDetails.Where(current => current.ProductId == id).FirstOrDefault();

				if (orderItem is null)
				{
					orderDetails.Add(new OrderDetail(product: foundedProduct));
				}
				else
				{
					orderItem.Count += 1;
				}

				HttpContext.Session.SetJson(key: "OrderDetail", value: orderDetails);

				TempData["Success"] = "The product has been added!";

				return Redirect(Request.Headers["Referer"].ToString());
			}
			else
				AddMessage(type: Infrastructure.Messages.MessageType.ToastError, "موجودی این محصول کافی نیست!");

			return Redirect(Request.Headers["Referer"].ToString());
		}
		#endregion

		// **************************************************
		// **************************************************

		#region Decrease(Test)
		public IActionResult Decrease(Guid id)
		{
			List<OrderDetail> orderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail");

			var orderItem = orderDetails.Where(current => current.ProductId == id).FirstOrDefault();

			if (orderItem!.Count > 1)
			{
				--orderItem.Count;
			}
			else
			{
				orderDetails?.RemoveAll(current => current.ProductId == id);
			}
			if (orderDetails!.Count == 0)
			{
				HttpContext.Session.Remove("OrderDetail");
			}
			else
			{
				HttpContext.Session.SetJson("OrderDetail", orderDetails);
			}
			TempData["Success"] = "حذف محصول با موفقیت انجام شد!";

			return RedirectToAction(controllerName: "Order", actionName: "OrderDetails");
		}
		#endregion

		// **************************************************
		// **************************************************

		#region Remove
		public IActionResult Remove(Guid id)
		{
			List<OrderDetail> orderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail");

			orderDetails.RemoveAll(current => current.ProductId == id);

			if (orderDetails.Count == 0)
			{
				HttpContext.Session.Remove("OrderDetail");
			}
			else
			{
				HttpContext.Session.SetJson("OrderDetail", orderDetails);
			}

			TempData["Success"] = "حذف محصول با موفقیت انجام شد!";

			return RedirectToAction(controllerName: "Order", actionName: "OrderDetails");
		}
		#endregion

		// **************************************************
		// **************************************************

		#region Increase Number Of Products
		[HttpPost]
		public async Task<JsonResult> IncreaseProduct(string productId)
		{
			int result = 1;

			if (string.IsNullOrEmpty(value: productId))
				return Json(data: result);

			var foundedProduct =
				 await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(productId));

			if (foundedProduct is null)
				return Json(data: result);

			List<OrderDetail> orderDetails =
				HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail");

			Models.OrderDetail orderItem =
				orderDetails.Where(current => current.ProductId.Equals(foundedProduct.Id)).FirstOrDefault();


			if (orderDetails is not null)
			{
				TempData["Success"] = "The product has been added!";

				result = orderItem!.Count + 1;

				orderItem.Count += 1;

				HttpContext.Session.SetJson("OrderDetail", orderDetails);

				return Json(data: result);
			}
			else
			{
				// Logger
				orderDetails?.Add(new OrderDetail(product: foundedProduct));

				result = 1;

				return Json(data: result);
			}
		}
		#endregion

		// **************************************************
		// **************************************************

		#region Decrease Number Of Products
		[HttpPost]
		public async Task<JsonResult> DecreaseProduct(string productId)
		{
			int result = 0;

			if (string.IsNullOrEmpty(value: productId))
				return Json(data: result);

			var foundedProduct =
				 await UnitOfWork.Products.GetProductByIdAsync(id: Guid.Parse(productId));

			if (foundedProduct is null)
				return Json(data: result);

			List<OrderDetail> orderDetails =
				HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail");

			Models.OrderDetail orderItem =
				orderDetails.Where(current => current.ProductId.Equals(foundedProduct.Id)).FirstOrDefault();

			if (orderItem is null)
				return Json(data: result);

			if (orderItem.Count <= 1)
			{
				// Message
				result = 1;

				return Json(data: result);
			}
			else
			{
				// Message
				result = orderItem.Count - 1;

				orderItem.Count -= 1;

				HttpContext.Session.SetJson("OrderDetail", orderDetails);

				return Json(data: result);
			}

		}
		#endregion

		// **************************************************
		// **************************************************

		#region Order Submission
		[HttpGet]
		public async Task<IActionResult> OrderSubmission(double discountPercentage)
		{
			var foundedUser =
				 GetCurrentUser();

			ViewData["foundedOnlineUser"] = foundedUser;

			if (foundedUser is not null)
			{
				var foundedAddress =
			  await UnitOfWork.Addresses.GetAllAddressesAsync(userId: foundedUser!.Id);

				List<OrderDetail> OrderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail") ?? new List<OrderDetail>();

				ViewData["Addresses"] = foundedAddress;

				var model = new OrderSubmissionViewModel()
				{
					OrderDetails = OrderDetails,
				};

				return View(model: model);
			}
			else
				return RedirectToAction(controllerName: "Account", actionName: "Login");
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> OrderSubmission(OrderSubmissionViewModel viewModel)
		{
			var foundedUser =
				 GetCurrentUser();

			var getSequenceNumber =
					await UnitOfWork.SequenceNumbers.GetByNameAsync(name: "TracingCode");

			var foundedAddress =
				await UnitOfWork.Addresses.GetByIdAsync(id: viewModel.AddressId);

			Models.Discount? foundedDiscount =
				await UnitOfWork.Discounts.GetCupponePercentByItsNameAsync(discountText: viewModel?.DiscountText);

			ViewData["foundedOnlineUser"] = foundedUser;

			if (foundedUser is not null)
			{
				List<OrderDetail> OrderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail") ??
					new List<OrderDetail>();

				string tracingCode = string.Empty;

				// SequenceNumber => property: number

				var getTime = DateTime.Now;

				var year = getTime.GetShamsiYear();

				tracingCode = $"emni{year}-{getSequenceNumber!.Number}";

				var order = new Order()
				{
					OrderDetails = viewModel?.OrderDetails,
					Description = viewModel?.Description,
					UserId = foundedUser.Id,
					Total = viewModel?.OrderDetails?.Sum(current => current.Count * current.ProductPrice),
					TracingCode = tracingCode,
					OrderStatus = Domain.Enums.OrderStatus.UnderProcess,
					SendWay = viewModel?.SendWay,
					SelectedUserAddress = foundedAddress?.UserAddress,
					DiscountText = viewModel?.DiscountText,
					DiscountPercentage = viewModel?.DiscountPercentage,
				};

				double? totalAmount = 0;

				foreach (var item in OrderDetails)
				{
					var orderDetail = new OrderDetail
					{
						OrderId = order.Id,
						ProductName = item.ProductName,
						Count = item.Count,
						Cupon = item.Cupon,
						ProductId = item.ProductId,
						ProductPrice = item.ProductPrice,
						ProductDiscountPercentage = item.ProductDiscountPercentage,
						ProductDiscountedPrice = item.ProductDiscountedPrice,
						ProductHasDiscount = item.ProductHasDiscount,
						ProductImage = item.ProductImage,
					};

					totalAmount += item.ProductPrice * item.Count;

					await UnitOfWork.OrderDetails.InsertAsync(entity: orderDetail);
				}

				getSequenceNumber.Number += 1;

				if (foundedDiscount is not null)
				{
					var deActiveDiscount =
					await UnitOfWork.UserDiscounts.GetUserDiscountAsync(discountId: foundedDiscount.Id, userId: foundedUser.Id);

					if (deActiveDiscount is not null)
					{
						deActiveDiscount.IsActive = false;

						UnitOfWork.UserDiscounts.Update(entity: deActiveDiscount);
					}
				}

				UnitOfWork.SequenceNumbers.Update(entity: getSequenceNumber);

				//Pay 
				var totalMoney =
					new Money(Convert.ToDecimal(totalAmount));

				var callbackUrl =
				  Url.Action("Verify", "Order", null, Request.Scheme);


				var result = await OnlinePayment.RequestAsync(invoice =>
				{
					invoice
					.SetTrackingNumber(order.TrackingNumber)
					.SetAmount(amount: totalMoney)
					.SetCallbackUrl(callbackUrl: callbackUrl)
					.SetGateway(gatewayName: "ParbadVirtual");
				});

				order.TrackingNumber = result.TrackingNumber;

				order.GenerateTrackingNumberAutomatically = true;

				await UnitOfWork.Orders.InsertAsync(entity: order);

				await UnitOfWork.SaveAsync();

				if (result.IsSucceed)
				{
					return result.GatewayTransporter.TransportToGateway();
				}

				return RedirectToAction(controllerName: "Order", actionName: "OrderDetails");
			}
			else
				return RedirectToAction(controllerName: "Order", actionName: "OrderDetails");
		}
		#endregion

		// **************************************************
		// **************************************************
		public async Task<IActionResult> Verify()
		{
			List<OrderDetail> orderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail");

			HttpContext.Session.Remove("OrderDetail");

			var invoice = await OnlinePayment.FetchAsync();

			if (!IsEverythingOK(invoice.TrackingNumber))
			{
				var cancelResult = await OnlinePayment.CancelAsync(invoice, cancellationReason: "متاسفانه پرداخت با موفقیت انجام نشد!");

				return View("CancelResult", cancelResult);
			}

			var result = await OnlinePayment.VerifyAsync(invoice.TrackingNumber);

			return View(result);
		}

		public bool IsEverythingOK(long trackingNumber)
		{
			return true;
		}
		// **************************************************
		// **************************************************

		#region Get Discount Percentage By Its Name
		[HttpPost]
		public async Task<JsonResult> GetCupponePercentByItsName(string discountText)
		{
			try
			{
				string result = System.String.Empty;

				if (string.IsNullOrEmpty(value: discountText))
					return Json(data: result);

				var foundedUser = GetCurrentUser();

				if (foundedUser is null)
				{
					return Json(data: result);
				}

				var foundedDiscount =
					await UnitOfWork.Discounts.GetCupponePercentByItsNameAsync(discountText: discountText);

				if (foundedDiscount is null)
				{
					AddMessage(Infrastructure.Messages.MessageType.ToastError, "کد تخیف وارد شده صحیح نمی باشد!");

					return Json(data: result);
				}

				var serverDate = DateTime.Now;

				var compareEndDate = DateTime.Compare(t1: foundedDiscount.EndDate, t2: serverDate);

				if (compareEndDate <= 0)
				{
					AddMessage(Infrastructure.Messages.MessageType.ToastError, "زمان استفاده از این کد تخفیف به اتمام رسیده است!");

					return Json(data: result);
				}

				var foundedUserDiscount =
					await UnitOfWork.UserDiscounts.GetUserDiscountAsync(discountId: foundedDiscount.Id, userId: foundedUser.Id);

				if (foundedUserDiscount is not null)
				{
					AddMessage(Infrastructure.Messages.MessageType.ToastError, "کد تخیف وارد شده فاقد اعتبار می باشد!");
				}
				else
				{
					var userDiscountModel = new UserDiscount
					{
						IsActive = true,
						UserId = foundedUser.Id,
						DiscountId = foundedDiscount.Id,
						Text = foundedDiscount.Text,
						DiscountPercentage = foundedDiscount.DiscountPercentage,
					};
				}

				var viewModel = new ViewModels.Order.OrderSubmissionViewModel()
				{
					DiscountPercentage = foundedDiscount.DiscountPercentage,
				};

				result = System.Text.Json.JsonSerializer.Serialize(value: viewModel.DiscountPercentage);

				return Json(data: result);

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

		#region Delete
		// POST: Admin/Order/Delete
		[HttpPost]
		public JsonResult Delete(string id)
		{
			try
			{
				bool result = false;

				List<OrderDetail> orderDetails = HttpContext.Session.GetJson<List<OrderDetail>>("OrderDetail");

				orderDetails.RemoveAll(current => current.ProductId == Guid.Parse(id));

				if (orderDetails.Count == 0)
				{
					HttpContext.Session.Remove("OrderDetail");

					return Json(data: result);
				}
				else
				{
					HttpContext.Session.SetJson("OrderDetail", orderDetails);
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
		// **************************************************
		// **************************************************

	}
}

