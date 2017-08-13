using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("CompanyCategory")]
	public class CompanyCategory
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CategoryID", Order = 0)]
		public short? CategoryID
		{
			set;
			get;
		}

		[Column("CategoryName")]
		public string CategoryName
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "CategoryID=" + CategoryID + ",CategoryName=" + CategoryName;
		}
		#endregion Model
	}
}
