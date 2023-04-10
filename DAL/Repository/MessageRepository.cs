using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class MessageRepository : Repository<Models.Message>, IMessageRepository
    {
        internal MessageRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<Message>> GetAllMessageAsync()
        {
            var result =
                await DbSet
                .ToListAsync()
                ;

            return result;
        }

        public async Task<List<Message>> GetAllMessageIndexViewAsync()
        {
            var result =
                await DbSet
                .Where(current => current.IsShow.Equals(true))
                .ToListAsync()
                ;

            return result;
        }

        public async Task<Message> GetMessageByIdAsync(Guid id)
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
