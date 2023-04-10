using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    public class ResetPasswordViewModel : object
    {
        public ResetPasswordViewModel() : base()
        {
        }

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Password))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.RePassword))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [Compare(
            otherProperty: nameof(Password),
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Compare))]
        [DataType(DataType.Password)]
        public string? RePassword { get; set; }
        // **********

        // **********
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? EmailAddress { get; set; }
        // **********
    }
}