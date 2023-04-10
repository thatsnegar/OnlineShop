using System.ComponentModel.DataAnnotations;

namespace ViewModels.Emails
{
    public class EmailConfigurationViewModel : object
    {
        public EmailConfigurationViewModel() : base()
        {
        }

        // **********
        public Guid EmailConfigId { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Username))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(DataType.EmailAddress)]
        public string? Username { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Password))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.IncomingHost))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? IncomingHost { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.IncomingPort))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public int IncomingPort { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.OutgoingHost))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? OutgoingHost { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.OutgoingPort))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public int OutgoingPort { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Pop3))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public bool Pop3 { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.IMap))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public bool Imap { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Email),
            Name = nameof(Resources.Tables.Email.Ssl))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public bool Ssl { get; set; }
        // **********
    }
}
