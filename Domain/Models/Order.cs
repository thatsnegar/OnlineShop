using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Order : Domain.Base.Entity
    {
        public Order() : base()
        {
            IsPaid = false;
        }

		//**********
		public DateTime? PaymentDate { get; set; }
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
		public Domain.Enums.OrderStatus OrderStatus { get; set; }
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

		//**********
		[Display(Name = "Tracking number")]
		public long TrackingNumber { get; set; }
		//**********

		//**********
		[Display(Name = "Generate the Tracking number automatically?")]
		public bool GenerateTrackingNumberAutomatically { get; set; } = true;
		//**********

		#region Relation One To One with User
		//**********
		[System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(User))]
		public System.Guid? UserId { get; set; }

		public virtual User? User { get; set; }
		//**********
		#endregion

		#region Relation One To Many with Order Detail
		public virtual IList<Models.OrderDetail>? OrderDetails { get; set; }
		#endregion
	}
}
