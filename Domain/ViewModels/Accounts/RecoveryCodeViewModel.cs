using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Accounts 
{
    public class RecoveryCodeViewModel : object
    {
        public RecoveryCodeViewModel() : base()
        {
        }

        //**********
        public Guid UserId { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.PhoneNumber))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        [DataType(dataType: DataType.PhoneNumber,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.PhoneNumber))]
        public string? PhoneNumber { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.VarificationCode))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? VerificationCode { get; set; }
        //**********
    }
}
