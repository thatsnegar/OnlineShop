using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    public class ConfirmRegistrationViewModel : object
    {
        public ConfirmRegistrationViewModel() : base()
        {
        }

        //**********
        public Guid UserId { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.PhoneNumber))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(dataType: DataType.PhoneNumber,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.PhoneNumber))]
        public string? PhoneNumber { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.VarificationCode))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? VerificationCode { get; set; }
        //**********
    }
}
