using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Products
{
    public class ProductViewModel : object
    {
        public ProductViewModel() : base()
        {
        }

        //**********
        public Guid ProductId { get; set; }
		//**********

		//**********
		public Guid ProducCategorytId { get; set; }
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
    }
}
