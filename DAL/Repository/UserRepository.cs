using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public class UserRepository : Repository<Models.User>, IUserRepository
    {
        internal UserRepository
            (DatabaseContext databaseContext) : base(databaseContext: databaseContext)
        {
        }

        // **************************************************
        public async Task<List<Models.User>> GetAllUsersAsync()
        {
            var result =
                await
                DbSet
                .Where(current => current.IsActive.Equals(true))
                .Include(current => current.Role)
                .Include(current => current.File)
                .ToListAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public Models.User? GetUserByUsername(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                return null;

            var result =
                DbSet
                .Where(current => current.Username == emailAddress)
                .Where(current => current.IsActive.Equals(true))
                .Include(current => current.Role)
                .Include(current => current.File)
                .FirstOrDefault()
                ;

            return result;
        }

        public async Task<Models.User?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return null;

            var result =
                await
                DbSet
                .Where(current => current.Username == username)
                .Where(current => current.IsActive.Equals(true))
                .Include(current => current.Role)
                .Include(current => current.File)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************


        // **************************************************
        public async Task<Models.User?> GetUserByEmailAddressAsync(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(value: emailAddress))
                return null;

            var result =
                await
                DbSet
                .Where(current => current.EmailAddress!.ToLower() == emailAddress.ToLower())
                .Where(current => current.IsActive.Equals(true))
                .Include(current => current.Role)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<User?> GetUserByMENumberAsync(string mENumber)
        {
            var result =
                await
                DbSet
                .Where(current => current.MENumber.Equals(mENumber))
                .Where(current => current.IsActive.Equals(true))
                .Include(current => current.Role)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.User?> GetUserByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return null;

            var result =
                await
                DbSet
                .Where(current => current.Id.Equals(id))
                .Where(current => current.IsActive.Equals(true))
                .Include(current => current.Role)
                .Include(current => current.File)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<List<Models.User>?> GetUsersByRoleNameAsync(string roleName)
        {
            if (string.IsNullOrEmpty(value: roleName))
                return null;

            var result =
                await
                DbSet
                .Where(current => current.IsActive.Equals(true))
                .Where(current => current.Role!.Name == roleName)
                .ToListAsync();

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            var result =
                await
                DbSet
                .Where(current => current.PhoneNumber!.Equals(phoneNumber) && current.IsActive.Equals(true))
                .Include(current => current.Role)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************
    }
}
