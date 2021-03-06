USE [NangShop]
GO
/****** Object:  StoredProcedure [dbo].[Customer_Buy_Product]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[Customer_Buy_Product] 
	@Customer_Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   select sh.SoHoaDon,sh.Sale_Date,sh.Total_Amount,sh.Ship_Price,sh.Discount,
	p.Name,sd.Count
	from Sale_Header sh 
	join Sale_Detail sd on sh.Sale_Header_Id = sd.Sale_Header_Id
	join Product p on p.Product_Id = sd.Product_Id
	where sh.Customer_Id =@Customer_Id order by Sale_Date desc; 
END

GO
/****** Object:  StoredProcedure [dbo].[Customer_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Customer_Insert] 
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
/****** Object:  StoredProcedure [dbo].[proc_allCode_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_allCode_Insert]
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
/****** Object:  StoredProcedure [dbo].[proc_Category_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_Category_Delete]
    @Category_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[tb_Category] where [Category_Id] =@Category_Id

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Category_GetAll]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Category_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[tb_Category]

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Category_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Category_Insert]
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
/****** Object:  StoredProcedure [dbo].[proc_Category_Update]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_Category_Update]
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
/****** Object:  StoredProcedure [dbo].[proc_Change_Product_By_Header]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Change_Product_By_Header] 
	@SoHoaDon nvarchar(100),
	@Sale_Header_Id int,
	@New_Product_Id int,
	@New_Count int,
	@Per_Discount decimal(18,2),
	@New_Total_Price int,
	@Modifi_Date date
AS
DECLARE @exit_new int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 
   -- kiểm tra xem trong don hàng có sản phầm mới hay chưa
   -- có thì + thêm nó vào
   select @exit_new= Product_Id from Sale_Detail where  Sale_Header_Id = @Sale_Header_Id and Product_Id = @New_Product_Id;

   if @exit_new <> 0 
		begin
			update Sale_Detail set Count = Count + @New_Count where  Sale_Header_Id = @Sale_Header_Id;

			--if @New_Product_Id > @Old_Product_Id 
			-- update lại số lượng đã bán
			--update Product set Total_Sale = Total_Sale + @New_Count where Product_Id = @Old_Product_Id;
		end
   ELSE 
	   begin
			-- thêm thằng mới
			insert into Sale_Detail([Sale_Header_Id],[Product_Id],[Count],[Per_Discount])
			values(@Sale_Header_Id,@New_Product_Id,@New_Count,@Per_Discount);

			-- update lại số lượng đã bán
			update Product set Total_Sale = Total_Sale + @New_Count where Product_Id = @New_Product_Id;
	   end 

   -- cập nhật lại tổng số tiền thanh toán
   update Sale_Header set Total_Amount =@New_Total_Price,[Modifi_Date] = @Modifi_Date 
   where SoHoaDon = @SoHoaDon and Sale_Header_Id = @Sale_Header_Id;

   -- cập nhật lại  giá trị trong bảng thu chi
   update ThuChi set Price = @New_Total_Price where SoHoadon = @SoHoaDon;

END


GO
/****** Object:  StoredProcedure [dbo].[proc_Change_Product_By_Header_Old]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[proc_Change_Product_By_Header_Old]
	@SoHoaDon nvarchar(100),
	@Sale_Header_Id int,
	@Old_Product_Id int,
	@Old_Count int
AS
DECLARE @exit_new int
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		-- delete thằng cũ
		delete Sale_Detail where Sale_Header_Id = @Sale_Header_Id and Product_Id = @Old_Product_Id;
		-- update lại số lượng đã bán
		update Product set Total_Sale = Total_Sale - @Old_Count where Product_Id = @Old_Product_Id;
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Color_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Color_Delete]
    @Color_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Color] where Color_Id =@Color_Id

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Color_GetAll]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Color_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Color]

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Color_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- =============================================
CREATE PROCEDURE [dbo].[proc_Color_Insert]
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
/****** Object:  StoredProcedure [dbo].[proc_customer_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_customer_Delete]
	@Customer_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update [dbo].[Customer] set [Deleted] = 0 where [Customer_Id]  = @Customer_Id 

END

GO
/****** Object:  StoredProcedure [dbo].[proc_customer_GetAll]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[proc_customer_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Customer] where [Deleted] = 0

END
GO
/****** Object:  StoredProcedure [dbo].[proc_Customer_Search]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Customer_Search]
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

	if @Customer_Name <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(Customer_Name) LIKE N'+ '''%' + @Customer_Name + '%''';
	
	if @Phone <> 'ALL'
		set @str_condition = @str_condition + ' AND  UPPER(Phone) LIKE '+ '''%' + @Phone+ '%''';
   
    DECLARE @query NVARCHAR(MAX);
	SET @query = 'select * from [dbo].[Customer] where Deleted = 0 ' + @str_condition;
    EXECUTE(@query)
	print(@query)
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Customer_Update]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[proc_Customer_Update]
	@Customer_Name nvarchar(200),
	@Phone nvarchar(50),
	@Address nvarchar(500),
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
/****** Object:  StoredProcedure [dbo].[proc_Function_Group_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Function_Group_Delete]
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   delete [dbo].[Function_Group] 
   where [user_type] = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Function_Group_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Function_Group_Insert]
	@user_type int,
	@functionid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   insert into [dbo].[Function_Group]([user_type],[functionid])
   values (@user_type,@functionid);

END

GO
/****** Object:  StoredProcedure [dbo].[proc_get_Product_By_SHD]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_get_Product_By_SHD]
	@SoHoaDon nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select  p.*,sd.Count as Count_Sale_By_Header,sh.SalesType from Sale_Detail sd
	join Product p on sd.Product_Id = p.Product_Id
	join Sale_Header sh on sh.Sale_Header_Id = sd.Sale_Header_Id
	where sh.SoHoaDon = @SoHoaDon
	order by sd.Sale_Header_Id
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Get_Product_Detail_By_Product_Id]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Get_Product_Detail_By_Product_Id]
	@Product_Id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     select c.ColorName as Color_Name,pd.*,pd.Total_Count - pd.Total_Sale as remain_Count
	 from [dbo].[Product_Detail] pd
	join [dbo].[Product] p on p.Product_Id = pd.Product_Id
	join Color c on c.Color_Id = pd.Color_Id
	where pd.Product_Id = @Product_Id
	 
END

GO
/****** Object:  StoredProcedure [dbo].[proc_GetBy_All]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetBy_All]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from AllCode
END

GO
/****** Object:  StoredProcedure [dbo].[proc_GetBy_Name_Type]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_GetBy_Name_Type]
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
/****** Object:  StoredProcedure [dbo].[proc_Group_User_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Group_User_Delete] 
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    delete GroupUser where Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Group_User_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Group_User_Insert]
	@Name nvarchar(100),
	@Group_Type int, 
	@Note nvarchar(500),
	@Id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into GroupUser ([Name],[Group_Type],[Note])
	values(@Name,@Group_Type,@Note);

	select @Id = id from GroupUser where Name = @Name;
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Group_User_Update]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Group_User_Update]
	@Name nvarchar(100),
	@Group_Type int, 
	@Note nvarchar(500),
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   update GroupUser set Name = @Name, Note = @Note where Id = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Group_UserGetAll]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Group_UserGetAll] 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select * from GroupUser
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Product_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Product_Delete]
    @Product_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Product] where [Product_Id] =@Product_Id

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Product_Detail_Delete_By_Product_Id]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Product_Detail_Delete_By_Product_Id]
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
/****** Object:  StoredProcedure [dbo].[proc_Product_Detail_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Product_Detail_Insert]
	@Product_Id int,
	@Color_Id int,
	@Ri_Count int,
	@Total_Count int,
	@Name nvarchar(50),
	@Size nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Insert into [dbo].[Product_Detail] ([Product_Id],[Color_Id],[Ri_Count],[Total_Count],[Total_Sale],[Name],[Size])
	values (@Product_Id,@Color_Id,@Ri_Count,@Total_Count,0,@Name,@Size);
	 
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Product_Get_ByCode]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Product_Get_ByCode] 
	@Product_Code nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    
	select p.*,s.Supplier_Name,s.Phone,c.Category_Name ,(p.Total_Receive - p.Total_Sale ) as total_remain
	from [dbo].[Product] p
	left join [dbo].[Supplier] s on s.Supplier_Id = p.Supplier_Id
	Join [dbo].[tb_Category] c on c.Category_Id = p.Category_Id

	where p.Product_Code LIKE  + '%'+ @Product_Code + '%';

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Product_Get_Max_Id]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Product_Get_Max_Id]
    @Product_Id int Out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select @Product_Id= max( [Product_Id]) from [dbo].[Product] where Deleted = 0
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Product_GetAll]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Product_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select a.*,s.Supplier_Name,s.Phone,c.Category_Name ,(a.Total_Receive - a.Total_Sale ) as total_remain
	from [dbo].[Product] a
	left join [dbo].[Supplier] s on s.Supplier_Id = a.Supplier_Id
	Join [dbo].[tb_Category] c on c.Category_Id = a.Category_Id

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Product_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Product_Insert]
	@Name nvarchar(50),
	@Note nvarchar(50),
    @Category_Id int,
	@Receive_Date date,
	@Receive_Price decimal(18,0),
	@Per_BanLe decimal(18,2),
	@BanLe_Price decimal(18,0),

	@Per_BanBuon decimal(18,2),
	@BanBuon_Price decimal(18,0),
	@Receive_Count int,
	@Count_by_Ri int,
	@Supplier_Id int,
	@Is_XuatDu int,
	@Color_Name nvarchar(50),
	@Total_Receive int,
	@Ship_Price decimal(18,0),
	@Product_Code nvarchar(50),
	@Size nvarchar(50),
	@Unit int,
	@User_Name nvarchar(50),
	@Product_Id INT OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into [dbo].[Product] ([Name],[Note],[Deleted],[Category_Id],[Receive_Date],[Receive_Price],
		[Per_BanLe],[BanLe_Price],[Per_BanBuon],[BanBuon_Price],[Receive_Count],[Count_by_Ri],[Supplier_Id],
		[Is_XuatDu],[Color_Name],[Total_Receive],[Total_Sale],[Ship_Price],[Product_Code],[Size],[Unit],[User_Name])
	values (@Name,@Note,0,@Category_Id,@Receive_Date,@Receive_Price,
		@Per_BanLe,@BanLe_Price,@Per_BanBuon,@BanBuon_Price,@Receive_Count,@Count_by_Ri,@Supplier_Id,
		@Is_XuatDu,@Color_Name,@Total_Receive,0,@Ship_Price,@Product_Code,@Size,@Unit,@User_Name)

	select @Product_Id=  [Product_Id] from [dbo].[Product] where [Name] = @Name

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Sale_Detail_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Sale_Detail_Insert] 
	@Sale_Header_Id int,
	@Product_Id int,
	@Status int,
	@Count int,
	@Color_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into [dbo].[Sale_Detail]([Sale_Header_Id],[Product_Id],[Status],[Count],[Color_Id])
	values (@Sale_Header_Id,@Product_Id,@Status,@Count,@Color_Id)
  
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Sale_Header_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_Sale_Header_Delete]
    @Sale_Header_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Sale_Header] where [Sale_Header_Id] =@Sale_Header_Id

END
GO
/****** Object:  StoredProcedure [dbo].[proc_Sale_Header_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	@Comment nvarchar(200),
	@SoHoaDon nvarchar(100),

	@Ship_Price decimal(18,0),
	@Per_Discont decimal(18,2),
	@Discount decimal(18,0),
	@Pay_Type int,
	@Per_Discount_Price int,
	@Sale_Header_Id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into [dbo].[Sale_Header]([Customer_Id],[BranchId],[Sale_Date],[SalesType],[Total_Amount],
		 [Debt_Amount],[UserName],[CreatedDate],[Comment],[SoHoaDon],[Ship_Price],
		 [Per_Discont],[Discount],[Pay_Type],[Modifi_Date],[Per_Discount_Price])
	values (@Customer_Id,@BranchId,@Sale_Date,@SalesType,
		@Total_Amount,@Debt_Amount,@UserName,@CreatedDate,@Comment,@SoHoaDon, @Ship_Price,
		@Per_Discont,@Discount,@Pay_Type,@CreatedDate,@Per_Discount_Price)

	select @Sale_Header_Id=  [Sale_Header_Id] from [dbo].[Sale_Header] where [SoHoaDon] =  @SoHoaDon
  
END

GO
/****** Object:  StoredProcedure [dbo].[proc_Sale_Header_Search]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[proc_Sale_Header_Search]
	@SoHoaDon nvarchar(100),
	@Sale_Date nvarchar(100),
	@Sale_Date_To nvarchar(100),
	@Customer_Name nvarchar(200)
AS
DECLARE @str_condition NVARCHAR(MAX)
DECLARE @str_sql NVARCHAR(MAX)
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    set @str_condition = '';

	if @SoHoaDon <> 'ALL' 
		set @str_condition = @str_condition + ' AND UPPER(sh.SoHoaDon) LIKE N'+ '''%' + @SoHoaDon + '%''';

	if @Sale_Date <> 'ALL' 
		set @str_condition = @str_condition + ' AND convert(varchar, sh.sale_date, 103) >= '+ '''' + @Sale_Date + '''';
	
	if @Sale_Date_To <> 'ALL' 
		set @str_condition = @str_condition + ' AND convert(varchar, sh.sale_date, 103) <= '+ '''' + @Sale_Date_To + '''';

	if @Customer_Name <> 'ALL'
		set @str_condition = @str_condition + ' AND  UPPER(c.Customer_Name) LIKE '+ '''%' + @Customer_Name+ '%''';
   
   set @str_condition = @str_condition + 'order by sh.Sale_Date,c.Customer_Name';

    DECLARE @query NVARCHAR(MAX);
	SET @query = 'select sh.*,c.Customer_Name 
	from Sale_Header sh
	join Customer c on c.Customer_Id = sh.Customer_Id WHERE 0 = 0 ' + @str_condition;

    EXECUTE(@query)

END

GO
/****** Object:  StoredProcedure [dbo].[proc_SaleHeader_Get_Max_Id]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_SaleHeader_Get_Max_Id]
    @Sale_Header_Id int Out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select @Sale_Header_Id= max( [Sale_Header_Id]) from [dbo].[Sale_Header]
END
GO
/****** Object:  StoredProcedure [dbo].[proc_Search_Product]    Script Date: 01/10/2014 11:40:16 PM ******/
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
		set @str_condition = @str_condition + ' AND UPPER(Product_Code) LIKE N'+ '''%' + @Product_Code + '%''';
	
	if @Product_Name <> 'all'
		set @str_condition = @str_condition + ' AND  UPPER(Name) LIKE N'+ '''%' + @Product_Name+  '%''';
   
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
/****** Object:  StoredProcedure [dbo].[proc_Supplier_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[proc_Supplier_Delete]
    @Supplier_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	delete [dbo].[Supplier] where Supplier_Id =@Supplier_Id

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Supplier_GetAll]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[proc_Supplier_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select * from [dbo].[Supplier]

END

GO
/****** Object:  StoredProcedure [dbo].[proc_Supplier_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_ThuChi_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_ThuChi_Insert]
	@SoHoadon nvarchar(50),
	@Create_Date date,
	@ThuChi int,
	@Price decimal(18,0),
	@DienGiai nvarchar(200),
	@Customer_Id int,
	@Supplier_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   insert into [dbo].[ThuChi] ([SoHoadon],[Create_Date],[ThuChi],[Price],[DienGiai],[Customer_Id],[Supplier_Id])
   values(@SoHoadon,@Create_Date,@ThuChi,@Price,@DienGiai,@Customer_Id,@Supplier_Id)
END

GO
/****** Object:  StoredProcedure [dbo].[proc_update_sale_Count]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_update_sale_Count]
	@Product_Id int,
	@Sale_count int,
	@Color_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[Product] set [Total_Sale] = [Total_Sale] + @Sale_count
	where Product_Id =@Product_Id

	if	@Color_id <> 0 
		update dbo.Product_Detail set Total_Sale = Total_Sale + @Sale_count where Product_Id = @Product_Id and Color_Id = @Color_id;
	 

END

GO
/****** Object:  StoredProcedure [dbo].[proc_User_Delete]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_User_Delete]
	@User_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Update [dbo].[User]  set  deleted = 1 where [User_Id] = @User_Id
END
GO
/****** Object:  StoredProcedure [dbo].[proc_User_Get_All]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_User_Get_All] 
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   Select us.*,g.Name as Group_Name from [dbo].[User] us
   join  GroupUser g on g.Id = us.Group_Id
    where deleted =0;

END
GO
/****** Object:  StoredProcedure [dbo].[proc_User_Insert]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[proc_User_Insert] 
	-- Add the parameters for the stored procedure here
	@User_Name nvarchar(50),
	@Pass nvarchar(50),
	@User_Type int,
	@FullName nvarchar(200),
	@Status int,
	@Phone nvarchar(50),
	@Group_Id int,
	@User_Id int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into [dbo].[User]([FullName],[User_Name],[Pass],[User_Type],[Status],[Phone],[Group_Id])
	values (@FullName,@User_Name,@Pass,@User_Type,@Status,@Phone,@Group_Id)

	select @User_Id=  [User_Id] from [dbo].[User] where [User_Name] = @User_Name;

END

GO
/****** Object:  StoredProcedure [dbo].[proc_User_Login]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_User_Login]
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
GO
/****** Object:  StoredProcedure [dbo].[proc_User_Update]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_User_Update] 
	-- Add the parameters for the stored procedure here
	@User_Name nvarchar(50),
	@Pass nvarchar(50),
	@User_Type int,
	@FullName nvarchar(200),
	@Status int,
	@Phone nvarchar(50),
	@Group_Id int,
	@User_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[User] set [FullName] = @FullName,[User_Name] = @User_Name,[Group_Id] = @Group_Id,
	[Status] = @Status,[User_Type] = @User_Type ,[Phone] = @Phone where [User_Id] = @User_Id;

END
GO
/****** Object:  StoredProcedure [dbo].[proc_User_Update_Last]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_User_Update_Last] 
	-- Add the parameters for the stored procedure here
	@Last_Login date,
	@User_Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    update [dbo].[User] set [Last_Login] = @Last_Login where [User_Id] = @User_Id  and deleted = 0;

END
GO
/****** Object:  StoredProcedure [dbo].[proc_User_Update_Pass]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_User_Update_Pass]
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
GO
/****** Object:  Table [dbo].[AllCode]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllCode](
	[CdName] [nvarchar](50) NULL,
	[CdType] [nvarchar](50) NULL,
	[CdValue] [nvarchar](50) NULL,
	[Content] [nvarchar](100) NULL,
	[Lstodr] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Color]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[Color_Id] [int] IDENTITY(1,1) NOT NULL,
	[ColorCode] [nvarchar](50) NOT NULL,
	[ColorName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[Color_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Customer_Id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_Name] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Deleted] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detail_Item]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Item](
	[Detail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL,
	[Sale_Price] [decimal](18, 0) NULL,
	[Per_Discount] [decimal](18, 0) NULL,
	[Status] [int] NULL,
	[Size] [nvarchar](50) NULL,
	[Color_Id] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Detail_Item] PRIMARY KEY CLUSTERED 
(
	[Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Function_Group]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Function_Group](
	[user_type] [int] NULL,
	[functionid] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupUser]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Group_Type] [int] NULL,
	[Note] [nvarchar](500) NULL,
 CONSTRAINT [PK_GroupUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Product_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL,
	[Deleted] [int] NULL,
	[Category_Id] [int] NULL,
	[Receive_Date] [date] NULL,
	[Receive_Price] [decimal](18, 0) NULL,
	[Per_BanLe] [decimal](18, 2) NULL,
	[BanLe_Price] [decimal](18, 0) NULL,
	[Per_BanBuon] [decimal](18, 2) NULL,
	[BanBuon_Price] [decimal](18, 0) NULL,
	[Receive_Count] [int] NULL,
	[Count_by_Ri] [int] NULL,
	[Supplier_Id] [int] NULL,
	[Is_XuatDu] [int] NULL,
	[Color_Name] [nvarchar](50) NULL,
	[Total_Receive] [int] NULL,
	[Total_Sale] [int] NULL,
	[Ship_Price] [decimal](18, 0) NULL,
	[Product_Code] [nvarchar](50) NULL,
	[Size] [nvarchar](200) NULL,
	[Unit] [int] NULL,
	[User_Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product_Detail]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Detail](
	[Product_Detail] [int] IDENTITY(1,1) NOT NULL,
	[Product_Id] [int] NOT NULL,
	[Color_Id] [int] NULL,
	[Ri_Count] [int] NULL,
	[Total_Count] [int] NULL,
	[Total_Sale] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Size] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product_Detail] PRIMARY KEY CLUSTERED 
(
	[Product_Detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sale_Detail]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Detail](
	[Sale_Detail_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Header_Id] [int] NULL,
	[Product_Id] [int] NULL,
	[Status] [int] NULL,
	[Count] [int] NULL,
	[Per_Discount] [decimal](18, 2) NULL,
	[Color_Id] [int] NULL,
 CONSTRAINT [PK_Sale_Detail] PRIMARY KEY CLUSTERED 
(
	[Sale_Detail_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sale_Header]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Header](
	[Sale_Header_Id] [int] IDENTITY(1,1) NOT NULL,
	[Sale_Date] [date] NULL,
	[SalesType] [int] NULL,
	[Customer_Id] [int] NULL,
	[Total_Amount] [decimal](18, 0) NULL,
	[Debt_Amount] [decimal](18, 0) NULL,
	[UserName] [nvarchar](50) NULL,
	[BranchId] [int] NULL,
	[CreatedDate] [date] NULL,
	[Comment] [nvarchar](200) NULL,
	[SoHoaDon] [nvarchar](100) NULL,
	[Ship_Price] [decimal](18, 0) NULL,
	[Per_Discont] [decimal](18, 2) NULL,
	[Discount] [decimal](18, 0) NULL,
	[Pay_Type] [int] NULL,
	[Modifi_Date] [date] NULL,
	[Per_Discount_Price] [int] NULL,
 CONSTRAINT [PK_Sale_Header] PRIMARY KEY CLUSTERED 
(
	[Sale_Header_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Supplier_Id] [int] IDENTITY(1,1) NOT NULL,
	[Supplier_Name] [nvarchar](200) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Supplier_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_Category]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_Category](
	[Category_Id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [nvarchar](50) NULL,
	[Note] [nvarchar](200) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThuChi]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuChi](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SoHoadon] [nvarchar](50) NULL,
	[Create_Date] [date] NULL,
	[ThuChi] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[DienGiai] [nvarchar](200) NULL,
	[Customer_Id] [int] NULL,
	[Supplier_Id] [int] NULL,
 CONSTRAINT [PK_ThuChi] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 01/10/2014 11:40:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](200) NULL,
	[User_Name] [nvarchar](50) NULL,
	[Pass] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[User_Type] [int] NULL,
	[Last_Login] [date] NULL,
	[Deleted] [int] NULL,
	[Phone] [nvarchar](50) NULL,
	[Group_Id] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Customer] ADD  CONSTRAINT [DF_Customer_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO
