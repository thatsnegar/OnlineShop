using Microsoft.EntityFrameworkCore;
using Models;
using ViewModels.Comment;
using ViewModels.ProfileDetails;

namespace DAL
{
    public class CommentRepository : Repository<Models.Comment>, ICommentRepository
    {
        internal CommentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<CommentsViewModel>> GetCommentForSpecificProduct(Guid productId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException(paramName: nameof(productId));

            var result =
                    await
                    DbSet
                    .Where(current => current.Isconfirm.Equals(true))
                    .Where(current => current.ProductId.Equals(productId))
                    .Include(current => current.Product)
                    .Include(current => current.User)
                    .Select(item => new ViewModels.Comment.CommentsViewModel
                    {
                        DisLikeNumbers = item.DisLikeNumbers,
                        LikeNumbers = item.LikeNumbers,
                        ProductId = productId,
                        Rate = item.Rate,
                        Text = item.Text,
                        InsertDateTime = item.InsertDateTime,
                        Username = item.User!.Username,
                        UserId = item.UserId,
                        CommentId = item.Id,
                        Isconfirm = item.Isconfirm,
                    })
                    .ToListAsync()
                    ;

            return result;
        }
        // **************************************************

        public async Task<List<UserCommentsViewModel>> GetAllUserCommentsAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(paramName: nameof(userId));

            var result =
               await DbSet
               .Where(current => current.UserId.Equals(userId))
               .Include(current => current.Product)
               .Include(current => current.Product.Files)
               .Select(item => new ViewModels.ProfileDetails.UserCommentsViewModel
               {
                   CommentId = item.Id,
                   UserId = userId,
                   ProductId = item.ProductId,
                   Rate = item.Rate,
                   Text = item.Text,
                   IsConfirm = item.Isconfirm,
                   ProductImage = item.Product!.Files!.Where(current => current.IsMainFile.Equals(true)).FirstOrDefault()!.Name,
               })
               .ToListAsync()
               ;

            return result;
        }
    }
}
