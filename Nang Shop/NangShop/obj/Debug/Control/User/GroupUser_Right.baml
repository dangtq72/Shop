   M S B A M L   `   `   `  ����  NangShop    NangShop.GroupUser_Right   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��frmGroupUser_Right��5   	     � Title$(  "Phân quyền nhóm người dùng��5   	   $	��544��6,   $	��800��69    � WindowStartupLocation$ CenterScreen=�5   	      WindowFormStyle#���   6.    � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  CheckBoxParentID  DataGridColumnButton d� 	IsChecked��%�  '        &	 �     &	 �     �� 5   
   "  6   .�5	      ��  � ��$ Center=�6;   �� 5
       � ��$ Center=�69   �� 5       � ��$ 30��6'   5      �� 5   
   " ��6)   .�5      ��  � ��
 �  ��6,   5      �� 5   
   .R�5      � .+�5      �� -   5        $��Center=�5      $��Center=�68   y�6S   �� *Show+ 5      �� *	ofgroup+��6P   �� *Br_N+5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   � $��0��6   .+�5       &   System.Windows.Controls.DataGrid  -   5        $��dgFunctions��5    ?   $��Stretch=�6   $��6q�63      CanUserAddRows .  	   AutoGenerateColumns	 .  
   CanUserSortColumns
 .     Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 350 6B      
IsReadOnly .   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [ 6`     TextCell   	CellStyle# �  6�      Binding 6)   �� *name+   Header 5$      �� 5%      $��Tên chức năng��6$   $��Center=�6<   $��28��6W   $
��Bold"�6c   5'      4  .System.Windows.Controls.DataGridTemplateColumn  5)         CellTemplate# [ 6-    . $	 160 6t    5*      �� 5+      -   5        $��ckAll��5+   a   $��Chức năng của nhóm��6'   $��Center=�6D   $��Center=�6n   $
��Bold"�6�   6�    5-      �� 5.      *  $System.Windows.Controls.DataGridCell"  6$   .�5/   "   -   5        50      52        54       . $	 100 6[    6)   �� *Status_Name+ 55      �� 56      $��Trạng thái��6$   $��Center=�69   $��28��6T   $
��Bold"�6`    58      �� 59      " ��6$   .�5:   "   ��  �@��TextAlignment$ Center=�6B   �� 5;   "    � ��$ Center=�6F   �� 5<   "    � ��$
 Bold"�6?    �� Triggers 5=   "   �� 5>   &    �� Binding 62   ��  �� Path$ status� �� Value A6R   .a�5?   *   ��  � ��
 � � �6G   5@   '   �� 5A   &    62   �� $ status� C6R   .a�5B   *   ��  � ��
 �  ��6G   5C   '   5E      5G        5I       . $	 110 6X   # [ 6d   # �  6�    6)   �� *
shortcut+ 5J      �� 5K      $��ShortCut��6$   $��Center=�67   $��28��6R   $
��Bold"�6^   5M        5O       . $	 300 6U   # [ 6a   # �  6�    6)   �� *notes+ 5P      �� 5Q      $��Ghi chú��6$   $��Center=�66   $��28��6Q   $
��Bold"�6]   5S      ��5V      �� 5W      )	  #System.Windows.Controls.DataGridRow" 	 6    5X      �� 5Y       6*   �� $
 prid� 06H   .a�5Z   "   ��  � ��$
 Bold"�6?   5[      5]      5_      5`      � 5b   
   $��1��6     
BottomGrid#���  6   $��0q�6A   .+�5c      � $��Center=�6   $��Center=�60   .+�5d      �� -   5        $��	btnUpdate��5d   d   $��Chấp nhận��6   $
��Left=�6-   $��0,0,0,0q�6H   $��90��6Y   $��Center=�6u   6�   �� 5e      -   5        $��	btnCancel��5e   b   $��Thoát��6   $
��Left=�6*   $��95,0,0,0q�6E   $��90��6W   $��Center=�6s   6�   5f      5g      5h      5i      