   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Activity management system5   /PS.ActivityManagementStudio.View.ActivityWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\
 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation  	 
 5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml   	 
 5   	   6sys&clr-namespace:System;assembly=mscorlib   	 
 5   	     � Title$  
Activities��5   	    � WindowState$ 	Maximized=�6    � DataContext 5   	   �� *ActivityViewModel+   Locator �� Source# [  .��5      � -   5         �Name$
 Main��5       � 	Resources 5	   
     RadUniformGridStyle �� 
TargetType8  2Telerik.Windows.Controls.Primitives.RadUniformGrid �� Property �� Value'  !Telerik.Windows.Controls.RadClock  RadClockStyle	  Name  TitleTextBlockStyleHeading  TitleTextBlockStyleContent  ContentStyle  RadExpanderStyle*  $Telerik.Windows.Controls.RadExpander+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadButtonStyle(  "Telerik.Windows.Controls.RadButton  RadTimePickerStyle,  &Telerik.Windows.Controls.RadTimePicker��%�  &	       &	 �     7  &	 v    &	     &	 �    &	 �    &	 �    &	 J    �� 5
      "  60   .�5      ��  �@ Rows$ 10��6)   �� 5       �@ ChildrenFlow$ 
Horizontal=�61   �� 5       � ��$ Visible=�6M   5      �� 5      "  6   .�5      ��  �@ Header$ Clock��6+   �� 5       � �� 5      �� 5      .R�5        $	 uniformGrid��65   8��  6J   5      5      5      �� 5      " ��67   .�5      ��  � ��$ 13(�6-   �� 5       � ��$ Segoe UI Regular)�6/   �� 5       � �� �#2e2e2e6/   5       �� 5"      " ��67   .�5#      ��  � ��$ 15(�6-   �� 5$       � ��$ Segoe UI Regular)�6/   �� 5%       � ��
 ��  �6/   �� 5&       � ��$ 25��6+   5'      �� 5)      " ��6)   .�5*      ��  � ��$ 15(�6-   �� 5+       � ��$ Segoe UI Regular)�6/   �� 5,       � ��
 ��  �6/   �� 5-       � ��$ 25��6+   5.      �� 50      "  6-   .�51      ��  �@ Theme$ Windows8 6?   52      �� 54      "  6+   .�55      ��  �@ Theme$ Windows8 6?   56      �� 58      "  6/   .�59      ��  �@ Theme$ Windows8 6?   5:      5;      
 � RowDefinitions
 5=   
   �� 5>      $��80 �6   �� 5?      .+�5B   
   �� 
���  ��$��Center=�6>   $
��auto��6[   ��6   �� *	Message+6[     5C   
   $��0��6   $��5q�6)   $
��20,1q�65   $��Right=�6C   $��Bottom=�6_   $��Add Activity��6z   #��[ 5E   c   y�5D      �� *IsModificationButtonVisibe+ 	 BoolToVisibilityConverter �� 	Converter# [	 ��5E      �� *#!DataContext.OpenAddActivityWindow+ �� ElementName$
 Main��6c   *  $Telerik.Windows.Controls.RadTileView  5H   
   -   5          Name$ tileView��5H      $��1��60   $   PreservePositionWhenMaximized .    MinimizedColumnWidth$	 200 �5I   "      MinimizedRowHeight$	 200 �6=      IsAutoScrollingEnabled .    	RowHeight$	 200 �5J   "      ColumnWidth$	 200 �62   $��10q�6D   ��5H   =   �� *ActivityList+��5K      �� 5L      .R�5M      � .+�5N      ��  �� Orientation$ Vertical=�6%   .+�5O      �� ��6(   �� *Name+5P      5Q      5R         ContentTemplate 5T      �� 5U      .R�5V      5	  /Telerik.Windows.Controls.RadFluidContentControl	   	  ContentChangeMode$ 	Automatic=�65    	  TransitionDuration$ 0:0:1h�6S    	  LargeContent 5W      �� 5X      $
��Auto=�6+   $
��Auto=�6P      Theme$ Windows8 6s   .��5Y   "   � $��Center=�6'   $��Center=�6D   
 5Z   &   �� 5[   *   $
��Auto �68   �� 5\   *   $
��Auto �68   �� 5]   *   $
��Auto �68   �� 5^   *   $
��Auto �68   �� 5_   *   $
��Auto �68   �� 5`   *   $
��Auto �68   �� 5a   *   $
��Auto �68   �� 5b   *   $
��Auto �68   �� 5c   *   $
��Auto �68   �� 5d   *   $
��Auto �68   .+�5f   &   �� $��0��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5g   *   �� $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5h   .   �� #��[ 68   $��Activity Name��6l   �� 5i   .   #��[ 68   ��6^   �� *Name+5j   +   �� 5k   *   $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5l   .   �� #��[ 68   $#��Capture Interval (In seconds)��6l   �� 5m   .   #��[ 6f   ��68   �� *CaptureInterval+ �� Mode$ TwoWay=�6f   5n   +   5o   '   �� 5q   &   $��1��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5r   &   $��1��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5s   *   �� $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5t   .   �� #��[ 68   $��Select QSpace��6l   �� 5u   .   #��[ 6T   ��68   �� *
QSpaceName+6T   5v   +   �� 5w   *   $ Vertical=�65   $	��5,0q�6L   .+�5x   .     $��Bottom=�6B      
IsExpanded .    ExpandDirection$
 Down=�6p   #��[ 6�   ��5y   2   �� 5z   6   $!��Assigned Keyword Dictionary��6@   ��5|   2   �� 5}   6   $	��200��6�   ��6>   �� *KeywordDictionariesList+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . ��5~   :   �� 5   >   .R�5�   B   �� ��6L   �� *DictionaryName+5�   ?   5�   7   5�   /   5�   +   �� 5�   *   $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5�   .       Name$ radExpander��6B   $��Bottom=�6W    . $
 Down=�6�   #��[ 6�   ��5�   2   �� 5�   6     ��Name$  expanderCaption��6@   $��Assigned Activity Tool��6Y   ��5�   2   �� 5�   6   ��6>   �� *ActivityToolsList+$ PropertyChanged=���5�   :   �� 5�   >   .R�5�   B   �� ��6L   �� *ToolDescription+5�   ?   5�   7   5�   /   5�   +   5�   '   �� 5�   &   $��2��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5�   &   $��2��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5�   *   �� $	��5,0q�65   $	��200��6B   .+�5�   .   �� #��[ 68   $��
Start Date��6l   �� 5�   .   #��[ 68   ��6^   �� *	StartDate+5�   +   �� 5�   *   $	��5,0q�65   $	��200��6B   .+�5�   .   �� #��[ 68   $��Due Date��6l   �� 5�   .   #��[ 68   ��6^   �� *	DueDate+5�   +   �� 5�   *   $	��5,0q�65   $	��200��6B   .+�5�   .   �� #��[ 68   $��Completion Date��6l   �� 5�   .   #��[ 68   ��6^   �� *CompletionDate+5�   +   5�   '   �� 5�   &   $��3��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5�   &   $��3��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5�   *   �� $	��5,0q�65   $	��200��6B   .+�5�   .   �� #��[ 68   $��Actual Duration��6l   �� 5�   .   #��[ 68   ��6^   �� *ActualDuration+5�   +   �� 5�   *   $	��5,0q�65   $	��200��6B   .+�5�   .   �� #��[ 68   $��Original Estimate��6l   �� 5�   .   #��[ 68   ��6^   �� *EstimatedDuration+5�   +   �� 5�   *   $	��5,0q�65   $	��200��6B   .+�5�   .   �� #��[ 68   $��Remaining Estimate��6l   �� 5�   .   #��[ 68   ��6^   �� *RemainingDuration+5�   +   5�   '   �� 5�   &   $��4��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   5�   '   �� 5�   &   $��5��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5�   &   $��5��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5�   *   �� $ 
Horizontal=�65   .+�5�   .   �� $ Vertical=�69   $	��5,0q�6P   $	��200��6]   .+�5�   2   �� #��[ 6<   $��Assigned To��6p   �� 5�   2   #��[ 6<   ��6b   �� *
AssignedTo+5�   /   �� 5�   .   $ Vertical=�69   $	��5,0q�6P   $	��200��6]   .+�5�   2   �� #��[ 6<   $��Requested By��6p   �� 5�   2   #��[ 6<   ��6b   �� *
ReportedBy+5�   /   �� 5�   .   $ Vertical=�69   $	��5,0q�6P   $	��200��6]   .+�5�   2   �� #��[ 6<   $��Priority��6p   �� 5�   2   #��[ 6<   ��6b   �� *AssignedPriority+5�   /   5�   +   5�   '   �� 5�   &   $��6��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5�   &   $��6��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5  *   �� $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5  .   �� #��[ 68   $��Activity Status��6l   �� 5   .   #��[ 68   ��6^   �� *ActivityStatusName+5!  +   �� 5"  *   $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5#  .   �� #��[ 68   $��Sequence��6l   �� 5$  .   #��[ 68   ��6^   �� *
Sequence+5%  +   �� 5&  *   $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�5'  .   �� #��[ 68   $��Variation Factor��6l   �� 5(  .   #��[ 68   ��6^   �� *VariationFactor+5)  +   5*  '   �� 5-  &   $��7��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5.  &   $��7��61   $ 
Horizontal=�6>   $��20,8,0,0q�6W   $
��Left=�6i   .+�5/  *   �� $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�50  .   �� #��[ 68   $��Additional Time��6l   �� 51  .   #��[ 68   ��6^   �� *AdditionalTime+52  +   �� 53  *   $ Vertical=�65   $	��5,0q�6L   $	��200��6Y   .+�54  .   �� #��[ 68   $��Percent Completed��6l   �� 55  .   #��[ 68   ��6^   �� *PercentCompleted+56  +   57  '   �� 5E  &   $��8��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5F  &   $��8��61   $ Vertical=�6>   $��20,8,0,0q�6U   .+�5G  *   �� #��[ 64   $��Description��6h   �� 5H  *   $
��Wrap=�6Q   #��[ 6e   $��40��6�   ��64   �� *Description+6�   �� 5J  *   #��[ 64   $��Expected Output��6h   �� 5K  *   $
��Wrap=�6T   #��[ 6h   $��40��6�   ��64   �� *ExpectedOutput+6�   �� 5M  *   #��[ 64   $��Actual Output��6h   �� 5N  *   $
��Wrap=�6R   #��[ 6f   $��40��6�   ��64   �� *ActualOutput+6�   5O  '   �� 5Q  &   $��9��6-   $	��Top=�6:   $��1��6R   
�������6]   �� 5R  &   $��9��61   $��20,8,0,0q�6?   $ 
Horizontal=�6Q   $��Right=�6j   .+�5W  *     $��5q�6<   $��	0,0,20,20q�6H   $��Right=�6[   $��Delete Activity��6w   #��[ 5Y  0   ��5X  <   �� *#!DataContext.DeleteActivityCommand+$
 Main����6�   �� y�5Y  X   �� *(&DataContext.IsModificationButtonVisibe+$
 Main��# [	   5Z  *   $��5q�6<   $��	0,0,20,20q�6H   $��Right=�6[   $��Edit Activity��6w   #��[ 5\  0   ��5[  <   �� *$"DataContext.OpenEditActivityWindow+$
 Main����6�   �� y�5\  X   �� *(&DataContext.IsModificationButtonVisibe+$
 Main��# [	 5]  '   5^  #    5_  "   ��%X   (��       5`  1   *,*SystemParameters.VerticalScrollBarWidthKey+)X�6&   3Q�6r   5a  #   5b     5d     5e     5g     /
  )Telerik.Windows.Controls.RadBusyIndicator
  5i  
   $��1��6#   $ Windows8 6J   ! 
  IsIndeterminate! . " 
  IsBusy" 60   �� *IsBusy+5k     5l     5m     