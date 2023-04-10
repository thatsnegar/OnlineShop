namespace DAL
{
    public interface IFileRepository : Base.IRepository<Models.File>
    {
        Task<Models.File> GetFileByNameAsync(string name);
    }
}
 