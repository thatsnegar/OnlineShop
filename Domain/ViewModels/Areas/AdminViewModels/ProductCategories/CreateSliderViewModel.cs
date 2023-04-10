using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.ProductCategories
{
    public class CreateSliderViewModel : object
    {
        public CreateSliderViewModel() : base()
        {
        }

        //**********
        public System.Guid ProductCategoryId { get; set; }
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
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public Microsoft.AspNetCore.Http.IFormFile? File { get; set; }
        //**********
    }
}
