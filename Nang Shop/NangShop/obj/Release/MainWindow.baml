   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:AvalonDock;assembly=AvalonDock
AvalonDock  ` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35tNclr-namespace:Microsoft.Windows.Controls.Ribbon;assembly=RibbonControlsLibrary!Microsoft.Windows.Controls.Ribbon  NangShop   NangShop.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;ad,clr-namespace:AvalonDock;assembly=AvalonDock     aribbonNclr-namespace:Microsoft.Windows.Controls.Ribbon;assembly=RibbonControlsLibrary     -     �Name$  frmmain��$	��768��$
��1024�� � Title$ Nắng Shop�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=� � Icon$( "/NangShop;component/Images/abc.png�� � 	Resources    mainSeparator �� 
TargetType �� Property �� Value	 �� Angle  DockETF   AvalonDock.DockingManager
 �� ImageSource j� Stretch j� TileMode j� Viewport j� ViewportUnits��%�   &	        &	 Y     �� " ��.���  � ��$ 1q���  � ��
 �������  � z� �� $	 90Q��� "  .���  � �� �� $4
 ./NangShop;component/Themes/Images/bgSystem.jpg��$
 Fill=�$
 Tile=�$ 0,0,257,256�$ Absolute=�.��� $��	-1,0,-1,0q� � RowDefinitions �� $
��Auto ��� $
��486* ��� $��37 �.+�� -   $��grid1��$��-.5,0,-.5,0q�$��0��.+��� $��Bottom=�$��	0,0,0,1.5q�
�������._�.  (Microsoft.Windows.Controls.Ribbon.Ribbon  -   $��ribbonMaster��$��Center=�$��	0,-23,0,0q����#FFF   ApplicationMenu =  7Microsoft.Windows.Controls.Ribbon.RibbonApplicationMenu  
�������
���iii�$��2q�.@�A  ;Microsoft.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   $��btnLock��$
��Lock��6  0Microsoft.Windows.Controls.Ribbon.RibbonMenuItem   ImageSource$ Images/Lock.png��$��Stretch=�   ToolTipTitle$ Lock (Ctrl + L)��   ToolTipDescription$ Khóa hệ thống��  -   $��	Resetpass��$��Change password��$ Images/ChangePass.png��  -   $
��Exit��$ Images/Exit.png��$ Exit (Alt + F4)��$  Thoát khỏi hệ thống��.@�1  +Microsoft.Windows.Controls.Ribbon.RibbonTab  -     Name$ rbnSale��$��
Bán hàng�� � OverridesDefaultStyle .  .@�3  -Microsoft.Windows.Controls.Ribbon.RibbonGroup  -     Name$ rg_Receive_Data��$�� ��$��Center=�$��Center=� J� SnapsToDevicePixels .   .  .@�4  .Microsoft.Windows.Controls.Ribbon.RibbonButton  -	     Name$ rbn_Receive��   Label$ Nhập hàng��   LargeImageSource$ Images/down.png��
 � Tag$ 
frmReceive��  -
   $ rbn_Sale��$ Hóa đơn bán lẻ��$ Images/up.png��$ frmSale��  -   $ rbn_Sale_Buon��$ Hóa đơn bán buôn��$ Images/up.png��$ frmSaleBuon��  -   $ 	rbnReport��$��Báo cáo, thống kê�� .  $��	-8,6,8,-6q�.@�  $��Tra Cứu Hóa Đơn��$��Center=�$��Center=� .   .  .@�  -   $ rbn_SaleHeader��$ 	Bán lẻ��$ Images/money.png��$ frmSaleHeaderDisplay��  -   $ rbn_SaleHeader_BanBuon��$ 
Bán buôn��$ Images/money.png��$! frmSaleHeaderDisplayBanBuon��  -   $ 	rbnAdjust��$��
Thông tin�� .  .@�  -   $ rg_Receive_Display��$��Thông tin sản phẩm��$��Center=�$��Center=� .   .  .@�  -   $ rbn_Product��$ Sản phẩm��$ Images/Product.png��$ frmProductDisplay��  -   $ rbn_Category��$ Loại sản phẩm��$ Images/Category.png��$ frmCategoryDisplay��  -   $ 	rbn_Color��$ 
Màu sắc��$ Images/Color.png��$ frmColorDisplay��  -   $ rg_Customer��$��Khách hàng��$��Center=�$��Center=� .   .  .@�  -   $ rbn_NhaBuon��$ 
Nhà buôn��$ Images/Suppliers.png��$ frmSupplierDisplay��  -   $ rbn_Customer��$ Khách mua hàng��$ Images/Customers.png��$ frmCustomerDisplay��  -   $ 
rbnManager��$��Quản trị�� .  .@�  -   $ rg_QT��$��Quản trị hệ thống��$��Center=�$��Center=� .   .  .@�  -   $ rbn_Group_User��$ Nhóm sử dụng��$ Images/icon_User.png��$ frmGroupUser��  -   $ rbn_User��$ Người sử dụng��$ Images/icon_User.png��$ frmUserDisplay��� -   $��grid2��$��1��$��0q�.+�  -     Name$ DockManager��$��0,0,0,-5q�$��1��  
mainSystem#���  $��Bottom=�   IsAnimationEnabled . ���	#FFC4C4C4   ActiveContent ��  �� ElementName$ Content1��.��	   AvalonDock.ResizingPanel	  .+�
   AvalonDock.DocumentPane
  $��0,0,0,0q��� $��Stretch=�$��2��  �� CornerRadius$  0,0,5,5��$��-.5,0,-.5,-5q�  BG2#���  ._�� ! � ColumnDefinitions! �� $��40 ��� $	��100 ��� $	��200 ��� $��* �.+��� -   $��
btnImgUser��$��0��$��20��$��20��  ButtonImage#���  $��Right=�$��Center=�" � ToolTip$
" User������ $)
 #/NangShop;component/Images/user.png���� -   $��username��$��1��$
��Bold"�$��0,0,0,0q�$
��Left=�$��Center=��� $��1��#���   $��Right=�$	��Top=�$��28��$��	0,7,-28,0q��� $��2��# �� Orientation$# 
Horizontal=�$��Stretch=�$��Center=�$��5,0,5,0q�.+��� $*��$/NangShop;component/Images/watch.png��$��20��$��20��$" Giờ giao dịch���� -   $��lbltime��$
��Left=�$��Center=�
���   �$
��Bold"�.��12:00