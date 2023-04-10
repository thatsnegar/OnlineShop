using DAL;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
	public class CommentsForCurrentUserController : BaseControllerWithDatabase
	{
		public CommentsForCurrentUserController(ILogger<CommentsForCurrentUserController> logger, IUnitOfwork unitOfwork) : base(unitOfwork)
		{
			Logger = logger;
		}

		public ILogger<CommentsForCurrentUserController> Logger { get; }

        // **************************************************
        // **************************************************


        // **************************************************
        // **************************************************

        #region Comments
        [HttpGet]
        public async Task<IActionResult> Comments()
        {
            try
            {
                var foundedCurrentUser = GetCurrentUser();

                if (foundedCurrentUser is not null)
                {

                    var foundedUsersComment =
                        await UnitOfWork.Comments.GetAllUserCommentsAsync(userId: foundedCurrentUser.Id);

                    if (foundedUsersComment.Any())
                        return View(model: foundedUsersComment);
                    else
                        return View(model: foundedUsersComment);
                }
                else
                {
                    //Logger
                    return NotFound();
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
