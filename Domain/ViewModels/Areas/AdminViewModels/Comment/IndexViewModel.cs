using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Comment
{
    public class IndexViewModel
    {

        //**********
        public Guid CommentId { get; set; }
        //**********

        //**********
        [Display(
           ResourceType = typeof(Resources.Tables.General),
           Name = nameof(Resources.Tables.General.IsActive))]
        public bool IsActive { get; set; }
        //**********

        //**********
        [Display(ResourceType = typeof(Resources.Tables.General),
          Name = nameof(Resources.Tables.General.InsertDateTime))]
        public DateTime InsertDateTime { get; set; }
        //**********

        //**********
        public bool Isconfirm { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Comment),
            Name = nameof(Resources.Tables.Comment.Text))]
        public string? Text { get; set; }
        //**********

        //**********
        public Guid ProductId { get; set; }
        //**********
    }
}
