   M S B A M L   `   `   `  ����H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  5   	    NangShop%   NangShop.User.Functions_Display   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     5   	   -   5            AvalonDock.DockableContent   Name$  frmFunctions��5   	      AvalonDock.ManagedContent   Title$ DANH SÁCH CHỨC NĂNG��5   	   $	��300��6%   $
��1000��62    � 	Resources 5	      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5
   
   "  6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 30��6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   $��Stretch=�6   $��Center=�6:   $��40��6U    � ColumnDefinitions 5      �� 5      $��15 �6#   �� 5      $	��500 �6#   �� 5      $	��100 �6#   �� 5      $��70 �6#   �� 5      $	��100 �6#   .+�5!      � $��1��6   
�������$
��Left=�66   $��Center=�6Q   .+�5"      �� -   5        $��	txtSearch��5"   L   $��23��6   $
��Left=�6&   $��0q�6A   $��Center=�6]   $��Center=�6x   $	��350��6�   $��5,0,0,0q�6�   .��6�    5#         
TextSearch j� TileMode	 j� Stretch
 j� 
AlignmentX !� Visual��%�   &	        !� 5$      $
 None=�69   $
	 None=�6I   $

 Left=�6X    5%      �� 5&   "   $��Tên chức năng��6(   $��Italic$�6@   
�������$��Center=�6e   $��5,0,0,0q�6�   5(      5)      .��6)   ��5*      �� 5+      " ��6     �� Triggers 5,      P� 5-   "    P� Property � �� P� Value$  ��6:   . �5.   &   ��  � ��# [  6C   5/   #   P� 50   "    � �� 6:   Z� . �51   &   ��  � ��# [  6C   52   #   54      .��55   %   56      57      �� 59      $��2��6   $��Right=�6$   $��Center=�6@   $��0,0,5,0q�6[   $��Tổng số bản ghi��6l   �� 5:      -   5        $��txtTotal��5:   �   $��3��6   $��Stretch=�6&   $��Center=�6D   $��Center=�6h   $��0,0,20,0q�6�   6�   �� 5;      -   5        $��	btnSearch��5;   p   $��4��6   $��Tìm kiếm��6%   $
��Left=�68   $��10,0,0,0q�6S   $��90��6e   $��Center=�6�   6�   5<      � 5>   
   $��1��6   .+�5?      &   System.Windows.Controls.DataGrid  -   5        $��dgFunctions��5?   E   $��Stretch=�6   $��1,0,1,0q�63      CanUserAddRows .     AutoGenerateColumns .     CanUserSortColumns .     Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Tên chức năng��6)      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 130 6k     CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 5C   )     TextCell   	CellStyle# �  6Z      Binding 5B   @   �� *name+5C   Z     5F      $ Trạng thái��6I    . $	 120 6o    6)   �� *Status_Name+ 5G      �� 5H      " ��6$   .�5I   "   ��  �@��TextAlignment$ Center=�6B   �� 5J   "    � ��$ Center=�6F    5K   "   �� 5L   &    �� Binding 62   ��  �� Path$ status� �� Value A6R   .a�5M   *   ��  � ��
 � � �6G   5N   '   �� 5O   &    62   �� $ status� C6R   .a�5P   *   ��  � ��
 �  ��6G   5Q   '   5S      5U        5W      $ Object��6E    . $	 300 6g   # [ 6s   # �  6�    6)   �� *	objname+6�     5Y      $ Shortcut��6F    . $	 120 6j   # [ 6v   # �  6�    6)   �� *
shortcut+6�     5\      $ Ghi chú��6C    . $	 300 6f   # [ 6r   # �  6�    6)   �� *notes+6�   ��5_      �� 5`      )	  #System.Windows.Controls.DataGridRow" 	 6    5a      �� 5b       6*   �� $
 prid� 06H   .a�5c   "   ��  � ��$
 Bold"�6?   5d      5f      5h      5i      � 5k   
   $��2��6     
BottomGrid#���  6   $��0q�6B   .+�5l      �� -   5        $��btnThoat��5l   B   $��Thoát��6   $��Center=�6%   $��90��6R   $��Center=�6]   6x   5m      5n      5o      