   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollViewerTreeView  �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType � ColumnDefinitions � RowDefinitions � UseLayoutRounding ��Name,	 �� %ComputedHorizontalScrollBarVisibility
 �� Orientation �� ViewportWidth �� ViewportSize � Minimum �� ScrollableWidth � Maximum � Value �� Path �� Mode �� RelativeSource* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ScrollableHeight4   .System.Windows.Automation.AutomationProperties    AutomationId �� CornerRadius  ExpandCollapseToggleStyle'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Hidden  R� Value!   Visible" F�Name# �� Color  TreeViewItemFocusVisual$ �� StrokeDashArray% J� Opacity& �� AncestorType' g� Duration8  2System.Windows.Media.Animation.EasingColorKeyFrame( �� KeyTime) �� Value* d�Name+ �� 	ClickMode, d� 	IsChecked- ��Name. �� Padding/ ��Name0 ��Name1 �� Triggers2 P� Property3 P� Value4 �� 
TargetName5 ]� 
Conditions6 �� Property7 �� Value�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml      %!  &	        'R� �    7   &	 �    &	 �    'Q� K    7  7  �� "  �� Z� .���  �@�UseLayoutRounding . ��  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R�� #��z�� �� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $��0��$��0�� . �� $ PART_HorizontalScrollBar��#y�z	 $��0��$��1��$
 
Horizontal=� . # z $ 0Q�# z $��0q� �� $ HorizontalOffset�$ OneWay=� �� *TemplatedParent+�� $ PART_VerticalScrollBar��#y�z $��1��$��0��$
 Vertical=� . # z $ 0Q�# z $ VerticalScrollBar��$��0q� �� $ VerticalOffset�$ OneWay=� �� *TemplatedParent+�� "  R�.���  �@�OverridesDefaultStyle . ��  �@J�SnapsToDevicePixels . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� �� " R�.R��� $��Border��$ 0��$��1q����#B9B9B9���#FFFFFF._��� |�.  ��. $��4q�8��  .���� �� "  d�.���  � |� .  ��  � �� �� " d�.R�� $��15��$��13��
������    CheckStates��.   Checked��. �� .��T� $ (UIElement.Visibility)�$ 	Collapsed��..�i� $ 0��#  Z T� $ (UIElement.Visibility)�$ Expanded��..�i� $ 0��#  Z!   	Unchecked��  Indeterminate��.+�F� $" 	Collapsed��$
��Left=�$��Center=�$��1,1,1,1q�"���� 	=     � z  	= � 	=  z 	���� $# #373A3D��F� $" Expanded��$
��Left=�$��Center=�$��1,1,1,1q�"����     	= � z  	= � 	=  z 	$y�Hidden=����� $# #373A3D���� .���  � �� �� .R��� ._��� $��0,0,0,0q�$��5��
���   �$	$ 1 2R�$% 0Q��� "  Q�.���  � ��
 ���� ��  � �� �� $  HorizontalContentAlignment� �� "& ����  � �� �� $ VerticalContentAlignment� �� "& ����  � ��$ 3q���  � �� �#373A3D��  �@�FocusVisualStyle8   ��  � �� �� " Q�.R��  �� $��15��$
��Auto ��� $
��Auto ��� $��* � �� $
��Auto ���    SelectionStates��.   Selected��. �� .���� $ Bd��$' 0:0:0.5000000D�$0 *(Panel.Background).(SolidColorBrush.Color)�.g�  $( 0��$) #F78A09��  
Unselected��  SelectedInactive��. �� .���� $ Bd��$0 *(Panel.Background).(SolidColorBrush.Color)�.g�  $( 0:0:0.15��$) #B9B9B9��  ExpansionStates��.   Expanded��. �� .��T� $ (UIElement.Visibility)�$ 	ItemsHost��..�i� $ 0��#  Z!   	Collapsed��.+�d� $* Expander��8�� $+ Press=�, �� *
IsExpanded+ �� *TemplatedParent+�� $- Bd��$��1��#��z��#��z��#��z��#. z��._��� $/ PART_Header��$��Header��#��z���� $0 	ItemsHost��$��1��$��1��$��2��$y�	Collapsed=�1 P� 2 �@Q�
IsSelected3 . . ���  � ��
 �����P� 2 �@��HasItems3 .  . ��� $4 Expander�� � y�$ Hidden=�]� 5 �� 6 � ��7 .  �� 6 � ��$
7 Auto��./��� $4 PART_Header�� � ��$ 75��]� 5 �� 6 � ��7 .  �� 6 � ��$
7 Auto��./��� $4 PART_Header�� � ��$ 19��