USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Color_Insert]    Script Date: 02/08/2014 2:24:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
-- =============================================
CREATE PROCEDURE [dbo].[proc_Color_Insert]
	@ColorCode nvarchar(50),
	@ColorName nvarchar(50),
    @Color_Id INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into [dbo].[Color] (ColorCode,ColorName)
	values (@ColorCode,@ColorName);


	select @Color_Id=  Color_Id from [dbo].[Color] where ColorCode = @ColorCode and ColorName = @ColorName;

END

GO

