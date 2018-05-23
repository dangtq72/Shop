USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Category_Delete]    Script Date: 02/08/2014 2:25:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[proc_Category_Delete]
    @Category_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[tb_Category] where [Category_Id] =@Category_Id

END

GO

