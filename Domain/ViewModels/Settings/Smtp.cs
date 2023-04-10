namespace ViewModels.Settings
{
    public class Smtp : object
    {
        public static readonly string KeyName = nameof(Smtp);

        public Smtp() : base()
        {
        }

        // **********
        public string? ServerName { get; set; }
        // **********

        // **********
        public string? ServerAdderss { get; set; }
        // **********

        // **********
        public int Port { get; set; }
        // **********

        // **********
        public bool Ssl { get; set; }
        // **********
    }
}
