namespace ViewModels.Settings
{
    public class InfoCompany : object
    {
        public static readonly string KeyName = nameof(InfoCompany);

        public InfoCompany() : base()
        {
        }

        // **********
        public string? CompanyName { get; set; }
        // **********

        // **********
        public string? WebsiteAddressCompany { get; set; }
        // **********

        // **********
        public string? CompanyEmailAddress { get; set; }
        // **********

        // **********
        public string? CompanyAddress { get; set; }
        // **********

        // **********
        public string? CompanyPhoneNumber { get; set; }
        // **********

        // **********
        public string? CompanyFaxNumber { get; set; }
        // **********
    }
}
