using Models;

namespace ViewModels.Order
{
    public class OrderSubmissionViewModel : object
    {
        public OrderSubmissionViewModel(): base()
        {
            DiscountPercentage = 0;
        }

        //**********
        public List<OrderDetail>? OrderDetails { get; set; }
        //**********

        //**********
        public Guid AddressId { get; set; }
        //**********

        //**********
        public string? SendWay { get; set; }
        //**********

        //**********
        public string? Description { get; set; }
        //**********

        //**********
        public Domain.Enums.OrderStatus OrderStatus { get; set; }
        //**********

        //**********
        public Guid DiscountId { get; set; }
        //**********

        //**********
        public string? DiscountText { get; set; }
        //**********

        //**********
        public double? DiscountPercentage { get; set; }
		//**********

		//**********
		public double? DeliveryCost { get; set; }
		//**********
	}
}
