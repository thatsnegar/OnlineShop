using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Messages
{
    public class CreateViewModel : object
    {
        public CreateViewModel() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.Title))]
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
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.Text))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Text { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.Summary))]
        [MaxLength(length: 200,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Summary { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.IsShow))]
        public bool IsShow { get; set; }
        //**********

    }
}


