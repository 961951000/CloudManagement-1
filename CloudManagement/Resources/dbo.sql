/*
Navicat SQL Server Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 110000
Source Host           : 127.0.0.1:1433
Source Database       : CloudManagement
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 110000
File Encoding         : 65001

Date: 2017-08-08 21:45:46
*/


-- ----------------------------
-- Table structure for City
-- ----------------------------
DROP TABLE [dbo].[City]
GO
CREATE TABLE [dbo].[City] (
[CityID] int NOT NULL IDENTITY(1,1) ,
[ProvinceID] int NOT NULL ,
[CityName] nvarchar(50) NOT NULL 
)


GO
DBCC CHECKIDENT(N'[dbo].[City]', RESEED, 2)
GO

-- ----------------------------
-- Records of City
-- ----------------------------
SET IDENTITY_INSERT [dbo].[City] ON
GO
INSERT INTO [dbo].[City] ([CityID], [ProvinceID], [CityName]) VALUES (N'2', N'1', N'Shanghai')
GO
GO
SET IDENTITY_INSERT [dbo].[City] OFF
GO

-- ----------------------------
-- Table structure for CompanyCategory
-- ----------------------------
DROP TABLE [dbo].[CompanyCategory]
GO
CREATE TABLE [dbo].[CompanyCategory] (
[CategoryID] smallint NOT NULL IDENTITY(1,1) ,
[CategoryName] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of CompanyCategory
-- ----------------------------
SET IDENTITY_INSERT [dbo].[CompanyCategory] ON
GO
INSERT INTO [dbo].[CompanyCategory] ([CategoryID], [CategoryName]) VALUES (N'1', N'Ltd.')
GO
GO
SET IDENTITY_INSERT [dbo].[CompanyCategory] OFF
GO

-- ----------------------------
-- Table structure for CompanyNature
-- ----------------------------
DROP TABLE [dbo].[CompanyNature]
GO
CREATE TABLE [dbo].[CompanyNature] (
[NatureID] smallint NOT NULL IDENTITY(1,1) ,
[NatureName] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of CompanyNature
-- ----------------------------
SET IDENTITY_INSERT [dbo].[CompanyNature] ON
GO
INSERT INTO [dbo].[CompanyNature] ([NatureID], [NatureName]) VALUES (N'1', N'IT')
GO
GO
SET IDENTITY_INSERT [dbo].[CompanyNature] OFF
GO

-- ----------------------------
-- Table structure for Country
-- ----------------------------
DROP TABLE [dbo].[Country]
GO
CREATE TABLE [dbo].[Country] (
[CountryID] int NOT NULL IDENTITY(1,1) ,
[CountryCode] nvarchar(10) NOT NULL ,
[CountryName] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of Country
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Country] ON
GO
INSERT INTO [dbo].[Country] ([CountryID], [CountryCode], [CountryName]) VALUES (N'1', N'0001', N'Chinese')
GO
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO

-- ----------------------------
-- Table structure for Province
-- ----------------------------
DROP TABLE [dbo].[Province]
GO
CREATE TABLE [dbo].[Province] (
[ProvinceID] int NOT NULL IDENTITY(1,1) ,
[ProvinceCode] nvarchar(10) NOT NULL ,
[ProvinceName] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of Province
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Province] ON
GO
INSERT INTO [dbo].[Province] ([ProvinceID], [ProvinceCode], [ProvinceName]) VALUES (N'1', N'0001', N'Shanghai')
GO
GO
SET IDENTITY_INSERT [dbo].[Province] OFF
GO

-- ----------------------------
-- Table structure for RoleNature
-- ----------------------------
DROP TABLE [dbo].[RoleNature]
GO
CREATE TABLE [dbo].[RoleNature] (
[RoleID] smallint NOT NULL IDENTITY(1,1) ,
[RoleName] nvarchar(50) NOT NULL 
)


GO

-- ----------------------------
-- Records of RoleNature
-- ----------------------------
SET IDENTITY_INSERT [dbo].[RoleNature] ON
GO
INSERT INTO [dbo].[RoleNature] ([RoleID], [RoleName]) VALUES (N'1', N'admin')
GO
GO
SET IDENTITY_INSERT [dbo].[RoleNature] OFF
GO

-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE [dbo].[User]
GO
CREATE TABLE [dbo].[User] (
[UserID] int NOT NULL IDENTITY(1,1) ,
[Account] nvarchar(200) NOT NULL ,
[PasswordKey] varchar(200) NOT NULL ,
[Name] nvarchar(200) NOT NULL ,
[RegNumber] nvarchar(200) NOT NULL ,
[PhotoPath] nvarchar(200) NOT NULL ,
[CountryID] int NOT NULL ,
[ProvinceID] int NOT NULL ,
[CityID] int NOT NULL ,
[Address] nvarchar(200) NOT NULL ,
[Phone] nvarchar(200) NOT NULL ,
[CompanyNatureID] smallint NOT NULL ,
[CategoryID] smallint NOT NULL ,
[CertificateType] nvarchar(200) NOT NULL ,
[Email] nvarchar(200) NOT NULL ,
[Token] nvarchar(200) NOT NULL ,
[UserProfile] nvarchar(200) NOT NULL ,
[RoleFlag] smallint NOT NULL 
)


GO

-- ----------------------------
-- Records of User
-- ----------------------------
SET IDENTITY_INSERT [dbo].[User] ON
GO
INSERT INTO [dbo].[User] ([UserID], [Account], [PasswordKey], [Name], [RegNumber], [PhotoPath], [CountryID], [ProvinceID], [CityID], [Address], [Phone], [CompanyNatureID], [CategoryID], [CertificateType], [Email], [Token], [UserProfile], [RoleFlag]) VALUES (N'1', N'caxian', N'1500000000', N'Xiangwei Cai', N'9131011577210650X7', N'C:\\', N'1', N'1', N'2', N'No 555,DongChuan Road,MinHang District,Shanghai', N'+86-10-5096 5588', N'1', N'1', N'business license', N'info@beyondsoft.com', N'001', N'...', N'1')
GO
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO

-- ----------------------------
-- Indexes structure for table City
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table City
-- ----------------------------
ALTER TABLE [dbo].[City] ADD PRIMARY KEY ([CityID])
GO

-- ----------------------------
-- Indexes structure for table CompanyCategory
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CompanyCategory
-- ----------------------------
ALTER TABLE [dbo].[CompanyCategory] ADD PRIMARY KEY ([CategoryID])
GO

-- ----------------------------
-- Indexes structure for table CompanyNature
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table CompanyNature
-- ----------------------------
ALTER TABLE [dbo].[CompanyNature] ADD PRIMARY KEY ([NatureID])
GO

-- ----------------------------
-- Indexes structure for table Country
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Country
-- ----------------------------
ALTER TABLE [dbo].[Country] ADD PRIMARY KEY ([CountryID])
GO

-- ----------------------------
-- Indexes structure for table Province
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table Province
-- ----------------------------
ALTER TABLE [dbo].[Province] ADD PRIMARY KEY ([ProvinceID])
GO

-- ----------------------------
-- Indexes structure for table RoleNature
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table RoleNature
-- ----------------------------
ALTER TABLE [dbo].[RoleNature] ADD PRIMARY KEY ([RoleID])
GO

-- ----------------------------
-- Foreign Key structure for table [dbo].[User]
-- ----------------------------
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[CompanyCategory] ([CategoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([CityID]) REFERENCES [dbo].[City] ([CityID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([CompanyNatureID]) REFERENCES [dbo].[CompanyNature] ([NatureID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([CountryID]) REFERENCES [dbo].[Country] ([CountryID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([ProvinceID]) REFERENCES [dbo].[Province] ([ProvinceID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [dbo].[User] ADD FOREIGN KEY ([RoleFlag]) REFERENCES [dbo].[RoleNature] ([RoleID]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
