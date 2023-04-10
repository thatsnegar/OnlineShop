using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Accounts
{
    public class SetNewPasswordViewModel : object
    {
        public SetNewPasswordViewModel() : base()
        {
        }

        //**********
        public Guid UserId { get; set; }
        //**********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.NewPassword))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.RePassword))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [Compare(
            otherProperty: nameof(NewPassword),
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Compare))]
        [DataType(DataType.Password)]
        public string? RePassword { get; set; }
        // **********
    }
}
