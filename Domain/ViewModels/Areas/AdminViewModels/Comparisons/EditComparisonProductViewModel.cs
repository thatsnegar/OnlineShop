using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Comparisons
{
    public class EditComparisonProductViewModel : object
    {
        public EditComparisonProductViewModel() : base()
        {
        }

        // **********
        public System.Guid ComparisonProductId { get; set; }
        // **********

        // **********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.Title))]
        public string? Title { get; set; }
        // **********

        //**********
        public string? Description { get; set; }
        //**********

        //**********
        public Models.File? ThumbNailImage { get; set; }
        //**********

        //**********
        public Models.File? BeforeImage { get; set; }
        //**********

        //**********
        public Models.File? AfterImage { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? ThumbnailImageProduct { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? BeforeImageProduct { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? AfterImageProduct { get; set; }
        //**********
    }
}
