   M S B A M L   `   `   `  ���� d  `GalaSoft.MvvmLight.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=eabbf6a5f5af5004iJclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.WPF45GalaSoft.MvvmLight.Command  c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  Activity management system>   8PS.ActivityManagementStudio.View.AddUpdateActivityWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ZcmdJclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.WPF45     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o	 kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b
 ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation  	 
    :sys&clr-namespace:System;assembly=mscorlib  	 
    -   $��Window��  � WindowState$  	Maximized=� � Title �� *WindowTitle+ � DataContext �� *ActivityViewModel+   Locator �� Source# [   � 	Resources   TextBoxErrorTemplate �� 
TargetType �� ElementName �� Path��%�   &	       �� " ��.R��� .+��� $	��Top=�$��Right=�$��5,0,0,0q�
���  ������ $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��1q�._��� $��	MyAdorner��.���    TitleTextBlockStyle �� 
TargetType	 �� Property
 �� Value  TitleEditTextBoxStyle  RadUniformGridStyle8  2Telerik.Windows.Controls.Primitives.RadUniformGrid'  !Telerik.Windows.Controls.RadClock  RadClockStyle  Name  RadTimePickerStyle,  &Telerik.Windows.Controls.RadTimePicker+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadExpanderStyle*  $Telerik.Windows.Controls.RadExpander  RadButtonStyle(  "Telerik.Windows.Controls.RadButton 	 SelectionBoxTemplate 
 RadComboBoxStyle*  $Telerik.Windows.Controls.RadComboBox  RadDatePickerStyle,	  &Telerik.Windows.Controls.RadDatePicker��%M  &	       &	 c     &	 �     &	 ]    7  &	 �    &	 �    &	     &		 L    &	
 �    &	 �    �� " ��.��� 	 � ��$
 12(��� 	 � ��$
 Segoe UI Regular)��� 	 � ��
 �#2e2e2e�� " ��.��� 	 � ��$
 15(��� 	 � ��$
 Segoe UI Regular)��� 	 � ��

 �   ��� 	 � ��$	
 300���� 	 � ��$
 25���� "  .��� 	 �@ Rows$
 10���� 	 �@ ChildrenFlow$
 
Horizontal=��� 	 � ��$
 Visible=��� "  .��� 	 �@ Header$
 Clock���� 	 � ��
 �� .R�  $ uniformGrid��8��  �� "  .��� 	 �@ Theme$
 Windows8 �� "  .��� 	 �@ Theme$
 Windows8 �� "  .��� 	 �@ Theme$
 Windows8 �� .R��� 
��� � �$
��Bold"����� *
QSpaceName+�� "  .��� 	 �@ Theme$
 Windows8 �� " 	 .��� 	 �@ Theme$
 Windows8 .+��� $
��Auto=�   Theme$ Windows8 .��� $��Center=�$��Center=�.+��� 
���  ��$��Right=����� *	Message+�� $��Bottom=�.+��� $��Add Activity��$��20(�$��Segoe UI Regular)�
�������� -    �Name$ PreviewGrid��$��Center=� � RowDefinitions �� $
��Auto ��� $
��Auto �.+��  J� Opacity$	 0.8Q����#ffffff$��43�� � ColumnDefinitions �� $
��Auto ��� $��* ��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�.+��� #��[ $��Activity Name����  =� ErrorTemplate# [ #��[ $	��200������ *ActivityModel.Name+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $#��Capture Interval (In seconds)���� # [ #��[ $	��200������ *ActivityModel.CaptureInterval+$ TwoWay=� �� TargetNullValue$  ���� $ Vertical=�$	��5,0q�$	��200��.+��� #��[ $��Capture Type��  $	��200�� �� SelectedItem �� $' !ActivityModel.ActivityCaptureType����� *ActivityCaptureTypeList+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . �� $��1��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�.+��� #��[ $��Select QSpace��  $	��200��#��[
  �� DisplayMemberPath$ 
QSpaceName�� �� SelectedValuePath$ Id�� �� SelectedValue �� $ ActivityModel.Project����� *
QSpaceList+$ PropertyChanged=� . �� $ Vertical=�$	��5,0q�$	��200��.+�  $��Bottom=�   
IsExpanded .     ExpandDirection$
 Down=�#��[ ���� $��Select Keyword Dictionary������ $	��100������ *DictionaryList+$ TwoWay=�$ PropertyChanged=� . ���� .R��� ���� *DictionaryName+ d� 	IsChecked �� *	IsChecked+$ TwoWay=�$ PropertyChanged=� . �� $ Vertical=�$	��5,0q�$	��200��.+�  -     Name$ radExpander��$��Bottom=� .  $
 Down=�#��[ ���� -     ��Name$  expanderCaption��$��Select Activity Tool������ $	��100��$ Windows8 ���� *ActivityToolList+���� .R��� ���� *ToolDescription+ �� *	IsChecked+$ TwoWay=�$ PropertyChanged=� . �� $��2��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $	��5,0q�.+��� #��[ $��
Start Date��	  $	��200��#��[ 0
  *Telerik.Windows.Controls.RadDateTimePicker! 
  SelectedDate! �� *ActivityModel.StartDate+$ TwoWay=�$  ���� $	��5,0q�.+��� #��[ $��Due Date��	  $	��200��#��[ ! �� *ActivityModel.DueDate+$ TwoWay=�$  ���� $	��5,0q�.+��� #��[ $��Completion Date��	  $	��200��#��[ ! �� *ActivityModel.CompletionDate+$ TwoWay=�$  ���� $��3��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $	��5,0q�.+��� #��[ $��Actual Duration (Hours)���� " �� 
IsReadOnly" . # �� TextWrapping$
# Wrap=�$	��200��#��[ ���� *ActivityModel.ActualDuration+$ TwoWay=�$  ���� $	��5,0q�.+��� #��[ $��Original Estimate (Hours)���� # [ $
# Wrap=�$	��200��#��[ ���� *!ActivityModel.EstimatedDuration+$ TwoWay=�$  ���� $	��5,0q�.+��� #��[ $ ��Remaining Estimate (Hours)���� " . $	��200��#��[ ���� *!ActivityModel.RemainingDuration+$ TwoWay=�$  ���� $��5��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ 
Horizontal=�.+��� $ Vertical=�$	��5,0q�.+��� #��[ $��Assigned To��  $	��200��#��[
 $ 	FirstName��$ Id�� �� $  ActivityModel.AssignedToId�$ TwoWay=� . ���� *
UserList+$ PropertyChanged=� . �� $ Vertical=�$	��5,0q�.+��� #��[ $��Requested By��  $	��200��#��[
 $ 	FirstName��$ Id�� �� $  ActivityModel.ReportedById�$ TwoWay=� . ���� *
UserList+$ PropertyChanged=� . �� $ Vertical=�$	��5,0q�.+��� #��[ $��Priority��  $	��200��#��[
 $ PriorityName��$ Id�� �� $ ActivityModel.Priority�$ TwoWay=� . ���� *PriorityList+$ PropertyChanged=� . �� $��6��$ 
Horizontal=�$��20,8,0,0q�$
��Left=�.+��� $ Vertical=�$	��5,0q�.+��� #��[ $��Activity Status��  $	��200��#��[
 $ 
StatusName��$ Id�� �� $$ ActivityModel.ActivityStatusId�$ TwoWay=����� *ActivityStatusList+$ PropertyChanged=� . �� $ Vertical=�$	��5,0q�.+��� #��[ $��Sequence���� # [ $	��200��#��[ ���� *ActivityModel.Sequence+$ TwoWay=� . $  ���� $ Vertical=�$	��5,0q�.+��� #��[ $��Variation Factor (%)���� # [ $	��200��#��[ ���� *ActivityModel.VariationFactor+$ TwoWay=� . $  ���� $��7��$��20,8,0,0q�$ Vertical=�.+��� #��[ $��Requirements details���� $
��auto��$
# Wrap=�$ �� AcceptsReturn$ . #��[ $��50������ *ActivityModel.Description+$ TwoWay=��� #��[ $��Expected Output���� $
��auto��$
# Wrap=�$ . #��[ $��50������ *ActivityModel.ExpectedOutput+$ TwoWay=��� #��[ $��Actual Output���� $
��auto��$
# Wrap=�$ . #��[ $��50������ *ActivityModel.ActualOutput+$ TwoWay=��� $��8��$��20,8,0,0q�$ Vertical=�.+�  $��Upload attachment��$	��130��$
��Left=�#��[ ���� *UplaodCommand+�� -   % J� 	AllowDrop% . $��0,5,0,0q�$��60��$
��Auto=�$
��Auto=����� *Attachments+$ PropertyChanged=����� .R��� $ 
Horizontal=�.+��� #��[ ����   $��Remove��$��2q�#��[ ���� ���� *%#DataContext.RemoveAttachmentCommand+$ Window���� $��9��$��20,8,0,0q�.+�  $��5q�$��Right=�#��[ ���� *
ButtonText+���� *AddActivityCommand+ ��%E   (��       *,*SystemParameters.VerticalScrollBarWidthKey+)X�5Q�/  )Telerik.Windows.Controls.RadBusyIndicator  $��1��$ Windows8 &   IsIndeterminate& . '   IsBusy' �� *IsBusy+