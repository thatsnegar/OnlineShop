using Models;

namespace ViewModels.Order
{
    public class OrderDetailsViewModel : object
    {
        public OrderDetailsViewModel() : base()
        {
        }

        //**********
        public List<OrderDetail> OrderDetails { get; set; }
        //**********

        //**********
        public double? Total { get; set; }
        //**********

        //**********
        public Guid UserId { get; set; }
        //**********

       
    }
}
