using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("RolePermissionMapping")]
	public class RolePermissionMapping
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RolePermissionMappingId", Order = 0)]
		public int? RolePermissionMappingId
		{
			set;
			get;
		}

		[Column("RoleId")]
		public int? RoleId
		{
			set;
			get;
		}

		[Column("PermissionId")]
		public int? PermissionId
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "RolePermissionMappingId=" + RolePermissionMappingId + ",RoleId=" + RoleId + ",PermissionId=" + PermissionId;
		}
		#endregion Model
	}
}
