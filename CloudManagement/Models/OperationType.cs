using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("OperationType")]
	public class OperationType
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("OperationTypeId", Order = 0)]
		public int? OperationTypeId
		{
			set;
			get;
		}

		[Column("OperationName")]
		public string OperationName
		{
			set;
			get;
		}

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
