using Models;
using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Messages;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class MessagesController : Infrastructure.BaseControllerWithDataBase
    {
        public MessagesController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }

        // **************************************************
        // **************************************************

        // GET: Admin/Message
        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var indexViewModel = new List<IndexViewModel>();

                var foundedMessages =
                    await UnitOfWork.Messages.GetAllMessageAsync();

                if (foundedMessages.Any())
                {
                    indexViewModel.AddRange(collection: foundedMessages.Select(item => new IndexViewModel
                    {
                        Id = item.Id,
                        Title = item.Title,
                        IsShow = item.IsShow,   
                    }));

                    return View(model: indexViewModel);
                }
                else
                    return View(model: indexViewModel);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // GET: Admin/Message/Create
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/Messages/Create
        #region Messages
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (viewModel.Text is null)
                    {
                        ModelState.AddModelError(key: nameof(viewModel.Text), errorMessage: "وارد کردن متن پیام اجباری می باشد.");
                    }

                    return View(model: viewModel);
                }

                var model = new Message
                {
                    Title = viewModel.Title,
                    Text = viewModel.Text,
                    Summary = viewModel.Summary,
                    IsShow=viewModel.IsShow,    
                };

                await UnitOfWork.Messages.InsertAsync(entity: model);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Messages");

            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

       // GET: Admin/Messages/Edit
        #region Edit
       [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var foundedMessage =
                    await UnitOfWork.Messages.GetMessageByIdAsync(id: id);

                if (foundedMessage is null)
                {
                    // Logger
                    return NotFound();
                }

                var viewModel = new ViewModels.AdminViewModels.Messages.EditViewModel
                {
                    Id = foundedMessage.Id,
                    Title = foundedMessage.Title,
                    Text = foundedMessage.Text,
                    Summary = foundedMessage.Summary,
                };

                return View(model: viewModel);
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

       // POST: Admin/‌Messages/Edit
        #region Edit
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model: viewModel);

                var foundedMessage =
                    await UnitOfWork.Messages.GetMessageByIdAsync(id: viewModel.Id);

                if (foundedMessage is null)
                    return View(model: viewModel);


                //Update Message
                foundedMessage.Title = viewModel.Title;
                foundedMessage.Text = viewModel.Text;
                foundedMessage.Summary = viewModel.Summary;

                UnitOfWork.Messages.Update(entity: foundedMessage);

                await UnitOfWork.SaveAsync();

                return RedirectToAction(actionName: "Index", controllerName: "Messages");
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

       // POST: Admin/Messages/Delete
        #region Delete
       [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                var foundedMessage =
                    await UnitOfWork.Messages.GetMessageByIdAsync(id: Guid.Parse(id));

                if (foundedMessage is not null)
                {

                    UnitOfWork.Messages.Delete(entity: foundedMessage);

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
                //Logger
                throw;
            }
        }
        #endregion

        //POST: Admin/Products/ConfirmShowInIndex
        #region confirmIsShow
       [HttpPost]
        public async Task<JsonResult> ConfirmShowMessage(string id)
        {
            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var guid = Guid.Parse(input: id);

                var foundedMessage =
                    await UnitOfWork.Messages.GetByIdAsync(id: guid);

                if (foundedMessage is not null)
                {
                    if (foundedMessage.IsShow == false)
                        foundedMessage.IsShow = true;

                    else
                        foundedMessage.IsShow = false;

                    UnitOfWork.Messages.Update(entity: foundedMessage);
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
