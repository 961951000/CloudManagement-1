using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 用户组角色映射表
	/// </summary>
	[Table("UserGroupRoleMapping")]
	public class UserGroupRoleMapping
	{
		#region Model
		/// <summary>
		/// 用户组角色映射编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserGroupRoleMappingId", Order = 0)]
		public int? UserGroupRoleMappingId
		{
			set;
			get;
		}

		/// <summary>
		/// 用户组编号
		/// </summary>
		[Column("UserGroupId")]
		public int? UserGroupId
		{
			set;
			get;
		}

		/// <summary>
		/// 角色编号
		/// </summary>
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
