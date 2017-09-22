using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 操作日志表
	/// </summary>
	[Table("OperationLog")]
	public class OperationLog
	{
		#region Model
		/// <summary>
		/// 操作日志编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("OperationLogId", Order = 0)]
		public int? OperationLogId
		{
			set;
			get;
		}

		/// <summary>
		/// 日志内容
		/// </summary>
		[Column("Context")]
		public string Context
		{
			set;
			get;
		}

		/// <summary>
		/// 日志添加时间
		/// </summary>
		[Column("CreateTime")]
		public DateTime? CreateTime
		{
			set;
			get;
		}

		/// <summary>
		/// 操作类型编号
		/// </summary>
		[Column("OperationTypeId")]
		public int? OperationTypeId
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

		public override string ToString()
		{
			return "OperationLogId=" + OperationLogId + ",Context=" + Context + ",CreateTime=" + CreateTime + ",OperationTypeId=" + OperationTypeId + ",UserId=" + UserId;
		}
		#endregion Model
	}
}
