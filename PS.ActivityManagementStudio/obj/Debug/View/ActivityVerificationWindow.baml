   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�\clr-namespace:Telerik.Windows.Controls.TileView;assembly=Telerik.Windows.Controls.Navigation!Telerik.Windows.Controls.TileView 5	   	   U QActivity management system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:PS.ActivityManagementStudio.ViewModel%PS.ActivityManagementStudio.ViewModel 5
   	   A   ;PS.ActivityManagementStudio.View.ActivityVerificationWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W	 SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R
 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation 	 
  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  	 
  5   	   6sys&clr-namespace:System;assembly=mscorlib  	 
  5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  	 
  5   	   ztelerikNavigation\clr-namespace:Telerik.Windows.Controls.TileView;assembly=Telerik.Windows.Controls.Navigation  	 
  5	   	   Gwpfdude3clr-namespace:PS.ActivityManagementStudio.ViewModel  	 
  5
   	   -   5          �Name$  Window��5   [    � Title$ ActivityCaptures��5   	    � WindowState$ 	Maximized=�6"    � DataContext 5   	   �� *ActivityVerificationModel+   Locator �� Source# [   � 	Resources 5        TtileViewItemHeaderStyleRed �� 
TargetType:  4Telerik.Windows.Controls.TileView.TileViewItemHeader �� Property �� Value	 �� 
StartPoint
 �� EndPoint � Color � Offset   TtileViewItemHeaderStyleGray��%�  &	       &	 �     �� 5   
   "  64   .�5      ��  � �� 5      �� 5      $		 0,0&�6*   $	
 1,1&�6;   .��5      � $ Yellow��6'   $
 0.75Q�66   � 5      $ White��6'   $	 1.0Q�65   5      5      5      �� 5   
   "  65   .�5      ��  � �� 5      �� 5      $		 0,0&�6*   $	
 1,1&�6;   .��5      � $ Yellow��6'   $
 0.75Q�66   � 5      $ White��6'   $	 1.0Q�65   5      5      5       5!      .��5$      � -   5         �Name$
 Main��5$       � RowDefinitions 5%   
   �� 5&      $��30 �6   �� 5'      .+�5)   
   )  #Telerik.Windows.Controls.RadToolBar  -   5          Name$ 
radToolBar��5)      $��0��61   $��Stretch=�6>   $��
-1 -2 -1 0q�6\   $	��510��6p   
�������.@�5*      �� $��Allowed captures��6    d� 	IsChecked 62   �� *ViewAllowedCaptures+2  ,Telerik.Windows.Controls.RadToolBarSeparator  5+      �� 5,      $$��All keyboard and filtered text��6    6@   �� *ViewFilteredText+  5-      �� 5.      $��Compress Repeat Keywords��6    6:   �� *CompressRepeatKeywords+  5/      �� 50      $��Create video��6<   ��6   �� *CreateVideoCommand+6<     51      �� 52      $��Refresh screen��6D   ��6   �� *RefreshCapturesListCommand+6D     53      �� 54      $��Change capture validity��6E   ��6   �� *ShowValidityCheckBoxCommand+y�6g   �� *IsRoleManager+  BoolToVisibilityConverter �� 	Converter# [   55      �� 56      $��Accept captures��6C   ��6   �� *ShowAcceptCheckBoxCommand+y�6]   �� *IsRoleManager+# [ 57      � 58   
   $��5q�6   $��1��6    � ColumnDefinitions 59      �� 5:      $	��25* �6#   �� 5;      $
��163* �6#   �� 5<      $
��562* �6#   .+�5?      � $��0��6   $��2��6#    5@      �� 5A      $	��50* �6$   �� 5B      $	��50* �6$   .+�5D      �� $��0��6   
����ح�$��1.5,1.5,1.5,0q�6>   ._�5E      �� $
��Auto=�6#   +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Windows8 6F   .��5F      ��  �� Orientation$ Vertical=�6%   $��4q�6<   .+�5G      �� $��Users��6(   $��
Calisto MT)�65   $��Center=�6M   $��Center=�6h   $��13(�6�   $
��Wrap=�6�   *  $Telerik.Windows.Controls.RadTileView  5H      -   5          Name$ tileViewUserList��5H   2   $
��Auto=�5I   "      IsSelectionEnabled .    MaximizeMode$
 Zero=�5J   "      
MaxColumns$ 2��66      	RowHeight$	 100 �6E      ColumnWidth$	 150 �6U    �� SelectedValuePath$ Id��5K   "   ��5H   L   �� *
UserList+ �� SelectedValue 5K   9   ��  �� Path$ SelectedUser� �� Mode$ TwoWay=���5L   "   �� 5M   &   .R�5N   *   � .+�5O   .   �� $��
Calisto MT)�6S   $��Center=�6k   $��Center=�6�   $��13(�6�   $
��Wrap=�6�   ��68   �� *	FirstName+6�   5P   +   5Q   '      ContentTemplate 5S   "   �� 5T   &   .R�5U   *   � .+�5V   .   �� $��
Calisto MT)�6S   $��Center=�6k   $��Center=�6�   $��13(�6�   $
��Wrap=�6�   ��68   �� *	FirstName+6�   5W   +   5X   '   5Z      5[      5\      5]      �� 5_      $��1��6   
����ح�$��1.5,1.5,1.5,0q�6>   ._�5`      �� $
��Auto=�6#   $ Windows8 6F   .��5a      �� $ Vertical=�6%   $��4q�6<   .+�5b      �� $��
Activities��6(   $��
Calisto MT)�6:   $��Center=�6R   $��Center=�6m   $��13(�6�   $
��Wrap=�6�     5c      -   5        $ tileViewActivityList��5c   2    . $	��Top=�5d   "   $
 Zero=�6:   $ 2��6N   $	 100 �6]   $	 150 �6m   $ Id��5e   "   ��5c   P   �� *ActivityList+ 5e   9   �� $ SelectedActivity�$ TwoWay=���5f   "   �� 5g   &   .R�5h   *   � .+�5i   .   �� $��
Calisto MT)�6V   $��Center=�6n   $��Center=�6�   $��13(�6�   $
��Wrap=�6�   ��68   �� *ActivityName+6�   5j   +   5k   '    5m   "   �� 5n   &   .R�5o   *   � .+�5p   .   �� $��
Calisto MT)�6V   $��Center=�6n   $��Center=�6�   $��13(�6�   $
��Wrap=�6�   ��68   �� *ActivityType+6�   5q   +   5r   '   5t      5u      5v      5w      5x      � 5z      $��2��6   .+�5{      �  5|      �� 5}      $	��116 �6(   �� 5~      $��* �6(   �� 5      $
��auto �6(   .+�5�      �� $��0��6   
����ح�$��0,1.5,1.5,1.5q�6B   $ Windows8 6b   ._�5�      )  #Telerik.Windows.Controls.RadTimeBar  -   5           Name$  
radTimeBar��5�   -   $��5,0,0,0q�6A   $��0��6R   $	��100��6_   !   IsSnapToIntervalEnabled! . y�5�      �� *ViewFilteredText+ $  BoolToVisibilityReverseConverter# [ " �� UpdateSourceTrigger$" PropertyChanged=�*  $Telerik.Windows.Controls.TimeBarBase#   PeriodStart# 5�      �� *PeriodStart+$ TwoWay=�$   	PeriodEnd$ 5�      �� *	PeriodEnd+$ TwoWay=�%   VisiblePeriodStart% 5�      �� *VisiblePeriodStart+$ TwoWay=�&   VisiblePeriodEnd& 5�      �� *VisiblePeriodEnd+$ TwoWay=�'   SelectionStart' 5�      �� *SelectedStartDate+$ TwoWay=�(   SelectionEnd( 5�      �� *SelectedEndDate+$ TwoWay=�)   MinSelectionRange) 5�      �� *MinSelectionRange+$ TwoWay=�*   	Intervals* 5�      6	  0Telerik.Windows.Controls.TimeBar.QuarterInterval	  5�   "   4
  .Telerik.Windows.Controls.TimeBar.MonthInterval
  5�   "   3  -Telerik.Windows.Controls.TimeBar.WeekInterval  5�   "   2  ,Telerik.Windows.Controls.TimeBar.DayInterval  5�   "   3  -Telerik.Windows.Controls.TimeBar.HourInterval  5�   "   5�      5�        5�      -   5        $ tileViewActivityCaptures��5�   *   $��1��6L   $ Id��6Y   $+   PreservePositionWhenMaximized+ . ,   MinimizedColumnWidth$	, 190 �5�   "   -   MinimizedRowHeight$	- 190 �6=   .   IsAutoScrollingEnabled. . $	 190 �5�   "   $	 190 �62    5�   *   �� *SelectedActivityCapture+��6\   �� *ActivityCaptureFilteredList+y�5�   "   �� *ViewFilteredText+# [ $" PropertyChanged=�/   HeaderStyle/ 5�      �� 5�      "  6$   .�5�   "   ��  � �� 6?   �� *CaptureColor+5�      ��5�      �� 5�      .R�5�   "   � .+�5�   &   �� $ Vertical=�61   .+�5�   *   �� 0 ��Name$0 Id��64   $y�	Collapsed=�6T   ��6@   �� *Id+6T   �� 5�   *   $��Is Valid��6d    63   �� *VerificationStatus.IsValid+y�6w   �� * DataContext.IsChangingValidity+1 �� ElementName$
1 Main��# [ ��6�   �� **(DataContext.UpdateStatusOfCaptureCommand+$
1 Main����6B  �� $1 Id��$
 Text��� 5�   *   $��Is Accepted��6g    63   �� *VerificationStatus.IsAccepted+y�6}   �� *" DataContext.IsChangingAcceptance+$
1 Main��# [ ��6�   �� **(DataContext.UpdateStatusOfCaptureCommand+$
1 Main����6I  �� $1 Id��$
 Text�5�   '   5�   #   5�       5�      �� 5�      .R�5�   "   5  /Telerik.Windows.Controls.RadFluidContentControl  -   5        2   ContentChangeMode$2 	Automatic=�5�   A   3   
TransitionD  >Telerik.Windows.Controls.TransitionControl.TransitionConverter$3 PerspectiveRotation 6_   ��5�   &   �� 5�   *   ��60   �� *ThumbnailImage+4   LargeContent4 5�   &   � 5�   *   
���   � 5�   .   �� 5�   2   $	��65* �6@   �� 5�   2   $	��35* �6@   .+�5�   .   � $��0��63    5�   2   �� 5�   6   .+�5�   2   �� $
��Auto=�6?   $
��Auto=�6d   $ Windows8 6�   .��5�   6   �� $��0��6<   $
��None=�6i   $��10q�6x   $	��Top=�6�   ��6L   �� *	FullImage+6�    5�   6   ��%X   (��       5�   E   *,*SystemParameters.VerticalScrollBarWidthKey+)X�6:   3Q�6�   5�   7   5�   3   5�   /   � 5�   .   $��1��63    5�   2   �� 5�   6   �� 5�   6   .+�5�   2   �� $��0��69   
�������$��.5q�6a   $��10q�6v   $	��130��6�   ._�5�   6   � .+�5�   :   �� $ Vertical=�6E   $��5q�6\   .+�5�   >   �� $ 
Horizontal=�6I   $��4q�6b   .+�5�   B   �� $��Mouse clicks : ��6L   
�������$
��Bold"�6z   $��Center=�6�   �� 5�   B   $
��Wrap=�6c   
�������$
��Auto=�6�   ��6L   �� *Mouse+6�   5�   ?   �� 5�   >   $ 
Horizontal=�6I   $��4q�6b   .+�5�   B   �� $��Keyboard input : ��6L   
�������$
��Bold"�6|   $��Center=�6�   $��Center=�6�   �� 5�   B   $ Vertical=�6M   $	��400��6d   .+�5�   F   �� $
��Wrap=�6j   
�������$
��Auto=�6�   ��6P   �� *
Keyboard+6�   5�   C   5�   ?   �� 5�   >   $ 
Horizontal=�6I   $��4q�6b   .+�5�   B   �� $��Date of capture : ��6L   
�������$
��Bold"�6}   $��Center=�6�   $��Center=�6�   �� 5�   B   $
��Wrap=�6m   
���������6L   �� *CaptureDateTime+6�   5�   ?   �� 5�   >   $ 
Horizontal=�6I   $��4q�6b   .+�5�   B   (  "Telerik.Windows.Controls.RadButton  $��Delete Activity��6T   ��6n   �� *#!DataContext.DeleteActivityCommand+$1 Window����6�   �� *Id+6�   5�   ?   5�   ;   5�   7   5�   3   �� 5�   2   $��1��69   
�������$��.5q�6a   $��10q�6v   $	��130��6�   ._�5�   6   �  5�   :   �� 5�   >   $��25 �6L   �� 5�   >   $��* �6L   .+�5�   :   �� $��0��6D   $��Matched Keywords��6Q   $��Center=�6i   
�������$��2q�6�   �� 5�   :   $��1��6C   ��6P   �� *MatchedKeywordList+5 �� View5 5�   >   �� 5�   B   6 �� AllowsColumnReorder6 . .P�5�   F   �� $��Keyword��6�   7 �� DisplayMemberBinding7 6U   �� $ CapturedData�6�   �� 5�   F   $��
Begin Time��6�   7 6U   �� $ 	BeginTime�6�   �� 5�   F   $��End Time��6�   7 6U   �� $ EndTime�6�   5�   C   5�   ;   5�   7   5�   3   5�   /   �� 5�   .   $��1��69   $ 
Horizontal=�6F   5�   /   5�   +   5�   #   5      5     � 5     $��1��6   y�6(   �� *ViewFilteredText+# [ $" PropertyChanged=�.+�5     �� $
��Auto=�6'   .��5     �� $ Vertical=�6)   $��10q�6@   .+�5  "   �� $ 
Horizontal=�6-   .+�5  &   �� $��All Keyboard capture: ��60   $
��Bold"�6N   
���   �6`   �� 5	  &   
�������$
��Wrap=�6c   ��60   �� *AllKeyboardText+6c   5
  #   �� 5  "   $ 
Horizontal=�6-   .+�5  &   �� $��All matched keywords: ��60   $
��Bold"�6N   
���   �6`   �� 5  &   
���������60   �� *AllFilteredText+6Q   5  #   �� 5  "   $ 
Horizontal=�6-   .+�5  &   �� $'��!Compressed All matched keywords: ��60   $
��Bold"�6Y   
���   �6k   �� 5  &   
���������60   �� *CompressedFilteredText+6X   5  #   �� 5  "   $ 
Horizontal=�6-   .+�5  &   �� $��Total Time Consumed: ��60   $
��Bold"�6M   
���   �6_   �� 5  &   
���������60   �� *TotalTimeConsumed+6S   5  #   �� 5  "   $ 
Horizontal=�6-   .+�5  &   �� $(��"Total keywords created (matched): ��60   $
��Bold"�6Z   
���   �6l   �� 5  &   
���������60   �� *TotalKeywordsCreated+6V   5  #   �� 5  "   $ 
Horizontal=�6-   .+�5  &   �� $$��Total Creation Time Consumed: ��60   $
��Bold"�6V   
���   �6h   �� 5  &   
���������60   �� *TotalCreationTimeConsumed+6[   5  #   5     5      5!       5#     $��10,0,0,0q�6(   $��5q�6:   $
��Left=�6F   $��Update captures��6a   $��2��6{   $ Windows8 5&     y�5$  (   �� *IsUpdateButtonVisible+# [ ��5%  (   �� *!ChangeVerificationStatusCommand+5&     5'     5(     5)     /  )Telerik.Windows.Controls.RadBusyIndicator  5*  
   $ Windows8 6=   $��1��6c   8   IsIndeterminate8 . 9   IsBusy9 6#   �� *IsBusy+5,     5-     5.     