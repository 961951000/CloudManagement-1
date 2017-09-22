using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 用户信息表
	/// </summary>
	[Table("User")]
	public class User
	{
		#region Model
		/// <summary>
		/// 用户编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserId", Order = 0)]
		public int? UserId
		{
			set;
			get;
		}

		/// <summary>
		/// 令牌
		/// </summary>
		[Column("Token")]
		public string Token
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
		/// 用户详细信息编号
		/// </summary>
		[Column("UserDetailId")]
		public int? UserDetailId
		{
			set;
			get;
		}

		/// <summary>
		/// 用户所在组编号
		/// </summary>
		[Column("UserGroupId")]
		public int? UserGroupId
		{
			set;
			get;
		}

		/// <summary>
		/// 用户所在企业编号
		/// </summary>
		[Column("TenantId")]
		public int? TenantId
		{
			set;
			get;
		}

	    [ForeignKey("UserDetailId")]
	    public UserDetail UserDetail { get; set; }

	    [ForeignKey("UserGroupId")]
	    public IEnumerable<UserGroup> UserGroup { get; set; }

	    [ForeignKey("TenantId")]
	    public Tenant Tenant { get; set; }

        public override string ToString()
		{
			return "UserId=" + UserId + ",Token=" + Token + ",CreateTime=" + CreateTime + ",UpdateTime=" + UpdateTime + ",UserDetailId=" + UserDetailId + ",UserGroupId=" + UserGroupId + ",TenantId=" + TenantId;
		}
		#endregion Model
	}
}
