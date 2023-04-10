using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Products
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.General),
           Name = nameof(Resources.Tables.General.IsActive))]
        public bool IsActive { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.General),
           Name = nameof(Resources.Tables.General.IsEdited))]
        public bool IsEditted { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.InsertDateTime))]
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.UpdateDateTime))]
        public DateTime UpdateDateTime { get; set; }
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
             Name = nameof(Resources.Tables.Product.ShowInIndex))]
        public bool ShowInIndex { get; set; }
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
         ResourceType = typeof(Resources.Tables.ProductCategory),
         Name = nameof(Resources.Tables.ProductCategory.Title))]
        public string? ProductCategoryTitle { get; set; }
        //**********
    }
}
