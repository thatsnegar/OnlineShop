namespace Services
{
    public interface IEmailService
    {
        // **************************************************
        // **************************************************
        public Task<bool> SendEmailWithSmtp(Models.Email email);

        // **************************************************
        // **************************************************

        public bool SendEmailWithPlainText(Models.Email email);

        // **************************************************
        // **************************************************

        public List<ViewModels.Emails.IndexViewModel> ReceiveEmailsWithPop3();

        // **************************************************
        // **************************************************

        public List<ViewModels.Emails.IndexViewModel> ReceiveEmailsWithImap();

        // **************************************************
        // **************************************************

        public ViewModels.Emails.DetailsViewModel ReceiveEmailWithPop3(int emailId);

        // **************************************************
        // **************************************************

        public ViewModels.Emails.DetailsViewModel ReceiveEmailWithImap(int emailId);

        // **************************************************
        // **************************************************

        public IEnumerable<MimeKit.MimeEntity> ReceiveAttachments(int emailId);
    }
}

