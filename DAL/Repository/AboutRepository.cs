using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class AboutRepository : Repository<Models.About>, IAboutRepository
	{
		internal AboutRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<ViewModels.AdminViewModels.Abouts.IndexViewModel>> GetAllAboutsAsync()
		{
			var result =
				await DbSet
				.Include(current => current.File)
				.Select(item => new ViewModels.AdminViewModels.Abouts.IndexViewModel
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
		public async Task<Models.About> GetAboutByIdAsync(Guid id)
		{
			var result =
				await DbSet
				.Where(current => current.Id.Equals(id))
				.Include(current => current.File)
				.FirstOrDefaultAsync()
				;

			return result!;
		}
		// **************************************************

		// **************************************************
		public async Task<About> GetActiveAboutAsync(System.Guid id)
		{
			var result =
				await DbSet
				.Where(current => current.IsActive.Equals(true))
				.Include(current => current.File)
				.FirstOrDefaultAsync()
				;

			return result!;
		}
		// **************************************************

	}
}
