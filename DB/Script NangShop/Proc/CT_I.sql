USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Category_Insert]    Script Date: 02/08/2014 2:25:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Category_Insert]
	@Category_Name nvarchar(50),
	@Note nvarchar(200),
    @Category_Id INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into [dbo].[tb_Category] ([Category_Name],[Note])
	values (@Category_Name,@Note);


	select @Category_Id=  [Category_Id] from [dbo].[tb_Category] where [Category_Name] = @Category_Name

END

GO

