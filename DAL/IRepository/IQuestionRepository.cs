using Models;

namespace DAL
{
    public interface IQuestionRepository : Base.IRepository<Question>
    {
        // **********
        Task<List<Question>> GetAllQuestionsAsync();
        // **********

        // **********
        Task<Question> GetQuestionByIdAsync(Guid id);
        // **********
    }
}
