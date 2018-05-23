
CREATE PROCEDURE Customer_Insert 
	@Customer_Name nvarchar(200),
	@Phone nvarchar(50),
	@Address nvarchar(500),
	@Customer_Id int out	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into [dbo].[Customer]([Customer_Name],[Phone],[Address])
	values(@Customer_Name,@Phone,@Address)

	select @Customer_Id=  Customer_Id from [dbo].[Customer] where Customer_Name = @Customer_Name and Phone = @Phone;

END
GO

Create PROCEDURE proc_Customer_Search
	@Customer_Name nvarchar(200),
	@Phone nvarchar(50)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @str_sql nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';

	if @Customer_Name <> 'all' 
		set @str_condition = @str_condition + ' AND Customer_Name LIKE '+ '''%' + @Customer_Name + '%''';
	
	if @Phone <> 'all'
		set @str_condition = @str_condition + ' AND  Phone LIKE '+ '''%' + @Phone+ '''%';
   
    DECLARE @query NVARCHAR(MAX);
	SET @query = 'select * from [dbo].[Customer] where Deleted = 0 ' + + @str_condition;
    EXECUTE(@query)

END

create procedure proc_customer_Delete
	@Customer_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update [dbo].[Customer] set [Deleted] = 0 where [Customer_Id]  = @Customer_Id 

END

create procedure proc_customer_GetAll
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Customer] where [Deleted] = 0

END

 
CREATE PROCEDURE proc_Customer_Update
	@Customer_Name nvarchar(200),
	@Phone nvarchar(50),
	@Address nvarchar(500)
	@Customer_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[Customer] set  [Customer_Name] = @Customer_Name,
	[Phone] = @Phone,[Address] = @Address
	where [Customer_Id] = @Customer_Id
END 
GO

