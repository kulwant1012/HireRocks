   M S B A M L   `   `   `  ����   Activity management system7    1PS.ActivityManagementStudio.View.DictionaryWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f	 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
   � Title$  Dictionaries�� � WindowState$ 	Maximized=� � DataContext �� *DictionaryModel+   Locator �� Source# [  .��� -    �Name$
 Main�� � 	Resources   TitleTextBlockStyleHeading �� 
TargetType �� Property �� Value  TitleTextBlockStyleContent  RadButtonStyle+ 	 %Telerik.Windows.Controls.StyleManager- 	 'Telerik.Windows.Controls.ThemeConverter��%   &	       &	 c     &	 �     �� " ��.���  � ��$ 13(���  � ��$ Segoe UI Regular)���  � �� �#2e2e2e�� " ��.���  � ��$ 15(���  � ��$ Segoe UI Regular)���  � ��
 ��  ���  � ��$ 25���� .���  �@ Theme$ Windows8 	 � RowDefinitions	 �� $��80 ��� .+�( 	 "Telerik.Windows.Controls.RadButton  $��0��$	��120��$
��20,1q�$��Right=�$��Bottom=�$��Add Dictionary��#��[ ���� *&$DataContext.OpenAddDictionaryCommand+
 �� ElementName$

 Main��* 
 $Telerik.Windows.Controls.RadTileView  -     Name$ radTileView��$��1��$   PreservePositionWhenMaximized .    IsSelectionEnabled .    MinimizedColumnWidth$	 150 �   MinimizedRowHeight$	 150 �   IsAutoScrollingEnabled .    	RowHeight$	 200 �   ColumnWidth$	 200 �$��10q�   Theme$ Windows8 ���� *KeywordDictionaryList+���� .R�� .+���  �� Orientation$ Vertical=�.+��� ���� *DictionaryName+   ContentTemplate �� .R�5 	 /Telerik.Windows.Controls.RadFluidContentControl  -      
TransitionD 	 >Telerik.Windows.Controls.TransitionControl.TransitionConverter$ PerspectiveRotation    LargeContent �� $��Center=�$��20q�.+�� 	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��70 �.+��� $��0��$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� #��[ $��Dictionary Name���� #��[ ���� *DictionaryName+ �� Mode$ TwoWay=��� $��3��$ 
Horizontal=�.+��� $ Vertical=�$��20q�$
��1070��.+��� $��Keywords��#��[ �� $
��Auto=�$
��auto��$	��300������ *keywordList+  $	��130��$��40��$��	0,0,20,20q�$��Right=�$��Edit Dictionary��$��Bottom=�$��4��#��[ ���� *)'DataContext.OpenUpdateDictionaryCommand+$

 Main������ ��� $ contentGrid��.+��� $��Center=�.+��� $ 
Horizontal=�$
��Left=�.+��� #��[ $��Dictionary Name���� #��[ ���� *DictionaryName+$ TwoWay=��� $ Vertical=�.+��� $
��Auto=�$��10q�$
��auto��$	��100������ *keywordList+