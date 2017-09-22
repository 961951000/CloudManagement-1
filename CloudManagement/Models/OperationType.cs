using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 操作类型表
	/// </summary>
	[Table("OperationType")]
	public class OperationType
	{
		#region Model
		/// <summary>
		/// 操作类型编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("OperationTypeId", Order = 0)]
		public int? OperationTypeId
		{
			set;
			get;
		}

		/// <summary>
		/// 操作名称
		/// </summary>
		[Column("OperationName")]
		public string OperationName
		{
			set;
			get;
		}

		/// <summary>
		/// 类型代码
		/// </summary>
		[Column("TypeCode")]
		public string TypeCode
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "OperationTypeId=" + OperationTypeId + ",OperationName=" + OperationName + ",TypeCode=" + TypeCode;
		}
		#endregion Model
	}
}
