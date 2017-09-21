using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
    [Table("Tenant")]
    public class Tenant
    {
        #region Model
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TenantId", Order = 0)]
        public int? TenantId
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

        [Column("TenantDetailId")]
        public int? TenantDetailId
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

        public ICollection<User> User { get; set; }

        [ForeignKey("TenantDetailId")]
        public TenantDetail TenantDetail { get; set; }

        [ForeignKey("CreateByUserId")]
        public User CreateByUser { get; set; }

        public override string ToString()
        {
            return "TenantId=" + TenantId + ",CreateTime=" + CreateTime + ",UpdateTime=" + UpdateTime + ",TenantDetailId=" + TenantDetailId + ",CreateByUserId=" + CreateByUserId;
        }
        #endregion Model
    }
}
