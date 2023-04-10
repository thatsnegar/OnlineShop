using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Banners
{
    public class CreateViewModel : object
    {
        public CreateViewModel() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Banner),
            Name = nameof(Resources.Tables.Banner.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Banner),
            Name = nameof(Resources.Tables.Banner.Url))]
        public string? Url { get; set; }
        //**********


        //**********
        public Microsoft.AspNetCore.Http.IFormFile? ImageBanner { get; set; }
        //**********
    }
}


