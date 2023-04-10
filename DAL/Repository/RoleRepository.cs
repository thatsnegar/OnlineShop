using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class RoleRepository : Repository<Models.Role>, IRoleRepository
	{
		internal RoleRepository
			(DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

        // **************************************************
        public async Task<List<Models.Role>> GetAllRolesAsync()
        {
            var result =
                await
                DbSet
                .OrderByDescending(current => current.InsertDateTime)
                .ToListAsync();

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.Role?> GetRoleByIdAsync(Guid id)
        {
            var result =
                await
                DbSet
                .Where(current => current.Id.Equals(id))
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<Models.Role?> GetRoleByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var result =
                await
                DbSet
                .Where(current => current.Name == name)
                .FirstOrDefaultAsync()
                ;

            return result;
        }
        // **************************************************
    }
}
