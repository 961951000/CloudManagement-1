using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
    /// <summary>
    /// 租户信息表
    /// </summary>
    [Table("Tenant")]
    public class Tenant
    {
        #region Model
        /// <summary>
        /// 租户编号
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TenantId", Order = 0)]
        public int? TenantId
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
        /// 租户详细信息编号
        /// </summary>
        [Column("TenantDetailId")]
        public int? TenantDetailId
        {
            set;
            get;
        }

        /// <summary>
        /// 创建人
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
        public IEnumerable<User> User { get; set; }

        /// <summary>
        /// 租户详细信息
        /// </summary>
        [ForeignKey("TenantDetailId")]
        public TenantDetail TenantDetail { get; set; }

        /// <summary>
        /// 租户创建人
        /// </summary>
        [ForeignKey("CreateByUserId")]
        public User CreateByUser { get; set; }

        public override string ToString()
        {
            return "TenantId=" + TenantId + ",CreateTime=" + CreateTime + ",UpdateTime=" + UpdateTime + ",TenantDetailId=" + TenantDetailId + ",CreateByUserId=" + CreateByUserId;
        }
        #endregion Model
    }
}
