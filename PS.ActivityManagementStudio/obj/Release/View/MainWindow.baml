   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity   Activity management system1   +PS.ActivityManagementStudio.View.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x	 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  biPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity    	 
  k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef70	mvvmlight http://www.galasoft.ch/mvvmlight    � Title$  	Main Menu�� � WindowState$ 	Maximized=� � DataContext �� *MainWindowModel+   Locator �� Source# [  .��� ����  �� ImageSource$ /Images/background.png�� � 	Resources  �� 
TargetType  TileLabelStyle �� Property �� Value��%�   &	       �� " ��.���  � ��$ 20(���  � ��$ Segoe UI)���  � ��$ 10q���  � ��$
 Bold"���  � ��
 �������  � ��$ Bottom=�	 � RowDefinitions	 �� $��70 ��� $	��75* ��� $��70 �.+�� $��Center=�$��0��$��Right=�
 � ColumnDefinitions
 �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Welcome��$��0��
�������$
��Bold"�$��5q�$��20(��� $��1��$��Light"�
�������$��5q�$��20(����� *
UserName+( 
 "Telerik.Windows.Controls.RadButton  + 
 %Telerik.Windows.Controls.StyleManager   Theme- 
 'Telerik.Windows.Controls.ThemeConverter$ Transparent $��5q�$��Log out��$��2��
���  ��$��7,0,7,0q�$
��Bold"�$��20(����� *LogoutCommand+* 
 $Telerik.Windows.Controls.RadTileList  -     Name$ RadTileList��$��1��$��10q�$��Visible=� �� SelectedValuePath$ 
MenuItemId������ *MenuItemsList+ �� SelectedValue �� *SelectedQSpace+ �� Mode$ TwoWay=����� .R�� $��-5q����� *MenuItemBackGround+.+�� 
�������$��50��$	��Top=��� #��[ 
���   �$	��Top=����� *MenuItemName+