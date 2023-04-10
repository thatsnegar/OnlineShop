using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class Discount : Entity
	{
		public Discount()
		{
			IsActive = false;
			IsTimeRegister = false;
		}

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

		//**********
		[Display(
		ResourceType = typeof(Resources.Tables.General),
		Name = nameof(Resources.Tables.General.IsActive))]
		public bool IsTimeRegister { get; set; }
		//**********

		#region Relation one to many with Users
		// ********** 
		public Guid? UserId { get; set; }

		public virtual Models.User? User { get; set; }
		// ********** 
		#endregion
	}
}
