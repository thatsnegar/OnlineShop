namespace DAL
{
    public interface IAddressRepository : Base.IRepository<Models.Address>
    {
        // **********
        Task<List<ViewModels.Addresses.IndexViewModel>> GetAllAddressesAsync(System.Guid userId);
       //  **********

        // **********
        Task<Models.Address?> GetAddressByIdAsync(System.Guid id);  
        // **********
    }
}
