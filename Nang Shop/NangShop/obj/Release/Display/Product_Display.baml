   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock   NangShop&    NangShop.Display.Product_Display   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     -       AvalonDock.DockableContent   Name$  frmProductDisplay��   AvalonDock.ManagedContent   Title$! Thông tin lô hàng nhập��$	��420��$
��1024�� � 	Resources    Cmu m� InputGestureText��%�   &	        �� ���#D5DCE6.@�m� -   $��_Thêm mới��$ F3��
���   �m� -   $��Sửa��$ F4��
���   �m� -   $
��Xóa��$	 Del��
���   �m� -   $��Xem Chi Tiết��$ F5��
���   �.���  � RowDefinitions �� �� $��35 �.+�&   System.Windows.Controls.DataGrid  -   $��
dgrProduct��$��0��   AutoGenerateColumns .   � ContextMenu# [     CanUserAddRows .  $��Bottom=�   RowStyle �� 	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  .�-   
 �� Triggers
 P�  P� Property �@ AlternationIndex P� Value$ 0��. ���  �� Property � �� �� Value �	#FFEDEDED   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã SP��   MinWidth$	 120Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Product_Code+   . $ Tên SP��$	 200Q� �� *Name+   .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 120  �� *Status_Name+ �� $��Trạng thái��$��Center=�$��28��$
��Bold"�   ElementStyle �� "	 ��.���  �@��TextAlignment$
 Left=���  � ��$ 5,0,0,0q���  � ��$ Center=���  � ��$
 Bold"�
 ��  �� Binding ��  �� Path$ Status_Remain� �� Value 0.a���  � ��
 �  ����  �� $ Status_Remain� 1.a���  � ��
 � � �   . $ SL Tồn��$ 70Q� �� *Total_Remain+ �� StringFormat$ #,##0��   . $ Tổng nhập��$ 70Q� �� *Total_Receive+$ #,##0��   . $ Số đã bán��$ 70Q� �� *
Total_Sale+$ #,##0��   . $ Số lượng Ri��$ 70Q� �� *Receive_Count+$ #,##0��   . $ Số áo/Ri��$ 70Q� �� *Count_by_Ri+$ #,##0��    CenterAlignStyle# [  . $ Ngày nhập��$	 100Q� �� *Receive_Date+$ 
dd/MM/yyyy��   . $ Giá nhập��$ 70Q� �� *Receive_Price+$ #,##0��   . $ Tỷ lệ bán lẻ��$ 70Q� �� *	Per_BanLe+   . $ Giá bán le��$ 70Q� �� *BanLe_Price+$ #,##0��   . $ Tỷ lệ bán buôn��$ 70Q� �� *Per_BanBuon+   . $ Giá bán buôn��$ 70Q� �� *BanBuon_Price+$ #,##0��   . $ Loại��$	 100Q� �� *Category_Name+   . $ 
Nhà buôn��$	 100Q� �� *Supplier_Name+� $��1��  
BottomGrid#���  .+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��	btnInsert��$��5,0,0,0q�$��Center=�$��Center=�$��Thêm mới��$��75���� -	   $��	btnUpdate��$��5,0,0,0q�$y�	Collapsed=�$��Center=�$��Center=�$��Cập nhật��$��75���� -
   $��	btnDelete��$��5,0,0,0q�$��Center=�$��Center=�$
��Xóa��$��75���� -   $��btnView��$��5,0,0,0q�$��Center=�$��Center=�$��Xem chi tiết��$��75��