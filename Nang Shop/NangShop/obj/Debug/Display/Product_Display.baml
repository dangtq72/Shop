   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    NangShop&    NangShop.Display.Product_Display   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmProductDisplay��5   	      AvalonDock.ManagedContent   Title$! Thông tin lô hàng nhập��5   
   $	��420��5   	   $
��1024��6    � 	Resources 5         Cmu m� InputGestureText��%  &	        �� 5	   
   ���#D5DCE6.@�5
      m� -   5        $��_Thêm mới��5
      $ F3��6*   
���   �6T   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $	 Del��6$   
���   �6O   m� 5      -   5        $��Xem Chi Tiết��5      $ F5��6-   
���   �6W   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��35 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgrProduct��5      $��0��6&      AutoGenerateColumns .   � ContextMenu# [  6Q      CanUserAddRows .  $��Bottom=�5   3      RowStyle 5      �� 5      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5      -   5        
 �� Triggers
 5      P� 5       P� Property �@ AlternationIndex P� Value$ 0��6>   . �5       ��  �� Property � �� �� Value �	#FFEDEDED6;   5!      5#         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Mã SP��6X      MinWidth$	 120Q�6g   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Product_Code+6g     5'       . $ Tên SP��6P   $	 200Q�6`    6%   �� *Name+6`     5)       .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6W    6%   �� *Status_Name+ 5*      �� 5+      $��Trạng thái��6    $��Center=�65   $��28��6P   $
��Bold"�6\      ElementStyle 5.      �� 5/      "	 ��6    .�50      ��  �@��TextAlignment$
 Left=�6>   �� 51       � ��$ 5,0,0,0q�67   �� 52       � ��$ Center=�6B   �� 53       � ��$
 Bold"�6;   
 54      �� 55   "    �� Binding 6.   ��  �� Path$ Status_Remain� �� Value 06U   .a�56   &   ��  � ��
 �  ��6C   57   #   �� 58   "    6.   �� $ Status_Remain� 16U   .a�59   &   ��  � ��
 � � �6C   5:   #   5<      5>        5@       . $ SL Tồn��6l   $ 70Q�6|    6%   �� *Total_Remain+ �� StringFormat$ #,##0��6|     5A       . $ Tổng nhập��6m   $ 70Q�6�    6%   �� *Total_Receive+$ #,##0��6�     5B       . $ Số đã bán��6j   $ 70Q�6}    6%   �� *
Total_Sale+$ #,##0��6}     5D       . $ Số lượng Ri��6m   $ 70Q�6�    6%   �� *Receive_Count+$ #,##0��6�     5E       . $ Số áo/Ri��6k   $ 70Q�6}    6%   �� *Count_by_Ri+$ #,##0��6}     5G        CenterAlignStyle# [ 6^    . $ Ngày nhập��6�   $	 100Q�6�    6%   �� *Receive_Date+$ 
dd/MM/yyyy��6�     5H       . $ Giá nhập��6m   $ 70Q�6    6%   �� *Receive_Price+$ #,##0��6     5J       . $ Tỷ lệ bán lẻ��6U   $ 70Q�6k    6%   �� *	Per_BanLe+6k     5K       . $ Giá bán le��6k   $ 70Q�6    6%   �� *BanLe_Price+$ #,##0��6     5M       . $ Tỷ lệ bán buôn��6W   $ 70Q�6o    6%   �� *Per_BanBuon+6o     5N       . $ Giá bán buôn��6m   $ 70Q�6�    6%   �� *BanBuon_Price+$ #,##0��6�     5P       . $ Loại��6Y   $	 100Q�6g    6%   �� *Category_Name+6g     5Q       . $ 
Nhà buôn��6Y   $	 100Q�6k    6%   �� *Supplier_Name+6k   5T      � 5V   
   $��1��6     
BottomGrid#���  6   .+�5W      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5X      �� -   5        $��	btnInsert��5X      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm mới��6s   $��75��6�   6�   �� 5Y      -	   5        $��	btnUpdate��5Y      $��5,0,0,0q�6*   $y�	Collapsed=�6;   $��Center=�6S   $��Center=�6p   $��Cập nhật��6�   $��75��6�   6�   �� 5Z      -
   5        $��	btnDelete��5Z      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   �� 5[      -   5        $��btnView��5[      $��5,0,0,0q�6(   $��Center=�6:   $��Center=�6W   $��Xem chi tiết��6r   $��75��6�   6�   5\      5]      5^      5_      