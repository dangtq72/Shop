   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    NangShop'   !NangShop.Display.Category_Display   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmCategoryDisplay��5   	      AvalonDock.ManagedContent   Title$( "Thông tin danh mục sản phẩm��5   	   $	��420��5   	   $
��1024��6    � 	Resources 5         Cmu m� InputGestureText��%&  &	        �� 5	   
   ���#D5DCE6.@�5
      m� -   5        $��_Thêm mới��5
      $ F3��6*   
���   �6T   m� 5      -   5        $��Sửa��5      $ F4��6$   
���   �6M   m� 5      -   5        $
��Xóa��5      $ F5��6$   
���   �6N   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��35 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgrCategory��5      $��0��6'      AutoGenerateColumns .   � ContextMenu# [  6R      CanUserAddRows .  $��Bottom=�5   3      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 Tên danh mục��6Y      MinWidth$	 200Q�6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Category_Name+6o     5      	 . $
 Ghi chú��6P   $	 200Q�6a    6%   �� *Note+6a   5      � 5   
   $��1��6     
BottomGrid#���  6   .+�5       ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5!      �� -   5        $��	btnInsert��5!      $��5,0,0,0q�6*   $��Center=�6;   $��Center=�6X   $��Thêm mới��6s   $��75��6�   6�   �� 5"      -   5        $��	btnUpdate��5"      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $��Cập nhật��6t   $��75��6�   6�   �� 5#      -   5        $��	btnDelete��5#      $��5,0,0,0q�6*   $��Center=�6<   $��Center=�6Y   $
��Xóa��6t   $��75��6�   6�   5$      5%      5&      5(      