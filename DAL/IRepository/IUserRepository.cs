namespace DAL
{
    public interface IUserRepository : Base.IRepository<Models.User>
    {

        // **********
        Task<List<Models.User>> GetAllUsersAsync();
        // **********

        // **********
        Models.User? GetUserByUsername(string username);
        // **********

        // **********
        Task<Models.User?> GetUserByUsernameAsync(string username);
        // **********

        // **********
        System.Threading.Tasks.Task<Models.User?> GetUserByEmailAddressAsync(string emailAddress);
        // **********

        // **********
        System.Threading.Tasks.Task<Models.User?> GetUserByIdAsync(System.Guid id);
        // **********

        // **********
        System.Threading.Tasks.Task<List<Models.User>?> GetUsersByRoleNameAsync(string roleName);
        // **********

        // **********
        System.Threading.Tasks.Task<Models.User?> GetUserByMENumberAsync(string mENumber);
        // **********

        // **********
        System.Threading.Tasks.Task<Models.User?> GetUserByPhoneNumberAsync(string phoneNumber);
        // **********
    }
}
