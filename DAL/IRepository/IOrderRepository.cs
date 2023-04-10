using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderRepository : Base.IRepository<Models.Order>
    {
        // **********
        Task<List<Order>> GetAllOrdersAsync();
        // **********

        // **********
        Task<List<Order>> GetAllUserOrdersAsync(Guid userId);
        // **********
    }
}
