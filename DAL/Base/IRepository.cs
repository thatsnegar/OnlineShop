namespace DAL.Base
{
    public interface IRepository<T> where T : Domain.Base.Entity
    {
        void Insert(T entity);

        System.Threading.Tasks.Task InsertAsync(T entity);

        // **********

        // **********
        void Update(T entity);
        // **********

        // **********
        void Delete(T entity);
        // **********

        // **********
        T? GetById(System.Guid id);

        System.Threading.Tasks.Task<T?> GetByIdAsync(System.Guid id);

        // **********

        // **********
        bool DeleteById(System.Guid id);

        System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id);

        // **********

        // **********
        System.Collections.Generic.IList<T> GetAll();

        System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
    }
}
