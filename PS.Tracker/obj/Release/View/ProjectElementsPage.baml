   M S B A M L   `   `   `  ����   
PS.Tracker)    #PS.Tracker.View.ProjectElementsPage   f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       � DataContext  �� *ProjectElementViewModel+   Locator �� Source# [   � 	Resources   BoolToVisibilityConverter��%   &	       �� .���  � RowDefinitions �� �� $
��auto �.+�*  $Telerik.Windows.Controls.RadTileView     IsSelectionEnabled .  �� SelectedValuePath$ 
ContractId��   	RowHeight$	 200 �   
MaxColumns$ 2��   MinimizedItemsPosition$ Bottom=�	   SelectionMode$	 Single=����� *WorkerJobList+
 �� SelectedValue
 ��  �� Path$ SelectedContractId����� .R��� ���� *
JobTitle+   ContentTemplate �� .R�5  /Telerik.Windows.Controls.RadFluidContentControl     ContentChangeMode$ 	Automatic=�   LargeContent � $��7q�  �� 
TargetType �� Property �� Value��%G   '��       �� " ��.���  � ��
 �������  � ��$
 Wrap=� � ColumnDefinitions �� $	��300 ��� .+�� $��0��.+��� $
��Left=�.+��� $��Job Title: ��$
��Bold"��� ���� *
JobTitle+�� $��Job Start Date: ��$
��Bold"��� ���� *JobStartDate+�� $��Weekly Limit: ��$
��Bold"��� ���� *
HoursLimit+�� $��
Job Type: ��$
��Bold"��� ���� *JobTypeName+�� $��Total Burned Hours: ��$
��Bold"��� ���� *TotalBurnedHours+�� $��Weekly Burned Hours: ��$
��Bold"��� ���� *WeeklyBurnedHours+�� $��Today Burned Hours: ��$
��Bold"��� ���� *TodayBurnedHours+� $��1��.+��� $	��Top=�$��Right=�$	��250��$	��230������ *LastCaptureUrl+�� $��35��$��1��._��  �� �� .+�(  "Telerik.Windows.Controls.RadButton  $��0��$
��Left=�$��Reload Jobs��$��5q����� *RefreshJobsCommand+  $��1�� � ToolTip$ Start��$��Right=�$��5q�y��� *IsStartTaskButtonVisible+ �� 	Converter# [ ���� *StartTaskCommand+���� *StartButtonText+���� *StartButtonText+