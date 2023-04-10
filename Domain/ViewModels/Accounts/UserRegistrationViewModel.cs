using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    //public class RegisterViewModel : ViewModels.Settings.CaptchaViewModel
    public class UserRegistrationViewModel : object
    {
        public UserRegistrationViewModel() : base()
        {
            IsActive = false;
        }

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.General),
           Name = nameof(Resources.Tables.General.IsActive))]
        public bool IsActive { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Username))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [MaxLength(length: 50,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Microsoft.AspNetCore.Mvc.Remote
            ("IsUsernameInUse", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken",
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.IsUsernameInUse))]
        public string? Username { get; set; }
        // **********

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
        [Microsoft.AspNetCore.Mvc.Remote
            ("IsPhoneNumberInUse", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken",
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.IsPhoneNumberInUse))]
        public string? PhoneNumber { get; set; }
        //**********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.EmailAddress))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [MaxLength(length: 254,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [EmailAddress(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.EmailAddress))]
        [Microsoft.AspNetCore.Mvc.Remote
            ("IsEmailInUse", "Account", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken",
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.IsEmailInUse))]
        public string? EmailAddress { get; set; }
        // **********

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


        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Gender))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public Domain.Enums.Gender Gender { get; set; }
        //**********
    }
}
