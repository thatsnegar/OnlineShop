using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Users
{
    public class EditViewModel : object
    {
        public EditViewModel() : base()
        {
        }

        //**********
        public System.Guid Id { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Gender))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public Domain.Enums.Gender Gender { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.FirstName))]
        public string? FirstName { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.User),
           Name = nameof(Resources.Tables.User.LastName))]
        public string? LastName { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.User),
           Name = nameof(Resources.Tables.User.Username))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        //[Microsoft.AspNetCore.Mvc.Remote
        //    ("IsUserNameInUse", "Users", HttpMethod = "POST", AdditionalFields = "__RequestVerificationToken",
        //    ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
        //    ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.IsUsernameInUse))]
        public string? Username { get; set; }
        //**********

        //**********

        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.EmailAddress))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(dataType: DataType.EmailAddress,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.EmailAddress))]
        public string? EmailAddress { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.PhoneNumber))]
        [DataType(dataType: DataType.PhoneNumber,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.PhoneNumber))]
        public string? PhoneNumber { get; set; }
        //**********

        //**********
        public Guid RoleId { get; set; }
        //**********

        //**********
        public string? UserAvatar { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? File { get; set; }
        //**********
    }
}
