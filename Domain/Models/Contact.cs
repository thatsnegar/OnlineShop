using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Contact : Entity
    {
        public Contact()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Contact),
            Name = nameof(Resources.Tables.Contact.FullName))]
        [MaxLength(length: 500,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? FullName { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Contact),
            Name = nameof(Resources.Tables.Contact.Email))]
        [MaxLength(length: 500,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [EmailAddress(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.EmailAddress))]
        public string? Email { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Contact),
            Name = nameof(Resources.Tables.Contact.PhoneNumber))]
        [MaxLength(length: 11,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? PhoneNumber { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Contact),
            Name = nameof(Resources.Tables.Contact.Issue))]
        public string? Issue { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Contact),
            Name = nameof(Resources.Tables.Contact.Message))]
        public string? Message { get; set; }
        //**********

        //**********
        public bool IsHandled { get; set; }
        //**********

        //**********
        public bool SendEmail { get; set; }
        //**********
    }
}
