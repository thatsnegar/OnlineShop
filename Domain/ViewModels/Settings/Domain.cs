namespace ViewModels.Settings
{
    public class Domain : object
    {
        public static readonly string KeyName = nameof(Domain);

        public Domain() : base()
        {
        }

        // **********
        public string? DomainName { get; set; }
        // **********
    }
}
