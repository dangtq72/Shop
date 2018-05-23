USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Category_Update]    Script Date: 02/08/2014 2:25:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[proc_Category_Update]
	@Category_Id int,
	@Category_Name nvarchar(50),
	@Note nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   update [dbo].[tb_Category] set [Category_Name] = @Category_Name,Note = @Note
   where [Category_Id] =@Category_Id

END

GO

