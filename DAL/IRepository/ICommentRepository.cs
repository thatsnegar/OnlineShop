namespace DAL
{
    public interface ICommentRepository : Base.IRepository<Models.Comment>
    {

        Task<List<ViewModels.Comment.CommentsViewModel>> GetCommentForSpecificProduct(Guid productId);

        Task<List<ViewModels.ProfileDetails.UserCommentsViewModel>> GetAllUserCommentsAsync(Guid userId);

    }
}
