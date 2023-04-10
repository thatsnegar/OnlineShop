using Microsoft.AspNetCore.Mvc;
using Models;
using Shared;
using ViewModels.AdminViewModels.Orders;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]

    public class TrackOrdersController : Infrastructure.BaseControllerWithDataBase
    {
        public TrackOrdersController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }

        // **************************************************
        // **************************************************

        #region TrackOrders
        //TrackOrders/GetAllOrders
        public async Task<IActionResult> Index()
        {
            try
            {
                var orderViewModel = new List<OrderViewModel>();

                var foundedOrders =
                    await UnitOfWork.Orders.GetAllOrdersAsync();

                if (foundedOrders.Any())
                {
                    orderViewModel.AddRange(collection: foundedOrders.Select(item => new OrderViewModel
                    {
                        OrderStatus = item.OrderStatus,
                        Description = item.Description,
                        OrderId = item.Id,
                        SendWay = item.SendWay,
                        UserName = item.User!.Username,
                        Address = item.SelectedUserAddress,
                    }));

                    return View(model: orderViewModel);
                }
                else
                    return View(model: orderViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region TrackOrdersDetails
        //TrackOrders/Details
        [HttpGet]
        public async Task<IActionResult> TrackOrders(Guid orderId)
        {
            try
            {
                var foundedOrder = await UnitOfWork.Orders.GetByIdAsync(id: orderId);

                var foundedOrderDetail =
                    await UnitOfWork.OrderDetails.GetOrderDetailsByOrderIdAsync(orderId: foundedOrder!.Id);

                if (foundedOrder is not null)
                {
                    var orderDetailsViewModel = new ViewModels.AdminViewModels.Orders.OrderDetailsViewModel
                    {
                        OrderDetails = foundedOrderDetail,
                        Address = foundedOrder.SelectedUserAddress,
                        UserName = foundedOrder.User?.Username,
                        SendWay = foundedOrder.SendWay,
                        Description = foundedOrder.Description,
                        DiscountText = foundedOrder?.DiscountText,
                        DiscountPercentage = foundedOrder?.DiscountPercentage,
                    };
                    return View(model: orderDetailsViewModel);
                }
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

        // POST: Admin/TrackOrders/ConfirmDeliverOrder
        #region Confirm Being Active
        [HttpPost]
        public async Task<JsonResult> ConfirmDeliverOrder(string id)
        {

            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var foundedOrder =
                    await UnitOfWork.Orders.GetByIdAsync(id: Guid.Parse(input: id));

                if (foundedOrder is not null)
                {
                    foundedOrder.OrderStatus = Domain.Enums.OrderStatus.Delivered;

                    UnitOfWork.Orders.Update(entity: foundedOrder);
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

        // POST: Admin/TrackOrders/ConfirmCanclation
        #region Confirm Being Active
        [HttpPost]
        public async Task<JsonResult> ConfirmCanclation(string id)
        {

            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var foundedOrder =
                    await UnitOfWork.Orders.GetByIdAsync(id: Guid.Parse(input: id));

                if (foundedOrder is not null)
                {
                    foundedOrder.OrderStatus = Domain.Enums.OrderStatus.Cancled;

                    UnitOfWork.Orders.Update(entity: foundedOrder);
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
    }
}
