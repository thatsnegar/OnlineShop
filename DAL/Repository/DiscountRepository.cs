using Microsoft.EntityFrameworkCore;
using Models;
using Shared;
using ViewModels.AdminViewModels.Discounts;

namespace DAL
{
	public class DiscountRepository : Repository<Models.Discount>, IDiscountRepository
	{
		internal DiscountRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<IndexViewModel>> GetAllDiscountsAsync()
		{
			var result =
				await DbSet
				.Select(item => new ViewModels.AdminViewModels.Discounts.IndexViewModel
				{
					Id = item.Id,
					InsertDateTime = item.InsertDateTime,
					IsActive = item.IsActive,
					IsEditted = item.IsEdited,
					Title = item.Title,
					UpdateDateTime = item.UpdateDateTime,
				})
				.ToListAsync()
				;

			return result;
		}

		// **************************************************

		// **************************************************
		public async Task<Discount> GetDiscountByIdAsync(Guid id)
		{
			var result =
				await DbSet
				.Where(current => current.Id.Equals(id))
				.FirstOrDefaultAsync()
				;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<Discount?> GetCupponePercentByItsNameAsync(string? discountText)
		{
			var result =
				await DbSet
				.Where(current => current.IsActive.Equals(true))
				.Where(current => current.Text!.Equals(discountText))
				.FirstOrDefaultAsync()
				;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<Discount> GetDiscountInTiemRegisterAsync(Guid userId)
		{
			var result =
				await DbSet
				.Where(current => current.IsActive.Equals(true) && current.IsTimeRegister.Equals(true))
				.Where(current => current.UserId.Equals(userId))
				.Include(current => current.User)
				.FirstOrDefaultAsync()
				;

			return result;
		}
		// **************************************************
	}
}
