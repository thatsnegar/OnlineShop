using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class ScientificInfoRepository : Repository<Models.ScientificInfo>, IScientificInfoRepository
	{
		internal ScientificInfoRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<ViewModels.AdminViewModels.ScientificInfo.IndexViewModel>> GetAllScientificInfosAsync()
		{
			var result =
				await DbSet
				.Include(current => current.File)
				.Select(item => new ViewModels.AdminViewModels.ScientificInfo.IndexViewModel
				{
					Id = item.Id,
					InsertDateTime = item.InsertDateTime,
					IsEditted = item.IsEdited,
					Title = item.Title,
					Text = item.Text,
					File = item.File,
					UpdateDateTime = item.UpdateDateTime,
				})
				.ToListAsync()
				;

			return result;
		}
		// **************************************************

		// **************************************************
		public async Task<Models.ScientificInfo> GetScientificInfoByIdAsync(Guid id)
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
	}
}
