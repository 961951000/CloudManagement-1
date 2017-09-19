using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudManagement.Models
{
	[Table("TenantDetail")]
	public class TenantDetail
	{
		#region Model
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("TenantDetailId", Order = 0)]
		public int? TenantDetailId
		{
			set;
			get;
		}

		[Column("TenantPrincipalName")]
		public string TenantPrincipalName
		{
			set;
			get;
		}

		[Column("RegistrationNumber")]
		public string RegistrationNumber
		{
			set;
			get;
		}

		[Column("BusinessLicense")]
		public string BusinessLicense
		{
			set;
			get;
		}

		[Column("OrganizationCode")]
		public string OrganizationCode
		{
			set;
			get;
		}

		[Column("TaxRegistrationCertificate")]
		public string TaxRegistrationCertificate
		{
			set;
			get;
		}

		[Column("LegalRepresentative")]
		public string LegalRepresentative
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

		[Column("RegisteredCapital")]
		public string RegisteredCapital
		{
			set;
			get;
		}

		[Column("EnterpriseStatus")]
		public string EnterpriseStatus
		{
			set;
			get;
		}

		[Column("CompanyType")]
		public string CompanyType
		{
			set;
			get;
		}

		[Column("EstablishmentDate")]
		public DateTime? EstablishmentDate
		{
			set;
			get;
		}

		[Column("BusinessTerm")]
		public string BusinessTerm
		{
			set;
			get;
		}

		[Column("RegistrationAuthority")]
		public string RegistrationAuthority
		{
			set;
			get;
		}

		[Column("AcceptingOrgans")]
		public string AcceptingOrgans
		{
			set;
			get;
		}

		[Column("BusinessScope")]
		public string BusinessScope
		{
			set;
			get;
		}

		public override string ToString()
		{
			return "TenantDetailId=" + TenantDetailId + ",TenantPrincipalName=" + TenantPrincipalName + ",RegistrationNumber=" + RegistrationNumber + ",BusinessLicense=" + BusinessLicense + ",OrganizationCode=" + OrganizationCode + ",TaxRegistrationCertificate=" + TaxRegistrationCertificate + ",LegalRepresentative=" + LegalRepresentative + ",Address=" + Address + ",RegisteredCapital=" + RegisteredCapital + ",EnterpriseStatus=" + EnterpriseStatus + ",CompanyType=" + CompanyType + ",EstablishmentDate=" + EstablishmentDate + ",BusinessTerm=" + BusinessTerm + ",RegistrationAuthority=" + RegistrationAuthority + ",AcceptingOrgans=" + AcceptingOrgans + ",BusinessScope=" + BusinessScope;
		}
		#endregion Model
	}
}
