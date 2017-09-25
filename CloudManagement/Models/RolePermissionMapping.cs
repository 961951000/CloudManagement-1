using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
    /// <summary>
    /// 角色权限映射表
    /// </summary>
    [Table("RolePermissionMapping")]
    public class RolePermissionMapping
    {
        #region Model
        /// <summary>
        /// 角色权限映射编号
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RolePermissionMappingId", Order = 0)]
        public int? RolePermissionMappingId
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

        /// <summary>
        /// 权限编号
        /// </summary>
        [Column("PermissionId")]
        public int? PermissionId
        {
            set;
            get;
        }

        /// <summary>
        /// 角色信息
        /// </summary>
        [ForeignKey("RoleId")]
        public Role Role
        {
            set;
            get;
        }

        /// <summary>
        /// 权限信息
        /// </summary>
        [ForeignKey("PermissionId")]
        public Permission Permission
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
