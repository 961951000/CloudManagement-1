using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("Permission")]
	public class Permission
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("PermissionId", Order = 0)]
		public int? PermissionId
		{
			set;
			get;
		}

		[Column("PermissionName")]
		public string PermissionName
		{
			set;
			get;
		}

		[Column("PermissionCode")]
		public string PermissionCode
		{
			set;
			get;
		}

		[Column("ServiceId")]
		public int? ServiceId
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "PermissionId=" + PermissionId + ",PermissionName=" + PermissionName + ",PermissionCode=" + PermissionCode + ",ServiceId=" + ServiceId;
		}
		#endregion Model
	}
}
