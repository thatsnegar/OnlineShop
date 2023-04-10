using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class FileRepository : Repository<Models.File>, IFileRepository
    {
        internal FileRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<Models.File> GetFileByNameAsync(string name)
        {
            if (name is not null)
                throw new ArgumentNullException(paramName: nameof(name));

            var result =
                await
                DbSet
                .Where(current => current.Name == name)
                .FirstOrDefaultAsync()
                ;

            return result!;
        }
        // **************************************************
    }
}
