using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.AdminViewModels.Questions
{
	public class IndexViewModel : Object
	{
		public IndexViewModel() : base()
		{
		}

		//**********
		public Guid Id { get; set; }
		//**********

		//**********
		[Display(
		   ResourceType = typeof(Resources.Tables.General),
		   Name = nameof(Resources.Tables.General.IsActive))]
		public bool IsActive { get; set; }
		//**********

		//**********
		public bool IsEditted { get; set; }
		//**********

		//**********
		[Display(ResourceType = typeof(Resources.Tables.General),
		  Name = nameof(Resources.Tables.General.InsertDateTime))]
		public DateTime InsertDateTime { get; set; }
		//**********

		//**********
		[Display(ResourceType = typeof(Resources.Tables.General),
			Name = nameof(Resources.Tables.General.UpdateDateTime))]
		public DateTime UpdateDateTime { get; set; }
		//**********

		//**********
		[Display(
		   ResourceType = typeof(Resources.Tables.Question),
		   Name = nameof(Resources.Tables.Question.Title))]
		public string? QuestionTitle { get; set; }
		//**********

		public Guid? ProductId { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Product),
			Name = nameof(Resources.Tables.Product.Title))]
		public string? ProductName { get; set; }
		//**********

		//**********
		[Display(
			ResourceType = typeof(Resources.Tables.Product),
			Name = nameof(Resources.Tables.Product.DisplayOrder))]
		public int DisplayOrder { get; set; }
		//**********
	}
}
