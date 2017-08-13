using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("Country")]
	public class Country
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("CountryID", Order = 0)]
		public int? CountryID
		{
			set;
			get;
		}

		[Column("CountryCode")]
		public string CountryCode
		{
			set;
			get;
		}

		[Column("CountryName")]
		public string CountryName
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "CountryID=" + CountryID + ",CountryCode=" + CountryCode + ",CountryName=" + CountryName;
		}
		#endregion Model
	}
}
