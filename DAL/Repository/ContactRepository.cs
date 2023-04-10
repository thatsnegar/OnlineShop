using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ContactRepository : Repository<Models.Contact>, IContactRepository
    {
        internal ContactRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<Models.Contact>> GetAllContactsAsync()
        {
            var result =
                await DbSet
                .OrderByDescending(current => current.InsertDateTime)
                .ToListAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.Contact> GetContactByIdAsync(Guid id)
        {
            var result =
                await DbSet
                .Where(current => current.Id.Equals(id))
                .FirstOrDefaultAsync()
                ;

            return result!;
        }
        // **************************************************
    }
}
