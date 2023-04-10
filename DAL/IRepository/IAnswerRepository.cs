using Models;

namespace DAL
{
    public interface IAnswerRepository : Base.IRepository<Answer>
    {
        // **********
        Task<List<Answer>> GetAllAnswersAsync();
        // **********

        // **********
        Task<Answer> GetAnswerByIdAsync(Guid id);
        // **********

        // **********
        Task<List<Answer>> GetAllAnswerByQuestionIdAsync(Guid questionId);
        // **********

        // **********
        Task<bool> IsExistAnswer(Guid questionId);
        // **********
    }
}
