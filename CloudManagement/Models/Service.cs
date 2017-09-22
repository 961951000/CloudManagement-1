using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 服务信息表
	/// </summary>
	[Table("Service")]
	public class Service
	{
		#region Model
		/// <summary>
		/// 服务编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ServiceId", Order = 0)]
		public int? ServiceId
		{
			set;
			get;
		}

		/// <summary>
		/// 服务名称
		/// </summary>
		[Column("ServiceName")]
		public string ServiceName
		{
			set;
			get;
		}

		/// <summary>
		/// 服务代码
		/// </summary>
		[Column("ServiceCode")]
		public string ServiceCode
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "ServiceId=" + ServiceId + ",ServiceName=" + ServiceName + ",ServiceCode=" + ServiceCode;
		}
		#endregion Model
	}
}
