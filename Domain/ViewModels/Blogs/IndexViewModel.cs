using System.ComponentModel.DataAnnotations;

namespace ViewModels.Blogs
{
    public class IndexViewModel : object
    {
        public IndexViewModel() : base()
        {
        }

        //**********
        public Guid BlogId { get; set; }
        //**********

        //**********
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Title))]
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
        [MaxLength(length: 200,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string Summary { get; set; }
        //**********

        //**********
        public string? ImageBlogName { get; set; }
        //**********
    }
}
