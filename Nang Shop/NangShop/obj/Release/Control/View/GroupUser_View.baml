   M S B A M L   `   `   `  ����   NangShop    NangShop.GroupUser_View   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$)  #Xem chi tiết nhóm người dùng��   WindowFormStyle#���   $	��470��$	��700�� � WindowStartupLocation$ CenterScreen=�.���  � RowDefinitions �� $	��115 ��� $��* ��� $��40 �.+��� -   $��	grbStatus��$%��Thông tin nhóm người dùng��$��6q�$	��105��.��� $��75�� �� $��25 ��� $��50 � � ColumnDefinitions �� $	��135 ��� .+��� $��Tên nhóm người dùng��$��Right=�$��0,0,5,0q�$��Center=��� $��Ghi chú��$��Right=�$��0,0,5,0q�$��Center=�$��0��$��1���� -   $��txtName��$��Center=�$��1��$��0��$��0,0,15,0q�$��Stretch=�$��1�� �� 	MaxLength$	 100�� �� 
IsReadOnly . �� -   $��txtNotes��$��1��$��1��$��Stretch=�$��0,0,15,0q�$��Center=�$��45�� �� TextWrapping$
 Wrap=�$	 245��$��2�� . �� $��1��$��6,0,6,6q�$��Danh sách người dùng��.��&   System.Windows.Controls.DataGrid  -   $��dgrUser��$��3q�   CanUserAddRows .     AutoGenerateColumns .  	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   
IsReadOnly
 .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 120   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [   TextCell   	CellStyle# �     Binding �� *	User_Name+   Header �� $��Tên đăng nhập��$��Center=�$��28��$
��Bold"�  
 . $	 120 # [ # �   �� *
FullName+ �� $��Tên đầy đủ��$��Center=�$��28��$
��Bold"�  
 . $	 120 # [ # �   �� *
Group_Name+ �� $��Nhóm người SD��$��Center=�$��28��$
��Bold"�  
 . $	 250 # [ # �   �� *
Last_Login+ �� $&�� Lần đăng nhập cuối cùng��$��Center=�$��28��$
��Bold"�� $��2��  
BottomGrid#���  $��0q�.+��� -   $��	btnCancel��$��Thoát��$��Center=�$��70��$��Center=�$��3��