namespace DAL
{
	public interface IScientificInfoRepository : Base.IRepository<Models.ScientificInfo>
	{
		Task<List<ViewModels.AdminViewModels.ScientificInfo.IndexViewModel>> GetAllScientificInfosAsync();

		Task<Models.ScientificInfo> GetScientificInfoByIdAsync(System.Guid id);
	}
}

