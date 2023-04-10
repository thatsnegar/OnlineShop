using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ProductCategories
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
        public bool IsEditted { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.General),
          Name = nameof(Resources.Tables.General.InsertDateTime))]
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.ProductCategory),
           Name = nameof(Resources.Tables.ProductCategory.HasSlider))]
        public bool HasSlider { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.UpdateDateTime))]
        public DateTime UpdateDateTime { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.ProductCategory),
           Name = nameof(Resources.Tables.ProductCategory.Title))]
        public string? Title { get; set; }
        //**********
    }
}
