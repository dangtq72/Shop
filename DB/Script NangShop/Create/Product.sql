USE [NangShop]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 02/08/2014 2:21:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL,
	[Deleted] [int] NULL,
	[Category_Id] [int] NULL,
	[Receive_Date] [date] NULL,
	[Receive_Price] [decimal](18, 0) NULL,
	[Per_BanLe] [decimal](18, 2) NULL,
	[BanLe_Price] [decimal](18, 0) NULL,
	[Per_BanBuon] [decimal](18, 2) NULL,
	[BanBuon_Price] [decimal](18, 0) NULL,
	[Receive_Count] [int] NULL,
	[Count_by_Ri] [int] NULL,
	[Supplier_Id] [int] NULL,
	[Is_XuatDu] [int] NULL,
	[Color_Name] [nvarchar](50) NULL,
	[Total_Receive] [int] NULL,
	[Total_Sale] [int] NULL,
	[Ship_Price] [decimal](18, 0) NULL,
	[Product_Code] [nvarchar](50) NULL,
	[Size] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


