   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollViewerTreeView  �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType � ColumnDefinitions � RowDefinitions � UseLayoutRounding ��Name,	 �� %ComputedHorizontalScrollBarVisibility
 �� Orientation �� ViewportWidth �� ViewportSize � Minimum �� ScrollableWidth � Maximum � Value �� Path �� Mode �� RelativeSource* �� #ComputedVerticalScrollBarVisibility �� ViewportHeight �� ScrollableHeight4   .System.Windows.Automation.AutomationProperties    AutomationId �� CornerRadius  ExpandCollapseToggleStyle'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName R� KeyTime  System.Windows.Visibility   Hidden  R� Value!   Visible" F�Name# �� Color  TreeViewItemFocusVisual$ �� StrokeDashArray% J� Opacity& �� AncestorType' g� Duration8  2System.Windows.Media.Animation.EasingColorKeyFrame( �� KeyTime) �� Value* d�Name+ �� 	ClickMode, d� 	IsChecked- ��Name. �� Padding/ ��Name0 ��Name1 �� Triggers2 P� Property3 P� Value4 �� 
TargetName5 ]� 
Conditions6 �� Property7 �� Value�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        'R� 3    7   &	     &	 
    'Q� �
    7  7  �� 5      "  ��6)    6L   Z� .�5   
   ��  �@�UseLayoutRounding . 6.   �� 5   
    � ��$ Stretch=�67   �� 5   
    � ��$ Stretch=�60   �� 5   
    � �� 5	      �� 5
      " ��6"   .R�5      � #��z��6    5      �� 5      $��* �6/   �� 5      $
��Auto �6/    5      �� 5      $��* �6,   �� 5      $
��Auto �6,   .+�5      �� $��0��61   $��0��6A    . 6N   �� 5      $ PART_HorizontalScrollBar��5   1   #y�z	 5   $   $��0��6i   $��1��5   $   $
 
Horizontal=�6S    . # z 5   $   $ 0Q�6S   # z 6_   $��0q�5   $    5   $   �� $ HorizontalOffset�$ OneWay=� �� *TemplatedParent+5   $   �� 5      $ PART_VerticalScrollBar��5   1   #y�z 5   $   $��1��6g   $��0��5   $   $
 Vertical=�6Q    . # z 5   $   $ 0Q�6T   # z 6`   $ VerticalScrollBar��5   $   $��0q�6Z    5   $   �� $ VerticalOffset�$ OneWay=� �� *TemplatedParent+5   Z   5       5!      5#      5$      �� 5&      "  R�6&   .�5'   
   ��  �@�OverridesDefaultStyle . 62   �� 5(   
    �@J�SnapsToDevicePixels . 60   �� 5)   
    � ��$
 Auto=�6G   �� 5*   
    � ��$
 Auto=�6E   �� 5+   
    � �� 5,      �� 5-      " R�6"   .R�5.      �� $��Border��6   $ 0��6+   $��1q�6<   ���#B9B9B9���#FFFFFF._�5/      �� |�.  ��. $��4q�6Q   8��  .��50      �� 51      52      53      55      56      �� 58      "  d�6.   .�59   
   ��  � |� .  6&   �� 5:   
    � �� 5;      �� 5<      " d�6"   .R�5=      � $��15��6   $��13��6&   
������  5>        5?      CheckStates��. 5@   "     Checked��. 5A   &   �� .��5B   *   T� $ (UIElement.Visibility)�6H   $ 	Collapsed��5C   H   ..�5D   .   i� $ 0��6E   #  Z 6Q   5E   +   T� 5F   *   $ (UIElement.Visibility)�6H   $ Expanded��5G   H   ..�5H   .   i� $ 0��6E   #  Z! 6Q   5I   +   5J   '   5K   #     5L   "   	Unchecked��6.     5M   "   Indeterminate��6.   5N      .+�5P      F� $" 	Collapsed��6   $
��Left=�62   $��Center=�6M   $��1,1,1,1q�5Q      "���� 	=     � z  	= � 	=  z 	��5R      �� 5S   "   $# #373A3D��62   5U      F� 5V      $" Expanded��6   $
��Left=�61   $��Center=�6L   $��1,1,1,1q�5W      "����     	= � z  	= � 	=  z 	$y�Hidden=�6K   ��5X      �� 5Y   "   $# #373A3D��62   5[      5\      5]      5_      5`      �� 5a      .�5b   
   ��  � �� 5c      �� 5d      .R�5e      �� ._�5f      �� $��0,0,0,0q�6$   $��5��65   
���   �$	$ 1 2R�6X   $% 0Q�6n   5g      5h      5j      5k      �� 5l      "  Q�6*   .�5m   
   ��  � ��
 ���� 6'   �� 5n   
    � �� 5o      �� $  HorizontalContentAlignment� �� "& ���� 5p   
    � �� 5q      �� $ VerticalContentAlignment� �� "& ���� 5r   
    � ��$ 3q�6$   �� 5s   
    � �� �#373A3D6'   �� 5t   
    �@�FocusVisualStyle8   6-   �� 5u   
    � �� 5v      �� 5w      " Q�6"   .R�5x      �  5y      �� 5z      $��15��6/   $
��Auto �6=   �� 5{      $
��Auto �6/   �� 5|      $��* �6/    5~      �� 5      $
��Auto �6,   �� 5�       5�        5�      SelectionStates��. 5�   "     Selected��. 5�   &   �� .��5�   *   �� $ Bd��6G   $' 0:0:0.5000000D�6b   $0 *(Panel.Background).(SolidColorBrush.Color)�5�   G   .g�5�   .     $( 0��6B   $) #F78A09��6N   5�   +   5�   '   5�   #     5�   "   
Unselected��6.     5�   "   SelectedInactive��. 5�   &   �� .��5�   *   �� $ Bd��6G   $0 *(Panel.Background).(SolidColorBrush.Color)�5�   G   .g�5�   .     $( 0:0:0.15��6B   $) #B9B9B9��6U   5�   +   5�   '   5�   #   5�        5�      ExpansionStates��. 5�   "     Expanded��. 5�   &   �� .��5�   *   T� $ (UIElement.Visibility)�6H   $ 	ItemsHost��5�   H   ..�5�   .   i� $ 0��6E   #  Z! 6Q   5�   +   5�   '   5�   #     5�   "   	Collapsed��6.   5�      .+�5�      d� $* Expander��6'   8�� $+ Press=�6l   , 5�   '   �� *
IsExpanded+ �� *TemplatedParent+�� 5�      $- Bd��6!   $��1��6-   #��z��6=   #��z��6g   #��z��5�   !   #. z��6U   ._�5�      �� $/ PART_Header��6/   $��Header��6D   #��z��5�   /   5�      �� 5�      $0 	ItemsHost��6)   $��1��6<   $��1��6I   $��2��6Y   $y�	Collapsed=�6m   5�      1 5�      P� 5�      2 �@Q�
IsSelected3 . . �5�      ��  � ��
 �����6;   5�      P� 5�      2 �@��HasItems3 .  . �5�      �� $4 Expander��6%    � y�$ Hidden=�6Q   5�      ]� 5�      5 5�      �� 5�   "   6 � ��7 .  6A   �� 5�   "   6 � ��$
7 Auto��6=   ./�5�      �� $4 PART_Header��6%    � ��$ 75��6R   5�      ]� 5�      5 5�      �� 5�   "   6 � ��7 .  6A   �� 5�   "   6 � ��$
7 Auto��6>   ./�5�      �� $4 PART_Header��6%    � ��$ 19��6S   5�      5�      5�      5�      5�      