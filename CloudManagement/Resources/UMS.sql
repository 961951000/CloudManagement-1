/*
Navicat SQL Server Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 110000
Source Host           : 127.0.0.1:1433
Source Database       : UMS
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2017-09-20 02:52:24
*/


-- ----------------------------
-- Table structure for OperationLog
-- ----------------------------
DROP TABLE [dbo].[OperationLog]
GO
CREATE TABLE [dbo].[OperationLog] (
[OperationLogId] int NOT NULL IDENTITY(1,1) ,
[Context] varchar(255) NULL ,
[CreateTime] datetime NULL ,
[OperationTypeId] int NOT NULL ,
[UserId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for OperationType
-- ----------------------------
DROP TABLE [dbo].[OperationType]
GO
CREATE TABLE [dbo].[OperationType] (
[OperationTypeId] int NOT NULL IDENTITY(1,1) ,
[OperationName] varchar(255) NULL ,
[TypeCode] varchar(255) NULL 
)


GO

-- ----------------------------
-- Table structure for Permission
-- ----------------------------
DROP TABLE [dbo].[Permission]
GO
CREATE TABLE [dbo].[Permission] (
[PermissionId] int NOT NULL IDENTITY(1,1) ,
[PermissionName] varchar(255) NULL ,
[PermissionCode] varchar(255) NULL ,
[ServiceId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Role
-- ----------------------------
DROP TABLE [dbo].[Role]
GO
CREATE TABLE [dbo].[Role] (
[RoleId] int NOT NULL IDENTITY(1,1) ,
[RoleName] varchar(255) NULL ,
[CreateTime] datetime NULL ,
[UpdateTime] datetime NULL ,
[CreateByUserId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for RolePermissionMapping
-- ----------------------------
DROP TABLE [dbo].[RolePermissionMapping]
GO
CREATE TABLE [dbo].[RolePermissionMapping] (
[RolePermissionMappingId] int NOT NULL IDENTITY(1,1) ,
[RoleId] int NOT NULL ,
[PermissionId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for Service
-- ----------------------------
DROP TABLE [dbo].[Service]
GO
CREATE TABLE [dbo].[Service] (
[ServiceId] int NOT NULL IDENTITY(1,1) ,
[ServiceName] varchar(255) NULL ,
[ServiceCode] varchar(255) NULL 
)


GO

-- ----------------------------
-- Table structure for Tenant
-- ----------------------------
DROP TABLE [dbo].[Tenant]
GO
CREATE TABLE [dbo].[Tenant] (
[TenantId] int NOT NULL IDENTITY(1,1) ,
[CreateTime] datetime NULL ,
[UpdateTime] datetime NULL ,
[TenantDetailId] int NOT NULL ,
[CreateByUserId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for TenantDetail
-- ----------------------------
DROP TABLE [dbo].[TenantDetail]
GO
CREATE TABLE [dbo].[TenantDetail] (
[TenantDetailId] int NOT NULL IDENTITY(1,1) ,
[TenantPrincipalName] varchar(255) NULL ,
[RegistrationNumber] varchar(255) NULL ,
[BusinessLicense] varchar(255) NULL ,
[OrganizationCode] varchar(255) NULL ,
[TaxRegistrationCertificate] varchar(255) NULL ,
[LegalRepresentative] varchar(255) NULL ,
[Address] varchar(255) NULL ,
[RegisteredCapital] varchar(255) NULL ,
[EnterpriseStatus] varchar(255) NULL ,
[CompanyType] varchar(255) NULL ,
[EstablishmentDate] date NULL ,
[BusinessTerm] varchar(255) NULL ,
[RegistrationAuthority] varchar(255) NULL ,
[AcceptingOrgans] varchar(255) NULL ,
[BusinessScope] varchar(255) NULL 
)


GO

-- ----------------------------
-- Table structure for ThirdPartyService
-- ----------------------------
DROP TABLE [dbo].[ThirdPartyService]
GO
CREATE TABLE [dbo].[ThirdPartyService] (
[ThirdPartyServiceId] int NOT NULL IDENTITY(1,1) ,
[ThirdPartyServiceName] varchar(255) NULL ,
[ThirdPartyServiceCode] varchar(255) NULL ,
[BindToken] varchar(255) NULL 
)


GO

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE [dbo].[User]
GO
CREATE TABLE [dbo].[User] (
[UserId] int NOT NULL IDENTITY(1,1) ,
[Token] varchar(255) NULL ,
[CreateTime] datetime NULL ,
[UpdateTime] datetime NULL ,
[UserDetailId] int NOT NULL ,
[UserGroupId] int NULL ,
[TenantId] int NULL 
)


GO

-- ----------------------------
-- Table structure for UserDetail
-- ----------------------------
DROP TABLE [dbo].[UserDetail]
GO
CREATE TABLE [dbo].[UserDetail] (
[UserDetailId] int NOT NULL IDENTITY(1,1) ,
[UserPrincipalName] varchar(255) NULL ,
[AccountEnabled] varchar(255) NULL ,
[Password] varchar(255) NULL ,
[MailNickname] varchar(255) NULL ,
[DisplayName] varchar(255) NULL ,
[GivenName] varchar(255) NULL ,
[Surname] varchar(255) NULL ,
[JobTitle] varchar(255) NULL ,
[Department] varchar(255) NULL ,
[StreetAddress] varchar(255) NULL ,
[City] varchar(255) NULL ,
[State] varchar(255) NULL ,
[Country] varchar(255) NULL ,
[PhysicalDeliveryOfficeName] varchar(255) NULL ,
[TelephoneNumber] varchar(255) NULL ,
[PostalCode] varchar(255) NULL 
)


GO

-- ----------------------------
-- Table structure for UserGroup
-- ----------------------------
DROP TABLE [dbo].[UserGroup]
GO
CREATE TABLE [dbo].[UserGroup] (
[UserGroupId] int NOT NULL IDENTITY(1,1) ,
[UserGroupName] varchar(255) NULL ,
[CreateTime] datetime NULL ,
[UpdateTime] datetime NULL ,
[CreateByUserId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for UserGroupRoleMapping
-- ----------------------------
DROP TABLE [dbo].[UserGroupRoleMapping]
GO
CREATE TABLE [dbo].[UserGroupRoleMapping] (
[UserGroupRoleMappingId] int NOT NULL IDENTITY(1,1) ,
[UserGroupId] int NOT NULL ,
[RoleId] int NOT NULL 
)


GO

-- ----------------------------
-- Table structure for UserThirdPartyServiceMapping
-- ----------------------------
DROP TABLE [dbo].[UserThirdPartyServiceMapping]
GO
CREATE TABLE [dbo].[UserThirdPartyServiceMapping] (
[UserThirdPartyServiceMappingId] int NOT NULL IDENTITY(1,1) ,
[UserId] int NOT NULL ,
[ThirdPartyServiceId] int NOT NULL 
)


GO

-- ----------------------------
-- Indexes structure for table OperationLog
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table OperationLog
-- ----------------------------
ALTER TABLE [dbo].[OperationLog] ADD PRIMARY KEY ([OperationLogId])
GO

-- ----------------------------
-- Indexes structure for table OperationType
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table OperationType
-- ----------------------------
ALTER TABLE [dbo].[OperationType] ADD PRIMARY KEY ([OperationTypeId])
GO

-- ----------------------------
-- Indexes structure for table Permission
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Permission
-- ----------------------------
ALTER TABLE [dbo].[Permission] ADD PRIMARY KEY ([PermissionId])
GO

-- ----------------------------
-- Indexes structure for table Role
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Role
-- ----------------------------
ALTER TABLE [dbo].[Role] ADD PRIMARY KEY ([RoleId])
GO

-- ----------------------------
-- Indexes structure for table RolePermissionMapping
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table RolePermissionMapping
-- ----------------------------
ALTER TABLE [dbo].[RolePermissionMapping] ADD PRIMARY KEY ([RolePermissionMappingId])
GO

-- ----------------------------
-- Indexes structure for table Service
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Service
-- ----------------------------
ALTER TABLE [dbo].[Service] ADD PRIMARY KEY ([ServiceId])
GO

-- ----------------------------
-- Indexes structure for table Tenant
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Tenant
-- ----------------------------
ALTER TABLE [dbo].[Tenant] ADD PRIMARY KEY ([TenantId])
GO

-- ----------------------------
-- Indexes structure for table TenantDetail
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table TenantDetail
-- ----------------------------
ALTER TABLE [dbo].[TenantDetail] ADD PRIMARY KEY ([TenantDetailId])
GO

-- ----------------------------
-- Uniques structure for table TenantDetail
-- ----------------------------
ALTER TABLE [dbo].[TenantDetail] ADD UNIQUE ([RegistrationNumber] ASC)
GO

-- ----------------------------
-- Indexes structure for table ThirdPartyService
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table ThirdPartyService
-- ----------------------------
ALTER TABLE [dbo].[ThirdPartyService] ADD PRIMARY KEY ([ThirdPartyServiceId])
GO

-- ----------------------------
-- Indexes structure for table User
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD PRIMARY KEY ([UserId])
GO

-- ----------------------------
-- Indexes structure for table UserDetail
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table UserDetail
-- ----------------------------
ALTER TABLE [dbo].[UserDetail] ADD PRIMARY KEY ([UserDetailId])
GO

-- ----------------------------
-- Uniques structure for table UserDetail
-- ----------------------------
ALTER TABLE [dbo].[UserDetail] ADD UNIQUE ([UserPrincipalName] ASC)
GO

-- ----------------------------
-- Indexes structure for table UserGroup
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table UserGroup
-- ----------------------------
ALTER TABLE [dbo].[UserGroup] ADD PRIMARY KEY ([UserGroupId])
GO

-- ----------------------------
-- Indexes structure for table UserGroupRoleMapping
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table UserGroupRoleMapping
-- ----------------------------
ALTER TABLE [dbo].[UserGroupRoleMapping] ADD PRIMARY KEY ([UserGroupRoleMappingId])
GO

-- ----------------------------
-- Indexes structure for table UserThirdPartyServiceMapping
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table UserThirdPartyServiceMapping
-- ----------------------------
ALTER TABLE [dbo].[UserThirdPartyServiceMapping] ADD PRIMARY KEY ([UserThirdPartyServiceMappingId])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[OperationLog]
-- ----------------------------
ALTER TABLE [dbo].[OperationLog] ADD FOREIGN KEY ([OperationTypeId]) REFERENCES [dbo].[OperationType] ([OperationTypeId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[OperationLog] ADD FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Permission]
-- ----------------------------
ALTER TABLE [dbo].[Permission] ADD FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Service] ([ServiceId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Role]
-- ----------------------------
ALTER TABLE [dbo].[Role] ADD FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[RolePermissionMapping]
-- ----------------------------
ALTER TABLE [dbo].[RolePermissionMapping] ADD FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([PermissionId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[RolePermissionMapping] ADD FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[Tenant]
-- ----------------------------
ALTER TABLE [dbo].[Tenant] ADD FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[Tenant] ADD FOREIGN KEY ([TenantDetailId]) REFERENCES [dbo].[TenantDetail] ([TenantDetailId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[User]
-- ----------------------------
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([TenantId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([UserDetailId]) REFERENCES [dbo].[UserDetail] ([UserDetailId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[UserGroup]
-- ----------------------------
ALTER TABLE [dbo].[UserGroup] ADD FOREIGN KEY ([CreateByUserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[UserGroupRoleMapping]
-- ----------------------------
ALTER TABLE [dbo].[UserGroupRoleMapping] ADD FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[UserGroupRoleMapping] ADD FOREIGN KEY ([UserGroupId]) REFERENCES [dbo].[UserGroup] ([UserGroupId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[UserThirdPartyServiceMapping]
-- ----------------------------
ALTER TABLE [dbo].[UserThirdPartyServiceMapping] ADD FOREIGN KEY ([ThirdPartyServiceId]) REFERENCES [dbo].[ThirdPartyService] ([ThirdPartyServiceId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[UserThirdPartyServiceMapping] ADD FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
