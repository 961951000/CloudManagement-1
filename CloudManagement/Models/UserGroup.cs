using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
    /// <summary>
    /// 用户组信息表
    /// </summary>
    [Table("UserGroup")]
    public class UserGroup
    {
        #region Model
        /// <summary>
        /// 用户组编号
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserGroupId", Order = 0)]
        public int? UserGroupId
        {
            set;
            get;
        }

        /// <summary>
        /// 用户组名称
        /// </summary>
        [Column("UserGroupName")]
        public string UserGroupName
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
        /// 用户信息
        /// </summary>
        public IList<User> User { get; set; }

        /// <summary>
        /// 用户组角色映射信息
        /// </summary>
        [ForeignKey("UserGroupRoleMapping.UserGroupId")]
        public UserGroupRoleMapping UserGroupRoleMapping
        {
            set;
            get;
        }

        /// <summary>
        /// 用户组创建人
        /// </summary>
        [ForeignKey("CreateByUserId")]
        public User CreateByUser { get; set; }

        public override string ToString()
        {
            return "UserGroupId=" + UserGroupId + ",UserGroupName=" + UserGroupName + ",CreateTime=" + CreateTime + ",UpdateTime=" + UpdateTime + ",CreateByUserId=" + CreateByUserId;
        }
        #endregion Model
    }
}
