using System.ComponentModel.DataAnnotations;

namespace ViewModels.Emails
{
    public class AttachmentViewModel : object
    {
        public AttachmentViewModel() : base()
        {
            PathFiles = new List<string>();
        }

        // **********
        public List<string> PathFiles { get; set; }
        // **********
    }
}
