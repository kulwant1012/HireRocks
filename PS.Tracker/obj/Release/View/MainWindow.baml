   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  f bGalaSoft.MvvmLight.Platform, Version=5.0.2.32241, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command  
PS.Tracker    PS.Tracker.View.MainWindow   f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity    	 acommandMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform    	   � Title$  
Hire Rocks��$	��600��$	��500�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency .  � WindowStyle$
 None=� � DataContext �� *MainViewModel+   Locator �� Source# [  ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.��� 	 � Color$	 	#FF4B4B4B��
 � Offset$
 0Q�� $	 	#FF8F8F8F��$
 1Q� � 	Resources    BooleanToVisibilityConverter  BusyContentDataTemplate �� Orientation �� 
TargetType �� Property �� Value��%�   &	       &	      '�� W     �� �� .R��� $ 
Horizontal=�.+��� $��Please wait... ��$
��Thin"�
��������� " ��.���  � ��
 �����.���  � RowDefinitions �� $��30 ��� $��35 ��� $��* �.+��� $��Bottom=�$��0��$��5,0,5,0q�
�������$��0,0,0,1q�$��29��._�]� .+��� $��
Hire Rocks��$��Center=�$��15(�(  "Telerik.Windows.Controls.RadButton  $��16��$��16��$��0q�$��Right=�
������ $��0q�$��Center=����� *CloseWindow+.���� $��16��$��16��$-��'pack://application:,,,/Images/Close.png���� 
�������$��1��y��� *IsTopNavigationVisible+ �� 	Converter# [ ._�]� $��5,0,5,0q�.+��� $ 
Horizontal=�$��Right=�.+��� $��Center=�.+��� $��0,0,0,-5q� �� Padding$ 5,0,5,0q�$��Right=����� *	FirstName+�� $ 5,0,5,0q�$��Right=����� *
LastName+�� $��30��$��30��$��0,0,5,0q����� *
ProfilePic+   � ToolTip$ Logout��  SimpleButton#��[ ���� *LogoutCommand+����  �� ImageSource$. (pack://application:,,,/Images/Logout.png���� $��5,0,0,0q�$��1��$
��Left=�$��20��$��20��$
 Sync��y��� *IsSyncingData+# [ ���� $, &pack://application:,,,/Images/Sync.png�� � -     �Name$ MainContent��$��2��  � NavigationUIVisibility$ Hidden=�y��� *IsBusy+ $  BoolToVisibilityReverseConverter# [ /  )Telerik.Windows.Controls.RadBusyIndicator     IsIndeterminate . $��2��$��1��+  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Windows8Touch    BusyContentTemplate# [    IsBusy �� *IsBusy+