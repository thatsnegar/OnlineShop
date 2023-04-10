using Domain.Base;

namespace Models
{
    public class WishListProduct : Entity
    {
        #region Constructor
        public WishListProduct() : base()
        {
        }
        #endregion

        #region Properties
        //**********
        public System.Guid UserId { get; set; }
        //**********

        //**********
        public System.Guid ProductId { get; set; }
        //********** 
        #endregion

        #region Relations
        //**********
        // One To Many With User
        public virtual User? User { get; set; }
        //**********

        //**********
        // One To Many With Product
        public virtual Product? Product { get; set; }
        //**********

        #endregion
    }
}
