   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   Activity management system3   -PS.ActivityManagementStudio.View.QSpaceWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x	 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
    � Title$  QSpaces�� � WindowState$ 	Maximized=� � DataContext �� *QSpaceViewModel+   Locator �� Source# [  .��� -    �Name$
 Main�� � 	Resources   TitleTextBlockStyleHeading �� 
TargetType �� Property �� Value  TitleTextBlockStyleContent  RadButtonStyle( 
 "Telerik.Windows.Controls.RadButton+ 
 %Telerik.Windows.Controls.StyleManager- 
 'Telerik.Windows.Controls.ThemeConverter��%%  &	       &	 c     &	 �     �� " ��.���  � ��$ 13(���  � ��$ Segoe UI Regular)���  � �� �#2e2e2e�� " ��.���  � ��$ 15(���  � ��$ Segoe UI Regular)���  � ��
 ��  ���  � ��$ 25���� "  .���  �@ Theme$ Windows8 	 � RowDefinitions	 �� $��50 ��� .+�  $��0��$
��auto��$��5q�$
��20,1q�$��Right=�$��Center=�$��
Add QSpace��#��[ ���� *(&DataContext.OpenAddQSpaceScreenCommand+
 �� ElementName$

 Main���� $
��auto��$��0��$��Bottom=�$��.5q�
����ح�*  $Telerik.Windows.Controls.RadTileView  -     Name$ TileViewQSpaces��$��1��$   PreservePositionWhenMaximized .    MinimizedColumnWidth$	 200 �   MinimizedRowHeight$	 200 �   IsAutoScrollingEnabled .    	RowHeight$	 200 �   ColumnWidth$	 200 �$��10q����� *
QSpaceList+���� .R�� .+���  �� Orientation$ Vertical=�.+��� ���� *
QSpaceName+   ContentTemplate �� .R�5 
 /Telerik.Windows.Controls.RadFluidContentControl     ContentChangeMode$ 	Automatic=�   TransitionDuration$ 0:0:1h�   LargeContent �� $
��Auto=�$
��Auto=�   Theme$ Windows8 .���� $��Center=�$��20q�.+�� 	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��70 �.+��� $��0��$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� #��[ $��QSpace Name���� #��[ ���� *
QSpaceName+ �� Mode$ TwoWay=��� $��1��$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� #��[ $��QSpace Type���� #��[ ���� *
QSpaceType+$ TwoWay=��� $��2��$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� $��Description��#��[ �� #��[ $	��400��$��60��$
��Wrap=����� *Description+$ TwoWay=��� $��3��$ 
Horizontal=�$��	20,10,0,0q�.+��� $ Vertical=�$	��200��.+��� $��
Start Date��#��[ �� #��[ ���� *	StartDate+�� $ Vertical=�$��20,0,0,0q�$	��200��.+��� $��Due Date��#��[ �� #��[ ���� *	DueDate+  $��5q�$��	0,0,20,20q�$��Right=�$��Edit QSpace��$��Bottom=�$��4��#��[ ���� *+)DataContext.OpenUpdateQSpaceScreenCommand+$

 Main������ / 
 )Telerik.Windows.Controls.RadBusyIndicator  $��1��$ Windows8    IsIndeterminate .    IsBusy �� *IsBusy+