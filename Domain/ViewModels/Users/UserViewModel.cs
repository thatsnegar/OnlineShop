using System.ComponentModel.DataAnnotations;

namespace ViewModels.Users
{
    public class UserViewModel : object
    {
        public UserViewModel() : base()
        {
        }

        //**********
        public System.Guid Id { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Gender))]
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
        public string? FullName { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.User),
           Name = nameof(Resources.Tables.User.Username))]
        public string? Username { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.EmailAddress))]
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
        public string? CellPhoneNumber { get; set; }
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

        //**********
        public DateTime BirthDate { get; set; }
        //**********

        //**********
        public string? NationalCode { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.MENumber))]
        public string? MENumber { get; set; }
        //**********

        //**********
        public string? OfficeAddress { get; set; }
        //**********

        //**********
        public string? Especialty { get; set; }
        //**********
    }
}
