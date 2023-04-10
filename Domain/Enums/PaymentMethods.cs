using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum PaymentMethods
    {
        [Display(Name = "پرداخت درب منزل")]
        CashOnDelivery,

        [Display(Name = "پرداخت آنلاین")]
        OnlinePayment,
    }
}
    