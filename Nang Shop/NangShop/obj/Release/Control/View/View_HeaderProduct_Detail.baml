   M S B A M L   `   `   `  ���� C  ?NangShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NangShop.ControlNangShop.Control  5    /NangShop.Control.View.View_HeaderProduct_Detail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .abcclr-namespace:NangShop.Control     -     � WindowStartupLocation$  CenterScreen=� � Title$ Thông tin hóa đơn��$	��800�� � ShowInTaskbar .     WindowFormStyle#���    � 
ResizeMode$ NoResize=� � SizeToContent$ Height=�.���  � RowDefinitions �� $��80 ��� �� $��35 �.+�� $��0�� �� $��35 ��� $��35 ��� $��35 ��� $��35 ��� $��* � � ColumnDefinitions �� $	��105 ��� $��* ��� $	��105 ��� $��* ��� $	��105 ��� $��* �.+��� $��Tên khách hàng:��$��0��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtCustomer_Name��$��1��$��0��$	��145��$��Center=�$
��Left=�{�.  �� $��Ngày mua hàng��$��0��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtSaleDate��$��1��$��1��$��Center=�$	��145��$
��Left=�{�.  �� $��Chiết khấu:��$��2��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPerDiscount��$��3��$��0��$	��145��$��Center=�$
��Left=�{�.  �� $��Khuyến mãi:��$��2��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtDiscount��$��3��$��1��$	��145��$��Center=�$
��Left=�{�.  �� $��Số tiền TT��$��4��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPayPrice��$��5��$��0��$��Center=�$	��145��$
��Left=�{�.  �� $��
Ship Hàng��$��4��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtShipPrice��$��5��$��1��$��Center=�$	��145��$
��Left=�{�.  �� $��Chi tiết đơn hàng��$��1��.��� .+�&   System.Windows.Controls.DataGrid  -   $��dgrProduct_Detail��   CanUserAddRows .     AutoGenerateColumns .  $	��200��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly
 .    Header$ Tên sản phẩm��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 250   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *Name+  
 . $ Số lượng��$ 90 # [ # �   �� *Count_Sale_By_Header+ �� StringFormat$ #,##0��  
 . $ 
Đơn giá��$	 120 # [ # �   �� *DonGia_By_Type+$ #,##0��  
 . $ Thành tiền��$	 150 # [ # �   �� *Total_Price+$ #,##0��� $��2��$��0q�  
BottomGrid#���  .+��� -	   $��grdBtn�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -
   $��	btnCancel��$��Thoát��$��5,0,0,0q�$��75��$��5��