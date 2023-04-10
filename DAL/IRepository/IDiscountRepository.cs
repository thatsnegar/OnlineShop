using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDiscountRepository : Base.IRepository<Models.Discount>
    {
        Task<List<ViewModels.AdminViewModels.Discounts.IndexViewModel>> GetAllDiscountsAsync();

        Task<Discount> GetDiscountByIdAsync(System.Guid id);

        Task<Discount> GetDiscountInTiemRegisterAsync(System.Guid userId);

        Task<Discount?> GetCupponePercentByItsNameAsync(string? discountText);
    }
}