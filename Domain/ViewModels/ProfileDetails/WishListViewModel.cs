using System.ComponentModel.DataAnnotations;

namespace ViewModels.ProfileDetails
{
    public class WishListViewModel : object
    {

        public WishListViewModel() : base()
        {
            IsInWishList = false;
            Count = 1;
        }

        //**********
        public Guid ProductId { get; set; }
        //**********

        //**********
        public Guid UserrId { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.HasDiscount))]
        public bool HasDiscount { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Product),
            Name = nameof(Resources.Tables.Product.Title))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.DiscountedPrice))]
        public double DiscountedPrice { get; set; }
        //**********

        //**********
        [Display(
        ResourceType = typeof(Resources.Tables.Product),
        Name = nameof(Resources.Tables.Product.Price))]
        public double Price { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Product),
            Name = nameof(Resources.Tables.Product.Rate))]
        public int Rate { get; set; }
        //**********

        //**********
        [Display(
        ResourceType = typeof(Resources.Tables.Product),
        Name = nameof(Resources.Tables.Product.DiscountPercentage))]
        public double DiscountPercentage { get; set; }
        //**********

        //**********
        public string? ImageProductName { get; set; }
        //**********

        //**********
        [Display(
          ResourceType = typeof(Resources.Tables.Product),
          Name = nameof(Resources.Tables.Product.Description))]
        public string? Description { get; set; }
        //**********

        //**********
        public bool IsInWishList { get; set; }
        //**********

        //**********
        public int Count { get; set; }
        //**********
    }
}
