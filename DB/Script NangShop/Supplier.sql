CREATE PROCEDURE proc_Supplier_Insert
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


CREATE PROCEDURE proc_Supplier_Delete
    @Supplier_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Supplier] where Supplier_Id =@Supplier_Id

END
GO

CREATE PROCEDURE proc_Supplier_GetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Supplier]

END
GO