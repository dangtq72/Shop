USE [NangShop]
GO

/****** Object:  Table [dbo].[Product_Detail]    Script Date: 02/08/2014 2:21:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product_Detail](
	[Product_Detail] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NOT NULL,
	[Color_Id] [int] NULL,
	[Ri_Count] [int] NULL,
	[Total_Count] [int] NULL,
	[Total_Sale] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Size] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product_Detail] PRIMARY KEY CLUSTERED 
(
	[Product_Detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


