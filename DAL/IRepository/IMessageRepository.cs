namespace DAL
{
    public interface IMessageRepository : Base.IRepository<Models.Message>
    {
        Task<List<Models.Message>> GetAllMessageAsync();

        Task<List<Models.Message>> GetAllMessageIndexViewAsync();

        Task<Models.Message> GetMessageByIdAsync(System.Guid id);
    }
}
