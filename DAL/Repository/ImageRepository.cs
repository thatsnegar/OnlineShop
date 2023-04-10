using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class ImageRepository : Repository<Models.Image>, IImageRepository
    {
        internal ImageRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<Image>> GetAllImagesAsync()
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
        public async Task<Image> GetImageByIdAsync(Guid id)
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

        // **************************************************
        public async Task<Models.Image> GetImageByImageTitleAsync(string imageTitle)
        {
            if (imageTitle is null)
                return null;

            var result =
                 await DbSet
                 .Where(current => current.ImageTitle!.Equals(imageTitle))
                 .Include(current => current.File)
                 .FirstOrDefaultAsync()
                 ;

            return result!;
        }
        // **************************************************
    }
}
