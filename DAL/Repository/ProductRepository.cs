using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ProductRepository : Repository<Models.Product>, IProductRepository
    {
        internal ProductRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }


        // **************************************************
        public async Task<List<Models.Product>> GetAllProductsAsync()
        {
            var result =
                 await DbSet
                 .Include(current => current.ProductCategory)
                 .Include(current => current.Files)
                 .Include(current => current.Comments)
                 .ToListAsync()
                 ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.Product> GetProductByIdAsync(Guid id)
        {
            if (id.Equals(Guid.Empty))
                throw (new System.ArgumentNullException(paramName: nameof(id)));

            var result =
                 await DbSet
                 .Where(current => current.Id.Equals(id))
                 .Include(current => current.ProductCategory)
                 .Include(current => current.Files)
                 .Include(current => current.Comments)
                 .FirstOrDefaultAsync()
                 ;

            return result!;
        }
        // **************************************************

        // **************************************************
        public async Task<List<Models.Product>> GetProductByProductCategoryIdAsync(Guid id)
        {
            var result =
                 await DbSet
                 .Where(current => current.ProductCategoryId == id)
                 .Include(current => current.ProductCategory)
                 .Include(current => current.Files)
                 .ToListAsync()
                 ;

            return result!;
        }
        // ************************************************** 

        // **************************************************
        public async Task<List<Models.Product>> GetAllHasCompariosonProductsAsync()
        {
            var result =
                 await DbSet
                 .Where(current => current.HasComparison.Equals(true))
                 .Include(current => current.ProductCategory)
                 .Include(current => current.Files)
                 .ToListAsync()
                 ;

            return result;
        }

        // **************************************************

        // **************************************************
        public async Task<List<Product>> GetAllShowIndexProductsAsync()
        {
            var result =
                 await DbSet
                 .Where(current => current.ShowInIndex.Equals(true))
                 .Include(current => current.Files)
                 .Include(current => current.Comments)
                 .ToListAsync()
                 ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<List<Product>> GetAllAddedToWishListProductsAsync()
        {
            var result =
                await DbSet
                .Where(current => current.AddedToWishList.Equals(true))
                .Include(current => current.WishListProducts)
                .Include(current => current.Files)
                .ToListAsync()
                ;

            return result;
        }

        // **************************************************


    }
}
