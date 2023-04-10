using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<T> : Base.Repository<T> where T : Domain.Base.Entity
    {
        internal Repository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        // **************************************************
        public override void Update(T entity)
        {
            if (entity is null)
                throw new System.ArgumentNullException(paramName: nameof(entity));

            entity.IsEdited = true;
            entity.UpdateDateTime = System.DateTime.Now;

            DbSet.Update(entity);
        }
        // **************************************************

        // **************************************************
        public override async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
        {
            var result =
                await DbSet
                .OrderByDescending(current => current.InsertDateTime)
                .ToListAsync();

            return result;
        }
        // **************************************************
    }
}
