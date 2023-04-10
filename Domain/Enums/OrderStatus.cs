using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "در حال پردازش")]
        UnderProcess,

        [Display(Name = "تحویل داده شده")]
        Delivered,

        [Display(Name = "لغو شده")]
        Cancled
    }
}
