   M S B A M L   `   `   `  ����  Activity management system4    .PS.ActivityManagementStudio.View.ReportsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f	 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	     � Title$  Reports��5   	    � WindowState$ 	Maximized=�6    � DataContext 5   	   �� *ReportsViewModel+   Locator �� Source# [   � 	Resources 5        Windows8Style+ 	 %Telerik.Windows.Controls.StyleManager �� Property �� Value- 	 'Telerik.Windows.Controls.ThemeConverter��%T   &	       �� 5   
   .�5	      ��  �@ Theme$ Windows8 6;   5
      5      .��5      � .+�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��50 �6    �� 5      .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��25��6N   .+�5      $ 	 Telerik.Windows.Controls.Label  $��Time Period��6    #��[ 66   *  $Telerik.Windows.Controls.RadComboBox  5      $	��200��6&   #��[ 62   	 �� DisplayMemberPath$	 	RangeName��5   &   
 �� SelectedValuePath$
 	RangeName��5   &    �� SelectedValue 5   &   ��  �� Path$ SelectedRange� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . ��5   &   �� *RangeTypeList+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . 5      �� 5      $ 
Horizontal=�6   $
��Left=�62   $��25��6M   y�6Y   �� *IsCustomDateRangeSelected+ $  BoolToVisibilityReverseConverter �� 	Converter# [ .+�5      ( 	 "Telerik.Windows.Controls.RadButton  $��<��6$   $��25��63   #��[ 6>   ��6e   �� *PreviousButtonClickCommand+  5      #��[ 6M   $��5,0,5,0q�6t   ��6    �� *SelectedRangeDisplayText+6t     5      $��>��6$   $��25��63   #��[ 6>   ��6e   �� *NextButtonClickCommand+5       �� 5!      $ 
Horizontal=�6   $��25��62   $
��Left=�6>   y�6Y   �� *IsCustomDateRangeSelected+  BoolToVisibilityConverter# [ .+�5"        $
��From��6    $��20,0,0,0q�6/   ,  &Telerik.Windows.Controls.RadDatePicker  5#      $	��200��6s   #��[ 6   0  *Telerik.Windows.Controls.RadDateTimePicker   SelectedDate 6(   �� *SelectedStartDate+$ TwoWay=� �� TargetNullValue$  ��6     5$      $��To��6    $��20,0,0,0q�6-     5%      #��[ 6(   $	��200��6�    6O   �� *SelectedEndDate+$ TwoWay=�$  ��6�   5&      �� 5(      
�������$��1��6'   $��Bottom=�62   ]� 5+      $��1��6   $��25��6%   .+�5,        $��Select QSpace��6    $��20,0,0,0q�68     5-      $	��200��6&   #��[ 62   %   ClearSelectionButtonVisibility$ Visible=�5.   &   "   ClearSelectionButtonContent$ Select QSpace��5/   &   $	 
QSpaceName��50   &   $
 Id��51   &    52   &   �� $ SelectedQSpace�$ TwoWay=� . ��53   &   �� *
QSpaceList+$ PropertyChanged=� .   55      $��Select User��6    $��20,0,0,0q�66     56      $	��200��6&   #��[ 62   $ Visible=�57   &   $ Select User��58   &   $	 	FirstName��59   &   $
 Id��5:   &    5;   &   �� $ SelectedUser�$ TwoWay=� . ��5<   &   �� *
UserList+$ PropertyChanged=� .   5>      $��Create Report��6$   $��Right=�6d   #��[ 6�   ��6<   �� *CreateReportCommand+6�   5?      �� 5@      
�������$��1��6'   $��1��64   $��Bottom=�6?   *  $Telerik.Windows.Controls.RadGridView  5B      $��2��6"   #��[ 6R   $��0q�5C   	   8	  2Telerik.Windows.Controls.GridView.BaseItemsControl 	  GroupRenderMode$
 Flat=�6   ;
  5Telerik.Windows.Controls.GridView.GridViewDataControl 
  RowIndicatorVisibility$ 	Collapsed=�5D   	    
  
IsReadOnly .  
  ShowColumnFooters .  
  ShowGroupFooters .  
  AutoGenerateColumns .   
  CanUserFreezeColumns .   
  CanUserResizeColumns .  *  $Telerik.Windows.Controls.DataControl   ItemsSource 5B   /   �� *
ReportList+ 
  Columns 5K      1  +Telerik.Windows.Controls.GridViewDataColumn  5L      6  0Telerik.Windows.Controls.GridViewBoundColumnBase    Header$  	User Name��61   -  'Telerik.Windows.Controls.GridViewColumn!   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$! * 6k   "   DataMemberBinding" 6D   �� *
UserName+6k     5M      $  Activity Name��61   $! * 6s   " 6H   �� *ActivityName+6s     5N      $  Qspace Name��61   $! * 6o   " 6F   �� *
QspaceName+6o     5O      $
  Date��61   $! * 6b   " 6?   �� *Date+6b     5P      $  Time Logged��61   $! * 6o   " 6F   �� *
TimeLogged+#   AggregateFunctions# 5Q      &   Telerik.Windows.Data.SumFunction  5R      ,  &Telerik.Windows.Data.AggregateFunction$   Caption$$ Total time logged: ��62   5T        5U      $  Original Estimate��61   $! * 6{   " 6L   �� *OriginalEstimate+6{   5X      / 	 )Telerik.Windows.Controls.RadBusyIndicator  5Y      $��0��6'   $��3��64   %   IsIndeterminate% . #��[ 6v   &   IsBusy& 6E   �� *IsBusy+6v   5Z      5[      5\      