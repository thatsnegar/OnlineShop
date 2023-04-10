using Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
	public class Answer : Entity
	{
		public Answer()
		{
		}

		//**********
		public int DisplayOrder { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Answer),
			Name = nameof(Resources.Tables.Answer.Text))]
		public string? Text { get; set; }
		//**********

		#region Relation One To Many with Question
		//**********
		[ForeignKey(nameof(Question))]
		public System.Guid? QuestionId { get; set; }

		public virtual Models.Question? Question { get; set; }
		//**********
		#endregion

		#region Relation one to many with Product
		//**********
		[ForeignKey(nameof(Product))]
		public Guid? ProductId { get; set; }

		public virtual Models.Product? Product { get; set; }
		//**********
		#endregion
	}
}
