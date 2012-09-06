USE [Dev_TaxGenie]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Library_RSRules_Data_Select]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Library_RSRules_Data_Select]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Library_RSRules_Index]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Library_RSRules_Index]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Library_RSRules_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Library_RSRules_Insert]
GO

/****** Object:  StoredProcedure [dbo].[Library_RSRules_SelectAll]    Script Date: 09/06/2012 16:46:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Library_RSRules_SelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Library_RSRules_SelectAll]
GO

/****** Object:  Table [dbo].[Library]    Script Date: 09/06/2012 16:31:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Library]') AND type in (N'U'))
DROP TABLE [dbo].[Library]
GO

USE [Dev_TaxGenie]
GO

/****** Object:  Table [dbo].[Library]    Script Date: 09/06/2012 16:31:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Library](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubCategory] [nvarchar](max) NULL,
	[IndexName] [nvarchar](max) NULL,
	[Data] [nvarchar](max) NULL,
	[Document] [varbinary](max) NULL,
	[datetime] [datetime] NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


create PROCEDURE [dbo].[Library_Data_Select]
@subcategory varchar(20)
,@indexname varchar(max)
AS
BEGIN
select data,Document from Library where subcategory = @subcategory and indexname = @indexname
END

GO

create PROCEDURE [dbo].[Library_Index_Select]
@subcategory varchar(20)

AS
BEGIN
select distinct Indexname from Library where subcategory = @subcategory
END

Go

create procedure [dbo].[Library_Insert] 
 @SubCategory nvarchar(50) 
 ,@IndexName nvarchar(max) 
  ,@Data nvarchar(max)
 ,@Document varbinary(max)
 
 
as
begin
if @SubCategory=''
begin
 set @SubCategory=NULL
 end
 if @IndexName=''
begin
 set @IndexName=NULL
 end
  if @Data=''
begin
 set @Data=NULL
 end
 if @Document=''
begin
 set @Document=NULL
 end
  


insert into Library
(
SubCategory 
 ,IndexName

 ,Data
 ,datetime
 ,Document


)
 values
(
@SubCategory 
 ,@IndexName 
 
 ,@Data
 ,GETDATE()
 ,@Document

)
end

GO

create PROCEDURE [dbo].[Library_SelectAll]
@subcategory varchar(20)
,@indexname varchar(max)
AS
BEGIN
select * from Library
END

GO