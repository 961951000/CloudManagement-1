using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
    /// <summary>
    /// 权限信息表
    /// </summary>
    [Table("Permission")]
    public class Permission
    {
        #region Model
        /// <summary>
        /// 权限信息编号
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("PermissionId", Order = 0)]
        public int? PermissionId
        {
            set;
            get;
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        [Column("PermissionName")]
        public string PermissionName
        {
            set;
            get;
        }

        /// <summary>
        /// 描述
        /// </summary>
        [Column("Description")]
        public string Description
        {
            set;
            get;
        }

        /// <summary>
        /// 权限代码
        /// </summary>
        [Column("PermissionCode")]
        public string PermissionCode
        {
            set;
            get;
        }

        /// <summary>
        /// 服务编号
        /// </summary>
        [Column("ServiceId")]
        public int? ServiceId
        {
            set;
            get;
        }

        public override string ToString()
        {
            return "PermissionId=" + PermissionId + ",PermissionName=" + PermissionName + ",Description=" + Description + ",PermissionCode =" + PermissionCode + ",ServiceId=" + ServiceId;
        }
        #endregion Model
    }
}
