using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    public class ForgotPasswordViewModel : object
    {
        public ForgotPasswordViewModel() : base()
        {
        }

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
    }
}