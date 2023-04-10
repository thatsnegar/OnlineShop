
using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class OrderSubmission : Entity
    {
        public OrderSubmission() : base()
        {
        }

        //**********
        public int Total { get; set; }
        //**********

        //**********
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public Domain.Enums.PaymentMethods PaymentMethods { get; set; }
        //**********

        //**********
        public string? OrderDetails { get; set; }
        //**********

        #region Relation one to many with Product
        // ********** 
        public Guid ProductId { get; set; }

        public virtual Models.Product? Product { get; set; }
        // ********** 
        #endregion

        #region Relation one to one with Address
        //**********
        public virtual Models.Address? Address { get; set; }
        //**********
        #endregion
    }
}
