using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ProductCategories
{
    public class GetSliderViewModel : object
    {
        public GetSliderViewModel() : base()
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
            ResourceType = typeof(Resources.Tables.ProductCategory),
            Name = nameof(Resources.Tables.ProductCategory.Url))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Url { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.ProductCategory),
         Name = nameof(Resources.Tables.ProductCategory.Title))]
        public string? ProductCategoryTitle { get; set; }
        //**********

    }
}
