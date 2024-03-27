USE [ApexDB]
GO
/*Insert basic roles*/
INSERT INTO [dbo].[UserRoles] ([Name], [NormalizedName]) VALUES ('Manager','MANAGER')
INSERT INTO [dbo].[UserRoles] ([Name], [NormalizedName]) VALUES ('Member','MEMBER')
GO