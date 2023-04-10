using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ProductCategories
{
    public class CreateViewModel : object
    {
        public CreateViewModel() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.ProductCategory),
            Name = nameof(Resources.Tables.ProductCategory.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Title { get; set; }
        //**********
    }
}
