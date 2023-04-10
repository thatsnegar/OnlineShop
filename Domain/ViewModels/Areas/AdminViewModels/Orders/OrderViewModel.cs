using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Orders
{
    public class OrderViewModel
    {
        //**********
        public Guid OrderId { get; set; }
        //**********

        //**********
        public Guid? UserId { get; set; }
        //**********

        //**********
        public Guid? AddressId { get; set; }
        //**********

        //**********
        public string? SendWay { get; set; }
        //**********

        //**********
        public string? UserName { get; set; }
        //**********

        //**********
        public string? Description { get; set; }
        //**********

        //**********
        public string? Address { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.General),
          Name = nameof(Resources.Tables.General.InsertDateTime))]
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        public Domain.Enums.OrderStatus OrderStatus { get; set; }
        //**********
    }
}
