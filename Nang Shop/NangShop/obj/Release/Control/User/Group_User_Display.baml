   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock   NangShop&    NangShop.User.Group_User_Display   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     -       AvalonDock.DockableContent   Name$  frmGroupUser��   AvalonDock.ManagedContent   Title$% DANH SÁCH NHÓM NGƯỜI DÙNG��$	��300��$	��900�� � 	Resources  ��Name   Cmu m�Name m� InputGestureText*  $System.Windows.Controls.DataGridCell �� 
TargetType��%  &	        '  Y    �� $ cmuUser�����#D5DCE6.@�m� $ Cmu_Add��-   $��Thêm mới��$ F3��m� $ 
Cmu_Update��-   $��Cập nhật��$ F4��m� $ Cmu_View��-   $	��Xem��$ F5��m� $ Cmu_DelCorporateInfo��-   $
��Xóa��$	 Del��
���   ��� ���#B9B9B9m� $ Cmu_SetRight��-   $��Phân quyền��$ F7��
���   ��� "  .�-   .���  � RowDefinitions �� $��0 ��� $��* ��� $��40 �.+�&   System.Windows.Controls.DataGrid  -   $��dgrGroupUser��$��1��$��Stretch=�$��1,0,1,0q� � ContextMenu# [  	   CanUserAddRows	 .  
   AutoGenerateColumns
 .  $��3��   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .�-	    �� Triggers P�  P� Property �@ AlternationIndex P� Value$ 0��. ���  �� Property � �� �� Value �	#FFEDEDED   Columns 0  *System.Windows.Controls.DataGridTextColumn     
FontWeight$
 Bold"�,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 180   CenterAlignStyle1	  +System.Windows.Controls.DataGridBoundColumn 	  ElementStyle# [   TextCell   	CellStyle# �   	  Binding �� *Name+   Header �� $%��Tên nhóm người sử dụng��$��Center=�$��28��$
��Bold"�  $
 Bold"� . $ * # [ # �   �� *Note+ �� $��Ghi chú��$��Center=�$��28��$
��Bold"�� $��2��  
BottomGrid#���  $��0q�.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� -
   $��btnPhanQuyen��$��Phân quyền��$
��Left=�$��Center=�$��0,0,0,0q�$��4��  Button90#���  �� -   $��btnView��$	��Xem��$
��Left=�$��Center=�$��10,0,0,0q�$��5��#���  �� -   $��btnThem��$��Thêm mới��$
��Left=�$��10,0,0,0q�$��Center=�$��6��#���  �� -   $��btnSua��$��Cập nhật��$
��Left=�$��10,0,0,0q�$��Center=�$��7��#���  �� -   $��btnXoa��$
��Xóa��$
��Left=�$��10,0,0,0q�$��Center=�$��8��#���  �� -   $��btnThoat��$��Thoát��$
��Left=�$��10,0,0,0q�$��Center=�$��9��#���  