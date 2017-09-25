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

Date: 2017-09-24 21:05:02
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationLog', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作日志表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作日志表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationLog', 
'COLUMN', N'OperationLogId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作日志编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'OperationLogId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作日志编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'OperationLogId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationLog', 
'COLUMN', N'Context')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'日志内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'Context'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'日志内容'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'Context'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationLog', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'日志添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'日志添加时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationLog', 
'COLUMN', N'OperationTypeId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作类型编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'OperationTypeId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作类型编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'OperationTypeId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationLog', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationLog'
, @level2type = 'COLUMN', @level2name = N'UserId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationType', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作类型表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作类型表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationType', 
'COLUMN', N'OperationTypeId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作类型编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
, @level2type = 'COLUMN', @level2name = N'OperationTypeId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作类型编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
, @level2type = 'COLUMN', @level2name = N'OperationTypeId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationType', 
'COLUMN', N'OperationName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
, @level2type = 'COLUMN', @level2name = N'OperationName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
, @level2type = 'COLUMN', @level2name = N'OperationName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'OperationType', 
'COLUMN', N'TypeCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'类型代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
, @level2type = 'COLUMN', @level2name = N'TypeCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'类型代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'OperationType'
, @level2type = 'COLUMN', @level2name = N'TypeCode'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Permission', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权限信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权限信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Permission', 
'COLUMN', N'PermissionId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权限信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'PermissionId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权限信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'PermissionId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Permission', 
'COLUMN', N'PermissionName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权限名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'PermissionName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权限名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'PermissionName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Permission', 
'COLUMN', N'PermissionCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权限代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'PermissionCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权限代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'PermissionCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Permission', 
'COLUMN', N'ServiceId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'ServiceId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Permission'
, @level2type = 'COLUMN', @level2name = N'ServiceId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'RoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'RoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'RoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'RoleName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'RoleName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'RoleName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Role', 
'COLUMN', N'CreateByUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'CreateByUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Role'
, @level2type = 'COLUMN', @level2name = N'CreateByUserId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RolePermissionMapping', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色权限映射表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色权限映射表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RolePermissionMapping', 
'COLUMN', N'RolePermissionMappingId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色权限映射编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
, @level2type = 'COLUMN', @level2name = N'RolePermissionMappingId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色权限映射编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
, @level2type = 'COLUMN', @level2name = N'RolePermissionMappingId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RolePermissionMapping', 
'COLUMN', N'RoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
, @level2type = 'COLUMN', @level2name = N'RoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
, @level2type = 'COLUMN', @level2name = N'RoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'RolePermissionMapping', 
'COLUMN', N'PermissionId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'权限编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
, @level2type = 'COLUMN', @level2name = N'PermissionId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'权限编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'RolePermissionMapping'
, @level2type = 'COLUMN', @level2name = N'PermissionId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Service', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'服务信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'服务信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Service', 
'COLUMN', N'ServiceId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
, @level2type = 'COLUMN', @level2name = N'ServiceId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
, @level2type = 'COLUMN', @level2name = N'ServiceId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Service', 
'COLUMN', N'ServiceName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'服务名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
, @level2type = 'COLUMN', @level2name = N'ServiceName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'服务名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
, @level2type = 'COLUMN', @level2name = N'ServiceName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Service', 
'COLUMN', N'ServiceCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'服务代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
, @level2type = 'COLUMN', @level2name = N'ServiceCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'服务代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Service'
, @level2type = 'COLUMN', @level2name = N'ServiceCode'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Tenant', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'租户信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'租户信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Tenant', 
'COLUMN', N'TenantId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'租户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'TenantId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'租户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'TenantId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Tenant', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Tenant', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Tenant', 
'COLUMN', N'TenantDetailId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'租户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'TenantDetailId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'租户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'TenantDetailId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'Tenant', 
'COLUMN', N'CreateByUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'CreateByUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建人'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'Tenant'
, @level2type = 'COLUMN', @level2name = N'CreateByUserId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'租户详细信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'租户详细信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'TenantDetailId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'租户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'TenantDetailId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'租户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'TenantDetailId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'TenantPrincipalName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'租户名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'TenantPrincipalName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'租户名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'TenantPrincipalName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'RegistrationNumber')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'统一社会信用码/注册号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'RegistrationNumber'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'统一社会信用码/注册号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'RegistrationNumber'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'BusinessLicense')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'工商营业执照'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'BusinessLicense'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'工商营业执照'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'BusinessLicense'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'OrganizationCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'组织机构代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'OrganizationCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'组织机构代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'OrganizationCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'TaxRegistrationCertificate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'税务登记证'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'TaxRegistrationCertificate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'税务登记证'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'TaxRegistrationCertificate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'LegalRepresentative')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'法定代表人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'LegalRepresentative'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'法定代表人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'LegalRepresentative'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'Address')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'住所'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'Address'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'住所'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'Address'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'RegisteredCapital')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'注册资本'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'RegisteredCapital'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'注册资本'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'RegisteredCapital'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'EnterpriseStatus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'企业状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'EnterpriseStatus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'企业状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'EnterpriseStatus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'CompanyType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'公司类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'CompanyType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'公司类型'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'CompanyType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'EstablishmentDate')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'成立日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'EstablishmentDate'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'成立日期'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'EstablishmentDate'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'BusinessTerm')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'营业期限'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'BusinessTerm'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'营业期限'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'BusinessTerm'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'RegistrationAuthority')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'登记机关'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'RegistrationAuthority'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'登记机关'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'RegistrationAuthority'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'AcceptingOrgans')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'受理机关'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'AcceptingOrgans'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'受理机关'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'AcceptingOrgans'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'TenantDetail', 
'COLUMN', N'BusinessScope')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'经营范围'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'BusinessScope'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'经营范围'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'TenantDetail'
, @level2type = 'COLUMN', @level2name = N'BusinessScope'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ThirdPartyService', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'第三方服务信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'第三方服务信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ThirdPartyService', 
'COLUMN', N'ThirdPartyServiceId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'第三方服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'第三方服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ThirdPartyService', 
'COLUMN', N'ThirdPartyServiceName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'第三方服务名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'第三方服务名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ThirdPartyService', 
'COLUMN', N'ThirdPartyServiceCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'第三方服务代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'第三方服务代码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'ThirdPartyService', 
'COLUMN', N'BindToken')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'绑定令牌'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'BindToken'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'绑定令牌'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'ThirdPartyService'
, @level2type = 'COLUMN', @level2name = N'BindToken'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'Token')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'令牌'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Token'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'令牌'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'Token'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'UserDetailId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UserDetailId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UserDetailId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'UserGroupId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户所在组编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UserGroupId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户所在组编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'UserGroupId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'User', 
'COLUMN', N'TenantId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户所在企业编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'TenantId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户所在企业编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'User'
, @level2type = 'COLUMN', @level2name = N'TenantId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户详细信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户详细信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'UserDetailId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'UserDetailId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户详细信息编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'UserDetailId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'UserPrincipalName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户名（英文名@域名）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'UserPrincipalName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户名（英文名@域名）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'UserPrincipalName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'AccountEnabled')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'账号状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'AccountEnabled'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'账号状态'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'AccountEnabled'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'Password')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Password'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Password'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'MailNickname')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'MailNickname'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'别名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'MailNickname'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'DisplayName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'显示名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'DisplayName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'显示名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'DisplayName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'GivenName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'名字'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'GivenName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'名字'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'GivenName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'Surname')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'姓氏'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Surname'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'姓氏'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Surname'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'JobTitle')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'职务'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'JobTitle'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'职务'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'JobTitle'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'Department')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'部门'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Department'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'部门'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Department'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'StreetAddress')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'街道地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'StreetAddress'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'街道地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'StreetAddress'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'City')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'城市'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'City'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'城市'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'City'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'State')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'省/自治区/直辖市'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'State'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'省/自治区/直辖市'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'State'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'Country')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'国家或地区'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Country'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'国家或地区'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'Country'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'PhysicalDeliveryOfficeName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'办公室号码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'PhysicalDeliveryOfficeName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'办公室号码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'PhysicalDeliveryOfficeName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'TelephoneNumber')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'办公电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'TelephoneNumber'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'办公电话'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'TelephoneNumber'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserDetail', 
'COLUMN', N'PostalCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'邮政编码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'PostalCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'邮政编码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserDetail'
, @level2type = 'COLUMN', @level2name = N'PostalCode'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroup', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户组信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户组信息表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroup', 
'COLUMN', N'UserGroupId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户组编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'UserGroupId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户组编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'UserGroupId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroup', 
'COLUMN', N'UserGroupName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户组名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'UserGroupName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户组名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'UserGroupName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroup', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroup', 
'COLUMN', N'UpdateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'UpdateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroup', 
'COLUMN', N'CreateByUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'CreateByUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroup'
, @level2type = 'COLUMN', @level2name = N'CreateByUserId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroupRoleMapping', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户组角色映射表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户组角色映射表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroupRoleMapping', 
'COLUMN', N'UserGroupRoleMappingId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户组角色映射编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
, @level2type = 'COLUMN', @level2name = N'UserGroupRoleMappingId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户组角色映射编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
, @level2type = 'COLUMN', @level2name = N'UserGroupRoleMappingId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroupRoleMapping', 
'COLUMN', N'UserGroupId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户组编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
, @level2type = 'COLUMN', @level2name = N'UserGroupId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户组编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
, @level2type = 'COLUMN', @level2name = N'UserGroupId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserGroupRoleMapping', 
'COLUMN', N'RoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
, @level2type = 'COLUMN', @level2name = N'RoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserGroupRoleMapping'
, @level2type = 'COLUMN', @level2name = N'RoleId'
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
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserThirdPartyServiceMapping', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户第三方服务映射表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户第三方服务映射表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserThirdPartyServiceMapping', 
'COLUMN', N'UserThirdPartyServiceMappingId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户第三方服务映射编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
, @level2type = 'COLUMN', @level2name = N'UserThirdPartyServiceMappingId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户第三方服务映射编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
, @level2type = 'COLUMN', @level2name = N'UserThirdPartyServiceMappingId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserThirdPartyServiceMapping', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'UserThirdPartyServiceMapping', 
'COLUMN', N'ThirdPartyServiceId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'第三方服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'第三方服务编号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'UserThirdPartyServiceMapping'
, @level2type = 'COLUMN', @level2name = N'ThirdPartyServiceId'
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
