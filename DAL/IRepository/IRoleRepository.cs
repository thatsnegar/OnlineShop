namespace DAL
{
	public interface IRoleRepository : Base.IRepository<Models.Role>
	{
		// **********
		System.Threading.Tasks.Task<List<Models.Role>> GetAllRolesAsync();
		// **********

		// **********
		System.Threading.Tasks.Task<Models.Role?> GetRoleByIdAsync(Guid id);
		// **********

		// **********
		System.Threading.Tasks.Task<Models.Role?> GetRoleByNameAsync(string name);
		// **********
	}
}
