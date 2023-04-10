using DAL;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class WishListForCurrentUserController : BaseControllerWithDatabase
	{
		public WishListForCurrentUserController(ILogger<WishListForCurrentUserController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<WishListForCurrentUserController> Logger { get; }

        // **************************************************
        // **************************************************

        #region WishList
        [HttpGet]
        public async Task<IActionResult> WishListsForCurrentUser()
        {
            try
            {
                var foundedCurrentUser = GetCurrentUser();

                if (foundedCurrentUser is not null)
                {
                    var foundedWishListProducts =
                        await UnitOfWork.WishListProducts.GetAllAddedToWishListProductsAsync(userId: foundedCurrentUser.Id);

                    if (foundedWishListProducts.Any())
                        return View(model: foundedWishListProducts);
                    else
                        return View(model: foundedWishListProducts);
                }
                else
                {
                    // Logger

                    return NotFound();
                }
            }
            catch (Exception e)
            {
                string message =
                    $"message: {e.Message} - Description: {e.InnerException}";

                Logger.LogCritical(message);
                //Logger.LogDebug(exception, "Error while processing request from {Address}", address)
                throw;
            }
        }
        #endregion

        #region Remove From WishList
        [HttpPost]
        public async Task<JsonResult> RemoveFromWishList(string id)
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
                    await UnitOfWork.WishListProducts.GetProductWishListAsync(productId: Guid.Parse(id), userId: foundedCurrentUser.Id);

                if (foundedProduct != Guid.Empty)
                {
                    UnitOfWork.WishListProducts.DeleteById(foundedProduct);
                    await UnitOfWork.SaveAsync();
                    result = true;
                }
                else
                {
                    return Json(data: result);
                }

                return Json(data: result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        // **************************************************
        // **************************************************
    }
}
