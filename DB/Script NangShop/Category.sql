CREATE PROCEDURE proc_Category_Insert
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


CREATE PROCEDURE proc_Category_Delete
    @Category_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[tb_Category] where [Category_Id] =@Category_Id

END
GO

CREATE PROCEDURE proc_Category_GetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[tb_Category]

END
GO


CREATE PROCEDURE proc_Category_Update
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