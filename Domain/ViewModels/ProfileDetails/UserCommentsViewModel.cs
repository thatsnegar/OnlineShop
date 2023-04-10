using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProfileDetails
{
    public class UserCommentsViewModel : object
    {
        public UserCommentsViewModel() : base()
        {
            IsConfirm = false;
        }

        //**********
        public Guid? UserId { get; set; }
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
        public Guid CommentId { get; set; }
        //**********

        //**********
        public string? ProductImage { get; set; }
        //**********

        //**********
        public bool IsConfirm { get; set; }
        //**********
    }
}
