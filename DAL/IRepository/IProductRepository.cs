namespace DAL
{
    public interface IProductRepository : Base.IRepository<Models.Product>
    {
        Task<List<Models.Product>> GetAllProductsAsync();

        Task<Models.Product> GetProductByIdAsync(Guid id);

        Task<List<Models.Product>> GetProductByProductCategoryIdAsync(Guid id);

        Task<List<Models.Product>> GetAllHasCompariosonProductsAsync();

        Task<List<Models.Product>> GetAllShowIndexProductsAsync();

        Task<List<Models.Product>> GetAllAddedToWishListProductsAsync();


    }
}
