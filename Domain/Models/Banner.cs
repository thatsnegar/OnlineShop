using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Banner : Entity
    {
        public Banner()
        {
            File = new File();
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Banner),
            Name = nameof(Resources.Tables.Banner.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Banner),
            Name = nameof(Resources.Tables.Banner.Url))]
        public string? Url { get; set; }
        //**********

        #region Relation One To One With File
        //**********
        public virtual Models.File? File { get; set; }
        //**********
        #endregion
    }
}
