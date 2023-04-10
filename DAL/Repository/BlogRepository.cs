using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class BlogRepository : Repository<Models.Blog>, IBlogRepository
    {
        internal BlogRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<Models.Blog>> GetAllBlogsAsync()
        {
            var result =
                await DbSet
                .Include(current => current.File)
                .ToListAsync()
                ;

            return result;
        }

        // **************************************************
        public async Task<List<Blog>> GetAllBlogsIndexViewAsync()
		{
            var result =
                await DbSet
                .Where(current => current.ShowInIndex.Equals(true))
                .Include(current => current.File)
                .ToListAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.Blog> GetBlogByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Where(current => current.Id.Equals(id))
                .Include(current => current.File)
                .FirstOrDefaultAsync()
                ;

            return result!;
        }
        // **************************************************
    }
}
