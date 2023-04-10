using Shared;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class ProductCategoryRepository : Repository<Models.ProductCategory>, IProductCategoryRepository
	{
		internal ProductCategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<Models.ProductCategory>> GetAllProductCategoriesAsync()
		{
			var result =
				 await DbSet
				 .Include(current => current.Products)
				 .Include(current => current.File)
				 .ToListAsync()
				 ;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<Models.ProductCategory> GetProductCategoryByIdAsync(Guid id)
		{
			var result =
				 await DbSet
				 .Where(current => current.Id == id)
				 .Include(current => current.Products)
				 .Include(current => current.File)
				 .FirstOrDefaultAsync()
				 ;

			return result!;
		}
		// **************************************************

		// **************************************************
		public async Task<bool> IsExistProductCategoryAsync(string title)
		{
			if (title is null)
				throw (new System.ArgumentNullException(paramName: nameof(title)));

			var result =
				 await DbSet
				 .Where(current => current.Title.Fix().Equals(title.Fix()))
				 .AnyAsync();
			;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<List<Models.ProductCategory>> GetAllSlidersAsync()
		{
			var result =
				  await DbSet
				  .Where(current => current.HasSlider.Equals(true))
				  .Include(current => current.File)
				  .ToListAsync()
				  ;

			return result;
		}
		// **************************************************
	}
}
