using Microsoft.AspNetCore.Mvc;
using ViewModels.AdminViewModels.Comment;
using ViewModels.Comment;

namespace Server.Areas.Admin.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin, Developer")]

    public class ConfirmCommentController : Infrastructure.BaseControllerWithDataBase
    {
        public ConfirmCommentController(DAL.IUnitOfwork unitOfwork) : base(unitOfwork)
        {
        }
        // **************************************************
        // **************************************************

        //Get/Admin/ConfirmComment/GetAll

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var commentViewModel = new List<ViewModels.AdminViewModels.Comment.IndexViewModel>();

                var foundedComment =
                    await UnitOfWork.Comments.GetAllAsync();

                if (foundedComment.Any())
                {
                    commentViewModel.AddRange(collection: foundedComment.Select(item => new IndexViewModel
                    {
                        CommentId = item.Id,
                        ProductId = item.ProductId,
                        Text = item.Text,
                        InsertDateTime = item.InsertDateTime,
                        Isconfirm = item.Isconfirm,
                    }));

                    return View(model: commentViewModel);
                }
                else
                    return View(model: commentViewModel);

            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
        #endregion

        // POST: Admin/ConfirmComment/ConfirmCommentToShow
        #region confirmShowIndex
        [HttpPost]
        public async Task<JsonResult> ConfirmCommentToShow(string id)
        {
            try
            {
                bool result = false;

                if (string.IsNullOrEmpty(value: id))
                    return Json(data: result);

                var guid = Guid.Parse(input: id);

                var foundedComment =
                    await UnitOfWork.Comments.GetByIdAsync(id: guid);

                if (foundedComment is not null)
                {
                    if (foundedComment.Isconfirm == false)
                        foundedComment.Isconfirm = true;

                    else
                        foundedComment.Isconfirm = false;

                    UnitOfWork.Comments.Update(entity: foundedComment);
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


        // POST: Admin/ConfirmComment/Delete
        #region Delete
        [HttpPost]
        public async Task<JsonResult> Delete(string id)
        {
            try
            {
                bool result = false;

                var foundedComment =
                    await UnitOfWork.Comments.GetByIdAsync(id: Guid.Parse(id));

                if (foundedComment is not null)
                {
                    UnitOfWork.Comments.Delete(entity: foundedComment);

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
    }
}
