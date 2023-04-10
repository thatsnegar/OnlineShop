using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class About : Entity
    {
        public About()
        {
            IsActive = false;
        }

        // **********
        [Display(
         ResourceType = typeof(Resources.Tables.About),
         Name = nameof(Resources.Tables.About.Title))]
        public bool IsActive { get; set; }
        // **********

        // **********
        [Display(
         ResourceType = typeof(Resources.Tables.About),
         Name = nameof(Resources.Tables.About.Title))]
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

        #region Relation One To One With File
        //**********
        public virtual Models.File? File { get; set; }
        //**********
        #endregion
    }
}
