   M S B A M L   `   `   `  ����   NangShop    NangShop.GroupUser_Right   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $��frmGroupUser_Right��  � Title$(  "Phân quyền nhóm người dùng��$	��544��$	��800�� � WindowStartupLocation$ CenterScreen=�   WindowFormStyle#���    � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  CheckBoxParentID  DataGridColumnButton d� 	IsChecked��%  '        &	 W     &	 |     �� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 30���� " ��.���  � ��
 �  ���� .R�� .+��� -   $��Center=�$��Center=�y��� *Show+ �� *	ofgroup+���� *Br_N+.���  � RowDefinitions �� $��* ��� $��40 �.+�� $��0��.+�&   System.Windows.Controls.DataGrid  -   $��dgFunctions��$��Stretch=�$��6q�   CanUserAddRows .  	   AutoGenerateColumns	 .  
   CanUserSortColumns
 .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 350    
IsReadOnly .   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *name+   Header �� $��Tên chức năng��$��Center=�$��28��$
��Bold"�4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [  . $	 160  �� -   $��ckAll��$��Chức năng của nhóm��$��Center=�$��Center=�$
��Bold"� �� *  $System.Windows.Controls.DataGridCell"  .�-      . $	 100  �� *Status_Name+ �� $��Trạng thái��$��Center=�$��28��$
��Bold"� �� " ��.���  �@��TextAlignment$ Center=���  � ��$ Center=���  � ��$
 Bold"� �� Triggers ��  �� Binding ��  �� Path$ status� �� Value A.a���  � ��
 � � ���  �� $ status� C.a���  � ��
 �  ��   . $	 110 # [ # �   �� *
shortcut+ �� $��ShortCut��$��Center=�$��28��$
��Bold"�   . $	 300 # [ # �   �� *notes+ �� $��Ghi chú��$��Center=�$��28��$
��Bold"����� )	  #System.Windows.Controls.DataGridRow" 	  ��  �� $
 prid� 0.a���  � ��$
 Bold"�� $��1��  
BottomGrid#���  $��0q�.+�� $��Center=�$��Center=�.+��� -   $��	btnUpdate��$��Chấp nhận��$
��Left=�$��0,0,0,0q�$��90��$��Center=��� -   $��	btnCancel��$��Thoát��$
��Left=�$��95,0,0,0q�$��90��$��Center=�