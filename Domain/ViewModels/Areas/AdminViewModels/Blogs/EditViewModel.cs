using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Blogs
{
    public class EditViewModel : object
    {
        public EditViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Text))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Text { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Blog),
            Name = nameof(Resources.Tables.Blog.Summary))]
        [MaxLength(length: 100,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string Summary { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? ImageBlog { get; set; }
        //**********

        //**********
        public string? ImageBlogName { get; set; }
        //**********
    }
}


