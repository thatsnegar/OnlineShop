namespace DAL
{
    public interface IVirtualTourRepository : Base.IRepository<Models.VirtualTour>
    {
        Task<List<Models.VirtualTour>> GetAllVirtualToursAsync();

        Task<Models.VirtualTour> GetVirtualTourByIdAsync(Guid id);
    }
}
