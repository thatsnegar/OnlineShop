using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Discounts
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
            IsActive = false;
        }

        //**********
        public Guid Id { get; set; }
        //**********

        // **********
        public string? Title { get; set; }
        // **********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.General),
           Name = nameof(Resources.Tables.General.IsActive))]
        public bool IsActive { get; set; }
        //**********

        //**********
        [Display(
          ResourceType = typeof(Resources.Tables.General),
          Name = nameof(Resources.Tables.General.IsEdited))]
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
    }
}
