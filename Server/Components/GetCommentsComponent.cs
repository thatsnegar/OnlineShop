using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Server.Components
{
    public class GetCommentsComponent : ViewComponent
    {
        private const string CommentViewName = "~/Views/Comment/Index.cshtml";

        public GetCommentsComponent(IUnitOfwork unitOfWork) : base()
        {
            UnitOfWork = unitOfWork;
        }
        protected DAL.IUnitOfwork UnitOfWork { get; }

        // **************************************************
        // **************************************************

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            try
            {
                    var foundedComments =
                    await UnitOfWork.Comments.GetCommentForSpecificProduct(productId: productId);

                if (foundedComments.Any())
                    return View(viewName: CommentViewName, model: foundedComments);
                else
                {
                    ViewData["NullMessage"] = "No Comment";
                    return View(viewName: CommentViewName, model: foundedComments);
                }
            }
            catch (Exception)
            {
                //Logger
                throw;
            }
        }
    }
}
