   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Activity management system1   +PS.ActivityManagementStudio.View.UserWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x	 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
  5   	     � Title$  User Window��5   	    � WindowState$ 	Maximized=�6    � DataContext 5      �� 5   
    �� Path$ UserViewModel�6      Locator �� Source# [  6'   .��5
      � -   5         �Name$
 Main��5
       � 	Resources 5   
     TitleTextBlockStyleHeading �� 
TargetType �� Property	 �� Value  TitleTextBlockStyleContent  RadButtonStyle+ 
 %Telerik.Windows.Controls.StyleManager- 
 'Telerik.Windows.Controls.ThemeConverter  RadExpanderStyle��%$  &	       &	 �     &	 h    &	 �    �� 5      " ��67   .�5      ��  � ��$	 13(�6-   �� 5       � ��$	 Segoe UI Regular)�6/   �� 5       � ��	 �#2e2e2e6/   5      �� 5      " ��67   .�5      ��  � ��$	 15(�6-   �� 5       � ��$	 Segoe UI Regular)�6/   �� 5       � ��
	 ��  �6/   �� 5       � ��$	 25��6+   5      �� 5      .�5      ��  �@ Theme$	 Windows8 6?   5      �� 5      .�5      ��  �@ Theme$	 Windows8 6?   5      5       
 � RowDefinitions
 5"   
   �� 5#      $��50 �6   �� 5$      .+�5&   
   �� 
���  ��$��Center=�6>   $
��auto��6[   ��6   �� *	Message+6[   ( 
 "Telerik.Windows.Controls.RadButton  5'   
   $��99��6   $
��20,1q�6'   $��Right=�65   $��Center=�6Q   $��Add User��6l   #��[ 5(   q   ��6-   �� * DataContext.OpenAddUserCommand+ �� ElementName$
 Main��6q   �� 5*   
   $
��auto��6   $��0��6   $��Bottom=�6+   $��.5q�6F   
����ح�6[   *  $Telerik.Windows.Controls.RadTileView  5+   
   -   5          Name$ tileViewUsers��5+      $��1��65   $   PreservePositionWhenMaximized .    MinimizedColumnWidth$	 250 �5,   "      MinimizedRowHeight$	 250 �6=      IsAutoScrollingEnabled .    	RowHeight$	 250 �5.   "      ColumnWidth$	 250 �62   $��10q�6D   ��5+   B   �� *
UserList+y�5-   "   �� *IsUserListVisible+  BoolToVisibilityConverter �� 	Converter# [  �� UpdateSourceTrigger$ PropertyChanged=���5/      �� 50      .R�51      � .+�52      ��  �� Orientation$ Vertical=�6%   .+�53      �� ��6(   �� *	FirstName+54      55      56         ContentTemplate 58      �� 59      .R�5:      5 
 /Telerik.Windows.Controls.RadFluidContentControl     ContentChangeMode$ 	Automatic=�65      TransitionDuration$ 0:0:1h�6S      LargeContent 5;      �� 5<      $
��Auto=�6+   $
��Auto=�6P      Theme$ Windows8 6s   .��5=   "   � $��10q�6'    � ColumnDefinitions 5>   &   �� 5?   *   �� 5@   *   .+�5B   &   � $��0��6+   
 5C   *   �� 5D   .   $
��Auto �6<   �� 5E   .   $
��Auto �6<   �� 5F   .   $
��Auto �6<   �� 5G   .   $
��Auto �6<   �� 5H   .   $
��Auto �6<   �� 5I   .   $
��Auto �6<   �� 5J   .   $
��Auto �6<   .+�5M   *   �� $��0��65   $ Vertical=�6B   $
��20,4q�6Y   $	��350��6g   .+�5N   .   �� #��[ 68   $��Online��6l   y�6z   �� *
IsOnline+ �� Mode$ TwoWay=�# [ �� 5O   .   #��[ 68   $��Offline��6l   y�6{   �� *
IsOnline+$ TwoWay=� $  BoolToVisibilityReverseConverter# [ 5P   +   �� 5R   *   $��1��65   $ Vertical=�6B   $
��20,4q�6Y   $	��350��6g   .+�5S   .   �� #��[ 68   $��
Login Name��6m   �� 5T   .   #��[ 6]   ��68   �� *	LoginId+$ TwoWay=�6]   5U   +   �� 5W   *   $��2��65   $ Vertical=�6B   $
��20,4q�6Y   $	��350��6g   .+�5X   .   �� #��[ 68   $��
First Name��6l   �� 5Y   .   #��[ 6_   ��68   �� *	FirstName+$ TwoWay=�6_   5Z   +   �� 5\   *   $��3��65   $ Vertical=�6B   $
��20,4q�6Z   $	��350��6h   .+�5]   .   �� #��[ 68   $��	Last Name��6l   �� 5^   .   #��[ 6^   ��68   �� *
LastName+$ TwoWay=�6^   5_   +   �� 5a   *   $��4��65   $ Vertical=�6B   $
��20,4q�6Y   $	��350��6g   .+�5b   .   �� #��[ 68   $��Email��6l   �� 5c   .   #��[ 6[   ��68   �� *Email+$ TwoWay=�6[   5d   +   �� 5f   )   $��5��64   $ Vertical=�6A   $
��20,4q�6X   $	��350��6f   .+�5g   .   * 
 $Telerik.Windows.Controls.RadExpander  $��Bottom=�6B      
IsExpanded .     ExpandDirection$
 Down=�6q   #��[ 6�   ��5h   2   �� 5i   6   $��Assigned security roles��6@   ��5k   2   �� 5l   6   ��6>   �� *AssignedUserRoles+$ TwoWay=�$ PropertyChanged=� �� NotifyOnSourceUpdated . ��5m   :   �� 5n   >   .R�5o   B   �� ��6L   �� *Name+5p   ?   5r   7   5t   /   5u   +   5w   '   � 5x   &   $��1��6+   
 5y   *   �� 5z   .   $
��Auto �6<   �� 5{   .   $
��Auto �6<   �� 5|   .   $��* �6<   .+�5~   *   �� $��0��65   $ Vertical=�6B   $
��20,4q�6Y   $	��350��6g   .+�5   .   �� #��[ 68   $��	Is Active��6l   �� 5�   .   #��[ 6^   ��68   �� *
IsActive+$ TwoWay=�6^   5�   +   �� 5�   *   $��1��65   $ Vertical=�6B   $
��20,4q�6Z   $	��350��6h   .+�5�   .   �� #��[ 68   $��	Is Locked��6l   �� 5�   .   #��[ 6^   ��68   �� *
IsLocked+$ TwoWay=�6^   5�   +   �� 5�   *   $��2��65   $ Vertical=�6B   $
��20,4q�6Y   $	��350��6g   .+�5�   .     $��99��6@   $
��20,1q�6K   $��Right=�6Y   $��Bottom=�6u   $��	Edit User��6�   #��[ 5�   �   ��6-   �� *!DataContext.OpenEditUserCommand+$
 Main����6s   �� 6�   5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�   
   $ Vertical=�6   $��1��6,   $��Center=�69   $��Center=�6T   y�5�      �� *IsUserListVisible+# [ $ PropertyChanged=�.+�5�      �� $��No User created yet��6   $��Center=�62   $��45(�6O   $��	ExtraBold"�6]   
�������6t   �� 5�      $7��1Start by adding User, press Add User button above��6   $��Center=�6P   $��30(�6m   $��Normal"�6{   
�������6�   5�      / 
 )Telerik.Windows.Controls.RadBusyIndicator  5�   
   $��1��6=   $ Windows8 6J       IsIndeterminate  . !   IsBusy! 6#   �� *IsBusy+5�      5�      5�      