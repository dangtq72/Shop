USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Product_Insert]    Script Date: 02/08/2014 2:23:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Product_Insert]
	@Name nvarchar(50),
	@Note nvarchar(50),
    @Category_Id int,
	@Receive_Date date,
	@Receive_Price decimal(18,0),
	@Per_BanLe decimal(18,2),
	@BanLe_Price decimal(18,0),

	@Per_BanBuon decimal(18,2),
	@BanBuon_Price decimal(18,0),
	@Receive_Count int,
	@Count_by_Ri int,
	@Supplier_Id int,
	@Is_XuatDu int,
	@Color_Name nvarchar(50),
	@Total_Receive int,
	@Ship_Price decimal(18,0),
	@Product_Code nvarchar(50),
	@Size nvarchar(50),
	@Product_Id INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into [dbo].[Product] ([Name],[Note],[Deleted],[Category_Id],[Receive_Date],[Receive_Price],
		[Per_BanLe],[BanLe_Price],[Per_BanBuon],[BanBuon_Price],[Receive_Count],[Count_by_Ri],[Supplier_Id],
		[Is_XuatDu],[Color_Name],[Total_Receive],[Total_Sale],[Ship_Price],[Product_Code],[Size])
	values (@Name,@Note,0,@Category_Id,@Receive_Date,@Receive_Price,
		@Per_BanLe,@BanLe_Price,@Per_BanBuon,@BanBuon_Price,@Receive_Count,@Count_by_Ri,@Supplier_Id,
		@Is_XuatDu,@Color_Name,@Total_Receive,0,@Ship_Price,@Product_Code,@Size)

	select @Product_Id=  [Product_Id] from [dbo].[Product] where [Name] = @Name

END

GO

