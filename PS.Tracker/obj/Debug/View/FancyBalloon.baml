   M S B A M L   `   `   `  ����  
PS.Tracker"    PS.Tracker.View.FancyBalloon   5      f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      -   5          >�Name$  me��5      $	��210��5      $	��240��5       � DataContext 5	      �� *FancyBaloonViewModel+   Locator �� Source# [   � 	Resources 5
       
 FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut   BooleanToVisibilityConverter��%=  &	       &	     &	     &	     &	 �    &	 �    �� 5   
   .��5      U� $ 00:00:00X�6,   $
 grid��5   ,   $ (UIElement.Opacity)�5   ,   .\�5      �� $ 00:00:00��6'   $ 0Q�5   '   �� 5      $ 00:00:01��6'   $
 0.95Q�5   '   �� 5      $ 00:00:03��6'   $
 0.95Q�5   '   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��5   ,   $ (UIElement.Opacity)�5   ,   .\�5      �� $ 00:00:00��6'   $	 0.4Q�5   '   �� 5      $ 00:00:00.3000000��6'   $ 1Q�5   '   5       5!      �� 5"   
   .��5#      U� $ 00:00:00X�6,   $ imgClose��5$   ,   $ (UIElement.Opacity)�5%   ,   .\�5&      �� $ 00:00:00��6'   $ 1Q�5'   '   �� 5(      $ 00:00:00.3000000��6'   $	 0.4Q�5)   '   5*      5+      �� 5,   
   .��5-      U� $ 00:00:00X�6,   $
 grid��5.   ,   $ (UIElement.Opacity)�5/   ,   .\�50      �� $ 00:00:00��6'   $ 1Q�51   '   �� 52      $ 00:00:00.3000000��6'   $ 1Q�53   '   54      55      �� 56   
   -   5        .��58      U� $ 00:00:00X�6,   $
 grid��59   ,   $ (UIElement.Opacity)�5:   ,   .\�5;      �� $ 00:00:00��6'   $ 1Q�5<   '   �� 5=      $ 00:00:00.3000000��6'   $	 0.2Q�5>   '   5?      5@      �� 5A   
   6'   5B      	 � Triggers	 5C      :� 5D   
   
 :� RoutedEvent$#
 tb:TaskbarIcon.BalloonShowing��6   .[�5E      �� -   5         ��Name$ FadeIn_BeginStoryboard��5F      #��[ 5E      5F      5G      :� 5H   
   $
 Mouse.MouseEnter��6    :� 
SourceName$ imgClose��5I      .[�5J      �� -   5        $* $HighlightCloseButton_BeginStoryboard��5K      #��[ 5J      5K      5L      :� 5M   
   $
 Mouse.MouseLeave��6   $ imgClose��5N      .[�5O      �� -   5        $% FadeCloseButton_BeginStoryboard��5P      #��[ 5O      5P      5Q      :� 5R   
   $
 Mouse.MouseEnter��6   .[�5S      ��  �� BeginStoryboardName$ FadeIn_BeginStoryboard��6   �� 5T      -   5        $ FadeBack_BeginStoryboard1��5T      #��[ 5U      5V      :� 5W   
   $#
 tb:TaskbarIcon.BalloonClosing��6   .[�5X      �� -   5        $ FadeOut_BeginStoryboard��5Y      #��[ 5X      5Y      5Z      .��5\      � -   5         �Name$
 grid��5\      .+�5]   
   �� $��Stretch=�6   $��5,5,5,5q�5^      $��1,1,1,1q�5_      ���	#FF997137 J� Effect 5a      3  -System.Windows.Media.Effects.DropShadowEffect  5b         Color$ 	#FF747474��6#   ��5d      �� 5e       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�5f   &   .��5g      �  � Color$ 	#FF4B4B4B��6#    � Offset$ 0Q�5h   #   � 5i      $ 	#FF8F8F8F��6#   $ 1Q�5j   #   5k      5m      �� 5n   
   $��15,49.2,10,0q�6   $	��Top=�5o      ���	#FFECAD25$
��Wrap=�5q      y�5r      �� *IsCaptureNotification+ $  BoolToVisibilityReverseConverter �� 	Converter# [ �� 5s      �6   �� *NotificationText+5t      �� 5u   
    �� Orientation$ Vertical=�6z   $��
15,50,15,0q�6�   y�6   �� *IsCaptureNotification+# [ .+�5v      �� ��6   �� *ScreenCaptureFullImage+6@   �� 5w      $ 
Horizontal=�6   .+�5x      (  "Telerik.Windows.Controls.RadButton  $��Discard��6$   $��25��6`   $
��auto��6l   $��0,5,0,0q�6y   ��66   �� *DiscardCaptureCommand+6y     5y      $��Preview��6$   $��25��6`   $
��auto��6l   $��5,5,0,0q�6y   ��66   �� *PreviewCaptureCommand+{�6�   �� *IsPreviewButtonEnabled+�� 5z      ���	#FFECAD25$��10,0,2,0q�6Z   $��Center=�6l   ��63   �� *TimeLeftForSubmission+6l   5{      5|      F� 5}   
   ���	#FFFFFFFF �� Stretch$
 Fill=�5~      $��15,38.2,34,0q�5      $	��Top=�5�      $��1��5�      ���Ѐ����`����`	 J� SnapsToDevicePixels . ��5�      �� 5�      $ 	0.973,0.5&�6&   $ 	0.005,0.5&�5�   &   .��5�      � $ 	#00ECAD25��6#   $ 1Q�5�   #   � 5�      $ 	#87ECAD25��6#   $ 0Q�5�   #   5�      5�      �� 5�   
   $��
15,10,10,0q�6   $	��Top=�5�      $
��23.2��5�      $
��Wrap=�5�      ���	#FFECAD25$
��Bold"�5�      ��5�      ��  �� Path$ BalloonText� �� ElementName$ me�� �� Mode$ Default=�5�      �� 5�   
   -	   5         ��Name$ imgClose��5�      $��Right=�5�      $��	0,10,10,0q�5�      $	��Top=�5�      $��16��5�      $��16��5�      $��/Images/Close.png��5�      $
��Fill=�5�       J� Opacity$	 0.4Q�5�       � ToolTip$ Close��5�      5�      5�      5�      