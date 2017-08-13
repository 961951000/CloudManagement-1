using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("RoleNature")]
	public class RoleNature
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RoleID", Order = 0)]
		public short? RoleID
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

		public override string ToString()
		{
			return "RoleID=" + RoleID + ",RoleName=" + RoleName;
		}
		#endregion Model
	}
}
