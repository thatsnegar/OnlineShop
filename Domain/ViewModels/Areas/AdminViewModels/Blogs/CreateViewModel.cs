using System.ComponentModel.DataAnnotations;

namespace ViewModels.AdminViewModels.Blogs
{
    public class CreateViewModel : object
    {
        public CreateViewModel() : base()
        {
        }

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
        public string Text { get; set; }
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
        //[Microsoft.AspNetCore.Mvc.ModelBinding.Validation.ValidateNever]
        public Microsoft.AspNetCore.Http.IFormFile? ImageBlog { get; set; }
        //**********
    }
}


