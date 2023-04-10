using System.ComponentModel.DataAnnotations;

namespace ViewModels.Emails
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
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
        [Display(Name = "Is/are Attachment(s)")]
        public bool IsAttachment { get; set; }
        // **********
    }
}
