using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class VirtualTour : Entity
    {
        public VirtualTour() : base()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.VirtualTour),
            Name = nameof(Resources.Tables.VirtualTour.VideoId))]
        public string? VideoId { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.VirtualTour),
            Name = nameof(Resources.Tables.VirtualTour.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.VirtualTour),
            Name = nameof(Resources.Tables.VirtualTour.Link))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Link { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.VirtualTour),
            Name = nameof(Resources.Tables.VirtualTour.Link))]
        public string? Description { get; set; }
        //**********
    }
}
