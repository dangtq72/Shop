   M S B A M L   `   `   `  ����   NangShop3    -NangShop.Control.Created.FrmCreateSale_Header   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Hóa đơn bán lẻ�� � 
ResizeMode$ NoResize=� � SizeToContent$ Height=�$	��950�� � WindowStartupLocation$ CenterScreen=�   WindowFormStyle#���   .���  � RowDefinitions �� $��35 ��� $��35 ��� �� $��35 �.+���  �� Orientation$ 
Horizontal=�$
��Left=�$��Center=�.+��� $��Ngày bán:��$��Center=�$��5,0,0,0q�(  "System.Windows.Controls.DatePicker  -   $��
dpSaleDate��$��Center=�$	��100��$��5,0,0,0q��� $��Số HD:��$��Center=�$��5,0,0,0q��� -   $��txtSaleHeader��$��5,0,0,0q�$��Center=�$	��150��{�.  �� $��Mã/Tên SP:��$��Center=�$��5,0,0,0q��� -   $��txtProductCode��$��5,0,0,0q�$��Center=�$	��150��$��1���� -   $��btnQuickSearch��$	��...��$��Center=�$��2,0,0,0q�$��30���� $��Màu:��$��Center=�$��5,0,0,0q��� -   $��cboColor��$��5,0,0,0q�$��Center=�$	��100��$��2���� $	��SL:��$��Center=�$��5,0,0,0q��� -   $��txtCount��$��5,0,0,0q�$��Center=�$��75��$��3��� $��1�� � ColumnDefinitions �� $��* ��� $��80 �.+��� $ 
Horizontal=�$
��Left=�$��Center=�$��1��.+��� $��Tên SP:��$��Center=�$��23,0,0,0q��� -   $��lblProduct_Name��$4��.AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA��$��Center=�$
��Bold"�$��0,0,0,0q��� $��Giá bán lẻ:��$��Center=�$��23,0,0,0q�$
��Bold"�
���  ���� -	   $��lblSalePrice��$�� ��$��Center=�$
��Bold"�$��5,0,0,0q�
���  ���� $
��SL: ��$��Center=�$��23,0,0,0q�$
��Bold"�
���  ���� -
   $��	lblRemain��$�� ��$��Center=�$
��Bold"�$��1,0,0,0q�
���  ���� $
��(SP)��$��Center=�$��0,0,0,0q�$
��Bold"�
���  ��$y�	Collapsed=��� -   $��btnViewProduct��$	��...��$��Center=�$��10,0,0,0q�$��30���� -   $��btnAdd��$��Thêm SP��$��1��$��2,0,0,0q�$��Center=�$
��Left=�$��70��$��4��� $��2�� �� $��* ��� $��* �.+��� $��Sản phẩm đã chọn��.��&   System.Windows.Controls.DataGrid  -   $��
dgrProduct��   CanUserAddRows .     AutoGenerateColumns .  $	��250��	   RowStyle	 �� 
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  .�-    �� Triggers P�  P� Property �@ AlternationIndex P� Value$ 0��. ���  �� Property � �� �� Value �	#FFEDEDED   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã SP��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100   LeftAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *Product_Code+   . $ Tên SP��$	 200 # [ # �   �� *Name+   . $
 Size��$ 60   CenterAlignStyle# [ # �   �� *Size+   . $
 Màu��$ 80 # [ # �   �� *
Color_Name+   . $ 
Đơn vị��$ 60 # [ # �   �� *	Unit_Name+   . $ 	Giá bán��$	 150   RightAlignStyle# [ # �   �� *BanLe_Price+ �� StringFormat$ #,##0��     
Visibility$ 	Collapsed=�$ Chiết khấu��$	 100 # [  �� *Per_Discount+ �� Mode$ TwoWay=�   . $ SL��$ 50 # [  �� *Count_Sale_By_Header+$ #,##0��   . $ Thành tiền��$ *  �� *Total_Price+$ #,##0��� $��1�� �� $��35 ��� $��35 ��� $��35 ��� $��35 ��� $��* � �� $	��105 ��� $��* ��� $	��105 ��� $��* ��� $	��105 ��� $��* �.+��� $��Kiểu thanh toán:��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��
cboPayType��$��1��$��0��$	��145��$��Center=�$
��Left=�$��3���� $��Tiền hàng��$��0��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtTotalPrice��$��1��$��1��$��Center=�$	��145��$
��Left=�$��4���� $��Chiết khấu:��$��0��$��2��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPerDiscount��$��1��$��2��$	��145��$��Center=�$
��Left=�$��5���� $��Khuyến mãi:��$��0��$��3��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtDiscount��$��1��$��3��$	��145��$��Center=�$
��Left=�$��6���� $��Số tiền TT��$��0��$��4��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPayPrice��$��1��$��4��$��Center=�$	��145��$
��Left=�$��7���� $��Tên khách hàng:��$��2��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtCustomer_Name��$��3��$��0��$	��165��$��Center=�$
��Left=�$��8���� -   $��btnSearchCustomer��$	��...��$��3��$��0,0,0,0q�$��0��$��30��$��Center=�$��Right=�$��8���� $��Số điện thoại:��$��4��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPhone��$��5��$��0��$��Center=�$	��145��$
��Left=�$��9���� $��Địa chỉ��$��2��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��
txtAddress��$��3��$��1��$	��448��$��3��$��Center=�$
��Left=�$��10���� $��	Ghi chú:��$��2��$��2��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtNote��$��3��$��2��$	��448��$��3��$��Center=�$
��Left=�$��11���� $��Tiền ship:��$��2��$��3��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtShipPrice��$��3��$��3��$	��145��$��Center=�$
��Left=�$��12���� $��Tổng mặt hàng:��$��2��$��4��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtCount_Grid��$��3��$��4��$	��145��$��Center=�$
��Left=�{�.  �� $��Số lượng:��$��4��$��4��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtTotal_Count��$��5��$��4��$	��145��$��Center=�$
��Left=�{�.  � $��3��$��0q�  
BottomGrid#���  .+��� -   $��grdBtn��$ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��	btnExport��$��Kết xuất��$��0,0,0,0q�$	��110��$��13��$y�	Collapsed=��� -   $��	btnAccept��$��Tạo hóa đơn��$��5,0,0,0q�$��75��$��14���� -   $��	btnCancel��$��
Hủy bỏ��$��5,0,0,0q�$��75��$��15��