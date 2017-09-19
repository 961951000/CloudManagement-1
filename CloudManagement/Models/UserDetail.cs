using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("UserDetail")]
	public class UserDetail
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserDetailId", Order = 0)]
		public int? UserDetailId
		{
			set;
			get;
		}

		[Column("UserPrincipalName")]
		public string UserPrincipalName
		{
			set;
			get;
		}

		[Column("AccountEnabled")]
		public string AccountEnabled
		{
			set;
			get;
		}

		[Column("Password")]
		public string Password
		{
			set;
			get;
		}

		[Column("MailNickname")]
		public string MailNickname
		{
			set;
			get;
		}

		[Column("DisplayName")]
		public string DisplayName
		{
			set;
			get;
		}

		[Column("GivenName")]
		public string GivenName
		{
			set;
			get;
		}

		[Column("Surname")]
		public string Surname
		{
			set;
			get;
		}

		[Column("JobTitle")]
		public string JobTitle
		{
			set;
			get;
		}

		[Column("Department")]
		public string Department
		{
			set;
			get;
		}

		[Column("StreetAddress")]
		public string StreetAddress
		{
			set;
			get;
		}

		[Column("City")]
		public string City
		{
			set;
			get;
		}

		[Column("State")]
		public string State
		{
			set;
			get;
		}

		[Column("Country")]
		public string Country
		{
			set;
			get;
		}

		[Column("PhysicalDeliveryOfficeName")]
		public string PhysicalDeliveryOfficeName
		{
			set;
			get;
		}

		[Column("TelephoneNumber")]
		public string TelephoneNumber
		{
			set;
			get;
		}

		[Column("PostalCode")]
		public string PostalCode
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "UserDetailId=" + UserDetailId + ",UserPrincipalName=" + UserPrincipalName + ",AccountEnabled=" + AccountEnabled + ",Password=" + Password + ",MailNickname=" + MailNickname + ",DisplayName=" + DisplayName + ",GivenName=" + GivenName + ",Surname=" + Surname + ",JobTitle=" + JobTitle + ",Department=" + Department + ",StreetAddress=" + StreetAddress + ",City=" + City + ",State=" + State + ",Country=" + Country + ",PhysicalDeliveryOfficeName=" + PhysicalDeliveryOfficeName + ",TelephoneNumber=" + TelephoneNumber + ",PostalCode=" + PostalCode;
		}
		#endregion Model
	}
}
