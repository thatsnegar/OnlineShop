using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Abouts
{
    public class EditViewModel : object
    {
        public EditViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.Title))]
        [MaxLength(length: 100,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.Text))]
        public string? Text { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.SubTitle))]
        public string? SubTitle { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.Slogan))]
        public string? Slogan { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.GoalTitle))]
        public string? GoalTitle { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.GoalDescription))]
        public string? GoalDescription { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.MissionTitle))]
        public string? MissionTitle { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.MissionDescription))]
        public string? MissionDescription { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.VisionTitle))]
        public string? VisionTitle { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.VisionDescription))]
        public string? VisionDescription { get; set; }
        // **********

        //**********
        [Display(
        ResourceType = typeof(Resources.Tables.About),
        Name = nameof(Resources.Tables.About.AboutImage))]
        public string? AboutImageName { get; set; }
        //**********

        //**********
        public Microsoft.AspNetCore.Http.IFormFile? AboutImage { get; set; }
        //**********
    }
}
