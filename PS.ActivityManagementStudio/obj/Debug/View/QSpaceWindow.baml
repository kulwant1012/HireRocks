   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Activity management system3   -PS.ActivityManagementStudio.View.QSpaceWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x	 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  5   	     � Title$  QSpaces��5   	    � WindowState$ 	Maximized=�6    � DataContext 5   	   �� *QSpaceViewModel+   Locator �� Source# [  .��5      � -   5         �Name$
 Main��5       � 	Resources 5	   
     TitleTextBlockStyleHeading �� 
TargetType �� Property �� Value  TitleTextBlockStyleContent  RadButtonStyle( 
 "Telerik.Windows.Controls.RadButton+ 
 %Telerik.Windows.Controls.StyleManager- 
 'Telerik.Windows.Controls.ThemeConverter��%�  &	       &	 �     &	 h    �� 5
      " ��67   .�5      ��  � ��$ 13(�6-   �� 5       � ��$ Segoe UI Regular)�6/   �� 5       � �� �#2e2e2e6/   5      �� 5      " ��67   .�5      ��  � ��$ 15(�6-   �� 5       � ��$ Segoe UI Regular)�6/   �� 5       � ��
 ��  �6/   �� 5       � ��$ 25��6+   5      �� 5      "  6+   .�5      ��  �@ Theme$ Windows8 6?   5      5      	 � RowDefinitions	 5   
   �� 5      $��50 �6   �� 5      .+�5"   
     $��0��6   $
��auto��6)   $��5q�66   $
��20,1q�6B   $��Right=�6P   $��Center=�6l   $��
Add QSpace��6�   #��[ 5$   !   ��5#   -   �� *(&DataContext.OpenAddQSpaceScreenCommand+
 �� ElementName$

 Main��5$   !   �� 5%   
   $
��auto��6   $��0��6   $��Bottom=�6+   $��.5q�6F   
����ح�6[   *  $Telerik.Windows.Controls.RadTileView  5&   
   -   5          Name$ TileViewQSpaces��5&      $��1��67   $   PreservePositionWhenMaximized .    MinimizedColumnWidth$	 200 �5'   "      MinimizedRowHeight$	 200 �6=      IsAutoScrollingEnabled .    	RowHeight$	 200 �5(   "      ColumnWidth$	 200 �62   $��10q�6D   ��5&   D   �� *
QSpaceList+��5)      �� 5*      .R�5+      � .+�5,      ��  �� Orientation$ Vertical=�6%   .+�5-      �� ��6(   �� *
QSpaceName+5.      5/      50         ContentTemplate 52      �� 53      .R�54      5 
 /Telerik.Windows.Controls.RadFluidContentControl     ContentChangeMode$ 	Automatic=�65      TransitionDuration$ 0:0:1h�6S      LargeContent 55      �� 56      $
��Auto=�6+   $
��Auto=�6P      Theme$ Windows8 6s   .��57   "   �� $��Center=�6-   $��20q�6H   .+�59   &   � 	 5:   *   �� 5;   .   $
��Auto �6<   �� 5<   .   $
��Auto �6<   �� 5=   .   $
��Auto �6<   �� 5>   .   $
��Auto �6<   �� 5?   .   $��70 �6<   .+�5A   *   �� $��0��65   $ Vertical=�6B   $��	20,10,0,0q�6Y   $
��Left=�6l   .+�5B   .   �� #��[ 68   $��QSpace Name��6l   �� 5C   .   #��[ 6`   ��68   �� *
QSpaceName+ �� Mode$ TwoWay=�6`   5D   +   �� 5F   *   $��1��65   $ Vertical=�6B   $��	20,10,0,0q�6Y   $
��Left=�6l   .+�5G   .   �� #��[ 68   $��QSpace Type��6l   �� 5H   .   #��[ 6`   ��68   �� *
QSpaceType+$ TwoWay=�6`   5I   +   �� 5K   *   $��2��65   $ Vertical=�6B   $��	20,10,0,0q�6Y   $
��Left=�6l   .+�5L   .   �� $��Description��68   #��[ 6K   �� 5M   .   #��[ 6b   $	��400��6�   $��60��6�   $
��Wrap=�6�   ��68   �� *Description+$ TwoWay=�6�   5N   +   �� 5P   *   $��3��65   $ 
Horizontal=�6B   $��	20,10,0,0q�6[   .+�5Q   .   �� $ Vertical=�69   $	��200��6P   .+�5R   2   �� $��
Start Date��6<   #��[ 6N   �� 5S   2   #��[ 6W   ��6<   �� *	StartDate+6W   5T   /   �� 5V   .   $ Vertical=�69   $��20,0,0,0q�6P   $	��200��6b   .+�5W   2   �� $��Due Date��6<   #��[ 6L   �� 5X   2   #��[ 6U   ��6<   �� *	DueDate+6U   5Y   /   5Z   +     5\   *   $��5q�6<   $��	0,0,20,20q�6H   $��Right=�6[   $��Edit QSpace��6w   $��Bottom=�5]   �   $��4��6�   #��[ 5^   1   ��5]   =   �� *+)DataContext.OpenUpdateQSpaceScreenCommand+$

 Main����5^   Y   �� 5_   '   5`   #   5a      5c      5d      5f      / 
 )Telerik.Windows.Controls.RadBusyIndicator  5h   
   $��1��6#   $ Windows8 6J      IsIndeterminate .    IsBusy 60   �� *IsBusy+5j      5k      5l      