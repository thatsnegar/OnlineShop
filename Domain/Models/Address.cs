using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    public class Address : Entity
    {
        public Address()
        {
        }

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.Country))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Country { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.State))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? State { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.City))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? City { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.ZipCode))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public int ZipCode { get; set; }
        // **********

        // **********
        [Display(
            ResourceType = typeof(Resources.Tables.Address),
            Name = nameof(Resources.Tables.Address.UserAddress))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? UserAddress { get; set; }
        // **********

        #region Relation one to many with User
        // ********** 
        public Guid UserId { get; set; }

        public virtual Models.User? User { get; set; }
        // ********** 
        #endregion

        #region Relation one to one with Ordersubmission
        //**********
        public virtual Models.OrderSubmission? OrderSubmission { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(OrderSubmission))]
        public System.Guid? OrderSubmissionId { get; set; }
        //**********
        #endregion

    }
}
