using System.ComponentModel.DataAnnotations;

namespace ViewModels.Banner
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        //**********
        public string? ImageBannerName { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Banner),
            Name = nameof(Resources.Tables.Banner.Url))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Url { get; set; }
        //**********
    }
}
