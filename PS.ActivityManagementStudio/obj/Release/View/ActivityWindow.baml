   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   Activity management system5   /PS.ActivityManagementStudio.View.ActivityWindow   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\
 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation  	 
 R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml   	 
 6sys&clr-namespace:System;assembly=mscorlib   	 
   � Title$  
Activities�� � WindowState$ 	Maximized=� � DataContext �� *ActivityViewModel+   Locator �� Source# [  .��� -    �Name$
 Main�� � 	Resources   RadUniformGridStyle �� 
TargetType8  2Telerik.Windows.Controls.Primitives.RadUniformGrid �� Property �� Value'  !Telerik.Windows.Controls.RadClock  RadClockStyle	  Name  TitleTextBlockStyleHeading  TitleTextBlockStyleContent  ContentStyle  RadExpanderStyle*  $Telerik.Windows.Controls.RadExpander+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadButtonStyle(  "Telerik.Windows.Controls.RadButton  RadTimePickerStyle,  &Telerik.Windows.Controls.RadTimePicker��%�  &	       &	 n     7  &	 �     &	 3    &	 �    &	     &	 L    &	 {    �� "  .���  �@ Rows$ 10����  �@ ChildrenFlow$ 
Horizontal=���  � ��$ Visible=��� "  .���  �@ Header$ Clock����  � �� �� .R�  $	 uniformGrid��8��  �� " ��.���  � ��$ 13(���  � ��$ Segoe UI Regular)���  � �� �#2e2e2e�� " ��.���  � ��$ 15(���  � ��$ Segoe UI Regular)���  � ��
 ��  ���  � ��$ 25���� " ��.���  � ��$ 15(���  � ��$ Segoe UI Regular)���  � ��
 ��  ���  � ��$ 25���� "  .���  �@ Theme$ Windows8 �� "  .���  �@ Theme$ Windows8 �� "  .���  �@ Theme$ Windows8 
 � RowDefinitions
 �� $��80 ��� .+��� 
���  ��$��Center=�$
��auto������ *	Message+  $��0��$��5q�$
��20,1q�$��Right=�$��Bottom=�$��Add Activity��#��[ y��� *IsModificationButtonVisibe+ 	 BoolToVisibilityConverter �� 	Converter# [	 ���� *#!DataContext.OpenAddActivityWindow+ �� ElementName$
 Main��*  $Telerik.Windows.Controls.RadTileView  -     Name$ tileView��$��1��$   PreservePositionWhenMaximized .    MinimizedColumnWidth$	 200 �   MinimizedRowHeight$	 200 �   IsAutoScrollingEnabled .    	RowHeight$	 200 �   ColumnWidth$	 200 �$��10q����� *ActivityList+���� .R�� .+���  �� Orientation$ Vertical=�.+��� ���� *Name+   ContentTemplate �� .R�5	  /Telerik.Windows.Controls.RadFluidContentControl	   	  ContentChangeMode$ 	Automatic=� 	  TransitionDuration$ 0:0:1h� 	  LargeContent �� $
��Auto=�$
��Auto=�   Theme$ Windows8 .��� $��Center=�$��Center=�
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Activity Name���� #��[ ���� *Name+�� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $#��Capture Interval (In seconds)���� #��[ ���� *CaptureInterval+ �� Mode$ TwoWay=��� $��1��$	��Top=�$��1��
��������� $��1��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Select QSpace���� #��[ ���� *
QSpaceName+�� $ Vertical=�$	��5,0q�.+�  $��Bottom=�   
IsExpanded .    ExpandDirection$
 Down=�#��[ ���� $!��Assigned Keyword Dictionary������ $	��200������ *KeywordDictionariesList+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . ���� .R��� ���� *DictionaryName+�� $ Vertical=�$	��5,0q�$	��200��.+�    Name$ radExpander��$��Bottom=� . $
 Down=�#��[ ����   ��Name$  expanderCaption��$��Assigned Activity Tool������ ���� *ActivityToolsList+$ PropertyChanged=����� .R��� ���� *ToolDescription+�� $��2��$	��Top=�$��1��
��������� $��2��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $	��5,0q�$	��200��.+��� #��[ $��
Start Date���� #��[ ���� *	StartDate+�� $	��5,0q�$	��200��.+��� #��[ $��Due Date���� #��[ ���� *	DueDate+�� $	��5,0q�$	��200��.+��� #��[ $��Completion Date���� #��[ ���� *CompletionDate+�� $��3��$	��Top=�$��1��
��������� $��3��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $	��5,0q�$	��200��.+��� #��[ $��Actual Duration���� #��[ ���� *ActualDuration+�� $	��5,0q�$	��200��.+��� #��[ $��Original Estimate���� #��[ ���� *EstimatedDuration+�� $	��5,0q�$	��200��.+��� #��[ $��Remaining Estimate���� #��[ ���� *RemainingDuration+�� $��4��$ 
Horizontal=�$��20,8,0,0q�$
��Left=��� $��5��$	��Top=�$��1��
��������� $��5��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ 
Horizontal=�.+��� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Assigned To���� #��[ ���� *
AssignedTo+�� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Requested By���� #��[ ���� *
ReportedBy+�� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Priority���� #��[ ���� *AssignedPriority+�� $��6��$	��Top=�$��1��
��������� $��6��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Activity Status���� #��[ ���� *ActivityStatusName+�� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Sequence���� #��[ ���� *
Sequence+�� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Variation Factor���� #��[ ���� *VariationFactor+�� $��7��$	��Top=�$��1��
��������� $��7��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Additional Time���� #��[ ���� *AdditionalTime+�� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Percent Completed���� #��[ ���� *PercentCompleted+�� $��8��$	��Top=�$��1��
��������� $��8��$ Vertical=�$��20,8,0,0q�.+��� #��[ $��Description���� $
��Wrap=�#��[ $��40������ *Description+�� #��[ $��Expected Output���� $
��Wrap=�#��[ $��40������ *ExpectedOutput+�� #��[ $��Actual Output���� $
��Wrap=�#��[ $��40������ *ActualOutput+�� $��9��$	��Top=�$��1��
��������� $��9��$��20,8,0,0q�$ 
Horizontal=�$��Right=�.+�  $��5q�$��	0,0,20,20q�$��Right=�$��Delete Activity��#��[ ���� *#!DataContext.DeleteActivityCommand+$
 Main������ y��� *(&DataContext.IsModificationButtonVisibe+$
 Main��# [	   $��5q�$��	0,0,20,20q�$��Right=�$��Edit Activity��#��[ ���� *$"DataContext.OpenEditActivityWindow+$
 Main������ y��� *(&DataContext.IsModificationButtonVisibe+$
 Main��# [	  ��%E   (��       *,*SystemParameters.VerticalScrollBarWidthKey+)X�3Q�/
  )Telerik.Windows.Controls.RadBusyIndicator
  $��1��$ Windows8 ! 
  IsIndeterminate! . " 
  IsBusy" �� *IsBusy+