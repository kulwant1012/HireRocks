   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem   Activity management system1   +PS.ActivityManagementStudio.View.UserWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x	 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f
 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
    � Title$  User Window�� � WindowState$ 	Maximized=� � DataContext ��  �� Path$ UserViewModel�   Locator �� Source# [  .��� -    �Name$
 Main�� � 	Resources   TitleTextBlockStyleHeading �� 
TargetType �� Property	 �� Value  TitleTextBlockStyleContent  RadButtonStyle+ 
 %Telerik.Windows.Controls.StyleManager- 
 'Telerik.Windows.Controls.ThemeConverter  RadExpanderStyle��%T  &	       &	 c     &	 �     &	     �� " ��.���  � ��$	 13(���  � ��$	 Segoe UI Regular)���  � ��	 �#2e2e2e�� " ��.���  � ��$	 15(���  � ��$	 Segoe UI Regular)���  � ��
	 ��  ���  � ��$	 25���� .���  �@ Theme$	 Windows8 �� .���  �@ Theme$	 Windows8 
 � RowDefinitions
 �� $��50 ��� .+��� 
���  ��$��Center=�$
��auto������ *	Message+( 
 "Telerik.Windows.Controls.RadButton  $��99��$
��20,1q�$��Right=�$��Center=�$��Add User��#��[ ���� * DataContext.OpenAddUserCommand+ �� ElementName$
 Main���� $
��auto��$��0��$��Bottom=�$��.5q�
����ح�*  $Telerik.Windows.Controls.RadTileView  -     Name$ tileViewUsers��$��1��$   PreservePositionWhenMaximized .    MinimizedColumnWidth$	 250 �   MinimizedRowHeight$	 250 �   IsAutoScrollingEnabled .    	RowHeight$	 250 �   ColumnWidth$	 250 �$��10q����� *
UserList+y��� *IsUserListVisible+  BoolToVisibilityConverter �� 	Converter# [  �� UpdateSourceTrigger$ PropertyChanged=����� .R�� .+���  �� Orientation$ Vertical=�.+��� ���� *	FirstName+   ContentTemplate �� .R�5 
 /Telerik.Windows.Controls.RadFluidContentControl     ContentChangeMode$ 	Automatic=�   TransitionDuration$ 0:0:1h�   LargeContent �� $
��Auto=�$
��Auto=�   Theme$ Windows8 .��� $��10q� � ColumnDefinitions �� �� .+�� $��0��
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��Online��y��� *
IsOnline+ �� Mode$ TwoWay=�# [ �� #��[ $��Offline��y��� *
IsOnline+$ TwoWay=� $  BoolToVisibilityReverseConverter# [ �� $��1��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��
Login Name���� #��[ ���� *	LoginId+$ TwoWay=��� $��2��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��
First Name���� #��[ ���� *	FirstName+$ TwoWay=��� $��3��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��	Last Name���� #��[ ���� *
LastName+$ TwoWay=��� $��4��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��Email���� #��[ ���� *Email+$ TwoWay=��� $��5��$ Vertical=�$
��20,4q�$	��350��.+�* 
 $Telerik.Windows.Controls.RadExpander  $��Bottom=�   
IsExpanded .     ExpandDirection$
 Down=�#��[ ���� $��Assigned security roles������ ���� *AssignedUserRoles+$ TwoWay=�$ PropertyChanged=� �� NotifyOnSourceUpdated . ���� .R��� ���� *Name+� $��1��
 �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��	Is Active���� #��[ ���� *
IsActive+$ TwoWay=��� $��1��$ Vertical=�$
��20,4q�$	��350��.+��� #��[ $��	Is Locked���� #��[ ���� *
IsLocked+$ TwoWay=��� $��2��$ Vertical=�$
��20,4q�$	��350��.+�  $��99��$
��20,1q�$��Right=�$��Bottom=�$��	Edit User��#��[ ���� *!DataContext.OpenEditUserCommand+$
 Main������ �� $ Vertical=�$��1��$��Center=�$��Center=�y��� *IsUserListVisible+# [ $ PropertyChanged=�.+��� $��No User created yet��$��Center=�$��45(�$��	ExtraBold"�
��������� $7��1Start by adding User, press Add User button above��$��Center=�$��30(�$��Normal"�
�������/ 
 )Telerik.Windows.Controls.RadBusyIndicator  $��1��$ Windows8     IsIndeterminate  . !   IsBusy! �� *IsBusy+