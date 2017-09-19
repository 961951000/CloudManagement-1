using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("OperationLog")]
	public class OperationLog
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("OperationLogId", Order = 0)]
		public int? OperationLogId
		{
			set;
			get;
		}

		[Column("Context")]
		public string Context
		{
			set;
			get;
		}

		[Column("CreateTime")]
		public DateTime? CreateTime
		{
			set;
			get;
		}

		[Column("OperationTypeId")]
		public int? OperationTypeId
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

		public override string ToString()
		{
			return "OperationLogId=" + OperationLogId + ",Context=" + Context + ",CreateTime=" + CreateTime + ",OperationTypeId=" + OperationTypeId + ",UserId=" + UserId;
		}
		#endregion Model
	}
}
