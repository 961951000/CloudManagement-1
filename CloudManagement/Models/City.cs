using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("City")]
	public class City
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CityID", Order = 0)]
		public int? CityID
		{
			set;
			get;
		}

		[Column("ProvinceID")]
		public int? ProvinceID
		{
			set;
			get;
		}

		[Column("CityName")]
		public string CityName
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "CityID=" + CityID + ",ProvinceID=" + ProvinceID + ",CityName=" + CityName;
		}
		#endregion Model
	}
}
