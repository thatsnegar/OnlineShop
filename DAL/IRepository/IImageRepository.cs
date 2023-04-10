namespace DAL
{
    public interface IImageRepository : Base.IRepository<Models.Image>
    {
        Task<List<Models.Image>> GetAllImagesAsync();

        Task<Models.Image> GetImageByIdAsync(System.Guid id);

        Task<Models.Image> GetImageByImageTitleAsync(string imageTitle);
    }
}
