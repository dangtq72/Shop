USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Get_Product_Detail_By_Product_Id]    Script Date: 02/08/2014 2:24:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Get_Product_Detail_By_Product_Id]
	@Product_Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     select pd.*,p.Size
	 from [dbo].[Product_Detail] pd
	join [dbo].[Product] p on p.Product_Id = pd.Product_Id

	where pd.Product_Id = @Product_Id
	 
END

GO

