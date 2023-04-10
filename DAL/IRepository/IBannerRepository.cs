namespace DAL
{
    public interface IBannerRepository : Base.IRepository<Models.Banner>
    {
        Task<List<Models.Banner>> GetAllBannersAsync();

        Task<Models.Banner> GetBannerByIdAsync(System.Guid id);
    }
}
