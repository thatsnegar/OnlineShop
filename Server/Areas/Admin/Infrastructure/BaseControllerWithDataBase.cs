namespace Server.Areas.Admin.Infrastructure
{
    public class BaseControllerWithDataBase : BaseController
    {
        public BaseControllerWithDataBase(DAL.IUnitOfwork unitOfwork)
        {
            UnitOfWork = unitOfwork;
        }

        public DAL.IUnitOfwork UnitOfWork { get; set; }
    }
}
