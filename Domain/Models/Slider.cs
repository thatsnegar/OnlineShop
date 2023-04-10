using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Slider : Entity
    {
        public Slider()
        {
            File = new File();
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Slider),
            Name = nameof(Resources.Tables.Slider.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Slider),
            Name = nameof(Resources.Tables.Slider.Description))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Description { get; set; }
        //**********

        #region Relation one to one with File
        //**********
        public virtual Models.File File { get; set; }
        //**********
        #endregion
    }
}   
