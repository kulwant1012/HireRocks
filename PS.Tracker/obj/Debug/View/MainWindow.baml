   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command 5	   	    
PS.Tracker    PS.Tracker.View.MainWindow   5   	   f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity    	 5   	   acommandMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform    	 5	   	     � Title$  
Hire Rocks��5   	   $	��600��6   $	��500��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5
   #    � DataContext 5   	   �� *MainViewModel+   Locator �� Source# [  ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�5   &   .��5      � 	 � Color$	 	#FF4B4B4B��6   
 � Offset$
 0Q�6-   � 5      $	 	#FF8F8F8F��6   $
 1Q�6-   5       � 	Resources 5         BooleanToVisibilityConverter  BusyContentDataTemplate �� Orientation �� 
TargetType �� Property �� Value��%  &	       &	      '�� �     �� 5   
   6'   �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��Please wait... ��6   $
��Thin"�63   
�������6E   5      5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5       $��35 �6   �� 5!      $��* �6   .+�5#   
   �� $��Bottom=�6   $��0��6,   $��5,0,5,0q�69   
�������$��0,0,0,1q�6_   $��29��6y   ._�5$      ]� .+�5%      �� $��
Hire Rocks��6   $��Center=�5&      $��15(�5'      (  "Telerik.Windows.Controls.RadButton  5(      $��16��6$   $��16��60   $��0q�5)       $��Right=�5*       
������ $��0q�5,       $��Center=�5-       ��5.       �� *CloseWindow+.��5/      �� $��16��6   $��16��6(   $-��'pack://application:,,,/Images/Close.png��63   6f   50      51      52      �� 53   
   
�������$��1��6'   y�64   �� *IsTopNavigationVisible+ �� 	Converter# [ ._�54      ]� $��5,0,5,0q�6   .+�55      �� $ 
Horizontal=�6   $��Right=�66   .+�56      �� $��Center=�6!   .+�57      �� $��0,0,0,-5q�6?    �� Padding$ 5,0,5,0q�6Q   $��Right=�6c   ��6$   �� *	FirstName+6c   �� 58      $ 5,0,5,0q�6>   $��Right=�6P   ��6$   �� *
LastName+6P   59      �� 5:      $��30��6   $��30��6(   $��0,0,5,0q�6Q   ��63   �� *
ProfilePic+6d     5;       � ToolTip$ Logout��6(     SimpleButton#��[ 69   ��6_   �� *LogoutCommand+��5<      �� 5=       �� ImageSource$. (pack://application:,,,/Images/Logout.png��6)   5?      5@      5A      5B      �� 5C   
   $��5,0,0,0q�6   $��1��5D      $
��Left=�5E      $��20��5F      $��20��5G      $
 Sync��5H      y�5I      �� *IsSyncingData+# [ ��5J      �� 5K      $, &pack://application:,,,/Images/Sync.png��6   5M       � 5N   
   -   5          �Name$ MainContent��5N      $��2��6%     � NavigationUIVisibility$ Hidden=�5O   %   y�5P   %   �� *IsBusy+ $  BoolToVisibilityReverseConverter# [ 6�   /  )Telerik.Windows.Controls.RadBusyIndicator  5Q   
      IsIndeterminate . $��2��5S   #   $��1��64   +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Windows8Touch 5T   #      BusyContentTemplate# [ 5U   #      IsBusy 5Q   #   �� *IsBusy+5U   #   5V      5W      