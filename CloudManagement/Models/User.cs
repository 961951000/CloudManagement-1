using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("User")]
	public class User
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserID", Order = 0)]
		public int? UserID
		{
			set;
			get;
		}

		[Column("Account")]
		public string Account
		{
			set;
			get;
		}

		[Column("PasswordKey")]
		public string PasswordKey
		{
			set;
			get;
		}

		[Column("Name")]
		public string Name
		{
			set;
			get;
		}

		[Column("RegNumber")]
		public string RegNumber
		{
			set;
			get;
		}

		[Column("PhotoPath")]
		public string PhotoPath
		{
			set;
			get;
		}

		[Column("CountryID")]
		public int? CountryID
		{
			set;
			get;
		}

		[Column("ProvinceID")]
		public int? ProvinceID
		{
			set;
			get;
		}

		[Column("CityID")]
		public int? CityID
		{
			set;
			get;
		}

		[Column("Address")]
		public string Address
		{
			set;
			get;
		}

		[Column("Phone")]
		public string Phone
		{
			set;
			get;
		}

		[Column("CompanyNatureID")]
		public short? CompanyNatureID
		{
			set;
			get;
		}

		[Column("CategoryID")]
		public short? CategoryID
		{
			set;
			get;
		}

		[Column("CertificateType")]
		public string CertificateType
		{
			set;
			get;
		}

		[Column("Email")]
		public string Email
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

		[Column("UserProfile")]
		public string UserProfile
		{
			set;
			get;
		}

		[Column("RoleFlag")]
		public short? RoleFlag
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "UserID=" + UserID + ",Account=" + Account + ",PasswordKey=" + PasswordKey + ",Name=" + Name + ",RegNumber=" + RegNumber + ",PhotoPath=" + PhotoPath + ",CountryID=" + CountryID + ",ProvinceID=" + ProvinceID + ",CityID=" + CityID + ",Address=" + Address + ",Phone=" + Phone + ",CompanyNatureID=" + CompanyNatureID + ",CategoryID=" + CategoryID + ",CertificateType=" + CertificateType + ",Email=" + Email + ",Token=" + Token + ",UserProfile=" + UserProfile + ",RoleFlag=" + RoleFlag;
		}
		#endregion Model
	}
}
