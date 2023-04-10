namespace DAL
{
    public interface IBlogRepository : Base.IRepository<Models.Blog>
    {
        Task<List<Models.Blog>> GetAllBlogsAsync();

        Task<List<Models.Blog>> GetAllBlogsIndexViewAsync();

        Task<Models.Blog> GetBlogByIdAsync(System.Guid id);
    }
}
