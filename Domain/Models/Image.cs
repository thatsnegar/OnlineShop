using Domain.Base;

namespace Models
{
	public class Image : Entity
	{
		public Image()
		{
		}

		//**********
		public string? ImageTitle { get; set; }
		//**********

		//**********
		public string? FirstSlogan { get; set; }
		//**********

		//**********
		public string? SecondSlogan { get; set; }
		//**********

		//**********
		public string? ThirdSlogan { get; set; }
		//**********

		#region Relation One To One With File
		//**********
		public virtual Models.File? File { get; set; }
		//**********
		#endregion
	}
}
