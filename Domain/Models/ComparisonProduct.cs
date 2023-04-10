using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class ComparisonProduct : Entity
	{
		public ComparisonProduct()
		{
		}

		//**********
		public string? Title { get; set; }
		//**********

		//**********
		public string? Description { get; set; }
		//**********

		#region Relation One To Many With File
		//**********
		public virtual List<File>? Files { get; set; }
		//**********
		#endregion
	}
}
