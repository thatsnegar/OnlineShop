using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Products
{
    public class DetailViewModel : object
    {
        public DetailViewModel() : base()
        {
            IsInWishList = false;
        }

        //**********
        public Guid ProductId { get; set; }
        //**********

        //**********
        public Guid ProductCategoryId { get; set; }
        //**********


        //**********
        public Guid? UserId { get; set; }
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
            Name = nameof(Resources.Tables.Product.Rate))]
        public int Rate { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.HasDiscount))]
        public bool HasDiscount { get; set; }
        //**********

        //**********
        public bool IsInWishList { get; set; }
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
         Name = nameof(Resources.Tables.Product.DiscountedPrice))]
        public double DiscountedPrice { get; set; }
        //**********

        //**********
        public string? ProductCategoryTitle { get; set; }
        //**********

        //**********
        public List<Models.File>? ProductImages { get; set; }
        //**********



    }
}
