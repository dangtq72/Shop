USE [NangShop]
GO

/****** Object:  Table [dbo].[Detail_Item]    Script Date: 02/08/2014 2:21:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Detail_Item](
	[Detail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL,
	[Sale_Price] [decimal](18, 0) NULL,
	[Per_Discount] [decimal](18, 0) NULL,
	[Status] [int] NULL,
	[Size] [nvarchar](50) NULL,
	[Color_Id] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Detail_Item] PRIMARY KEY CLUSTERED 
(
	[Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


