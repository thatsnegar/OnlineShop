using System.ComponentModel.DataAnnotations;

namespace ViewModels.Addresses
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        // **********   
        public System.Guid Id { get; set; }
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
        public int ZipCode { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.UserAddress))]
        public string? UserAddress { get; set; }
        // **********
    }
}
