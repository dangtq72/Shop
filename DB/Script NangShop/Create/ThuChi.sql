USE [NangShop]
GO

/****** Object:  Table [dbo].[ThuChi]    Script Date: 02/08/2014 2:22:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ThuChi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SoHoadon] [nvarchar](50) NULL,
	[Ngay_Lap] [date] NULL,
	[ThuChi] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[DienGiai] [nvarchar](200) NULL,
	[CustomerName] [nvarchar](200) NULL,
 CONSTRAINT [PK_ThuChi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

