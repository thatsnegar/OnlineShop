using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Image
{
    public class CreateViewModel : object
    {
        public CreateViewModel() : base()
        {
        }


        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Image),
            Name = nameof(Resources.Tables.Image.ImageTitle))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? ImageTitle { get; set; }
        //**********

        //**********
        public string? FirstSlogan { get; set; }
        //**********

        //**********
        public string? SecondSlogan { get; set; }
        //**********

        //**********
        public string? ThirdSlogan { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? Image { get; set; }
        //**********
    }
}
