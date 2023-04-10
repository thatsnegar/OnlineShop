using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserLogin : Entity
    {
        public UserLogin() : base()
        {
        }

        //**********
        public string? IpAddress { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.Username))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Username { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.User),
            Name = nameof(Resources.Tables.User.EmailAddress))]
        public string? EmailAddress { get; set; }
        //**********

        public int Test { get; set; }

        #region Relation one to many with User
        // ********** 
        public System.Guid UserId { get; set; }

        public virtual Models.User? User { get; set; }
        // ********** 
        #endregion
    }
}
