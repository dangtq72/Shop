   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock   NangShop%   NangShop.Display.HoaDon_Display   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     -       AvalonDock.DockableContent   Name$  frmSaleHeaderDisplay��   AvalonDock.ManagedContent   Title$ Hóa đơn bán lẻ��$	��420��$
��1024�� � 	Resources    Cmu m� InputGestureText��%�   &	        �� ���#D5DCE6.@�m� -   $��In hóa đơn��$ Print��
���   �m� -   $��Kết xuất��$ F3��
���   �m� -   $��Đổi hàng��$ F4��
���   �.���  � RowDefinitions �� $��35 ��� �� $��35 �.+���  �� Orientation$ 
Horizontal=�$��Center=����#E1E1E1.+��� $��Số hóa đơn��$��5,0,0,0q�$
��Left=��� -   $��txtSoHoaDon��$��5,0,0,0q�$	��150��$��Center=�$��1���� $��Tên khách hàng��$��5,0,0,0q�$
��Left=��� -   $��txtCustomer_Name��$��5,0,0,0q�$	��150��$��Center=�$��2���� $��Ngày bán từ��$��5,0,0,0q�$
��Left=�(  "System.Windows.Controls.DatePicker  -   $��
dpSaleDate��$��1��$��5��$��Center=�$	��100��$
��Left=�$��3���� $��Ngày bán đến��$��5,0,0,0q�$
��Left=�  -   $��dpSaleDateTo��$��1��$��5��$��Center=�$	��100��$
��Left=�$��4���� -	   $��	btnSearch��$��Tìm kiếm��$��15,0,0,0q�$��Center=�$��90��$��5���� -
   $��	btnExport��$��5,0,0,0q�$��Center=�$��Center=�$��Kết xuất��$��75��$��6��&   System.Windows.Controls.DataGrid  -   $��dgrSaleHeader��$��1��   AutoGenerateColumns .   � ContextMenu# [     CanUserAddRows .  $��Bottom=�	   RowStyle	 �� 
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  .�-    �� Triggers P�  P� Property �@ AlternationIndex P� Value$ 0��. ���  �� Property � �� �� Value �	#FFEDEDED   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Số hóa đơn��   MinWidth$	 200Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
SoHoaDon+   . $ 
Ngày bán��$	 120Q� �� *	Sale_Date+ �� StringFormat$ 
dd/MM/yyyy��   . $ Loại��$	 120Q� �� *Str_SalesType+   . $ Tên khách hàng��$	 200Q� �� *Customer_Name+   . $ Tổng số tiền TT��$	 120Q� �� *Total_Amount+$ #,##0��   . $ Tiền khuyến mại��$	 120Q� �� *
Discount+$ #,##0��   . $ Người lập hóa đơn��$	 120Q� �� *
UserName+� $��2��  
BottomGrid#���  .+��� $ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��btnChangeProduct��$��5,0,0,0q�$��Center=�$��Center=�$��Đổi hàng��$��75��$��7���� -   $��
btnExport1��$��5,0,0,0q�$��Center=�$��Center=�$��Kết xuất��$��75��$��8���� -   $��btnPrint��$��5,0,0,0q�$��Center=�$��Center=�$��In hóa đơn��$��75��$��9���� -   $��btnExit��$��5,0,0,0q�$��Center=�$��Center=�$��Thoát��$��75��$��10��