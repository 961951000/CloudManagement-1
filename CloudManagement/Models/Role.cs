using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 角色信息表
	/// </summary>
	[Table("Role")]
	public class Role
	{
		#region Model
		/// <summary>
		/// 角色编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RoleId", Order = 0)]
		public int? RoleId
		{
			set;
			get;
		}

		/// <summary>
		/// 角色名称
		/// </summary>
		[Column("RoleName")]
		public string RoleName
		{
			set;
			get;
		}

		/// <summary>
		/// 创建时间
		/// </summary>
		[Column("CreateTime")]
		public DateTime? CreateTime
		{
			set;
			get;
		}

		/// <summary>
		/// 修改时间
		/// </summary>
		[Column("UpdateTime")]
		public DateTime? UpdateTime
		{
			set;
			get;
		}

		/// <summary>
		/// 创建用户编号
		/// </summary>
		[Column("CreateByUserId")]
		public int? CreateByUserId
		{
			set;
			get;
		}

	    /// <summary>
	    /// 角色创建人
	    /// </summary>
	    [ForeignKey("CreateByUserId")]
	    public User CreateByUser { get; set; }

        public override string ToString()
		{
			return "RoleId=" + RoleId + ",RoleName=" + RoleName + ",CreateTime=" + CreateTime + ",UpdateTime=" + UpdateTime + ",CreateByUserId=" + CreateByUserId;
		}
		#endregion Model
	}
}
