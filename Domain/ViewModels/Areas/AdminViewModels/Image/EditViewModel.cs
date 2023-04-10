using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Image
{
    public class EditViewModel
    {
        public EditViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Image),
            Name = nameof(Resources.Tables.Image.ImageTitle))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? ImageTitle { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? Image { get; set; }
        //**********

        //**********
        public string? ImageName { get; set; }
        //**********

        //**********
        public string? FirstSlogan { get; set; }
        //**********

        //**********
        public string? SecondSlogan { get; set; }
        //**********

        //**********
        public string? ThirdSlogan { get; set; }
        //**********
    }
}
