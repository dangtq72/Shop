   M S B A M L   `   `   `  ����   NangShop    NangShop.User.User_Rights   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$&   Phân quyền cho người dùng��$	��544��$
��1000�� � WindowStartupLocation$ CenterScreen=�   WindowFormStyle#���    � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value  	Use_Right d� 	IsChecked  
View_Right  Insert_Right  Update_Right  Delete_Right  Approve_Right  
Full_Right��%^  '        &	 o     &	 �     &	 o    &	 �    &	 y    &	 �    &	 �    �� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$
 Bold"���  � ��$ 30���� .R�� .+��� $��	Use_Right��-   $��Center=�$��Center=�y��� *Show+ �� *	use_right+���� *Br_N+�� .R�� .+��� $��
view_right��-   $��Center=�$��Center=�y��� *Show+ �� *
view_right+���� *Br_N+�� .R�� .+��� $��insert_right��-   $��Center=�$��Center=�y��� *Show+ �� *insert_right+���� *Br_N+�� .R�� .+��� $��update_right��-   $��Center=�$��Center=�y��� *Show+ �� *update_right+���� *Br_N+�� .R�� .+��� $��delete_right��-   $��Center=�$��Center=�y��� *Show+ �� *delete_right+���� *Br_N+�� .R�� .+��� $��approveInfo_right��-   $��Center=�$��Center=�y��� *Show+ �� *approveInfo_right+���� *Br_N+�� .R�� .+��� $��
Full_Right��-   $��Center=�$��Center=�y��� *Show+ �� *
Full_Right+���� *Br_N+.���  � RowDefinitions �� $��45 ��� $��* ��� $��40 �.+�� $��0�� � ColumnDefinitions �� $��15 ��� $��* �.+�� $��1�����#FFFFFF$
��Left=�$��Center=�.+��� -	   $��	txtSearch��$��23��$��0,0,0,0q�$��5,0,0,0q�$��Center=�$��Center=�$	��350��.��   
TextSearch	 j� TileMode
 j� Stretch j� 
AlignmentX !� Visual��%�   &	       !� $
	 None=�$

 None=�$
 Left=� �� $��Tên chức năng��$��Center=�$��Center=�$��Italic$�
�������$��5,0,0,0q�.������ " �� �� Triggers P�  P� Property � �� P� Value$  ��. ���  � ��# [ P�  � �� Z� . ���  � ��# [ .���� -
   $��	btnSearch��$��1��$��90��$��Tìm kiếm��$
��Left=�$��	365,0,0,0q�$��Center=�� $��1��.+�&   System.Windows.Controls.DataGrid  -   $��grUser_Rights��   CanUserAddRows .     AutoGenerateColumns .  $��3q�$��Stretch=�$��Stretch=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *name+   Header �� $��Tên chức năng��$��Center=�$��Center=�$
��Bold"�4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [  . $ 80  �� $��Sử dụng��$��Center=�$��Center=�$
��Bold"�   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .�-     # [  . $ 80  �� $��Xem TT��$��Center=�$��Center=�$
��Bold"� �� "  .�-     # [  . $ 80  �� $��Thêm��$��Center=�$��Center=�$
��Bold"� �� "  .�-     # [  . $ 80  �� $��Sửa��$��Center=�$��Center=�$
��Bold"� �� "  .�-     # [  . $ 80  �� $
��Xóa��$��Center=�$��Center=�$
��Bold"� �� "  .�-     # [  . $ 80    
Visibility$ Hidden=� �� $��
Duyệt TT��$��Center=�$��Center=�$
��Bold"� �� "  .�-     # [  . $ 40  �� "  .�-    �� -   $��chkCheckAll��$��Center=�$��Center=����� )	  #System.Windows.Controls.DataGridRow" 	  ��  �� Binding ��  �� Path$
 prid� �� Value 0.a���  � ��$
 Bold"�� -   $��	grdButton��$��2�� 	 
BottomGrid#��� 	 $��0q�.+�� $��Center=�$��Center=�.+��� -   $��btnChapNhan��$��Chấp nhận��$��90��$
��Left=�$��Center=�$��0,0,0,0q��� -   $��btnHuy��$��Thoát��$��90��$
��Left=�$��85,0,0,0q�$��Center=�