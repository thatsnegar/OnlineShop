using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Order
{
    public class UserOrdersViewModel : object
    {
        public UserOrdersViewModel() : base()
        {
        }

        //**********
        public Guid UserId { get; set; }
        //**********

        //**********
        public List<OrderDetail> OrderDetails { get; set; }
        //**********

        //**********
        public bool IsPaid { get; set; }
        //**********

        //**********
        public double? Total { get; set; }
        //**********

        //**********
        public string? SendWay { get; set; }
        //**********

        //**********
        public string? SelectedUserAddress { get; set; }
        //**********

        //**********
        public string? ProductName { get; set; }
        //**********

        //**********
        public Domain.Enums.OrderStatus OrderStatus { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.General),
          Name = nameof(Resources.Tables.General.InsertDateTime))]
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        [Display(Name = "کد پیگیری")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string? TracingCode { get; set; }
        //**********

        //**********
        [Display(Name = "کد پیگیری")]
        //[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
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
