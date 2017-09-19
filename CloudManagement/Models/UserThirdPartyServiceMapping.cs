using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("UserThirdPartyServiceMapping")]
	public class UserThirdPartyServiceMapping
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserThirdPartyServiceMappingId", Order = 0)]
		public int? UserThirdPartyServiceMappingId
		{
			set;
			get;
		}

		[Column("UserId")]
		public int? UserId
		{
			set;
			get;
		}

		[Column("ThirdPartyServiceId")]
		public int? ThirdPartyServiceId
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "UserThirdPartyServiceMappingId=" + UserThirdPartyServiceMappingId + ",UserId=" + UserId + ",ThirdPartyServiceId=" + ThirdPartyServiceId;
		}
		#endregion Model
	}
}
