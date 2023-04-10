namespace DAL
{
    public interface IWishListProductRepository :Base.IRepository<Models.WishListProduct>
    {
        Task<List<ViewModels.ProfileDetails.WishListViewModel>> GetAllAddedToWishListProductsAsync(Guid userId);

        Task<Guid> GetProductWishListAsync(Guid productId, Guid userId);

        Task<bool> IsExsistProductInWishListCurrentUserAsync(Guid userId, Guid productId);
    }
}
