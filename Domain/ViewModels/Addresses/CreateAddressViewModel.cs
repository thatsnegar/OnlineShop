using System.ComponentModel.DataAnnotations;

namespace ViewModels.Addresses
{
    public class CreateAddressViewModel : object
    {
        public CreateAddressViewModel() : base()
        {
        }

        // **********
        public System.Guid UserId { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.Country))]
        public string? Country { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.State))]
        public string? State { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.City))]
        public string? City { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.ZipCode))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public int ZipCode { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.UserAddress))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? UserAddress { get; set; }
        // **********
    }
}
