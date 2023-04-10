using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Answer
{
    public class CreateViewModel : object
    {
        public CreateViewModel() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Answer),
            Name = nameof(Resources.Tables.Answer.Text))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Text { get; set; }
        //**********
    }
}
