   M S B A M L   `   `   `  ���� C  ?NangShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NangShop.ControlNangShop.Control  /    )NangShop.Control.View.View_Product_Detail   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .abcclr-namespace:NangShop.Control     -     � Title$(  "Thông tin chi tiết sản phầm��$	��800�� � WindowStartupLocation$ CenterScreen=� � ShowInTaskbar .     WindowFormStyle#���    � 
ResizeMode$ NoResize=� � SizeToContent$ Height=�.���  � RowDefinitions �� �� �� $��35 �.+�� $��0�� �� $��1 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��1 ��� $��25 ��� $��25 ��� $��50 � � ColumnDefinitions �� $	��130 ��� .+��� $��Số HD:��$y�	Collapsed=�$��0��$��0��$��Right=�$��0,0,3,0q�$��Center=��� $��Tên sản phẩm:��$��0��$��1��$��Right=�$��0,0,3,0q�$��Center=��� $��
Loại SP:��$��0��$��2��$��Right=�$��0,0,3,0q�$��Center=��� $��Số dây áo:��$��0��$��3��$��Right=�$��0,0,3,0q�$��Center=��� $��Số áo/dây:��$��0��$��4��$��Right=�$��0,0,3,0q�$��Center=��� $��Ngày nhập:��$��0��$��5��$��Right=�$��0,0,3,0q�$��Center=��� $��
Size từ:��$��0��$��6��$��Right=�$��0,0,3,0q�$��Center=��� $��Giá nhập:��$��0��$��7��$��Right=�$��0,0,3,0q�$��Center=��� $��Tổng số tiền:��$y�	Collapsed=�$��0��$��8��$��Right=�$��0,0,3,0q�$��Center=��� $��Tỷ lệ bán lẻ:��$��0��$��9��$��Right=�$��0,0,3,0q�$��Center=��� $��Tỷ lệ bán buôn:��$��0��$��10��$��Right=�$��0,0,3,0q�$��Center=��� $��	Ghi chú:��$��0��$��11��$��Right=�$��0,0,3,0q�$��Center=��� -   $��txtSoHoaDon��$y�	Collapsed=�$��1��$��0��$��0,0,15,0q�$	��220��$��Center=�$
��Left=�{�.  �� -   $��txtProduct_Name��{�.  $��1��$��1��$��0,0,15,0q�$��Center=�$��Stretch=�$��1���� $��Mã Sản phẩm:��$��1��$��2��$
��Left=�$��	120,0,3,0q�$��Center=��� -   $��txtProductCode��$��2��$��1��$	��200��$��
220,0,15,0q�$��Center=�$
��Left=�$��3��{�.  �� $��Nhà buôn:��$��1��$��3��$
��Left=�$��	140,0,3,0q�$��Center=��� -   $��txtSupplier��$��3��$��1��$	��200��$��
220,0,15,0q�$��Center=�$
��Left=�$��5��{�.  �� -   $��txtItem_Type��$��2��$��1��$	��100��$��0,0,15,0q�$��Center=�$
��Left=�$��2��{�.  �� -   $��
txtCount_J��{�.  $��1��$��3��$	��100��$��0,0,15,0q�$��Center=�$
��Left=�$��4���� -   $��txtCount��{�.  $��1��$��4��$	��100��$��0,0,15,0q�$��Center=�$
��Left=�$��6���� $��Đơn vị:��$��1��$��4��$
��Left=�$��	140,0,3,0q�$��Center=��� -	   $��txtUnitName��{�.  $��4��$��1��$	��200��$��
220,0,15,0q�$��Center=�$
��Left=�$��7���� -
   $��txtReceiveDate��$��1��{�.  $��5��$��Center=�$	��100��$
��Left=�$��8���� -   $��txtSize��$��1��$��1��$��6��{�.  $��0,0,15,0q�$	��100��$��Center=�$
��Left=�$��9���� -   $��txtReceive_Price��$��1��$��7��{�.  $��0,0,15,0q�$	��150��$��Center=�$
��Left=�$��11���� $��Tiền ship:��$��1��$��7��$
��Left=�$��	170,0,3,0q�$��Center=��� -   $��txtShip_Price��$��1��$��7��{�.  $��
250,0,15,0q�$	��150��$��Center=�$
��Left=�$��12���� -   $��txtTotal_Price��$y�	Collapsed=�$��1��$��8��{�.  $��0,0,15,0q�$��Center=�$	��150��$
��Left=�$��13���� -   $��txtPerBanLe��$��1��$��9��{�.  $��0,0,15,0q�$��50��$��Center=�$
��Left=�$��14���� $��Giá bán lẻ:��$��1��$��9��$��	60,0,15,0q�$
��Left=�$��Center=��� -   $��txtPrice_BanLe��$��1��$��9��{�.  $��
150,0,15,0q�$	��150��$��Center=�$
��Left=�$��15���� -   $��txtPerBanBuon��$��1��$��10��{�.  $��0,0,15,0q�$��50��$��Center=�$
��Left=�$��16���� $��Giá bán buôn:��$��1��$��10��$��	60,0,15,0q�$
��Left=�$��Center=��� -   $��txtPrice_BanBuon��$��1��$��10��{�.  $��
150,0,15,0q�$	��150��$��Center=�$
��Left=�$��17���� -   $��txtNote��$��1��$��11��$��0,0,15,0q�{�.  $��42��$	��500�� �� TextWrapping$
 Wrap=�$��Center=�$
��Left=�$��16���� $��Chi tiết sản phẩm��$��1��.���  � 	Resources   ColorDataProvider	 S� 
ObjectType#   NangShop.Control.Color_Member
 S� 
MethodName��%$   &	       S� "	  $
 	Get_Color��.+�&   System.Windows.Controls.DataGrid  -   $��dgrProduct_Detail��   CanUserAddRows .     AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Ri��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *Name+4  .System.Windows.Controls.DataGridComboBoxColumn  $	 120    ElementStyle# [    SelectedValuePath$ Color_Id��   DisplayMemberPath$ 	ColorName��$
 Màu�� .    SelectedValueBinding �� *
Color_Id+   ItemsSource ��  �� Source# [    . $
 Size��$	 100 # [ # �   �� *Size+   . $ Tổng��$	 100 # [ # �   �� *Total_Count+   . $ SL đã bán��$	 100 # [ # �   �� *
Total_Sale+   . $ SL còn lại��$	 100 # [ # �   �� *Remain_Count+� $��2��$��0q�  
BottomGrid#���  .+��� -   $��grdBtn�� �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��	btnCancel��$��Thoát��$��5,0,0,0q�$��75��$��19��