using System.ComponentModel.DataAnnotations;

namespace ViewModels.Sliders
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.Slider),
           Name = nameof(Resources.Tables.Slider.Description))]
        public string? Description { get; set; }
        //**********

        //**********
        public string? ImageSliderName { get; set; }
        //**********
    }
}
