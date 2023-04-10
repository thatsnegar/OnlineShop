using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Order;

namespace DAL
{
    public class OrderRepository : Repository<Models.Order>, IOrderRepository
    {
        internal OrderRepository
          (DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        // **************************************************
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var result =
                   await DbSet
                   .Include(current => current.User)
                   .ToListAsync()
                   ;
            return result;
        }
        // **************************************************

        // **************************************************
        public async Task<List<Order>> GetAllUserOrdersAsync(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentNullException(paramName: nameof(userId));

            var result =
                await DbSet
                .Where(current => current.UserId.Equals(userId))
                .Include(current => current.OrderDetails)
                .ToListAsync()
                ;

            return result;
        }
        // **************************************************
    }
}
