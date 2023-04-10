using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    //public class LoginViewModel : ViewModels.Settings.CaptchaViewModel
    public class LoginViewModel : object
    {
        public LoginViewModel() : base()
        {
        }
        //**********
        [Display(Name = "Username")]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [MaxLength(length: 50,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? UserName { get; set; }
        // **********

        // **********
        [Display(Name = "Password")]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        // **********

        // **********
        [Display(Name = "Rememberme")]
        public bool RememberMe { get; set; }
        // **********

        // **********
        public string? ReturnUrl { get; set; }
       
    }
}
