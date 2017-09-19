using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("Service")]
	public class Service
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("ServiceId", Order = 0)]
		public int? ServiceId
		{
			set;
			get;
		}

		[Column("ServiceName")]
		public string ServiceName
		{
			set;
			get;
		}

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
