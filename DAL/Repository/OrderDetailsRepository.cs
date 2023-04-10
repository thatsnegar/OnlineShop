using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDetailsRepository : Repository<Models.OrderDetail>, IOrderDetailsRepository
    {
        internal OrderDetailsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<List<OrderDetail>> GetOrderDetailsByOrderIdAsync(Guid orderId)
        {
            var result =
                await DbSet
                .Where(current => current.OrderId == orderId)
                .Include(current => current.Order)
                .Include(current => current.Order.User)
                .ToListAsync()
                ;

            return result!;
        }
        // **************************************************

    }
}
