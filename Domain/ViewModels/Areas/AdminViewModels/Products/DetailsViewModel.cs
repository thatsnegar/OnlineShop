using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Products
{
    public class DetailsViewModel : object
    {
        public DetailsViewModel() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Product),
            Name = nameof(Resources.Tables.Product.DiscountPercentage))]
        public double DiscountPercentage { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.DiscountedPrice))]
        public double DiscountedPrice { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.InsertDateTime))]
        public string? InsertDateTime { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.UpdateDateTime))]
        public string? UpdateDateTime { get; set; }
        //**********
    }
}
