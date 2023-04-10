using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
	public class SequenceNumberRepository : Repository<Models.SequenceNumber>, ISequenceNumberRepository
	{
		protected internal SequenceNumberRepository
			(DatabaseContext databaseContext) : base(databaseContext: databaseContext)
		{
		}

		// **************************************************
		public SequenceNumber? GetByName(string name = "TracingCode")
		{
			var result =
				DbSet
				.Where(current => current.Name == name)
				.FirstOrDefault()
				;

			return result;
		}

		// **************************************************
		public async Task<Models.SequenceNumber?> GetByNameAsync(string name = "TracingCode")
		{
			var result =
				await
				DbSet
				.Where(current => current.Name == name)
				.FirstOrDefaultAsync()
				;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<Models.SequenceNumber?> GetByNamForRegisterDiscountAsync(string name = "RegisterDiscount")
		{
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
