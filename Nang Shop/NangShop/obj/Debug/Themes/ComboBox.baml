   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ComboBoxToggleButton  �� 
TargetType �Name ��Name ��Name F�Name � UseLayoutRounding �� Stretch �� Triggers P� 
SourceName	 P� Property
 P� Value �� 
TargetName �� Property �� Value  ComboBoxTextBox �� 
TargetType � 	Resources  Key g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource d�Name ��Name �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name  �� 
IsReadOnly! �� 
IsReadOnly" J� Opacity# �Name$ �� IsDropDownOpen% � AllowsTransparency& �� MaxDropDownHeight' � ActualWidth( J� SnapsToDevicePixels) �� CornerRadius* K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation+    DirectionalNavigation, N� ExitActions  
FocusedOff- N� EnterActions  	FocusedOn. ]� 
Conditions/ �� Property0 �� Value1 g� Duration	2 W� To3 ��Name  HighlightOff  HighlightOn�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      UThemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5      %�  &	        &	 �    '��     7  7  '�� �    7  7  �� 5      "  d�63   .R�5   
   � $
 grid��6   .+�5      �� $ 
Background��6   ���#FFFFFF���#B9B9B96;   �� 5	      $ border��6   $��0q�6%   
������ $��20��6R   $��Right=�6]   $��0,0,0,0q�6y   ._�5
      F� $ BtnArrow��6   $��7��6)   ���#333333$��Center=�6B   "����        ���j     ��g5  �D 	 . $ Uniform=�5   M   5      5       5   
   P� 5      $ border��6:   	 �@J�IsMouseOver
 . . �5      �� $ border��6    � �� �#B9B9B96C   5      P� 5      $ 
Background��6-   	 �@J�IsMouseOver
 . . �5      �� $ 
Background��6    � �� �#F0F0F06A   5      5      �� 5      "  ��6.   .R�5   
   �� $ PART_ContentHost��6   |�.  
������ 6=   5      �� 5      " ��6   .�5   
   ��  � �� �#373A3D6'   �� 5   
    � ��$ Segoe UI)�6'   �� 5    
    � ��$
 11.5(�6%   �� 5!   
    � ��
 ���� 6'   �� 5"   
    �@J�SnapsToDevicePixels . 60   �� 5#   
    � ��$ Stretch=�67   �� 5$   
    � ��$ Center=�65   �� 5%   
    � ��$ 21��6#   �� 5'   
    �@�UseLayoutRounding . 6.   �� 5(   
    � �� 5)      �� 5*      "  ��6"    5+      ���� 5,      	FocusedOn .��5-      U� $ 00:00:00X�6<   $ FocusVisualElement��6Q   $ (UIElement.Opacity)�6|   .\�5.   "   �� $ 	00:00:0.3��67   $ 1Q�6K   5/      50      �� 52      
FocusedOff .��53      U� $ 00:00:00X�6<   $ FocusVisualElement��6Q   $ (UIElement.Opacity)�6|   .\�54   "   �� $ 	00:00:0.3��67   $ 0Q�6K   55      56      57      .R�59      � .+�5:      d� |�.  $ Press=�5;   '    5:   9   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+��5;   9   Z� d� 5<      $ ToggleButton��6Y   #���   6'   |�.  $ Press=�5=   �    6'   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+6�   �� 5>      $ ContentSite��6X   $
��Left=�6+   $��5,0,23,0q�6F   $��Center=�6m    . #��z 5?   +   #��z 6X   #��z��5@   +    .  6l   �� 5A      $ PART_EditableTextBox��5B   4   $y�Hidden=�5A   "   #���  66   $
��Left=�6c   $��3,0,23,0q�5B   "   $��Center=�6c   |�. 
������ #! z  5C   L   $��Center=�5D   "   
������ ��5B   R   Z� 5D   D   �� 5E      $ FocusVisualElement��6$   ���#F78A09$��1��6Q    .  $" 0Q�6~   � 5F      $# Popup��6]   #��z$ 6    $��Bottom=�6J   |�.  % . $��Slide=�5G   :   $��0,1,0,0q�6Q   .��5H      � $ DropDown��6|   #��z& 6#   #��z' 6S   ( . .+�5I   "   �� $ DropDownBorder��6)   $��0,-1,0,0q�6A   ���#f78a09$��1q�6i   $) 0,0,0,0��6}   ���#FFFFFF._�5J   &   �� $��1,1,1,1q�63   ( . $
��Auto=�6_   $
��Auto=�6�   ��. .��5K   *   �� * . $+ 	Contained=�6H   5L   '   5M   #   5N      5O      5Q       5R      P� 5S      	 �@J�	IsFocused
 . , 5T      �� 5U   "   8��  62   - 5W      �� 5X   "   8�� 62   5Z      ]� 5\      . 5]      �� 5^   "   / �@J�	IsFocused0 .  6A   �� 5_   "   / �@��
IsEditable0 . 6B   ./�5a      �� $ FocusVisualElement��6%    � �� �#b9b9b96W   �� 5b       � �� .  6:   �� 5c      $ PART_EditableTextBox��6K    � y�$ Visible=�6;   6K   5d      P� 5k      	 � {�
 .  . �5l      ��  � �� �#8886;   5m      P� 5o      	 �@��
IsGrouping
 . . �5p      ��  � �� .  6N   5q      P� 5s      $ Popup��6@   	 �@�AllowsTransparency
 . . �5t      �� $ DropDownBorder��6G    �@��CornerRadius$ 0��6=   6G   �� 5u      $ DropDownBorder��6G    � ��$ 0,2,0,0q�67   6G   5v      5x      5z      5{      �� 5}      " ��6   .�5~   
   ��  � �� �#373A3D6'   �� 5   
    �@J�SnapsToDevicePixels . 60   �� 5�   
    � ��$ Stretch=�67   �� 5�   
    � ��$ Center=�65   �� 5�   
    � ��$ 3,1,3,1q�6$   �� 5�   
    � ��$ 20��6#   �� 5�   
    �@�UseLayoutRounding . 6.   �� 5�   
    � �� 5�      �� 5�      "  ��6"    5�      ���� 5�      HighlightOn .��5�      W� $1 00:00:00.1000000D�6.   $ BackgroundGradientOver��6J   $ Opacity�6y   $
2 0.73X�6�   5�      �� 5�      HighlightOff .��5�      W� $1 00:00:00.4000000D�6.   $ BackgroundGradientOver��6J   $ Opacity�6y   $2 0X�6�   5�      5�      .R�5�      � ( . .+�5�      �� $ BackgroundGradientOver��6$   ���#B9B9B9���#B9B9B9$" 0Q�6d   �� 5�      $ contentPresenter��6+   #��z��6E   #��z��5�   +    . 6N   5�       5�      P� 5�      	 �@J�IsMouseOver
 . , 5�      �� 5�   "   $#3 HighlightOff_BeginStoryboard1��6]   8��  - 5�      �� 5�   "   8�� 62   5�      P� 5�      	 � {�
 .  . �5�      ��  � �� �#8886;   5�      5�      5�      5�      5�      