using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class UserDiscount : Entity
	{
		public UserDiscount()
		{
			IsActive = false;
		}

		// **********
		public Guid DiscountId { get; set; }
		// **********

		// **********
		public Guid UserId { get; set; }
		// **********

		// **********
		[Display(
		 ResourceType = typeof(Resources.Tables.Discount),
		 Name = nameof(Resources.Tables.Discount.Title))]
		public string? Title { get; set; }
		// **********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Discount),
			Name = nameof(Resources.Tables.Discount.Text))]
		public string? Text { get; set; }
		//**********

		//**********
		[Display(
		 ResourceType = typeof(Resources.Tables.Discount),
		 Name = nameof(Resources.Tables.Discount.DiscountPercentage))]
		public double DiscountPercentage { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.Discount),
		Name = nameof(Resources.Tables.Discount.StartDate))]
		public DateTime StartDate { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.Discount),
		Name = nameof(Resources.Tables.Discount.EndDate))]
		public DateTime EndDate { get; set; }
		//**********

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.General),
		Name = nameof(Resources.Tables.General.IsActive))]
		public bool IsActive { get; set; }
		//**********
	}
}

