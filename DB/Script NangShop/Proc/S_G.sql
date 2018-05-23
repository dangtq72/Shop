USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Supplier_GetAll]    Script Date: 02/08/2014 2:23:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_Supplier_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Supplier]

END

GO

