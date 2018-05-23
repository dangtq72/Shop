CREATE PROCEDURE proc_Product_Detail_Insert
	@Product_Id int,
	@Color_Id int,
	@Ri_Count int,
	@Total_Count int,
	@Name nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    IInsert into [dbo].[Product_Detail] ([Product_Id],[Color_Id],[Ri_Count],[Total_Count],[Total_Sale],[Name])
	values (@Product_Id,@Color_Id,@Ri_Count,@Total_Count,0,@Name);
	 
END
GO

CREATE PROCEDURE proc_Product_Detail_Delete_By_Product_Id
	@Product_Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Delete [dbo].[Product_Detail]  
	where [Product_Id] = @Product_Id
	 
END
GO

CREATE PROCEDURE proc_Get_Product_Detail_By_Product_Id
	@Product_Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     select pd.*,p.Size
	 from [dbo].[Product_Detail] pd
	join [dbo].[Product] p on p.Product_Id = pd.Product_Id

	where pd.Product_Id = @Product_Id
	 
END
GO