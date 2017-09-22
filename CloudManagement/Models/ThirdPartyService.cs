using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 第三方服务信息表
	/// </summary>
	[Table("ThirdPartyService")]
	public class ThirdPartyService
	{
		#region Model
		/// <summary>
		/// 第三方服务编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ThirdPartyServiceId", Order = 0)]
		public int? ThirdPartyServiceId
		{
			set;
			get;
		}

		/// <summary>
		/// 第三方服务名称
		/// </summary>
		[Column("ThirdPartyServiceName")]
		public string ThirdPartyServiceName
		{
			set;
			get;
		}

		/// <summary>
		/// 第三方服务代码
		/// </summary>
		[Column("ThirdPartyServiceCode")]
		public string ThirdPartyServiceCode
		{
			set;
			get;
		}

		/// <summary>
		/// 绑定令牌
		/// </summary>
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
