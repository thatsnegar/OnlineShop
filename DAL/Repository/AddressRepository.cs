using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AddressRepository : Repository<Models.Address>, IAddressRepository
    {
        internal AddressRepository
            (DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public async Task<List<ViewModels.Addresses.IndexViewModel>> GetAllAddressesAsync(System.Guid userId)
        {
            var result =
                  await
                  DbSet
                  .Where(current => current.UserId.Equals(userId))
                  .Select(item => new ViewModels.Addresses.IndexViewModel
                  {
                      Id = item.Id,
                      Country = item.Country,
                      State = item.State,
                      City = item.City,
                      ZipCode = item.ZipCode,
                      UserAddress = item.UserAddress,
                  })
                  .ToListAsync()
                  ;

            return result;
        }

        // **************************************************


        // **************************************************
        public async Task<Address?> GetAddressByIdAsync(Guid id)
        {
            var result =
               await
               DbSet
               .Where(current => current.Id.Equals(id))
               .FirstOrDefaultAsync();

            return result;
        }
        // **************************************************
    }
}
