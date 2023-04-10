using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Discounts
{
    public class EditViewModel : object
    {
        public EditViewModel() : base()
        {
        }

        //**********
        public Guid Id { get; set; }
        //**********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.Discount),
        Name = nameof(Resources.Tables.Discount.Title))]
        [MaxLength(length: 100,
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string? Title { get; set; }
        // **********

        // **********
        [Display(
        ResourceType = typeof(Resources.Tables.Discount),
        Name = nameof(Resources.Tables.Discount.Text))]
        public string? Text { get; set; }
        // **********

        //**********
        [Display(
         ResourceType = typeof(Resources.Tables.Discount),
         Name = nameof(Resources.Tables.Discount.DiscountPercentage))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public double DiscountPercentage { get; set; }
        //**********

        //**********
        [Display(
        ResourceType = typeof(Resources.Tables.Discount),
        Name = nameof(Resources.Tables.Discount.StartDate))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string StartDate { get; set; }
        //**********

        //**********
        [Display(
        ResourceType = typeof(Resources.Tables.Discount),
        Name = nameof(Resources.Tables.Discount.EndDate))]
        [Required(
            ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
            ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
        public string EndDate { get; set; }
        //**********

        //**********
        [Display(
        ResourceType = typeof(Resources.Tables.General),
        Name = nameof(Resources.Tables.General.IsActive))]
        public bool IsActive { get; set; }
        //**********
    }
}
