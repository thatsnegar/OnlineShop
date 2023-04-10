using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class VirtualTourRepository : Repository<Models.VirtualTour>, IVirtualTourRepository
    {
        internal VirtualTourRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<Models.VirtualTour>> GetAllVirtualToursAsync()
        {
            var result =
                 await DbSet
                 .ToListAsync()
                 ;

            return result;
        }

        public async Task<Models.VirtualTour> GetVirtualTourByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Where(current => current.Id.Equals(id))
                .FirstOrDefaultAsync()
                ;

            return result!;
        }
    }
}
