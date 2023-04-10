namespace DAL
{
    public interface IContactRepository : Base.IRepository<Models.Contact>
    {
        Task<List<Models.Contact>> GetAllContactsAsync();

        Task<Models.Contact> GetContactByIdAsync(System.Guid id);
    }
}
