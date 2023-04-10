using Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class File : Entity
	{
		public File() : base()
		{
			IsMainFile = false;
			IsAfterImage = false;
			IsBeforeImage = false;
			IsThumbnailImage = false;
		}

		//**********
		[Display(
		   ResourceType = typeof(Resources.Tables.File),
		   Name = nameof(Resources.Tables.File.Name))]
		[MaxLength(length: 250,
		   ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
		   ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? Name { get; set; }
		//**********

		//**********
		public string? ContentType { get; set; }
		//**********

		//**********
		public string? Path { get; set; }
		//**********

		//**********
		[Display(
		   ResourceType = typeof(Resources.Tables.File),
		   Name = nameof(Resources.Tables.File.Alt))]
		[MaxLength(length: 250,
		   ErrorMessageResourceType = typeof(Resources.Messages.ErrorMessages),
		   ErrorMessageResourceName = nameof(Resources.Messages.ErrorMessages.MaxLength))]
		public string? Alt { get; set; }
		//**********

		//**********
		public long Size { get; set; }
		//**********

		//**********
		public bool IsMainFile { get; set; }
		//**********

		//**********
		public bool IsBeforeImage { get; set; }
		//**********

		//**********
		public bool IsAfterImage { get; set; }
		//**********

		//**********
		public bool IsThumbnailImage { get; set; }
		//**********

		#region Relation one to one with Blog
		// **********
		[ForeignKey(nameof(Blog))]
		public Guid? BlogId { get; set; }

		public virtual Blog? Blog { get; set; }
		// **********
		#endregion

		#region Relation one to one with User
		// **********
		[ForeignKey(nameof(User))]
		public Guid? UserId { get; set; }

		public virtual User? User { get; set; }
		// **********
		#endregion

		#region Relation one to one with About
		// **********
		[ForeignKey(nameof(About))]
		public Guid? AboutId { get; set; }

		public virtual About? About { get; set; }
		// **********
		#endregion

		#region Relation one to one with Image
		// **********
		[ForeignKey(nameof(Image))]
		public Guid? ImageId { get; set; }

		public virtual Image? Image { get; set; }
		// **********
		#endregion

		#region Relation one to one with Banner
		// **********
		[ForeignKey(nameof(Banner))]
		public Guid? BannerId { get; set; }

		public virtual Banner? Banner { get; set; }
		// **********
		#endregion

		#region Relation one to one with slider
		// **********
		[ForeignKey(nameof(Slider))]
		public Guid? SliderId { get; set; }

		public virtual Slider? Slider { get; set; }
		// **********
		#endregion

		#region Relation one To many with Product
		//**********
		[ForeignKey(nameof(Product))]
		public Guid? ProductId { get; set; }

		public virtual Product? Product { get; set; }
		//**********
		#endregion

		#region Relation one To many with ComparisonProduct
		//**********
		[ForeignKey(nameof(ComparisonProduct))]
		public Guid? ComParisonProductId { get; set; }

		public virtual ComparisonProduct? ComparisonProduct { get; set; }
		//**********
		#endregion

		#region Relation one to one with ScientificInfo
		// **********
		[ForeignKey(nameof(ScientificInfo))]
		public Guid? ScientificInfoId { get; set; }

		public virtual ScientificInfo? ScientificInfo { get; set; }
		// **********
		#endregion

		#region Relation one to one with ProductCategory
		// **********
		[ForeignKey(nameof(ProductCategory))]
		public Guid? ProductCategoryId { get; set; }

		public virtual ProductCategory? ProductCategory { get; set; }
		// **********
		#endregion
	}
}
