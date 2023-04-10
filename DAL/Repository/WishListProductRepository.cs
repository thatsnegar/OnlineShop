using Microsoft.EntityFrameworkCore;
using ViewModels.ProfileDetails;

namespace DAL
{
    public class WishListProductRepository : Repository<Models.WishListProduct>, IWishListProductRepository
    {
        internal WishListProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<ViewModels.ProfileDetails.WishListViewModel>> GetAllAddedToWishListProductsAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(paramName: nameof(userId));

            var result =
               await DbSet
               .Where(current => current.UserId.Equals(userId))
               .Include(current => current.Product)
               .Select(item => new ViewModels.ProfileDetails.WishListViewModel
               {
                   ProductId = item.ProductId,
                   DiscountedPrice = item.Product!.DiscountedPrice,
                   DiscountPercentage = item.Product.DiscountPercentage,
                   HasDiscount = item.Product.HasDiscount,
                   ImageProductName =
                    ((item.Product.Files == null) ? "" : item.Product.Files.Where(current => current.IsMainFile.Equals(true)).Select(x => x.Name).First()),
                   Price = item.Product.Price,
                   Rate = item.Product.Rate,
                   Title = item.Product.Title,
               })
               .ToListAsync()
               ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Guid> GetProductWishListAsync(Guid productId, Guid userId)
        {
            if (productId == Guid.Empty)
                throw new ArgumentNullException(paramName: nameof(productId));

            var result =
                await
                DbSet
               .Where(current => current.ProductId.Equals(productId) && current.UserId.Equals(userId))
               .Select(current => current.Id)
               .FirstOrDefaultAsync()
               ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<bool> IsExsistProductInWishListCurrentUserAsync(Guid userId, Guid productId)
        {
            if (userId == Guid.Empty || productId == Guid.Empty)
                throw new ArgumentNullException(paramName: nameof(userId));

            var result =
               await DbSet
               .Where(current => current.UserId.Equals(userId) && current.ProductId.Equals(productId))
               .AnyAsync()
               ;

            return result;
        }
        // **************************************************

    }
}
