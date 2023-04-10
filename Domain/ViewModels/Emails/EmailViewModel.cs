using System.ComponentModel.DataAnnotations;

namespace ViewModels.Emails
{
    public class EmailViewModel : object
    {
        public EmailViewModel() : base()
        {
            IsHtmlBody = false;

            Attachments = new List<Microsoft.AspNetCore.Http.IFormFile>();
        }


        // **********
        public Guid RfqId { get; set; }
        // **********

        // **********
        public Guid RequestId { get; set; }
        // **********

        // **********
        [DataType(DataType.EmailAddress)]
        [Display(
            ResourceType = typeof(Resources.Tables.Email), 
            Name = nameof(Resources.Tables.Email.From))]
        public string? From { get; set; }
        // **********

        // **********
        [DataType(DataType.EmailAddress)]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.To))]
        public string? To { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Subject))]
        public string? Subject { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Cc))]
        public List<string>? Cc { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Bcc))]
        public List<string>? Bcc { get; set; }
        // **********

        // **********
        public string? Body { get; set; }
        // **********

        // **********
        public List<Microsoft.AspNetCore.Http.IFormFile> Attachments { get; set; }
        // **********

        // **********
        public bool IsHtmlBody { get; set; }
        // **********
    }
}
