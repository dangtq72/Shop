
CREATE PROCEDURE proc_allCode_Insert
	-- Add the parameters for the stored procedure here
	@CdName nvarchar(50),
	@CdType nvarchar(50),
	@CdVal nvarchar(50),
	@Content nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into AllCode ([CdName],[CdType],[CdValue],[Content])
	values (@CdName,@CdType,@CdVal,@Content)

END
GO


CREATE PROCEDURE proc_GetBy_Name_Type
	-- Add the parameters for the stored procedure here
	@CdName nvarchar(50),
	@CdType nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from AllCode
	where CdName = @CdName and CdType = @CdType

END
GO

CREATE PROCEDURE proc_GetBy_All
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from AllCode
END
GO