using System.ComponentModel.DataAnnotations;
namespace ViewModels.Comparison
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        // **********
        public Guid HrefId { get; set; }
        // **********

        // **********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.Title))]
        public string? Title { get; set; }
        // **********

        //**********
        public string? ThumbNailImageName { get; set; }
        //**********

        //**********
        public string? BeforeImageName { get; set; }
        //**********

        //**********
        public string? AfterImageName { get; set; }
        //**********

        //**********
        public string? Description { get; set; }
        //**********
    }
}
