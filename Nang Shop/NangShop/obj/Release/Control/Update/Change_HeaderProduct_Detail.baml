   M S B A M L   `   `   `  ���� C  ?NangShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NangShop.ControlNangShop.Control  7    1NangShop.Control.View.Change_HeaderProduct_Detail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .abcclr-namespace:NangShop.Control     -     � WindowStartupLocation$  CenterScreen=� � Title$ Thông tin hóa đơn��$	��800�� � ShowInTaskbar .     WindowFormStyle#���    � 
ResizeMode$ NoResize=� � SizeToContent$ Height=� � 	Resources   Cmu m� InputGestureText��%c   &	       �� ���#D5DCE6.@�m� $��
btnTraHang��-   $��Trả hàng��$	 Del��
���   �.���  � RowDefinitions �� $	��110 ��� $��35 ��� $��35 ��� �� �� $��35 �.+�� $��0�� �� $��35 ��� $��35 ��� $��35 ��� $��35 ��� $��* � � ColumnDefinitions �� $	��105 ��� $��* ��� $	��105 ��� $��* ��� $	��105 ��� $��* �.+��� $��Tên khách hàng:��$��0��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtCustomer_Name��$��1��$��3��$��0��$	��400��$��Center=�$
��Left=�{�.  �� $��Điện thoại:��$��4��$��0��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPhone��$��5��$��0��$��Center=�$	��145��$
��Left=�{�.  �� $��Ngày mua hàng��$��0��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtSaleDate��$��1��$��1��$��Center=�$	��145��$
��Left=�{�.  �� $��Tiền hàng��$��4��$��2��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtTotalPrice��$��5��$��2��$��Center=�$	��145��$
��Left=��� $��Chiết khấu:��$��2��$��2��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtPerDiscount��$��3��$��2��$	��145��$��Center=�$
��Left=�{�.  �� $��Khuyến mãi:��$��2��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtDiscount��$��3��$��1��$	��145��$��Center=�$
��Left=�{�.  �� $��Số tiền TT��$��0��$��2��$��Right=�$��0,0,3,0q�$��Center=��� -	   $��txtPayPrice��$��1��$��2��$��Center=�$	��145��$
��Left=�{�.  �� $��
Ship Hàng��$��4��$��1��$��Right=�$��0,0,3,0q�$��Center=��� -
   $��txtShipPrice��$��5��$��1��$��Center=�$	��145��$
��Left=�{�.  �� 	 �� Orientation$	 
Horizontal=�$��1��$
��Left=�$��Center=�.+��� $��Thêm hàng mới��$��Center=�$��23,0,0,0q��� $��Mã SP:��$��Center=�$��23,0,0,0q��� -   $��txtProductCode��$��5,0,0,0q�$��Center=�$	��150��$��1���� $	��SL:��$��Center=�$��5,0,0,0q��� -   $��txtCount��$��5,0,0,0q�$��Center=�$��50��$��2���� -   $��btnAdd��$��Thêm SP��$��1��$��15,0,0,0q�$��Center=�$��Right=�$	��100��$��3���� $	 
Horizontal=�$
��Left=�$��Center=�$��2��.+��� $��Tên SP:��$��Center=�$��23,0,0,0q��� -   $��lblProduct_Name��$4��.AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA��$��Center=�$
��Bold"�$��0,0,0,0q��� $��Giá bán lẻ:��$��Center=�$��23,0,0,0q�$
��Bold"�
���  ���� -   $��lblSalePrice��$�� ��$��Center=�$
��Bold"�$��5,0,0,0q�
���  ���� $��Còn:��$��Center=�$��23,0,0,0q�$
��Bold"�
���  ���� -   $��	lblRemain��$�� ��$��Center=�$
��Bold"�$��1,0,0,0q�
���  ���� $
��(SP)��$��Center=�$��0,0,0,0q�$
��Bold"�
���  ���� $��Chi tiết đơn hàng��$��3��.��� .+�&   System.Windows.Controls.DataGrid  -   $��dgrProduct_Detail��
   CanUserAddRows
 .   � ContextMenu# [    AutoGenerateColumns .  $	��200��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên sản phẩm��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 250   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *Name+   . $ Số lượng��$ 90 # [ # �   �� *Count_Sale_By_Header+ �� StringFormat$ #,##0��   . $ 
Đơn giá��$	 120 # [ # �   �� *DonGia_By_Type+$ #,##0��   . $ Thành tiền��$	 150 # [ # �   �� *Total_Price+$ #,##0���� $"��Chi tiết hàng trả lại��$��4��.��� .+�  -   $��dgrProduct_Return��
 .   .  $	��200��    . $ Tên sản phẩm��$	 250 # [ # �   �� *Name+   . $ Số lượng��$ 90 # [ # �   �� *Count_Sale_By_Header+$ #,##0��   . $ 
Đơn giá��$	 120 # [ # �   �� *DonGia_By_Type+$ #,##0��   . $ Thành tiền��$	 150 # [ # �   �� *Total_Price+$ #,##0��� $��5��$��0q�  
BottomGrid#���  .+��� -   $��grdBtn��$	 
Horizontal=�$��Center=�$��Center=�.+��� -   $��	btnChange��$��Thay đổi��$��5,0,0,0q�$��75��$��4���� -   $��	btnCancel��$��Thoát��$��5,0,0,0q�$��75��$��5��