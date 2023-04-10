using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base
{
    public class Repository<T> : object, IRepository<T> where T : Domain.Base.Entity
    {
        internal Repository(DatabaseContext databaseContext) : base()
        {
            DatabaseContext =
                databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));

            DbSet = DatabaseContext.Set<T>();
        }

        protected Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }

        internal DatabaseContext DatabaseContext { get; }

        // **************************************************

        // **************************************************
        public virtual void Insert(T entity)
        {
            if (entity is null)
                throw (new System.ArgumentNullException(paramName: nameof(entity)));

            DbSet.Add(entity: entity);
        }

        public virtual async System.Threading.Tasks.Task InsertAsync(T entity)
        {
            if (entity is null)
                throw (new System.ArgumentNullException(paramName: nameof(entity)));

            await DbSet.AddAsync(entity: entity);
        }

        // **************************************************

        // **************************************************
        public virtual void Update(T entity)
        {
            if (entity is null)
                throw (new System.ArgumentNullException(paramName: nameof(entity)));

            DbSet.Update(entity: entity);
        }

        // **************************************************

        // **************************************************
        public virtual void Delete(T entity)
        {
            if (entity is null)
                throw (new System.ArgumentNullException(paramName: nameof(entity)));

            DbSet.Remove(entity: entity);
        }

        // **************************************************

        // **************************************************
        public virtual T? GetById(System.Guid id)
        {
            if (id == System.Guid.Empty)
                throw (new System.ArgumentNullException(paramName: nameof(id)));

            T? entity =
                DbSet.Find(keyValues: id);

            return entity;
        }

        public virtual async System.Threading.Tasks.Task<T?> GetByIdAsync(System.Guid id)
        {
            var result =
                await DbSet.FindAsync(keyValues: id);

            return result;
        }

        // **************************************************

        // **************************************************
        public virtual bool DeleteById(System.Guid id)
        {
            if (id == System.Guid.Empty)
                throw (new System.ArgumentNullException(paramName: nameof(id)));

            T? entity = 
                GetById(id: id);

            if (entity is null)
                return false;

            Delete(entity: entity);

            return true;
        }
        public virtual async System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id)
        {
            T? entity =
                await GetByIdAsync(id: id);

            if (entity is null)
                return false;

            Delete(entity: entity);

            return true;
        }

        // **************************************************

        // **************************************************
        public virtual System.Collections.Generic.IList<T> GetAll()
        {
            var result =
                DbSet
                .OrderByDescending(current => current.InsertDateTime)
                .ToList();

            return result;
        }

        public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
        {
            var result =
                await
                DbSet
                .OrderByDescending(current => current.InsertDateTime)
                .ToListAsync();

            return result;
        }
    }
}
