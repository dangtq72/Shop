   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock   NangShop%   NangShop.User.Functions_Display   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     -       AvalonDock.DockableContent   Name$  frmFunctions��   AvalonDock.ManagedContent   Title$ DANH SÁCH CHỨC NĂNG��$	��300��$
��1000�� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%a   '        �� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 30��.���  � RowDefinitions �� $��40 ��� $��* ��� $��40 �.+�� $��0��$��Stretch=�$��Center=�$��40�� � ColumnDefinitions �� $��15 ��� $	��500 ��� $	��100 ��� $��70 ��� $	��100 �.+�� $��1��
�������$
��Left=�$��Center=�.+��� -   $��	txtSearch��$��23��$
��Left=�$��0q�$��Center=�$��Center=�$	��350��$��5,0,0,0q�.��    
TextSearch j� TileMode	 j� Stretch
 j� 
AlignmentX !� Visual��%�   &	        !� $
 None=�$
	 None=�$

 Left=� �� $��Tên chức năng��$��Italic$�
�������$��Center=�$��5,0,0,0q�.������ " �� �� Triggers P�  P� Property � �� P� Value$  ��. ���  � ��# [  P�  � �� Z� . ���  � ��# [  .���� $��2��$��Right=�$��Center=�$��0,0,5,0q�$��Tổng số bản ghi���� -   $��txtTotal��$��3��$��Stretch=�$��Center=�$��Center=�$��0,0,20,0q��� -   $��	btnSearch��$��4��$��Tìm kiếm��$
��Left=�$��10,0,0,0q�$��90��$��Center=�� $��1��.+�&   System.Windows.Controls.DataGrid  -   $��dgFunctions��$��Stretch=�$��1,0,1,0q�   CanUserAddRows .     AutoGenerateColumns .     CanUserSortColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Tên chức năng��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 130   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *name+  $ Trạng thái�� . $	 120  �� *Status_Name+ �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=� ��  �� Binding ��  �� Path$ status� �� Value A.a���  � ��
 � � ���  �� $ status� C.a���  � ��
 �  ��  $ Object�� . $	 300 # [ # �   �� *	objname+  $ Shortcut�� . $	 120 # [ # �   �� *
shortcut+  $ Ghi chú�� . $	 300 # [ # �   �� *notes+���� )	  #System.Windows.Controls.DataGridRow" 	  ��  �� $
 prid� 0.a���  � ��$
 Bold"�� $��2��  
BottomGrid#���  $��0q�.+��� -   $��btnThoat��$��Thoát��$��Center=�$��90��$��Center=�