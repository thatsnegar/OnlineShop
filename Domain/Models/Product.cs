using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product : Entity
    {
        public Product() : base()
        {
            Rate = 0;
            Price = 0;
            ShowInIndex = false;
            HasDiscount = false;
            IsInStock = false;
            HasComparison = false;
            AddedToWishList = false;
            DiscountPercentage = 0;
            DiscountPercentage = 0;
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Product),
            Name = nameof(Resources.Tables.Product.Title))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
          ResourceType = typeof(Resources.Tables.Product),
          Name = nameof(Resources.Tables.Product.Description))]
        public string? Description { get; set; }
        //**********

        //**********
        [Display(
          ResourceType = typeof(Resources.Tables.Product),
          Name = nameof(Resources.Tables.Product.Specification))]
        public string? Specification { get; set; }
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
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.Rate))]
        public int Rate { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.ShowInIndex))]
        public bool ShowInIndex { get; set; }
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
         Name = nameof(Resources.Tables.Product.IsInstock))]
        public bool IsInStock { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.IsInstock))]
        public bool HasComparison { get; set; }
        //**********

        //**********
        public bool AddedToWishList { get; set; }
        //**********

        //**********
        [Display(
          ResourceType = typeof(Resources.Tables.Product),
          Name = nameof(Resources.Tables.Product.Title))]
        public string? ProductCategoryTitle { get; set; }
        //**********


        #region Relation One To Many With File
        //**********
        public virtual List<File>? Files { get; set; }
        //**********
        #endregion

        #region Relation One To Many With File
        //**********
        public virtual List<OrderSubmission>? OrderSubmissions { get; set; }
        //**********
        #endregion

        #region Relation One To Many with Comment
        //**********
        public virtual List<Comment>? Comments { get; set; }
        //**********
        #endregion

        #region Relation One To Many with Order Detail
        //**********
        public virtual List<OrderDetail>? OrderDetails { get; set; }
        //**********
        #endregion

        #region Relation One To Many with wishList Product
        //**********
        public virtual List<WishListProduct>? WishListProducts { get; set; }
        //**********
        #endregion

        #region Relation One To Many with Product Category
        //**********
        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ProductCategory))]
        public System.Guid ProductCategoryId { get; set; }

        public virtual Models.ProductCategory? ProductCategory { get; set; }
        //**********
        #endregion
    }
}
