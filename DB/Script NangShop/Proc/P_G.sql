USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Product_GetAll]    Script Date: 02/08/2014 2:23:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Product_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select a.*,s.Supplier_Name,s.Phone,c.Category_Name 
	from [dbo].[Product] a
	left join [dbo].[Supplier] s on s.Supplier_Id = a.Supplier_Id
	Join [dbo].[tb_Category] c on c.Category_Id = a.Category_Id

END

GO

