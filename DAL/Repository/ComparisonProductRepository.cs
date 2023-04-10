using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public class ComparisonProductRepository : Repository<Models.ComparisonProduct>, IComparisonProductRepository
	{
		internal ComparisonProductRepository(DatabaseContext databaseContext) : base(databaseContext)
		{

		}
		// **************************************************
		public async Task<List<ComparisonProduct>> GetAllComparisonProduct()
		{
			var result =
				await DbSet
				.Include(current => current.Files)
				.ToListAsync()
				;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<ComparisonProduct> GetComparisonProductByIdAsync(Guid id)
		{
			if (id.Equals(Guid.Empty))
				throw (new ArgumentNullException(paramName: nameof(id)));

			var result =
				await DbSet
				.Where(current => current.Id.Equals(id))
				.Include(current => current.Files)
				.FirstOrDefaultAsync()
				;	

			return result!;
		}
		// **************************************************


	}
}
