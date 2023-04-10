using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Comparisons
{
    public class ComparisonProductViewModel : object
    {
        public ComparisonProductViewModel() : base()
        {
        }

        // **********
        public System.Guid Id { get; set; }
        // **********

        // **********
        [Display(
         ResourceType = typeof(Resources.Tables.ProductComparison),
         Name = nameof(Resources.Tables.ProductComparison.Title))]
        public string? Title { get; set; }
        // **********

        //**********
        public string? Description { get; set; }
        //**********
    }
}
