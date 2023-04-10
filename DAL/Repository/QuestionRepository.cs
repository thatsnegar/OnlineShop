using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class QuestionRepository : Repository<Models.Question>, IQuestionRepository
	{
		internal QuestionRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<Question>> GetAllQuestionsAsync()
		{
			var result =
				  await DbSet
				  .Include(current => current.Answers!)
				  .ThenInclude(current => current.Product)
				  .OrderBy(current => current.DisplayOrder)
				  .ToListAsync()
				  ;

			return result;
		}

		// **************************************************
		public async Task<Question> GetQuestionByIdAsync(Guid id)
		{
			var result =
				 await DbSet
				 .Where(current => current.Id == id)
				 .Include(current => current.Answers!)
				 .ThenInclude(current => current.Product)
				 .FirstOrDefaultAsync()
				 ;

			return result!;
		}
		// **************************************************
	}
}
