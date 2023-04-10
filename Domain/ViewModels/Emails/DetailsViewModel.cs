using System.ComponentModel.DataAnnotations;

namespace ViewModels.Emails
{
    public class DetailsViewModel : object
    {
        public DetailsViewModel() : base()
        {
            IsHtmlBody = false;
        }

        // **********
        public int EmailId { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.General),
            Name = nameof(Resources.Tables.General.InsertDateTime))]
        public System.DateTime InsertDateTime { get; set; }
        // **********

        // **********
        [DataType(DataType.EmailAddress)]
        [Display(Name = "From")]
        public string? From { get; set; }
        // **********

        // **********
        [Display(Name = "Subject")]
        public string? Subject { get; set; }
        // **********

        // **********
        public string? Body { get; set; }
        // **********

        // **********
        public bool IsHtmlBody { get; set; }
        // **********
    }
}
