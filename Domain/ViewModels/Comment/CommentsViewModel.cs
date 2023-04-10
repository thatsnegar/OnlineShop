using System.ComponentModel.DataAnnotations;

namespace ViewModels.Comment
{
    public class CommentsViewModel : object
    {
        public CommentsViewModel() : base()
        {
            Rate = 0;
            LikeNumbers = 0;
            DisLikeNumbers = 0;
            Isconfirm = false;
        }

        //**********
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        public Guid? UserId { get; set; }
        //**********

        //**********
        public string? Username { get; set; }
        //**********

        //**********
        public Guid ProductId { get; set; }
        //**********

        //**********
        public int Rate { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Comment),
            Name = nameof(Resources.Tables.Comment.Text))]
        public string? Text { get; set; }
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
        public Guid CommentId { get; set; }
        //**********

        //**********
        public bool Isconfirm { get; set; }
        //**********
    }
}
