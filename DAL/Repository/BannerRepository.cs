using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BannerRepository : Repository<Models.Banner>, IBannerRepository
    {
        internal BannerRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<Models.Banner>> GetAllBannersAsync()
        {
            var result =
                await DbSet
                .Include(current => current.File)
                .ToListAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.Banner> GetBannerByIdAsync(Guid id)
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
