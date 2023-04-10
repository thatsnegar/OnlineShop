using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Blog : Entity
    {
        public Blog()
        {
            File = new File();
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Text))]
        public string? Text { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Summary))]
        public string Summary { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Product),
         Name = nameof(Resources.Tables.Product.ShowInIndex))]
        public bool ShowInIndex { get; set; }
        //**********

        #region Relation One To One With File
        //**********
        public virtual Models.File File { get; set; }
        //**********
        #endregion
    }
}
