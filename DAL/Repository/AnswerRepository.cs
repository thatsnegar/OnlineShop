using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class AnswerRepository : Repository<Models.Answer>, IAnswerRepository
	{
		internal AnswerRepository(DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		// **************************************************
		public async Task<List<Answer>> GetAllAnswersAsync()
		{
			var result =
				  await DbSet
				  .OrderBy(current => current.DisplayOrder)
				  .ToListAsync()
				  ;

			return result;
		}

		// **************************************************
		public async Task<Answer> GetAnswerByIdAsync(Guid id)
		{
			var result =
				 await DbSet
				 .Where(current => current.Id == id)
				 .FirstOrDefaultAsync()
				 ;

			return result!;
		}
		// **************************************************

		// **************************************************

		public async Task<List<Answer>> GetAllAnswerByQuestionIdAsync(Guid questionId)
		{
			var result =
				 await DbSet
				 .Where(current => current.QuestionId == questionId)
				 .OrderBy(current => current.DisplayOrder)
				 .ToListAsync()
				 ;

			return result!;
		}
		// **************************************************

		// **************************************************
		public async Task<bool> IsExistAnswer(Guid questionId)
		{
			var result =
				 await DbSet
				 .Where(current => current.QuestionId.Equals(questionId))
				 .FirstOrDefaultAsync()
				 ;

			if (result is null)
				return true;
			else
				return false;
		}
		// **************************************************
	}
}
