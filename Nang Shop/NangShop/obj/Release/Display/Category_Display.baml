   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock   NangShop'   !NangShop.Display.Category_Display   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     -       AvalonDock.DockableContent   Name$  frmCategoryDisplay��   AvalonDock.ManagedContent   Title$( "Thông tin danh mục sản phẩm��$	��420��$
��1024�� � 	Resources    Cmu m� InputGestureText��%�   &	        �� ���#D5DCE6.@�m� -   $��_Thêm mới��$ F3��
���   �m� -   $��Sửa��$ F4��
���   �m� -   $
��Xóa��$ F5��
���   �.���  � RowDefinitions �� �� $��35 �.+�&   System.Windows.Controls.DataGrid  -   $��dgrCategory��$��0��   AutoGenerateColumns .   � ContextMenu# [     CanUserAddRows .  $��Bottom=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 Tên danh mục��   MinWidth$	 200Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Category_Name+  	 . $
 Ghi chú��$	 200Q� �� *Note+� $��1��  
BottomGrid#���  .+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��	btnInsert��$��5,0,0,0q�$��Center=�$��Center=�$��Thêm mới��$��75���� -   $��	btnUpdate��$��5,0,0,0q�$��Center=�$��Center=�$��Cập nhật��$��75���� -   $��	btnDelete��$��5,0,0,0q�$��Center=�$��Center=�$
��Xóa��$��75��