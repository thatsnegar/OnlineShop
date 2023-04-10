using System.ComponentModel.DataAnnotations;

namespace ViewModels.Blogs
{
    public class RecentBlogViewModel : object
    {
        public RecentBlogViewModel() : base()
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
        public string? ImageBlogName { get; set; }
        //**********
    }
}
