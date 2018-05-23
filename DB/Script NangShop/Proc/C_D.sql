USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Color_Delete]    Script Date: 02/08/2014 2:25:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Color_Delete]
    @Color_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Color] where Color_Id =@Color_Id

END

GO

