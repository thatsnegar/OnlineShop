using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Sliders
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
            ResourceType = typeof(Resources.Tables.Slider),
            Name = nameof(Resources.Tables.Slider.Title))]
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
            ResourceType = typeof(Resources.Tables.Slider),
            Name = nameof(Resources.Tables.Slider.Description))]
        [MaxLength(length: 500,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Description { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? ImageSlider { get; set; }
        //**********

        //**********
        public string? ImageSliderName { get; set; }
        //**********
    }
}


