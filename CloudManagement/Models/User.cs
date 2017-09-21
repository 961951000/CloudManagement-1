using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
    [Table("User")]
    public class User
    {
        #region Model
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserId", Order = 0)]
        public int? UserId
        {
            set;
            get;
        }

        [Column("Token")]
        public string Token
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

        [Column("UserDetailId")]
        public int? UserDetailId
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
