using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProductCategory : Entity
    {
        public ProductCategory() : base()
        {
            HasSlider = false;
        }  

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.ProductCategory),
            Name = nameof(Resources.Tables.ProductCategory.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.ProductCategory),
           Name = nameof(Resources.Tables.ProductCategory.Title))]
        [MaxLength(length: 250,
           ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
           ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Url { get; set; }
        //**********

        //**********
        public bool HasSlider { get; set; }
        //**********

        #region Relation one to one with File
        //**********
        public virtual Models.File? File { get; set; }
        //**********
        #endregion

        #region Relation One To Many with Product
        //**********
        public virtual List<Product>? Products { get; set; }
        //**********
        #endregion
    }
}
