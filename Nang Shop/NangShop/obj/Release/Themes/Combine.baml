   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35` \RibbonControlsLibrary, Version=4.0.0.11019, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Background_Lockin  �� EndPoint �� 
StartPoint � Color � Offset  btnLogin �� 
TargetType �� Property �� Value �� 
TargetType � 	Resources  Key	 g� 	BeginTime
 �� 
TargetName �� TargetProperty O� KeyTime O� Value9   3System.Windows.Media.Animation.EasingDoubleKeyFrame ��Name �� RadiusX �� RadiusY ��Name J� Opacity �� Triggers P� Property P� Value �� 
TargetName3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   
BlurRadius   	Direction   Color   Opacity N� EnterActions  HoverOn N� ExitActions  HoverOff  PressOn  PressOff  
btnConfirm  BG2 	 btnClose �� Triggers �� ImageSource 
 btnArrow  btnArrowTemp  �� Bullet! �� Color" F�Name# J� SnapsToDevicePixels 	 Close  Login_PasswordBox  Test$ ��Name
% � Tag& ��Name' � UseLayoutRounding  ButtonImage  
Labellogin  	MainColor  
HoverColor  NormalBrush  NormalBorderBrush  
HoverBrush  DisabledForegroundBrush  DisabledBackgroundBrush  DisabledBorderBrush  
ShineBrush  HoverShineBrush  RadioButtonFocusVisual( �� StrokeDashArray  RadioButton_Index  RadioButtonTemp_Index) ��Name* �� 
Background+ A�Name, J� IsHitTestVisible- ��Name  FocussedOff  
FocussedOn   	CheckedOn ! 
CheckedOff " 
PressedOff # 	PressedOn�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml      %z  &	        &	 R     7  7  7  7  &	 �    &	 $    &		 v    &	
 �	    &	 5
    &	 �    &	 1    &	 �    &	 R    &	 �    &	 �    &	 �    &	 �    7  &	 �    &	 �    7  &	     &	     &	 %    &	 5    &	 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  7  7   7 ! 7 " 7 # �� $  1,0.5&�$ 0,0.5&�.��� $ 	#FF9E9E9E��� $ 	#FFF0F0F0��$ 1Q��� " ��.���  � ��$ 25����  � ��$ 50����  � �� �� " �� ���� HoverOn .��U� $	 00:00:00X�$
 ON��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q�U� $	 00:00:00X�$	
 OFF��$ (UIElement.Opacity)�.\��� $ 00:00:01��$ 0Q��� HoverOff .��U� $	 00:00:00X�$
 ON��$ (UIElement.Opacity)�.\��� $ 00:00:01��$ 0Q�U� $	 00:00:00X�$	
 OFF��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� PressOn .��U� $	 00:00:00X�$
 ON��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�   $ 0��$ 1Q�U� $	 00:00:00X�$
 ON��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\�   $ 0��$ 1Q��� PressOff .��U� $	 00:00:00X�$
 ON��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�.\�   $ 0��$ 0Q�U� $	 00:00:00X�$
 ON��$U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)�.\�   $ 0��$ 0Q�.R�� $��25��$��46��.+��� $ Rectangle_Lockin��$ 1��$ 1��
���   �$��0q�
���   �$��1���� $	 OFF��$.��(/NangShop;component/Images/bg_button.png��$��Center=�$��Center=�$ 1Q�$��1q��� $ ON��$1��+/NangShop;component/Images/bg_button_on.png��$��Center=�$��Center=�$ 0Q�$��1q�z�V� .~��� �� �� T�  P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand���� $ Rectangle_Lockin�� �@J�Effect   $ 0Q�$ 10Q�$ 0Q�$ White��$ 1Q� �� 8��   �� 8�� P�  � �� .  �� 8��  �� 8�� �� " ��.���  � ��$ 20����  � ��$ 50���� $  0.5,1&�$ 0.5,0&�.��� $ 	#FFA7A7A7��� $ 	#FFEBEBEB��$ 1Q��� " �� P�  �@J�IsMouseOver . . ���  �@J�Effect   $ 15Q�$ 	#FFFF3535��$ 0Q�$ 1Q�P�  � �� . . ���  �@J�Effect   $ 15Q�$ 	#FF910000��$ 0Q�$ 1Q�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  �@�Cursor$
 Hand����  � �� �� " ��.R�� .+�A� #��z���� $ RefractionLayer������ $) #/NangShop;component/Images/exit.png���� $��0,2,0,0q�$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ RefractionLayer�� � �� �� $) #/NangShop;component/Images/exit.png���� " ��.���  � ��$ 15����  � ��$ 21����  � ��# �  �� " ��.R��� $��Center=�$��Center=�  � .+��� $��	rectangle��$��21��$��23��$ 2��$ 2������ $! 	#FF727272��F� $" Arrow��$y�Visible=�$��7��$��7��# .  $��1��"����        ��g5 ��[ ���j     	$��Center=�$��Center=����� $! 	#FF00AD00�� P�  �@J�IsMouseOver . . ��� $ Arrow�� � �� �	#FFD03434P�  � �� . . ��� $ Arrow�� � �� �	#FFA32626�� " ��.���  � �� �� $* $/NangShop;component/Images/close.png���� " G�.���  � �� �	#FFCCCCCC��  � ��
 ���� ��  � ��$ 0q���  � ��
 ���� �� " ��.���  � �� �	#FFCCCCCC��  � ��$ Center=���  � ��$
 Left=���  � �� �� " ��.R�� .+��� $	$ lbl��$
��Left=�$��Center=�$��4,0,0,0q�
�������$��Italic$�#��z% $ 0Q��� $& PART_ContentHost��$��3,0,0,0q����	#FFCCCCCC' . #��z��#��z�� P�  � ��$  ��. ��� $	 lbl�� �@J�Opacity$ 1Q�P�  Z�  � ��. ��� $	 lbl�� �@J�Opacity$ 1Q��� " ��.���  � �� �� " ��.R��� $��Center=�$��Center=�  � .+��� #��z��#��z��#��z��F� $" xClose��$y�Hidden=�$��25��$��25��# .  $��5��+����        �@x}@x}�    @x}�@x}    	���� $! 	#FFFF2121�� P�  � {� .  . ��� $ xClose�� � y�$ Visible=��� " ��.���  � �� �	#FF222222��	#FF595959����	#FF393939���� 8!   �� $! 	#FF333333���� 8!   �� $
! #888���� $! Black���� $
! #AAA���� $  	0.5,0.971&�$ 	0.5,0.042&�.��� $ 	#59FFFFFF��$ 0Q�� $ 	#00FFFFFF��$ 1Q�� $ 	#26FFFFFF��$ 0.467Q�� $ 	#00FFFFFF��$ 0.475Q��� $  	0.5,0.971&�$ 	0.5,0.042&�.��� $ 	#4CFFFFFF��$ 0Q�� $ 	#26FFFFFF��$ 1Q�� $ 	#26FFFFFF��$ 0.467Q�� $ 	#00FFFFFF��$ 0.475Q�� $ 	#00FFFFFF��$ 0.856Q��� " 	�.���  � �� �� .R��� ._��� $��15,0,0,0q�
�������$��1��$	( 1 2R��� " 	�.���  �@J�SnapsToDevicePixels . ��  �@�UseLayoutRounding . ��  �@�FocusVisualStyle# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  �� " 	� ���� 	PressedOn .��U� $	 00:00:00X�$
 PressedEllipse��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� 
PressedOff .��U� $	 00:00:00X�$
 PressedEllipse��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� 	CheckedOn .��U� $
 	CheckIcon��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� 
CheckedOff .��U� $
 	CheckIcon��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q��� 
FocussedOn .��U� $	 00:00:00X�$
 ContentFocusVisualElement��$ (UIElement.Opacity)�.\��� $ 00:00:00.1000000��$ 1Q��� FocussedOff .��U� $	 00:00:00X�$
 ContentFocusVisualElement��$ (UIElement.Opacity)�.\��� $ 00:00:00.3000000��$ 0Q�.R��� $) bulletDecorator��
* ����   � $��16��$��16��.+�A� $+ 
Background��$��14��$��1q�$��14��#��z��#��z��#��z��A� $+ BackgroundOverlay��$��14��$��1q�$��14��$��2��8��  $ 0Q�A� $+ PressedEllipse��$��14��$��1q�$��14��#��z��8�� $ 0Q�A� $+ 	CheckIcon��$��6��$��6��$ 0Q�
���  ��A� $+ DisabledVisualElement��$��14��$��14��$ 0Q�8�� A� $+ ContentFocusVisualElement��$��16��$��16��, .  $ 0Q�8�� $��1��A� $+ ShineEllipse��$��12��$��2,2,2,2q�$��12��#��z��8�� ��Z� ._��� ��. $��5,0,0,0q� P�  �@J�	IsFocused .  �� $!- FocussedOff_BeginStoryboard��8��  �� $ - FocussedOn_BeginStoryboard��8�� P�  �@d�	IsChecked$ falseY� �� $- CheckedOn_BeginStoryboard��8��  �� $ - CheckedOff_BeginStoryboard��8�� P�  �@d�	IsChecked$
 TrueY�P�  � �� .  �� $ - PressedOff_BeginStoryboard��8��	  �� $- PressedOn_BeginStoryboard��8��
 P�  � {� .  . ��� $ 
Background��# �   � ���� $ 
Background��# �   � ���� $ bulletDecorator�� �@J�Opacity$ 1Q�