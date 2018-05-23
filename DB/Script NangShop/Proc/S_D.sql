USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Supplier_Delete]    Script Date: 02/08/2014 2:23:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[proc_Supplier_Delete]
    @Supplier_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Supplier] where Supplier_Id =@Supplier_Id

END

GO

