   M S B A M L   `   `   `  ����   Activity management system4    .PS.ActivityManagementStudio.View.ReportsWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f	 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
   � Title$  Reports�� � WindowState$ 	Maximized=� � DataContext �� *ReportsViewModel+   Locator �� Source# [   � 	Resources   Windows8Style+ 	 %Telerik.Windows.Controls.StyleManager �� Property �� Value- 	 'Telerik.Windows.Controls.ThemeConverter��%4   &	       �� .���  �@ Theme$ Windows8 .��� .+�� $��10q� � RowDefinitions �� $��50 ��� $��50 ��� .+���  �� Orientation$ 
Horizontal=�$��Right=�$��25��.+�$ 	 Telerik.Windows.Controls.Label  $��Time Period��#��[ *  $Telerik.Windows.Controls.RadComboBox  $	��200��#��[ 	 �� DisplayMemberPath$	 	RangeName��
 �� SelectedValuePath$
 	RangeName�� �� SelectedValue ��  �� Path$ SelectedRange� �� Mode$ TwoWay=� �� ValidatesOnDataErrors . ���� *RangeTypeList+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . �� $ 
Horizontal=�$
��Left=�$��25��y��� *IsCustomDateRangeSelected+ $  BoolToVisibilityReverseConverter �� 	Converter# [ .+�( 	 "Telerik.Windows.Controls.RadButton  $��<��$��25��#��[ ���� *PreviousButtonClickCommand+  #��[ $��5,0,5,0q����� *SelectedRangeDisplayText+  $��>��$��25��#��[ ���� *NextButtonClickCommand+�� $ 
Horizontal=�$��25��$
��Left=�y��� *IsCustomDateRangeSelected+  BoolToVisibilityConverter# [ .+�  $
��From��$��20,0,0,0q�,  &Telerik.Windows.Controls.RadDatePicker  $	��200��#��[ 0  *Telerik.Windows.Controls.RadDateTimePicker   SelectedDate �� *SelectedStartDate+$ TwoWay=� �� TargetNullValue$  ��  $��To��$��20,0,0,0q�  #��[ $	��200�� �� *SelectedEndDate+$ TwoWay=�$  ���� 
�������$��1��$��Bottom=�]� $��1��$��25��.+�  $��Select QSpace��$��20,0,0,0q�  $	��200��#��[ %   ClearSelectionButtonVisibility$ Visible=�"   ClearSelectionButtonContent$ Select QSpace��$	 
QSpaceName��$
 Id�� �� $ SelectedQSpace�$ TwoWay=� . ���� *
QSpaceList+$ PropertyChanged=� .   $��Select User��$��20,0,0,0q�  $	��200��#��[ $ Visible=�$ Select User��$	 	FirstName��$
 Id�� �� $ SelectedUser�$ TwoWay=� . ���� *
UserList+$ PropertyChanged=� .   $��Create Report��$��Right=�#��[ ���� *CreateReportCommand+�� 
�������$��1��$��1��$��Bottom=�*  $Telerik.Windows.Controls.RadGridView  $��2��#��[ $��0q�8	  2Telerik.Windows.Controls.GridView.BaseItemsControl 	  GroupRenderMode$
 Flat=�;
  5Telerik.Windows.Controls.GridView.GridViewDataControl 
  RowIndicatorVisibility$ 	Collapsed=� 
  
IsReadOnly .  
  ShowColumnFooters .  
  ShowGroupFooters .  
  AutoGenerateColumns .   
  CanUserFreezeColumns .   
  CanUserResizeColumns .  *  $Telerik.Windows.Controls.DataControl   ItemsSource �� *
ReportList+ 
  Columns 1  +Telerik.Windows.Controls.GridViewDataColumn  6  0Telerik.Windows.Controls.GridViewBoundColumnBase    Header$  	User Name��-  'Telerik.Windows.Controls.GridViewColumn!   Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$! * "   DataMemberBinding" �� *
UserName+  $  Activity Name��$! * " �� *ActivityName+  $  Qspace Name��$! * " �� *
QspaceName+  $
  Date��$! * " �� *Date+  $  Time Logged��$! * " �� *
TimeLogged+#   AggregateFunctions# &   Telerik.Windows.Data.SumFunction  ,  &Telerik.Windows.Data.AggregateFunction$   Caption$$ Total time logged: ��  $  Original Estimate��$! * " �� *OriginalEstimate+/ 	 )Telerik.Windows.Controls.RadBusyIndicator  $��0��$��3��%   IsIndeterminate% . #��[ &   IsBusy& �� *IsBusy+