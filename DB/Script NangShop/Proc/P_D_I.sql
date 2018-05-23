USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Product_Detail_Insert]    Script Date: 02/08/2014 2:24:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Product_Detail_Insert]
	@Product_Id int,
	@Color_Id int,
	@Ri_Count int,
	@Total_Count int,
	@Name nvarchar(50),
	@Size nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into [dbo].[Product_Detail] ([Product_Id],[Color_Id],[Ri_Count],[Total_Count],[Total_Sale],[Name],[Size])
	values (@Product_Id,@Color_Id,@Ri_Count,@Total_Count,0,@Name,@Size);
	 
END

GO

