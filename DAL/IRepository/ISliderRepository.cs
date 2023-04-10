namespace DAL 
{ 
    public interface ISliderRepository : Base.IRepository<Models.Slider>
    {
        Task<List<Models.Slider>> GetAllSlidersAsync();

        Task<Models.Slider> GetSliderByIdAsync(System.Guid id);
    }
}
