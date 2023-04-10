using System.ComponentModel.DataAnnotations;

namespace ViewModels.Accounts
{
    public class DoctorLoginViewModel : object
    {
        public DoctorLoginViewModel() : base()
        {
        }

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.MENumber))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string MENumber { get; set; }
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
            Name = nameof(Resources.Tables.User.RememberMe))]
        public bool RememberMe { get; set; }
        // **********

        // **********
        public string? ReturnUrl { get; set; }
        // **********
    }
}
