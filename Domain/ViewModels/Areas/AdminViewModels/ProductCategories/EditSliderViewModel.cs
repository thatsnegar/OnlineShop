using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.ProductCategories
{
    public class EditSliderViewModel : object
    {
        public EditSliderViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Url { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? ImageProductCategorySlider { get; set; }
        //**********

        //**********
        public string? ImageProductCategorySliderName { get; set; }
        //**********
    }
}
