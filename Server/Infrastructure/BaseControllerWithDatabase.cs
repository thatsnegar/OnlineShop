namespace Infrastructure
{
	public class BaseControllerWithDatabase : BaseController
	{
		public BaseControllerWithDatabase(DAL.IUnitOfwork unitOfWork)
		{
			UnitOfWork = unitOfWork;
		}

        public DAL.IUnitOfwork UnitOfWork { get; set; }
    }
}