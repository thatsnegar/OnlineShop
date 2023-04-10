using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Messages
{
    public class IndexViewModel
    {
        public IndexViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

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
          Name = nameof(Resources.Tables.Message.IsShow))]
        public bool IsShow { get; set; }
        //**********
    }
}
