using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("Province")]
	public class Province
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ProvinceID", Order = 0)]
		public int? ProvinceID
		{
			set;
			get;
		}

		[Column("ProvinceCode")]
		public string ProvinceCode
		{
			set;
			get;
		}

		[Column("ProvinceName")]
		public string ProvinceName
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "ProvinceID=" + ProvinceID + ",ProvinceCode=" + ProvinceCode + ",ProvinceName=" + ProvinceName;
		}
		#endregion Model
	}
}
