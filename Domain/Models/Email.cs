using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Email : Domain.Base.Entity
    {
        public Email() : base()
        {
            EmailNumber = 0;
            IsBodyHtml = false;
        }

        // **********
        public int EmailNumber { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Username))]
        public string? Username { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Password))]
        public string? Password { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.IncomingHost))]
        public string? IncomingHost { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.IncomingPort))]
        public int IncomingPort { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.OutgoingHost))]
        public string? OutgoingHost { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.OutgoingPort))]
        public int OutgoingPort { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Pop3))]
        public bool Pop3 { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.IMap))]
        public bool Imap { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Ssl))]
        public bool Ssl { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.From))]
        [DataType(DataType.EmailAddress)]
        public string? From { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.To))]
        [DataType(DataType.EmailAddress)]
        public string? ToEmail { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Cc))]
        [DataType(DataType.EmailAddress)]
        public List<string>? EmailCC { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Bcc))]
        [DataType(DataType.EmailAddress)]
        public List<string>? EmailBCC { get; set; }

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Subject))]
        public string? Subject { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Body))]
        public string? Body { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Attachments))]
        public List<Microsoft.AspNetCore.Http.IFormFile>? Attachments { get; set; }
        // **********

        // **********
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool IsBodyHtml { get; set; }
        // **********

        // User
        #region Relation One To Many With User
        // **********
        public System.Guid? UserId { get; set; }

        public virtual Models.User? User { get; set; }
        // **********
        #endregion
    }
}
