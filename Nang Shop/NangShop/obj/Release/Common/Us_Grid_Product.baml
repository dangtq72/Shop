   M S B A M L   `   `   `  ���� C  ?NangShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NangShop.ControlNangShop.Control  %    NangShop.Common.Us_Grid_Product   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .abcclr-namespace:NangShop.Control     @d2http://schemas.microsoft.com/expression/blend/2008     $	��800��.���   � 	Resources     ColorDataProvider S� 
ObjectType#   NangShop.Control.Color_Member S� 
MethodName��%$   &	        S� "  $ 	Get_Color��.+�&   System.Windows.Controls.DataGrid  -   $��
dgrProduct��   CanUserAddRows .     AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .    Header$ Tên sản phẩm��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200   CenterAlignStyle1  +System.Windows.Controls.DataGridBoundColumn	   ElementStyle#	 [   TextCell
   	CellStyle#
 �     Binding �� *Name+4  .System.Windows.Controls.DataGridComboBoxColumn  $	 120    SelectedValuePath$ Color_Id��   DisplayMemberPath$ 
Color_Name��$
 Màu��   SelectedValueBinding �� *
Color_Id+   ItemsSource ��  �� Source# [     . $
 Size��$	 100 #	 [ #
 �   �� *Size+ �� Mode$ TwoWay=�   . $ Mô tả��$ * #	 [ #
 �   �� *Description+$ TwoWay=�