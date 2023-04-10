using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Message : Entity
    {
        public Message()
        {
        }

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.Title))]
        [MaxLength(length: 250,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        public string? Title { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.Text))]
        public string? Text { get; set; }
        //**********

        //**********
        [Display(
            ResourceType = typeof(Resources.Tables.Message),
            Name = nameof(Resources.Tables.Message.Summary))]
        public string? Summary { get; set; }
        //**********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Message),
         Name = nameof(Resources.Tables.Message.IsShow))]
        public bool IsShow { get; set; }
        //**********

        //**********
        public int Count { get; set; }
        //**********


    }
}
