using Models;

namespace DAL
{
	public interface IProductCategoryRepository : Base.IRepository<ProductCategory>
	{
		// **********
		Task<List<ProductCategory>> GetAllProductCategoriesAsync();
		// **********

		// **********
		Task<ProductCategory> GetProductCategoryByIdAsync(Guid id);
		// **********

		// **********
		Task<bool> IsExistProductCategoryAsync(string title);
		// **********

		// **********
		Task<List<ProductCategory>> GetAllSlidersAsync();
		// **********
	}
}
