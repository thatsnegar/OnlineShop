using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public class UserDiscountRepository : Repository<Models.UserDiscount>, IUserDiscountRepository
	{
		internal UserDiscountRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
			
		}

		// **************************************************
		public async Task<UserDiscount?> GetUserDiscountAsync(Guid discountId, Guid userId)
		{
			var result =
				await DbSet
				.Where(current => current.IsActive.Equals(true))
				.Where(current => current.UserId.Equals(userId) && current.DiscountId.Equals(discountId))
				.FirstOrDefaultAsync()
				;

			return result;
		}
		// **************************************************
	}
}
