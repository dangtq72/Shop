USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Supplier_Insert]    Script Date: 02/08/2014 2:23:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Supplier_Insert]
	@Supplier_Name nvarchar(200),
	@Phone nvarchar(50),
	@Address nvarchar(200),
    @Supplier_Id INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into [dbo].[Supplier] ([Supplier_Name],[Phone],[Address])
	values (@Supplier_Name,@Phone,@Address);


	select @Supplier_Id=  Supplier_Id from [dbo].[Supplier] where [Supplier_Name] = @Supplier_Name

END

GO

