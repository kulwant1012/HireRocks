   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	    Activity management system1   +PS.ActivityManagementStudio.View.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x	 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  5   	   biPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity    	 
  5   	   k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef70	mvvmlight http://www.galasoft.ch/mvvmlight  5   	     � Title$  	Main Menu��5   	    � WindowState$ 	Maximized=�6    � DataContext 5   	   �� *MainWindowModel+   Locator �� Source# [  .��5
      � ��5   
   �� 5       �� ImageSource$ /Images/background.png��6    � 	Resources 5   
    �� 
TargetType  TileLabelStyle �� Property �� Value��%  &	       �� 5      " ��6   .�5      ��  � ��$ 20(�6-   �� 5       � ��$ Segoe UI)�6/   �� 5       � ��$ 10q�6+   �� 5       � ��$
 Bold"�6/   �� 5       � ��
 �����6/   �� 5       � ��$ Bottom=�66   5      5      	 � RowDefinitions	 5   
   �� 5      $��70 �6   �� 5      $	��75* �6   �� 5      $��70 �6   .+�5    
   � $��Center=�6   $��0��6*   $��Right=�67   
 � ColumnDefinitions
 5!      �� 5"      $
��auto �6#   �� 5#      $
��auto �6#   �� 5$      $
��auto �6#   .+�5'      �� $��Welcome��6   $��0��6'   
�������$
��Bold"�6M   $��5q�6_   $��20(�6j   �� 5(      $��1��62   $��Light"�6B   
�������$��5q�6k   $��20(�6v   ��6   �� *
UserName+6v   ( 
 "Telerik.Windows.Controls.RadButton  5)      + 
 %Telerik.Windows.Controls.StyleManager   Theme- 
 'Telerik.Windows.Controls.ThemeConverter$ Transparent 6    $��5q�6I   $��Log out��6V   $��2��6h   
���  ��$��7,0,7,0q�6�   $
��Bold"�6�   $��20(�6�   ��6�   �� *LogoutCommand+5*      * 
 $Telerik.Windows.Controls.RadTileList  5,   
   -   5          Name$ RadTileList��5,      $��1��63   $��10q�6@   $��Visible=�6r    �� SelectedValuePath$ 
MenuItemId��5-      ��5,   L   �� *MenuItemsList+ �� SelectedValue 5-   =   �� *SelectedQSpace+ �� Mode$ TwoWay=���5.      �� 5/      .R�50      � $��-5q�6E   ��6   �� *MenuItemBackGround+.+�51      � 
�������$��50��66   $	��Top=�6B   6\   �� 52      #��[ 6F   
���   �$	��Top=�6�   ��6(   �� *MenuItemName+6�   53      54      56      57      58      