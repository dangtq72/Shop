   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock   NangShop"   NangShop.Display.UserDisplay   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     -       AvalonDock.DockableContent   Name$  frmUserDisplay��   AvalonDock.ManagedContent   Title$% Thông tin người sử dụng��$	��420��$
��1024�� � 	Resources    Cmu m� InputGestureText��%  &	        �� ���#D5DCE6.@�m� -   $��_Thêm mới��$ F3��
���   �m� -   $��Sửa��$ F4��
���   �m� -   $
��Xóa��$ F5��
���   �m� -   $��Reset mật khẩu��$ F6��
���   �m� -   $
��View��$ F7��
���   �.���  � RowDefinitions �� �� $��35 �.+�&   System.Windows.Controls.DataGrid  -   $��dgrUser��$��0��   AutoGenerateColumns .   � ContextMenu# [     CanUserAddRows .  $��Bottom=�   RowStyle �� 	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  .�-   
 �� Triggers
 P�  P� Property �@ AlternationIndex P� Value$ 0��. ���  �� Property � �� �� Value �	#FFEDEDED   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên đăng nhập��   MinWidth$	 150Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	User_Name+   . $ Tên đầy đủ��$	 200Q� �� *
FullName+   . $ Nhóm người dùng��$	 200Q� �� *
Group_Name+   . $&  Lần đăng nhập gần nhất��$	 200Q� �� *
Last_Login+ �� StringFormat$ dd/MM/yyyy:HH:MM:SS��� $��1��  
BottomGrid#���  .+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -	   $��	btnInsert��$��5,0,0,0q�$��Center=�$��Center=�$��Thêm mới��$��75���� -
   $��	btnUpdate��$��5,0,0,0q�$��Center=�$��Center=�$��Cập nhật��$��75���� -   $��	btnDelete��$��5,0,0,0q�$��Center=�$��Center=�$
��Xóa��$��75���� -   $��btnReset��$��5,0,0,0q�$��Center=�$��Center=�$��Reset mật khẩu��$��95���� -   $��btnView��$��5,0,0,0q�$��Center=�$��Center=�$	��Xem��$��75��