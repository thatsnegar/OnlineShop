
using System.ComponentModel.DataAnnotations;

namespace ViewModels.VirtualTour
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.VirtualTour),
           Name = nameof(Resources.Tables.VirtualTour.VideoId))]
        public string? VideoId { get; set; }
        //**********

        //**********
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.VirtualTour),
           Name = nameof(Resources.Tables.VirtualTour.Link))]
        public string? Link { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.VirtualTour),
           Name = nameof(Resources.Tables.VirtualTour.Description))]
        public string? Description { get; set; }
        //**********

    }


}
