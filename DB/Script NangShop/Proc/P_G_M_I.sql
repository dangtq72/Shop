USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Product_Get_Max_Id]    Script Date: 02/08/2014 2:23:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Product_Get_Max_Id]
    @Product_Id int Out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select @Product_Id= max( [Product_Id]) from [dbo].[Product] where Deleted = 0
END

GO

