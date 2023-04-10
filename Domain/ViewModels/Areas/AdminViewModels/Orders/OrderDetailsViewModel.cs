using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Orders
{
    public class OrderDetailsViewModel
    {
        public OrderDetailsViewModel() : base()
        {
        }

        //**********
        public List<OrderDetail>? OrderDetails { get; set; }
        //**********

        //**********
        public string? Address { get; set; }
        //**********

        //**********
        public string? UserName { get; set; }
        //**********

        //**********
        public string? SendWay { get; set; }
        //**********

        //**********
        public string? Description { get; set; }
        //**********

        //**********
        public string? DiscountText { get; set; }
        //**********

        //**********
        public double? DiscountPercentage { get; set; }
        //**********

    }
}
