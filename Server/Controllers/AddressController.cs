using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;
using ViewModels.Addresses;

namespace Server.Controllers
{
    public class AddressController : Infrastructure.BaseControllerWithDatabase
    {
        public AddressController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var foundedCurrentUser = GetCurrentUser();

                if(foundedCurrentUser is null)
                    return Unauthorized();

                var foundedAddresses = 
                    await UnitOfWork.Addresses.GetAllAddressesAsync(userId: foundedCurrentUser.Id);

                //if(TempData["AddAddress"] is not null)
                //{
                //    AddMessage(type: Infrastructure.Messages.MessageType.ToastSuccess, message: "آدرس شما با موفقیت ثبت گردید!");
                //}

                return View(model: foundedAddresses);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get: Address/Create
        #region Create
        [HttpGet]
        public async Task<JsonResult> Create()
        {
            try
            {
                string result = System.String.Empty;

                var foundedCurrentUser = GetCurrentUser();
               
                var foundedAddress =
                    await UnitOfWork.Addresses.GetAllAddressesAsync(userId: foundedCurrentUser.Id);

                if (foundedCurrentUser is null)
                {
                    // Logger
                    return Json(data: Unauthorized());
                }

                result = System.Text.Json.JsonSerializer.Serialize(value: foundedAddress);
                return Json(data: result);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Address/Create
        #region Create
        [HttpPost]
        public async Task<JsonResult> Create(ViewModels.Addresses.CreateAddressViewModel viewModel)
        {
            try
            {
                bool result = false;
                if (!ModelState.IsValid)
                    return Json(data: result);

                var foundedCurrentUser = GetCurrentUser();
                if (foundedCurrentUser is null)
                {
                    // Logger
                    return Json(Unauthorized());
                }

                var addressUser = new Models.Address
                {
                    Country = viewModel.Country,
                    State = viewModel.State,
                    City = viewModel.City,
                    ZipCode = viewModel.ZipCode,
                    UserAddress = viewModel.UserAddress,
                    UserId = foundedCurrentUser.Id,
                };
                await UnitOfWork.Addresses.InsertAsync(entity: addressUser);

                await UnitOfWork.SaveAsync();
                result = true;

                return Json(data: result);
            }
            
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // Get: Address/Edit

        #region Edit
        [HttpGet]
        public async Task<JsonResult> Edit(string id)
        {
            try
            {
                string result = System.String.Empty;

                if (string.IsNullOrEmpty(value: id))
                    return Json(result);

                var foundedCurrentUser = GetCurrentUser();

                if(foundedCurrentUser is null)
                {
                    return Json(data: Unauthorized());
                }
                var foundedAddress =
                     await UnitOfWork.Addresses.GetAddressByIdAsync(id: Guid.Parse(input: id));

                if (foundedAddress != null)
                {
                    var viewModel = new EditAddressViewModel()
                    {
                      Id = foundedAddress.Id,
                      City = foundedAddress.City,
                      Country = foundedAddress.Country,
                      State = foundedAddress.State,
                      UserAddress = foundedAddress.UserAddress ,
                      ZipCode = foundedAddress.ZipCode,
                      UserId = foundedCurrentUser.Id,
                    };

                    result = System.Text.Json.JsonSerializer.Serialize(value: viewModel);

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

        // Post: Address/Edit
        #region Edit
        [HttpPost]
        public async Task<JsonResult> Edit(string id,ViewModels.Addresses.EditAddressViewModel viewModel)
        {
            try
            {
                bool result = false;
                if (!ModelState.IsValid)
                    return Json(data: result);


                var foundedAddress =
                    await UnitOfWork.Addresses.GetByIdAsync(id: Guid.Parse(input: id));

                var foundedCurrentUser = GetCurrentUser();

                if(foundedCurrentUser is null)
                {
                    return Json(data: Unauthorized());
                }

                if (foundedAddress is not null)
                {
                    foundedAddress.Id = viewModel.Id;
                    foundedAddress.Country = viewModel.Country;
                    foundedAddress.State = viewModel.State;
                    foundedAddress.City = viewModel.City;
                    foundedAddress.ZipCode = viewModel.ZipCode;
                    foundedAddress.UserAddress = viewModel.UserAddress;
                    foundedAddress.UserId = foundedCurrentUser.Id;

                    UnitOfWork.Addresses.Update(entity: foundedAddress);

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

        //Post: Address/Delete

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

                var foundedAddess =
                    await UnitOfWork.Addresses.GetByIdAsync(id: guid);

                if (foundedAddess is not null)
                {

                    UnitOfWork.Addresses.Delete(entity: foundedAddess);
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
    }
}
