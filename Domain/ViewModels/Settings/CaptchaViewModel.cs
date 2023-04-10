using System.ComponentModel.DataAnnotations;

namespace ViewModels.Settings
{
    public class CaptchaViewModel : object
    {
		public CaptchaViewModel() : base()
		{
		}

        // **********
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Captcha { get; set; }
        // **********
    }
}
