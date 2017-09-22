using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	/// <summary>
	/// 用户详细信息表
	/// </summary>
	[Table("UserDetail")]
	public class UserDetail
	{
		#region Model
		/// <summary>
		/// 用户详细信息编号
		/// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("UserDetailId", Order = 0)]
		public int? UserDetailId
		{
			set;
			get;
		}

		/// <summary>
		/// 用户名
		/// </summary>
		[Column("UserPrincipalName")]
		public string UserPrincipalName
		{
			set;
			get;
		}

		/// <summary>
		/// 账号状态
		/// </summary>
		[Column("AccountEnabled")]
		public string AccountEnabled
		{
			set;
			get;
		}

		/// <summary>
		/// 密码
		/// </summary>
		[Column("Password")]
		public string Password
		{
			set;
			get;
		}

		/// <summary>
		/// 别名
		/// </summary>
		[Column("MailNickname")]
		public string MailNickname
		{
			set;
			get;
		}

		/// <summary>
		/// 显示名称
		/// </summary>
		[Column("DisplayName")]
		public string DisplayName
		{
			set;
			get;
		}

		/// <summary>
		/// 名字
		/// </summary>
		[Column("GivenName")]
		public string GivenName
		{
			set;
			get;
		}

		/// <summary>
		/// 姓氏
		/// </summary>
		[Column("Surname")]
		public string Surname
		{
			set;
			get;
		}

		/// <summary>
		/// 职务
		/// </summary>
		[Column("JobTitle")]
		public string JobTitle
		{
			set;
			get;
		}

		/// <summary>
		/// 部门
		/// </summary>
		[Column("Department")]
		public string Department
		{
			set;
			get;
		}

		/// <summary>
		/// 街道地址
		/// </summary>
		[Column("StreetAddress")]
		public string StreetAddress
		{
			set;
			get;
		}

		/// <summary>
		/// 城市
		/// </summary>
		[Column("City")]
		public string City
		{
			set;
			get;
		}

		/// <summary>
		/// 省/自治区/直辖市
		/// </summary>
		[Column("State")]
		public string State
		{
			set;
			get;
		}

		/// <summary>
		/// 国家或地区
		/// </summary>
		[Column("Country")]
		public string Country
		{
			set;
			get;
		}

		/// <summary>
		/// 办公室号码
		/// </summary>
		[Column("PhysicalDeliveryOfficeName")]
		public string PhysicalDeliveryOfficeName
		{
			set;
			get;
		}

		/// <summary>
		/// 办公电话
		/// </summary>
		[Column("TelephoneNumber")]
		public string TelephoneNumber
		{
			set;
			get;
		}

		/// <summary>
		/// 邮政编码
		/// </summary>
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
