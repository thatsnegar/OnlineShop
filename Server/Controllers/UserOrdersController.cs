using DAL;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    public class UserOrdersController : BaseControllerWithDatabase
    {

        public UserOrdersController(ILogger<UserOrdersController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
        {
            Logger = logger;
        }

        public ILogger<UserOrdersController> Logger { get; }

        // **************************************************
        // **************************************************

        #region UserOrders
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var foundedCurrentUser = GetCurrentUser();

                var viewModels = new List<ViewModels.Order.UserOrdersViewModel>();

                if (foundedCurrentUser is not null)
                {
                    var foundedOrder = await UnitOfWork.Orders.GetAllUserOrdersAsync(userId: foundedCurrentUser.Id);

                    viewModels.AddRange(collection: foundedOrder.Select(item => new ViewModels.Order.UserOrdersViewModel
                    {
                        OrderDetails = item.OrderDetails?.ToList(),
                        TracingCode = item.TracingCode,
                        OrderStatus = item.OrderStatus,
                        InsertDateTime = item.InsertDateTime,
                        DiscountPercentage = item.DiscountPercentage,
                        DiscountText = item.DiscountText,
                    }));

                    return View(model: viewModels);
                }
                else
                    return View(model: viewModels);
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
