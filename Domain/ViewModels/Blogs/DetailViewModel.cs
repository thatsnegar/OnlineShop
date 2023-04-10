using System.ComponentModel.DataAnnotations;

namespace ViewModels.Blogs
{
    public class DetailViewModel : object
    {
        public DetailViewModel() : base()
        {
        }

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
        public string? ImageBlogName { get; set; }
        //**********
    }
}
