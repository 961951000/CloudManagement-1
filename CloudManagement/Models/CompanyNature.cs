using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("CompanyNature")]
	public class CompanyNature
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("NatureID", Order = 0)]
		public short? NatureID
		{
			set;
			get;
		}

		[Column("NatureName")]
		public string NatureName
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "NatureID=" + NatureID + ",NatureName=" + NatureName;
		}
		#endregion Model
	}
}
