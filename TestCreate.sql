USE [Test]
GO

CREATE USER [SQL_User_App] FOR LOGIN [SQL_User_App] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [SQL_User_App]
GO

ALTER LOGIN SQL_User_App WITH PASSWORD = 'User$Pass';

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE DATABASE Test;
GO

Use Test
CREATE TABLE [dbo].[TableTest](
    [Id] [bigint] IDENTITY(1,1) NOT NULL,
    [Name] [nvarchar](max) NULL,
    [Mobile] [nvarchar](max) NULL,
    [Email] [nvarchar](max) NULL,
    CONSTRAINT [PK_TableTest] PRIMARY KEY CLUSTERED ([Id])
)
GO
