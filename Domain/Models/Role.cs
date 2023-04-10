using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Role : Entity
    {
        public Role()
        {
        }

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Role),
            Name = nameof(Resources.Tables.Role.Name))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Name { get; set; }
        // **********

        #region Relation one to many with User
        // ********** 
        public virtual System.Collections.Generic.IList<Models.User>? Users { get; set; }
        // ********** 
        #endregion
    }
}