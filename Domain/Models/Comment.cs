using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Comment : Entity
    {
        #region Constructors
        public Comment() : base()
        {
            Rate = 0;
            LikeNumbers = 0;
            DisLikeNumbers = 0;
            Isconfirm = false;
        }
        #endregion

        #region Properties
        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Comment),
            Name = nameof(Resources.Tables.Comment.Text))]
        public string? Text { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Comment),
         Name = nameof(Resources.Tables.Comment.Text))]
        public int Rate { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Comment),
         Name = nameof(Resources.Tables.Comment.LikeNumbers))]
        public int LikeNumbers { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.Comment),
           Name = nameof(Resources.Tables.Comment.DisLikeNumbers))]
        public int DisLikeNumbers { get; set; }
        //**********

        //**********
        public System.Guid UserId { get; set; }
        //**********

        //**********
        public System.Guid ProductId { get; set; }
        //**********

        //**********
        public bool Isconfirm { get; set; }
        //**********
        #endregion

        #region Relations
        //**********
        //One To Many With User
        public virtual User? User { get; set; }
        //**********

        //**********
        //One To Many With Product
        public virtual Product? Product { get; set; }
        //**********
        #endregion
    }
}
