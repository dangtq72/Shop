   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    NangShop%   NangShop.Display.HoaDon_Display   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmSaleHeaderDisplay��5   	      AvalonDock.ManagedContent   Title$ Hóa đơn bán lẻ��5      $	��420��5   	   $
��1024��6    � 	Resources 5         Cmu m� InputGestureText��%9  &	        �� 5	   
   ���#D5DCE6.@�5
      m� -   5        $��In hóa đơn��5
      $ Print��6+   
���   �6X   m� 5      -   5        $��Kết xuất��5      $ F3��6)   
���   �6S   m� 5      -   5        $��Đổi hàng��5      $ F4��6)   
���   �6S   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      �� 5      $��35 �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   ���#E1E1E1.+�5      �� $��Số hóa đơn��6   $��5,0,0,0q�6)   $
��Left=�6:   �� 5      -   5        $��txtSoHoaDon��5      $��5,0,0,0q�6)   $	��150��6:   $��Center=�6F   $��1��6a   �� 5      $��Tên khách hàng��6   $��5,0,0,0q�6-   $
��Left=�6>   �� 5      -   5        $��txtCustomer_Name��5      $��5,0,0,0q�6.   $	��150��6?   $��Center=�6K   $��2��6f   �� 5      $��Ngày bán từ��6   $��5,0,0,0q�6*   $
��Left=�6;   (  "System.Windows.Controls.DatePicker  5       -   5        $��
dpSaleDate��5       $��1��6+   $��5��6;   $��Center=�6H   $	��100��6c   $
��Left=�6o   $��3��6�   �� 5"      $��Ngày bán đến��6   $��5,0,0,0q�6+   $
��Left=�6<     5#      -   5        $��dpSaleDateTo��5#      $��1��6-   $��5��6=   $��Center=�6J   $	��100��6e   $
��Left=�6q   $��4��6�   �� 5&      -	   5        $��	btnSearch��5&   (   $��Tìm kiếm��6   $��15,0,0,0q�6Q   $��Center=�6c   $��90��6~   $��5��6�   �� 5'      -
   5        $��	btnExport��5'      $��5,0,0,0q�6&   $��Center=�68   $��Center=�6U   $��Kết xuất��6p   $��75��6�   $��6��6�   5(      &   System.Windows.Controls.DataGrid  5*   
   -   5        $��dgrSaleHeader��5*      $��1��6)      AutoGenerateColumns .   � ContextMenu# [  6T      CanUserAddRows .  $��Bottom=�5,   3   	   RowStyle	 5-      �� 5.      
 �� 
TargetType)  #System.Windows.Controls.DataGridRow"
  6   .�5/      -   5         �� Triggers 50      P� 51       P� Property �@ AlternationIndex P� Value$ 0��6>   . �52      ��  �� Property � �� �� Value �	#FFEDEDED6;   53      55         Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Số hóa đơn��6T      MinWidth$	 200Q�6h   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
SoHoaDon+6h     59       . $ 
Ngày bán��6m   $	 120Q�6    6%   �� *	Sale_Date+ �� StringFormat$ 
dd/MM/yyyy��6     5:       . $ Loại��6Y   $	 120Q�6g    6%   �� *Str_SalesType+6g     5;       . $ Tên khách hàng��6Y   $	 200Q�6q    6%   �� *Customer_Name+6q     5<       . $ Tổng số tiền TT��6l   $	 120Q�6�    6%   �� *Total_Amount+$ #,##0��6�     5=       . $ Tiền khuyến mại��6h   $	 120Q�6�    6%   �� *
Discount+$ #,##0��6�     5>       . $ Người lập hóa đơn��6T   $	 120Q�6o    6%   �� *
UserName+6o   5@      � 5B   
   $��2��6     
BottomGrid#���  6   .+�5C      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5D      �� -   5        $��btnChangeProduct��5D      $��5,0,0,0q�61   $��Center=�6C   $��Center=�6`   $��Đổi hàng��6{   $��75��6�   $��7��6�   �� 5E      -   5        $��
btnExport1��5E      $��5,0,0,0q�6+   $��Center=�6=   $��Center=�6Z   $��Kết xuất��6u   $��75��6�   $��8��6�   �� 5F      -   5        $��btnPrint��5F      $��5,0,0,0q�6)   $��Center=�6;   $��Center=�6X   $��In hóa đơn��6s   $��75��6�   $��9��6�   �� 5G      -   5        $��btnExit��5G      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $��Thoát��6r   $��75��6�   $��10��6�   5H      5I      5J      5L      