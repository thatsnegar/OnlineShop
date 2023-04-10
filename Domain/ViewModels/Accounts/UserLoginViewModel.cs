using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    //public class LoginViewModel : ViewModels.Settings.CaptchaViewModel
    public class UserLoginViewModel : object
    {
        public UserLoginViewModel() : base()
        {
        }

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
        public string? Username { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Password))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Password))]
        [DataType(DataType.Password)]
     
        public string? Password { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.RememberMe))]
        public bool RememberMe { get; set; }
        // **********

        // **********
        public string? ReturnUrl { get; set; }
        // **********
       
    }
}
