using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class SliderRepository : Repository<Models.Slider>, ISliderRepository
	{
		internal SliderRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<Models.Slider>> GetAllSlidersAsync()
		{
			var result =
				await DbSet
				.Include(current => current.File)
				.ToListAsync()
				;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<Models.Slider> GetSliderByIdAsync(Guid id)
		{
			var result =
				await DbSet
				.Where(current => current.Id.Equals(id))
				.Include(current => current.File)
				.FirstOrDefaultAsync();
				;

			return result!;
		}
		// **************************************************
	}
}
