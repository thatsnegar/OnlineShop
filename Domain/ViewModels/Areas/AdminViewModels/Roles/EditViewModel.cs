using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Roles
{
	public class EditViewModel : object
    {
        public EditViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Role),
            Name = nameof(Resources.Tables.Role.Name))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Name { get; set; }
        //**********
    }
}
