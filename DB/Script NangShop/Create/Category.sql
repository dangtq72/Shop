USE [NangShop]
GO

/****** Object:  Table [dbo].[tb_Category]    Script Date: 02/08/2014 2:21:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_Category](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL
) ON [PRIMARY]

GO


