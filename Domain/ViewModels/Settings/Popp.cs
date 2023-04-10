namespace ViewModels.Settings
{
    public class Popp : object
    {
        public static readonly string KeyName = nameof(Popp);

        public Popp() : base()
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
