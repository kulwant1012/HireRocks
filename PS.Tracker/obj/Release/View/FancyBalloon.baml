   M S B A M L   `   `   `  ����   
PS.Tracker"    PS.Tracker.View.FancyBalloon   f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  -     >�Name$  me��$	��210��$	��240�� � DataContext �� *FancyBaloonViewModel+   Locator �� Source# [   � 	Resources  
 FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut   BooleanToVisibilityConverter��%  &	       &	 �     &	 (    &	 �    &	 6    &	 �    �� .��U� $ 00:00:00X�$
 grid��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 0Q��� $ 00:00:01��$
 0.95Q��� $ 00:00:03��$
 0.95Q��� .��U� $ 00:00:00X�$ imgClose��$ (UIElement.Opacity)�.\��� $ 00:00:00��$	 0.4Q��� $ 00:00:00.3000000��$ 1Q��� .��U� $ 00:00:00X�$ imgClose��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.3000000��$	 0.4Q��� .��U� $ 00:00:00X�$
 grid��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.3000000��$ 1Q��� -   .��U� $ 00:00:00X�$
 grid��$ (UIElement.Opacity)�.\��� $ 00:00:00��$ 1Q��� $ 00:00:00.3000000��$	 0.2Q��� 	 � Triggers	 :� 
 :� RoutedEvent$#
 tb:TaskbarIcon.BalloonShowing��.[��� -    ��Name$ FadeIn_BeginStoryboard��#��[ :� $
 Mouse.MouseEnter�� :� 
SourceName$ imgClose��.[��� -   $* $HighlightCloseButton_BeginStoryboard��#��[ :� $
 Mouse.MouseLeave��$ imgClose��.[��� -   $% FadeCloseButton_BeginStoryboard��#��[ :� $
 Mouse.MouseEnter��.[���  �� BeginStoryboardName$ FadeIn_BeginStoryboard���� -   $ FadeBack_BeginStoryboard1��#��[ :� $#
 tb:TaskbarIcon.BalloonClosing��.[��� -   $ FadeOut_BeginStoryboard��#��[ .��� -    �Name$
 grid��.+��� $��Stretch=�$��5,5,5,5q�$��1,1,1,1q����	#FF997137 J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FF747474������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF4B4B4B�� � Offset$ 0Q�� $ 	#FF8F8F8F��$ 1Q��� $��15,49.2,10,0q�$	��Top=����	#FFECAD25$
��Wrap=�y��� *IsCaptureNotification+ $  BoolToVisibilityReverseConverter �� 	Converter# [ �� ��� *NotificationText+��  �� Orientation$ Vertical=�$��
15,50,15,0q�y��� *IsCaptureNotification+# [ .+��� ���� *ScreenCaptureFullImage+�� $ 
Horizontal=�.+�(  "Telerik.Windows.Controls.RadButton  $��Discard��$��25��$
��auto��$��0,5,0,0q����� *DiscardCaptureCommand+  $��Preview��$��25��$
��auto��$��5,5,0,0q����� *PreviewCaptureCommand+{��� *IsPreviewButtonEnabled+�� ���	#FFECAD25$��10,0,2,0q�$��Center=����� *TimeLeftForSubmission+F� ���	#FFFFFFFF �� Stretch$
 Fill=�$��15,38.2,34,0q�$	��Top=�$��1�����Ѐ����`����`	 J� SnapsToDevicePixels . ���� $ 	0.973,0.5&�$ 	0.005,0.5&�.��� $ 	#00ECAD25��$ 1Q�� $ 	#87ECAD25��$ 0Q��� $��
15,10,10,0q�$	��Top=�$
��23.2��$
��Wrap=����	#FFECAD25$
��Bold"�����  �� Path$ BalloonText� �� ElementName$ me�� �� Mode$ Default=��� -	    ��Name$ imgClose��$��Right=�$��	0,10,10,0q�$	��Top=�$��16��$��16��$��/Images/Close.png��$
��Fill=� J� Opacity$	 0.4Q� � ToolTip$ Close��