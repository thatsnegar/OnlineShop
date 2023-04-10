using Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public class User : Entity
	{
		public User() : base()
		{
			IsActive = false;
		}


		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.Gender))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public Domain.Enums.Gender Gender { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.DataDictionary),
			Name = nameof(Resources.Tables.DataDictionary.IsActive))]
		public bool IsActive { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.FirstName))]
		public string? FirstName { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.LastName))]
		public string? LastName { get; set; }
		//**********

		//**********
		public string? FullName { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.Username))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Username { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.EmailAddress))]
		public string? EmailAddress { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.MENumber))]
		public string? MENumber { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.PhoneNumber))]
		public string? PhoneNumber { get; set; }
		//**********

		//**********
		public string? CellPhoneNumber { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.User),
			Name = nameof(Resources.Tables.User.Password))]
		[Required(
			ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
			ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.Required))]
		public string? Password { get; set; }
		//**********

		//**********
		public string? ActivationCode { get; set; }
		//**********

		public string? GetFullName()
		{
			var fullName =
				$"{this.FirstName} {this.LastName}";

			return fullName;
		}

		//**********
		public DateTime BirthDate { get; set; }
		//**********

		//**********
		public string? NationalCode { get; set; }
		//**********

		//**********
		public string? OfficeAddress { get; set; }
		//**********

		//**********
		public string? Especialty { get; set; }
		//**********

		#region Relation one to one with File
		//**********
		public virtual Models.File? File { get; set; }
		//**********
		#endregion

		#region Relation one to many with Roles
		// ********** 
		public Guid RoleId { get; set; }

		public virtual Models.Role? Role { get; set; }
		// ********** 
		#endregion

		#region Relation one to many with Orders
		// ********** 
		public virtual System.Collections.Generic.IList<Models.Order>? Orders { get; set; }
		// ********** 
		#endregion

		#region Relation One To Many with UserLogin
		//**********
		public virtual List<UserLogin>? UserLogins { get; set; }
		//**********
		#endregion

		#region Relation One To Many with wishList Product
		//**********
		public virtual List<WishListProduct>? WishListProducts { get; set; }
		//**********
		#endregion
	}
}