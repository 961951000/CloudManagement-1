using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("ThirdPartyService")]
	public class ThirdPartyService
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ThirdPartyServiceId", Order = 0)]
		public int? ThirdPartyServiceId
		{
			set;
			get;
		}

		[Column("ThirdPartyServiceName")]
		public string ThirdPartyServiceName
		{
			set;
			get;
		}

		[Column("ThirdPartyServiceCode")]
		public string ThirdPartyServiceCode
		{
			set;
			get;
		}

		[Column("BindToken")]
		public string BindToken
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "ThirdPartyServiceId=" + ThirdPartyServiceId + ",ThirdPartyServiceName=" + ThirdPartyServiceName + ",ThirdPartyServiceCode=" + ThirdPartyServiceCode + ",BindToken=" + BindToken;
		}
		#endregion Model
	}
}
