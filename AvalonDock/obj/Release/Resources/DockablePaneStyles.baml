   M S B A M L   `   `   `  ���� H  DAvalonDock, Version=1.3.3585.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AvalonDock
AvalonDock  Q7clr-namespace:AvalonDock.Properties;assembly=AvalonDockAvalonDock.Properties  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� TypeInTargetAssembly    AvalonDock.DockingManager#   AvalonDock.ContextMenuElement   DockablePane �� 
ResourceId m� Command �� Path   AvalonDock.Converters    BoolToVisibilityConverter �� 	Converter   DockableContentTabItemStyle	 �� 
TargetType    AvalonDock.DockableContent
 �� Property �� Value �� 
TargetType J� SnapsToDevicePixels ��Name - )ManagedContentTabControlNormalBorderBrush �� CornerRadius ) %ManagedContentTabItemNormalBackground � ColumnDefinitions   AvalonDock.ImageEx  Name   AvalonDock.ManagedContent   Icon ��Name   Title 0 ,ManagedContentTabItemSelectedBorderBackround �� Triggers P� Property P� Value �� 
TargetName   AvalonDock.DockablePane  ad:DockingManager / +ad:AvalonDockBrushes.DefaultBackgroundBrush +� FocusedElement �� ElementName � RowDefinitions 4 0ad:AvalonDockBrushes.DockablePaneTitleBackground  PaneHeaderCommandStyle%   AvalonDock.Properties.Resources!   DockablePaneCommands_Close � ToolTip �� RelativeSource ��Name*    #DockablePaneCommands_ToggleAutoHide % !PaneHeaderContextMenuCommandStyle#!   DockablePane_ShowOptionsMenu 4	 0ad:AvalonDockBrushes.DockablePaneTitleForeground" ��Name-  'System.Windows.Input.KeyboardNavigation#   TabNavigation$   DirectionalNavigation%   TabIndex!	   AvalonDock.DockableTabPanel& 	 Name' K� IsItemsHost
   AvalonDock.PaneTabPanel( 
  TabItemStyle) �� Value* �� Binding <
 8ad:AvalonDockBrushes.DockablePaneTitleBackgroundSelected < 8ad:AvalonDockBrushes.DockablePaneTitleForegroundSelected   AvalonDock.Pane+ �� Angle%   AvalonDock.FloatingDockablePane, �� BasedOn�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     adclr-namespace:AvalonDock  AadRes7clr-namespace:AvalonDock.Properties;assembly=AvalonDock    �� $2 ,/AvalonDock;component/Resources/Brushes.xaml?��� $1 +/AvalonDock;component/Resources/Common.xaml?��� $> 8/AvalonDock;component/Resources/ManagedContentStyle.xaml?�%  (��       "   # Z )&	      7  7  7  7  '  v    7  7  7  7  7   '  �    7 �� .@�m� $/ )ad:DockableContentCommands.FloatingWindow��m� $$ ad:ManagedContentCommands.Show��m� $/ )ad:DockableContentCommands.ShowAsDocument��m� $/ )ad:DockableContentCommands.ToggleAutoHide��m� $$ ad:ManagedContentCommands.Hide��y��� $ IsCloseable�# Z �� "	  .��� 
 �@�FocusVisualStyle Z� �� 
 � �� �� "  .R��  . .+��� $ PART_DragArea��8��  $��1,0,1,1q�$��0,2,0,0q�$ 0,0,3,3��8�� ._��� $ tabItemIntBorder��$��0,1,0,2q�8�� ._�� $��4,0,4,0q� �� $
��Auto ��� $��* �.+�  $
 Icon��$��16��#��z �� $ tabItemTitle��$��1��$��CharacterEllipsis=�$��NoWrap=�#��z $��2,0,0,0q�$��Center=�#��� ���� $ HighlightBorder��$��3��$��Bottom=�$��0,0,0,0q�$ 0,0,3,3�����	#FFE68B2C8�� $y�Hidden=� P�  �@��
IsSelected . . ��� $ tabItemIntBorder��
 � ��$ 0q��� $ PART_DragArea��
 � ��$ 1,0,1,0q��� $ PART_DragArea��
 � �� �	#FFFCFCFE�� $ PART_DragArea��
 �@��CornerRadius$ 0,0,3,3���� $ HighlightBorder��
 � y�$ Visible=��� # � ��$ tabItemTitle��
 � ���� $ tabItemIntBorder��
 � ��$ 0,3,0,2q��� $ PART_DragArea��
 � ��$ 0,1,0,0q�P�  �@J�IsMouseOver . . ��� $ HighlightBorder��
 � y�$ Visible=�P�  Z�  �@ Icon. ��� $
 Icon��
 � y�$ 	Collapsed=��� "	  .��� 
 � �� C� *�� *M� *3 +�� *3 +++�� 
 �@�FocusVisualStyle Z� �� 
 � �� �� "  .R��� |�.  #��z��._��  �� $ PART_SelectedContent�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $ PART_Header��$��0��|�.  $��1,1,1,0q�
�������$��18����C� *�� *M� *3 +�� *3 +++._�]� ��. .+��� $��Right=�$��15��$��15��8��  $#��ad:DockablePaneCommands.Close��# Z y���  �� *TemplatedParent+$ SelectedItem.IsCloseable�# Z .��  $��Images\PinClose.png��$��13���� $ btnPinAutoHide��$��Right=�$��15��$��15��8�� $,��&ad:DockablePaneCommands.ToggleAutoHide��# Z  .��  $��Images\PinAutoHide.png��$��13���� $  PART_ShowContextMenuButton��$��Right=�$��15��$��15��8�� # Z! ._�  $��Images\PinMenu.png��$��13���� $ 	paneTitle��$��0��$��2,0,0,0q�$��CharacterEllipsis=�$��NoWrap=�$��Center=�����  �� *TemplatedParent+$ SelectedItem.Title���C� *�� *M� *3 +�� *3	 +++�� $��1��$��1,0,1,1q�
�����������  �� *TemplatedParent+$ SelectedItem.Background�._��� $" PART_SelectedContent��$# Local=�$$ 	Contained=�$% 1������  �� *TemplatedParent+$ SelectedItem.Content��� $ 	PART_Tabs��$��2��$��0,2,0,0q�$��25��$��0,1,0,0q�8�� 	  $& paneTabsPanel��$��2��$��24��$% 2��' . $��0,0,0,2q�8(   �� $
) True��* ��  �� *Self+$" SelectedItem.IsActiveContent�.a��� $ PART_Header�� C� *�� *M� *3 +�� *3
 +++
 � ���� $ 	paneTitle�� C� *�� *M� *3 +�� *3 +++
 � ��P�  �@ 
ShowHeader .  . ��� $ PART_Header��
 � y�$ 	Collapsed=�P�  �@ ShowTabs .  . ��� $ 	PART_Tabs��
 � y�$ 	Collapsed=�P�  �@ HasSingleItem . . ��� $ 	PART_Tabs��
 � y�$ 	Collapsed=��� $ paneTabsPanel��
 � y�$ 	Collapsed=��� $) AutoHide��* ��  �� *Self+$ SelectedItem.State�.a��� $ btnPinAutoHide��
 �@�LayoutTransform �� $+ 90Q��� "	  8,   