namespace ViewModels.Settings
{
    public class KavenegarInfo : object
    {
        public static readonly string KeyName = nameof(KavenegarInfo);

        public KavenegarInfo() : base()
        {
        }

        // **********
        public string? ApiKey { get; set; }
        // **********

        // **********
        public string? Sender { get; set; }
        // **********
    }
}
