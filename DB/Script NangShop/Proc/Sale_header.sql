
CREATE PROCEDURE proc_Sale_Detail_Insert 
	@Sale_Header_Id int,
	@Product_Id int,
	@Status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into [dbo].[Sale_Detail]([Sale_Header_Id],[Product_Id],[Status])
	values (@Sale_Header_Id,@Product_Id,@Status)
  
END
GO

CREATE PROCEDURE [dbo].[proc_Sale_Header_Insert] 
	@Customer_Id int,
	@BranchId int,
	@Sale_Date date,
	@SalesType int,
	
	@Total_Amount decimal(18,0),
	@Debt_Amount decimal(18,0),
	@UserName nvarchar(50),
	
	@CreatedDate date,
	@Comment nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into [dbo].[Sale_Header]([Customer_Id],[BranchId],[Sale_Date],[SalesType],[Total_Amount], [Debt_Amount],[UserName],[CreatedDate],[Comment])
	values (@Customer_Id,@BranchId,@Sale_Date,@SalesType,@Total_Amount,@Debt_Amount,@UserName,@CreatedDate,@Comment)
  
END
