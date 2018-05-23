USE [NangShop]
GO

/****** Object:  StoredProcedure [dbo].[proc_Search_Product]    Script Date: 03/08/2014 2:57:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
CREATE PROCEDURE [dbo].[proc_Search_Product]
	@Product_Code nvarchar(50),
	@Product_Name nvarchar(50)
AS

DECLARE @str_condition nvarchar(200)
DECLARE @str_sql nvarchar(2000)

BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	set @str_condition = '';

	if @Product_Code <> 'all' 
		set @str_condition = @str_condition + ' AND Product_Code LIKE '+ '''%' + @Product_Code + '%''';
	
	if @Product_Name <> 'all'
		set @str_condition = @str_condition + ' AND  Name LIKE '+ '''%' + @Product_Name+ '''%';
   
    DECLARE @query NVARCHAR(MAX);
	SET @query = 'select p.*,s.Supplier_Name,s.Phone,c.Category_Name ,(p.Total_Receive - p.Total_Sale ) as total_remain
	from [dbo].[Product] p
	left join [dbo].[Supplier] s on s.Supplier_Id = p.Supplier_Id
	Join [dbo].[tb_Category] c on c.Category_Id = p.Category_Id

	where p.deleted = 0 ' + + @str_condition;
     EXECUTE(@query)

	 print @query;

	

END

GO


