 
-- =============================================
CREATE PROCEDURE proc_Color_Insert
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


CREATE PROCEDURE proc_Color_Delete
    @Color_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Color] where Color_Id =@Color_Id

END
GO

CREATE PROCEDURE proc_Color_GetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Color]

END
GO

