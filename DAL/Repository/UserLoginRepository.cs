namespace DAL
{
    public class UserLoginRepository : Repository<Models.UserLogin>, IUserLoginRepository
    {
        internal UserLoginRepository
            (DatabaseContext databaseContext) : base(databaseContext: databaseContext)
        {
        }
    }
}
