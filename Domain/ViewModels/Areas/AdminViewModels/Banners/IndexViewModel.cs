using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Banners
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
        [Display(ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.UpdateDateTime))]
        public DateTime UpdateDateTime { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Banner),
            Name = nameof(Resources.Tables.Banner.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********
    }
}
