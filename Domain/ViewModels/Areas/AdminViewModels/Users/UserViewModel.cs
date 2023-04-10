namespace ViewModels.AdminViewModels.Users
{
    public class UserViewModel : object
    {
        public UserViewModel() : base()
        {
        }

        // **********
        public System.Guid Id { get; set; }
        // **********

        // **********
        public string? Username { get; set; }
        // **********

        // **********
        public string? Role { get; set; }
        // **********
    }
}
