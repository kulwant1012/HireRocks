   M S B A M L   `   `   `  ����  Activity management system<    6PS.ActivityManagementStudio.View.AddUpdateQSpaceWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\	 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
   	 5   	     � WindowState$  	Maximized=�5   '    � Title 6	   �� *WindowTitle+ � DataContext 5   	   �� *QSpaceViewModel+   Locator �� Source# [   � 	Resources 5        TextBoxErrorTemplate �� 
TargetType �� ElementName �� Path��%V  &	       �� 5   
   " ��67   .R�5	      �� .+�5
      �� $	��Top=�6   $��Right=�64   $��5,0,0,0q�5      
���  ����5      �� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      
���  ��$��1q�6+   ._�5      �� $��	MyAdorner��60   6D   5      5      5      5      .��5      �  5   
     TitleTextBlockStyle �� 
TargetType	 �� Property
 �� Value  TitleEditTextBoxStyle  RadButtonStyle(  "Telerik.Windows.Controls.RadButton+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadComboboxStyle,  &Telerik.Windows.Controls.RadDatePicker��%]  &	       &	 �     &	 �    &	 �    �� 5      " ��60   .�5      �� 	 � ��$
 13(�6-   �� 5      	 � ��$
 Segoe UI Regular)�6/   �� 5      	 � ��
 �#2e2e2e6/   5      �� 5      " ��62   .�5      �� 	 � ��$
 15(�6-   �� 5      	 � ��$
 Segoe UI Regular)�6/   �� 5       	 � ��

 �   �6/   �� 5!      	 � ��$	
 300��6*   �� 5"      	 � ��$
 25��6+   5#      �� 5%      "  6+   .�5&      �� 	 �@ Theme$
 Windows8 6?   5'      �� 5)      "  6-   .�5*      �� 	 �@ Theme$
 Windows8 6?   5+      5,       � RowDefinitions 5.   
   �� 5/      $��40 �6   �� 50      .+�53   
   �� $��0��6   
���  ��$��Right=�6K   ��6!   �� *	Message+6K   � 54   
   $��1��6   $	��420��6   $	��500��6)   .+�55      �� $��Center=�6   $��20q�64   .+�56      � $��Center=�6    57      �� 58      $
��Auto �6(   �� 59      $
��Auto �6(   .+�5<      �� $��0��6    $��QSpace Information��6-   $��15(�6G   $��	20,20,0,0q�6U   ���#2e2e2e$��Segoe UI)�5=   "   $��Normal"�68   � 5?      $��1��6    5@      �� 5A      $
��Auto �6,   �� 5B      $
��Auto �6,   �� 5C      $
��Auto �6,   �� 5D      $
��Auto �6,   �� 5E      $��70 �6,   .+�5G      �� $��0��6%    �� Orientation$ Vertical=�62   $��	20,10,0,0q�6I   $
��Left=�6\   .+�5H      �� #��[ 6(   $��QSpace Name��6U   �� 5I       =� ErrorTemplate# [ 6u   #��[ 6�   ��6&   �� *QSpaceModel.QSpaceName+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 6�   5J      �� 5L      $��1��6%   $ Vertical=�62   $��	20,10,0,0q�6I   $
��Left=�6\   .+�5M      �� #��[ 6(   $��QSpace Type��6U   �� 5N      # [ 6u   #��[ 6�   ��6&   �� *QSpaceModel.QSpaceType+$ TwoWay=� . 6�   5O      �� 5Q      $��2��6%   $ Vertical=�62   $��	20,10,0,0q�6I   $
��Left=�6\   .+�5R      �� $��Description��6(   #��[ 6;   �� 5S      #��[ 6\   $	��400��6�   $��60��6�    �� TextWrapping$
 Wrap=�6�   ��6&   �� *QSpaceModel.Description+$ TwoWay=�6�   5T      �� 5V      $��3��6%   $ 
Horizontal=�62   $��	20,10,0,0q�6K   .+�5W      �� $ Vertical=�6)   $	��200��6@   .+�5X   "   �� $��
Start Date��6,   #��[ 6>     5Y   "   # [ 6�   #��[ 6�   0  *Telerik.Windows.Controls.RadDateTimePicker   SelectedDate 68   �� *QSpaceModel.StartDate+$ TwoWay=� . 6�   5Z      �� 5\      $ Vertical=�6)   $��20,0,0,0q�6@   $	��200��6R   .+�5]   "   �� $��Due Date��6,   #��[ 6<     5^   "   # [ 6�   #��[ 6�    68   �� *QSpaceModel.DueDate+$ TwoWay=� . 6�   5_      5`        5b      $��5q�6,   $��	0,0,20,20q�68   $��Right=�6K   #��[ 5c   D   $��Bottom=�5d      $��4��64   ��5b   g   �� *
ButtonText+��5c      �� *AddUpdateQSpaceCommand+5d   4   5e      5f      5g      5h      /  )Telerik.Windows.Controls.RadBusyIndicator  5j   
   $��1��6#      Theme$ Windows8 6J      IsIndeterminate .    IsBusy 60   �� *IsBusy+5l      5m      5n      