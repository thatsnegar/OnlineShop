using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ProductCategories
{
    public class EditViewModel : object
    {
        public EditViewModel() : base()
        {
           
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.ProductCategory),
            Name = nameof(Resources.Tables.ProductCategory.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********
    }
}
