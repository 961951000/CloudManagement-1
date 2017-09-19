using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("Role")]
	public class Role
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RoleId", Order = 0)]
		public int? RoleId
		{
			set;
			get;
		}

		[Column("RoleName")]
		public string RoleName
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

		[Column("UpdateTime")]
		public DateTime? UpdateTime
		{
			set;
			get;
		}

		[Column("CreateByUserId")]
		public int? CreateByUserId
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "RoleId=" + RoleId + ",RoleName=" + RoleName + ",CreateTime=" + CreateTime + ",UpdateTime=" + UpdateTime + ",CreateByUserId=" + CreateByUserId;
		}
		#endregion Model
	}
}
