   M S B A M L   `   `   `  ����d  `GalaSoft.MvvmLight.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=eabbf6a5f5af5004iJclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.WPF45GalaSoft.MvvmLight.Command  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	    Activity management system>   8PS.ActivityManagementStudio.View.AddUpdateActivityWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ZcmdJclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.WPF45     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o	 kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b
 ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation  	 
    5   	   :sys&clr-namespace:System;assembly=mscorlib  	 
    5	   	   -   5        $��Window��5	   <     � WindowState$  	Maximized=�5   '    � Title 6	   �� *WindowTitle+ � DataContext 5   	   �� *ActivityViewModel+   Locator �� Source# [   � 	Resources 5        TextBoxErrorTemplate �� 
TargetType �� ElementName �� Path��%V  &	       �� 5   
   " ��67   .R�5      �� .+�5      �� $	��Top=�6   $��Right=�64   $��5,0,0,0q�5      
���  ����5      �� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      
���  ��$��1q�6+   ._�5      �� $��	MyAdorner��60   6D   5      5      5      5      .��5      �  5   
     TitleTextBlockStyle �� 
TargetType	 �� Property
 �� Value  TitleEditTextBoxStyle  RadUniformGridStyle8  2Telerik.Windows.Controls.Primitives.RadUniformGrid'  !Telerik.Windows.Controls.RadClock  RadClockStyle  Name  RadTimePickerStyle,  &Telerik.Windows.Controls.RadTimePicker+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadExpanderStyle*  $Telerik.Windows.Controls.RadExpander  RadButtonStyle(  "Telerik.Windows.Controls.RadButton 	 SelectionBoxTemplate 
 RadComboBoxStyle*  $Telerik.Windows.Controls.RadComboBox  RadDatePickerStyle,	  &Telerik.Windows.Controls.RadDatePicker��%t  &	       &	 �     &	 �    &	 <    7  &	     &	 W    &	 �    &		 �    &	
 d    &	 �    �� 5      " ��60   .�5      �� 	 � ��$
 12(�6-   �� 5      	 � ��$
 Segoe UI Regular)�6/   �� 5      	 � ��
 �#2e2e2e6/   5      �� 5!      " ��62   .�5"      �� 	 � ��$
 15(�6-   �� 5#      	 � ��$
 Segoe UI Regular)�6/   �� 5$      	 � ��

 �   �6/   �� 5%      	 � ��$	
 300��6*   �� 5&      	 � ��$
 25��6+   5'      �� 5)      "  60   .�5*      �� 	 �@ Rows$
 10��6)   �� 5+      	 �@ ChildrenFlow$
 
Horizontal=�61   �� 5,      	 � ��$
 Visible=�6M   5-      �� 5/      "  6   .�50      �� 	 �@ Header$
 Clock��6+   �� 52      	 � ��
 53      �� 54      .R�55        $ uniformGrid��65   8��  6J   56      58      59      �� 5;      "  6/   .�5<      �� 	 �@ Theme$
 Windows8 6?   5=      �� 5?      "  6-   .�5@      �� 	 �@ Theme$
 Windows8 6?   5A      �� 5C      "  6+   .�5D      �� 	 �@ Theme$
 Windows8 6?   5E      �� 5G      .R�5H      �� 
��� � �$
��Bold"�6K   ��6   �� *
QSpaceName+6K   5I      �� 5K      "  6-   .�5L      �� 	 �@ Theme$
 Windows8 6?   5M      �� 5O      " 	 6/   .�5P      �� 	 �@ Theme$
 Windows8 6?   5Q      5R      .+�5T   
   �� $
��Auto=�6      Theme$ Windows8 6:   .��5U      � $��Center=�6   $��Center=�60   .+�5V      �� 
���  ��$��Right=�6F   ��6   �� *	Message+6F   �� 5W      $��Bottom=�6   .+�5X      �� $��Add Activity��6    $��20(�64   $��Segoe UI Regular)�6B   
�������6`   � 5Y      -   5         �Name$ PreviewGrid��5Y      $��Center=�60    � RowDefinitions 5Z      �� 5[      $
��Auto �6,   �� 5\      $
��Auto �6,   .+�5_      �  J� Opacity$	 0.8Q�6   ���#ffffff$��43��6B    � ColumnDefinitions 5`      �� 5a   "   $
��Auto �63   �� 5b   "   $��* �63   5d      � 5e       5f      �� 5g   "   $
��Auto �60   �� 5h   "   $
��Auto �60   �� 5i   "   $
��Auto �60   �� 5j   "   $
��Auto �60   �� 5k   "   $
��Auto �60   �� 5l   "   $
��Auto �60   �� 5m   "   $
��Auto �60   �� 5n   "   $
��Auto �60   �� 5o   "   $
��Auto �60   �� 5p   "   $
��Auto �60   .+�5r      �� $��0��6)    �� Orientation$ 
Horizontal=�66   $��20,8,0,0q�6O   $
��Left=�6a   .+�5s   "   �� $ Vertical=�6-   $	��5,0q�6D   .+�5t   &   �� #��[ 60   $��Activity Name��6]   �� 5u   &    =� ErrorTemplate# [ 6y   #��[ 6�   $	��200��6�   ��6.   �� *ActivityModel.Name+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 6�   5v   #   �� 5w   "   $ Vertical=�6-   $	��5,0q�6D   $	��200��6Q   .+�5x   &   �� #��[ 60   $#��Capture Interval (In seconds)��6]   �� 5y   &   # [ 6~   #��[ 6�   $	��200��6�   ��6.   �� *ActivityModel.CaptureInterval+$ TwoWay=� �� TargetNullValue$  ��6�   5z   #   �� 5{   "   $ Vertical=�6-   $	��5,0q�6D   $	��200��6Q   .+�5|   &   �� #��[ 60   $��Capture Type��6]     5}   &   $	��200��6:    �� SelectedItem 5~   )   �� $' !ActivityModel.ActivityCaptureType���5   )   �� *ActivityCaptureTypeList+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . 5�   #   5�      �� 5�      $��1��6)   $ 
Horizontal=�66   $��20,8,0,0q�6O   $
��Left=�6a   .+�5�   "   �� $ Vertical=�6-   $	��5,0q�6D   .+�5�   &   �� #��[ 60   $��Select QSpace��6]     5�   &   $	��200��6:   #��[
 6F    �� DisplayMemberPath$ 
QSpaceName��5�       �� SelectedValuePath$ Id��5�       �� SelectedValue 5�      �� $ ActivityModel.Project���5�      �� *
QSpaceList+$ PropertyChanged=� . 5�   #   �� 5�   "   $ Vertical=�6-   $	��5,0q�6D   $	��200��6Q   .+�5�   &     $��Bottom=�6:      
IsExpanded .     ExpandDirection$
 Down=�6i   #��[ 6�   ��5�   *   �� 5�   .   $��Select Keyword Dictionary��68   ��5�   *   �� 5�   .   $	��100��6�   ��66   �� *DictionaryList+$ TwoWay=�$ PropertyChanged=� . ��5�   2   �� 5�   6   .R�5�   :   �� ��6C   �� *DictionaryName+ d� 	IsChecked 6f   �� *	IsChecked+$ TwoWay=�$ PropertyChanged=� . 5�   7   5�   /   5�   '   5�   #   �� 5�   "   $ Vertical=�6-   $	��5,0q�6D   $	��200��6Q   .+�5�   &     -   5          Name$ radExpander��5�   :   $��Bottom=�6O    .  $
 Down=�6~   #��[ 6�   ��5�   *   �� 5�   .   -   5          ��Name$  expanderCaption��5�   8   $��Select Activity Tool��6Q   ��5�   *   �� 5�   .   $	��100��6_   $ Windows8 6o   ��66   �� *ActivityToolList+��5�   2   �� 5�   6   .R�5�   :   �� ��6C   �� *ToolDescription+ 6g   �� *	IsChecked+$ TwoWay=�$ PropertyChanged=� . 5�   7   5�   /   5�   '   5�   #   5�      �� 5�      $��2��6)   $ 
Horizontal=�66   $��20,8,0,0q�6O   $
��Left=�6a   .+�5�   "   �� $	��5,0q�6-   .+�5�   &   �� #��[ 60   $��
Start Date��6]   	  5�   &   $	��200��6�   #��[ 6�   0
  *Telerik.Windows.Controls.RadDateTimePicker! 
  SelectedDate! 6<   �� *ActivityModel.StartDate+$ TwoWay=�$  ��6�   5�   #   �� 5�   "   $	��5,0q�6-   .+�5�   &   �� #��[ 60   $��Due Date��6]   	  5�   &   $	��200��6�   #��[ 6�   ! 6<   �� *ActivityModel.DueDate+$ TwoWay=�$  ��6�   5�   #   �� 5�   "   $	��5,0q�6-   .+�5�   &   �� #��[ 60   $��Completion Date��6]   	  5�   &   $	��200��6�   #��[ 6�   ! 6<   �� *ActivityModel.CompletionDate+$ TwoWay=�$  ��6�   5�   #   5�      �� 5�      $��3��6)   $ 
Horizontal=�66   $��20,8,0,0q�6O   $
��Left=�6a   .+�5�   "   �� $	��5,0q�6-   .+�5�   &   �� #��[ 60   $��Actual Duration (Hours)��6]   �� 5�   &   " �� 
IsReadOnly" . # �� TextWrapping$
# Wrap=�6�   $	��200��6�   #��[ 6�   ��6.   �� *ActivityModel.ActualDuration+$ TwoWay=�$  ��6�   5�   #   �� 5�   "   $	��5,0q�6-   .+�5�   &   �� #��[ 60   $��Original Estimate (Hours)��6]   �� 5�   &   # [ 6   $
# Wrap=�6�   $	��200��6�   #��[ 6�   ��6.   �� *!ActivityModel.EstimatedDuration+$ TwoWay=�$  ��6�   5�   #   �� 5�   "   $	��5,0q�6-   .+�5�   &   �� #��[ 60   $ ��Remaining Estimate (Hours)��6]   �� 5�   &   " . $	��200��6�   #��[ 6�   ��6.   �� *!ActivityModel.RemainingDuration+$ TwoWay=�$  ��6�   5�   #   5�      �� 5�      $��5��6)   $ 
Horizontal=�66   $��20,8,0,0q�6O   $
��Left=�6a   .+�5�   "   �� $ 
Horizontal=�6-   .+�5�   &   �� $ Vertical=�61   $	��5,0q�6H   .+�5�   *   �� #��[ 64   $��Assigned To��6a     5�   *   $	��200��6>   #��[
 6J   $ 	FirstName��5�   %   $ Id��5�   %    5�   %   �� $  ActivityModel.AssignedToId�$ TwoWay=� . ��5�   %   �� *
UserList+$ PropertyChanged=� . 5�   '   �� 5�   &   $ Vertical=�61   $	��5,0q�6H   .+�5�   *   �� #��[ 64   $��Requested By��6a     5�   *   $	��200��6>   #��[
 6J   $ 	FirstName��5�   %   $ Id��5�   %    5�   %   �� $  ActivityModel.ReportedById�$ TwoWay=� . ��5�   %   �� *
UserList+$ PropertyChanged=� . 5�   '   �� 5�   &   $ Vertical=�61   $	��5,0q�6H   .+�5�   *   �� #��[ 64   $��Priority��6a     5�   *   $	��200��6>   #��[
 6J   $ PriorityName��5�   &   $ Id��5�   &    5�   &   �� $ ActivityModel.Priority�$ TwoWay=� . ��5�   &   �� *PriorityList+$ PropertyChanged=� . 5�   '   5�   #   5�      �� 5�      $��6��6)   $ 
Horizontal=�66   $��20,8,0,0q�6O   $
��Left=�6a   .+�5  "   �� $ Vertical=�6-   $	��5,0q�6D   .+�5   &   �� #��[ 60   $��Activity Status��6]     5!  &   $	��200��6:   #��[
 6F   $ 
StatusName��5"  !   $ Id��5#  !    5$  !   �� $$ ActivityModel.ActivityStatusId�$ TwoWay=���5%  !   �� *ActivityStatusList+$ PropertyChanged=� . 5&  #   �� 5'  "   $ Vertical=�6-   $	��5,0q�6D   .+�5(  &   �� #��[ 60   $��Sequence��6]   �� 5)  &   # [ 6�   $	��200��6�   #��[ 6�   ��6.   �� *ActivityModel.Sequence+$ TwoWay=� . $  ��6�   5*  #   �� 5+  "   $ Vertical=�6-   $	��5,0q�6D   .+�5,  &   �� #��[ 60   $��Variation Factor (%)��6]   �� 5-  &   # [ 6�   $	��200��6�   #��[ 6�   ��6.   �� *ActivityModel.VariationFactor+$ TwoWay=� . $  ��6�   5.  #   5/     �� 5D     $��7��6)   $��20,8,0,0q�66   $ Vertical=�6H   .+�5E  "   �� #��[ 6,   $��Requirements details��6Y   �� 5F  "   $
��auto��6c   $
# Wrap=�6p   $ �� AcceptsReturn$ . #��[ 6�   $��50��6�   ��6+   �� *ActivityModel.Description+$ TwoWay=�6�   �� 5H  "   #��[ 6,   $��Expected Output��6Y   �� 5I  "   $
��auto��6f   $
# Wrap=�6s   $ . #��[ 6�   $��50��6�   ��6+   �� *ActivityModel.ExpectedOutput+$ TwoWay=�6�   �� 5K  "   #��[ 6,   $��Actual Output��6Y   �� 5L  "   $
��auto��6d   $
# Wrap=�6q   $ . #��[ 6�   $��50��6�   ��6+   �� *ActivityModel.ActualOutput+$ TwoWay=�6�   5M     �� 5O     $��8��6)   $��20,8,0,0q�66   $ Vertical=�6H   .+�5[  "     $��Upload attachment��64   $	��130��6r   $
��Left=�6~   #��[ 6�   ��6P   �� *UplaodCommand+6�   �� 5]  "   -   5        % J� 	AllowDrop% . $��0,5,0,0q�5]  T   $��60��6�   $
��Auto=�6�   $
��Auto=�6�   ��6e   �� *Attachments+$ PropertyChanged=���5^  &   �� 5_  *   .R�5`  .   �� $ 
Horizontal=�69   .+�5a  2   �� #��[ 6<   ��6i   �� 6}     5b  2   $��Remove��6D   $��2q�6s   #��[ 6�   ��6U   �� ��6~   �� *%#DataContext.RemoveAttachmentCommand+$ Window��6�   5c  /   5d  +   5f  #   5h     �� 5j     $��9��6)   $��20,8,0,0q�67   .+�5k  "     $��5q�64   $��Right=�6@   #��[ 5l  H   ��5k  \   �� *
ButtonText+��5l  !   �� *AddActivityCommand+6H   5m     5n     5o     5p     5q      5r     ��%X   (��       5s     *,*SystemParameters.VerticalScrollBarWidthKey+)X�6   5Q�6^   5t     5u     /  )Telerik.Windows.Controls.RadBusyIndicator  5w  
   $��1��6#   $ Windows8 6J   &   IsIndeterminate& . '   IsBusy' 60   �� *IsBusy+5y     5z     5{     