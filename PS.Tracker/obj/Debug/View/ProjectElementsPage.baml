   M S B A M L   `   `   `  ����  
PS.Tracker)    #PS.Tracker.View.ProjectElementsPage   5      f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � DataContext  5      �� *ProjectElementViewModel+   Locator �� Source# [   � 	Resources 5        BoolToVisibilityConverter��%   &	       �� 5   
   6'   5	      .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   *  $Telerik.Windows.Controls.RadTileView     IsSelectionEnabled .  �� SelectedValuePath$ 
ContractId��5         	RowHeight$	 200 �5         
MaxColumns$ 2��5         MinimizedItemsPosition$ Bottom=�5      	   SelectionMode$	 Single=�5      ��5      �� *WorkerJobList+
 �� SelectedValue
 5      ��  �� Path$ SelectedContractId���5      �� 5      .R�5      �� ��6    �� *
JobTitle+5         ContentTemplate 5      �� 5      .R�5      5  /Telerik.Windows.Controls.RadFluidContentControl     ContentChangeMode$ 	Automatic=�65      LargeContent 5       � 5!      $��7q�6#    5"   "    �� 
TargetType �� Property �� Value��%z   '��       �� 5#   &   " ��6,   .�5$   *   ��  � ��
 �����6G   �� 5%   *    � ��$
 Wrap=�6I   5&   '   5'   #    � ColumnDefinitions 5(   "   �� 5)   &   $	��300 �67   �� 5*   &   .+�5,   "   � $��0��6'   .+�5-   &   �� $
��Left=�61   .+�5.   *   �� $��Job Title: ��64   $
��Bold"�6G   �� 5/   *   ��64   �� *
JobTitle+�� 51   *   $��Job Start Date: ��64   $
��Bold"�6L   �� 52   *   ��64   �� *JobStartDate+�� 54   *   $��Weekly Limit: ��64   $
��Bold"�6J   �� 55   *   ��64   �� *
HoursLimit+�� 57   *   $��
Job Type: ��64   $
��Bold"�6F   �� 58   *   ��64   �� *JobTypeName+�� 5:   *   $��Total Burned Hours: ��64   $
��Bold"�6P   �� 5;   *   ��64   �� *TotalBurnedHours+�� 5=   *   $��Weekly Burned Hours: ��64   $
��Bold"�6Q   �� 5>   *   ��64   �� *WeeklyBurnedHours+�� 5@   *   $��Today Burned Hours: ��64   $
��Bold"�6P   �� 5A   *   ��64   �� *TodayBurnedHours+5B   '   5C   #   � 5D   "   $��1��6'   .+�5E   &   �� $	��Top=�6,   $��Right=�5F   ,   $	��250��5H   ,   $	��230��5I   ,   ��5G   ,   �� *LastCaptureUrl+5I   :   5J   #   5K      5M      5N      5P      �� 5Q   
   $��35��6   $��1��6   ._�5R      �  5S      �� 5T      �� 5U      .+�5W      (  "Telerik.Windows.Controls.RadButton  $��0��6$   $
��Left=�5X   $   $��Reload Jobs��5Y   $   $��5q�5[   $   ��5Z   $   �� *RefreshJobsCommand+5[   1     5\      $��1��6$    � ToolTip$ Start��5^   $   $��Right=�5a   $   $��5q�5b   $   y�5]   $   �� *IsStartTaskButtonVisible+ �� 	Converter# [ ��5_   $   �� *StartTaskCommand+��5`   $   �� *StartButtonText+��5c   $   �� *StartButtonText+5d      5e      5f      5g      5h      