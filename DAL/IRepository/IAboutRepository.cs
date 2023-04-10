namespace DAL
{
    public interface IAboutRepository : Base.IRepository<Models.About>
    {
        Task<List<ViewModels.AdminViewModels.Abouts.IndexViewModel>> GetAllAboutsAsync();

        Task<Models.About> GetAboutByIdAsync(System.Guid id);

        Task<Models.About> GetActiveAboutAsync(System.Guid id);
    }
}

