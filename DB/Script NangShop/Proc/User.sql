 
CREATE PROCEDURE proc_User_Insert 
	-- Add the parameters for the stored procedure here
	@User_Name nvarchar(50),
	@Pass nvarchar(50),
	@User_Type int,
	@FullName nvarchar(200),
	@Status int,
	@User_Id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into [dbo].[User]([FullName],[User_Name],[Pass],[User_Type],[Status])
	values (@FullName,@User_Name,@Pass,@User_Type,@Status)

	select @User_Id=  [User_Id] from [dbo].[User] where [User_Name] = @User_Name;

END


CREATE PROCEDURE proc_User_Get_All 
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Select * from [dbo].[User] where deleted =0;

END

CREATE PROCEDURE proc_User_Login
	@User_Name nvarchar(50),
	@Pass nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Select * from [dbo].[User] where deleted = 0 and upper([User_Name]) = upper(@User_Name) 
   and  upper([Pass]) = upper(@Pass)

END

CREATE PROCEDURE proc_User_Delete
	@User_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Update [dbo].[User]  set  deleted = 1 where [User_Id] = @User_Id
END


CREATE PROCEDURE proc_User_Update 
	-- Add the parameters for the stored procedure here
	@User_Name nvarchar(50),
	@Pass nvarchar(50),
	@User_Type int,
	@FullName nvarchar(200),
	@Status int,
	@User_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[User] set [FullName] = @FullName,[User_Name] = @User_Name,
	[Status] = @Status,[User_Type] = @User_Type where [User_Id] = @User_Id;

END


CREATE PROCEDURE proc_User_Update_Last 
	-- Add the parameters for the stored procedure here
	@Last_Login date,
	@User_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[User] set [Last_Login] = @Last_Login where [User_Id] = @User_Id;

END


CREATE PROCEDURE proc_User_Update_Pass
	-- Add the parameters for the stored procedure here
	
	@User_Id int,
	@Pass nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[User] set [Pass] = @Pass where [User_Id] = @User_Id and deleted = 0;

END