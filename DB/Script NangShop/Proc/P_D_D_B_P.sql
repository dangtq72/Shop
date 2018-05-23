USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Product_Detail_Delete_By_Product_Id]    Script Date: 02/08/2014 2:24:21 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Product_Detail_Delete_By_Product_Id]
	@Product_Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Delete [dbo].[Product_Detail]  
	where [Product_Id] = @Product_Id
	 
END

GO

