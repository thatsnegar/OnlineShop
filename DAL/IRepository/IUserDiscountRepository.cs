using Models;

namespace DAL
{
	public interface IUserDiscountRepository : Base.IRepository<Models.UserDiscount>
	{
		Task<UserDiscount?> GetUserDiscountAsync(Guid discountId, Guid userId);
	}
}
