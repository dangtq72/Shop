   M S B A M L   `   `   `  ����C  ?NangShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NangShop.ControlNangShop.Control  5      %    NangShop.Common.Us_Grid_Product   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .abcclr-namespace:NangShop.Control     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��800��6K   .��5      �   � 	Resources  5   
      ColorDataProvider S� 
ObjectType#   NangShop.Control.Color_Member S� 
MethodName��%7   &	        S� 5	      "  6;   $ 	Get_Color��6b   5
      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgrProduct��5         CanUserAddRows .     AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên sản phẩm��6P      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6f     CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn	   ElementStyle#	 [ 6r     TextCell
   	CellStyle#
 �  6�      Binding 6%   �� *Name+6�   4  .System.Windows.Controls.DataGridComboBoxColumn  5       $	 120 6S      SelectedValuePath$ Color_Id��5!   ,      DisplayMemberPath$ 
Color_Name��6I   $
 Màu��5"   n      SelectedValueBinding 5    )   �� *
Color_Id+   ItemsSource 5"   ,   ��  �� Source# [  6n     5$       . $
 Size��6]   $	 100 6k   #	 [ 6x   #
 �  6�    6%   �� *Size+ �� Mode$ TwoWay=�6�     5%       . $ Mô tả��6d   $ * 6s   #	 [ 6~   #
 �  6�    6%   �� *Description+$ TwoWay=�6�   5'      5(      5)      