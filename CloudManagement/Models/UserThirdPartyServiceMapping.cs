using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 用户第三方服务映射表
	/// </summary>
	[Table("UserThirdPartyServiceMapping")]
	public class UserThirdPartyServiceMapping
	{
		#region Model
		/// <summary>
		/// 用户第三方服务映射编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserThirdPartyServiceMappingId", Order = 0)]
		public int? UserThirdPartyServiceMappingId
		{
			set;
			get;
		}

		/// <summary>
		/// 用户编号
		/// </summary>
		[Column("UserId")]
		public int? UserId
		{
			set;
			get;
		}

		/// <summary>
		/// 第三方服务编号
		/// </summary>
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
