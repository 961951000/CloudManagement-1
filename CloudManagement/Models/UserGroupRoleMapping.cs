using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("UserGroupRoleMapping")]
	public class UserGroupRoleMapping
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserGroupRoleMappingId", Order = 0)]
		public int? UserGroupRoleMappingId
		{
			set;
			get;
		}

		[Column("UserGroupId")]
		public int? UserGroupId
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

		public override string ToString()
		{
			return "UserGroupRoleMappingId=" + UserGroupRoleMappingId + ",UserGroupId=" + UserGroupId + ",RoleId=" + RoleId;
		}
		#endregion Model
	}
}
