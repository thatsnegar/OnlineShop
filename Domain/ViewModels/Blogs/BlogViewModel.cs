using System.ComponentModel.DataAnnotations;

namespace ViewModels.Blogs
{
    public class BlogViewModel : object
    {
        public BlogViewModel() : base()
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
        public string Summary { get; set; }
        //**********

        //**********
        public string? ImageBlogName { get; set; }
        //**********
    }
}
