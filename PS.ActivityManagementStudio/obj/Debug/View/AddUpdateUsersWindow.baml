   M S B A M L   `   `   `  ����d  `GalaSoft.MvvmLight.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=eabbf6a5f5af5004iJclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.WPF45GalaSoft.MvvmLight.Command  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   U QActivity management system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:PS.ActivityManagementStudio.Helpers#PS.ActivityManagementStudio.Helpers 5	   	   ;   5PS.ActivityManagementStudio.View.AddUpdateUsersWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b	 ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x
 tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation   	 
   5   	   ^cmdJclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.WPF45   	 
   5   	   biPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity   	 
   5   	   Cw1clr-namespace:PS.ActivityManagementStudio.Helpers   	 
   5	   	     � WindowState$  	Maximized=�5   '    � DataContext 5   	   �� *UserViewModel+   Locator �� Source# [   � Title 5   	   �� *WindowTitle+ � 	Resources 5
        TextBoxErrorTemplate �� 
TargetType �� ElementName �� Path��%V  &	       �� 5   
   " ��67   .R�5      �� .+�5      �� $	��Top=�6   $��Right=�64   $��5,0,0,0q�5      
���  ����5      �� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      
���  ��$��1q�6+   ._�5      �� $��	MyAdorner��60   6D   5      5      5      5      .��5      �  5   
     TitleTextBlockStyle �� 
TargetType	 �� Property
 �� Value  TitleEditTextBoxStyle  RadButtonStyle+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadExpanderStyle��%$  &	       &	 �     &	 h    &	 �    �� 5      " ��60   .�5      �� 	 � ��$
 13(�6-   �� 5      	 � ��$
 Segoe UI Regular)�6/   �� 5      	 � ��
 �#2e2e2e6/   5      �� 5       " ��62   .�5!      �� 	 � ��$
 15(�6-   �� 5"      	 � ��$
 Segoe UI Regular)�6/   �� 5#      	 � ��

 �   �6/   �� 5$      	 � ��$
 25��6+   5%      �� 5'      .�5(      �� 	 �@ Theme$
 Windows8 6?   5)      �� 5+      .�5,      �� 	 �@ Theme$
 Windows8 6?   5-      5.       � RowDefinitions 50   
   �� 51      $��30 �6   �� 52      $
��auto �6   .+�55   
   �� $��0��6   
���  ��$��Center=�6K   $��Center=�6h   ��6!   �� *	Message+6h   �� 56   
   $��1��6      Theme$ Windows8 6$   $
��Auto=�6J   $
��Auto=�6o   $��Center=�6�   .��57      � $��Center=�6   $��Center=�6.    58      �� 59      $
��Auto �6$   �� 5:      $
��Auto �6$   �� 5;      $
��Auto �6$   �� 5<      $
��Auto �6$   �� 5=      $
��Auto �6$   �� 5>      $
��Auto �6$   �� 5?      $
��Auto �6$   .+�5B      �� $��0��6    �� Orientation$ Vertical=�6*   $
��20,4q�6A   $	��350��6O   .+�5C      �� #��[ 6    $��
Login Name��6M   �� 5D       �� TextWrapping$
 Wrap=�6   #��[ 6}    =� ErrorTemplate# [ 5E      ��5D   2   �� *UserModel.LoginId+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5E      5G      �� 5I      $��1��6   $ Vertical=�6*   $
��20,4q�6A   $	��350��6O   .+�5J      �� #��[ 6    $��
First Name��6M   �� 5K      #��[ 6k   # [ 5L      ��5K      �� *UserModel.FirstName+$ TwoWay=� . 5L      5M      �� 5O      $��2��6   $ Vertical=�6*   $
��20,4q�6B   $	��350��6P   .+�5P      �� #��[ 6    $��	Last Name��6M   �� 5Q      #��[ 6j   # [ 5R      ��5Q      �� *UserModel.LastName+$ TwoWay=� . 5R      5S      �� 5U      $��3��6   $ Vertical=�6*   $
��20,4q�6A   $	��350��6O   .+�5V      �� #��[ 6    $��Email��6M   �� 5W      #��[ 6g   # [ 5X      ��5W      �� *UserModel.Email+$ TwoWay=� . 5X      5Y      �� 5[      $��4��6   $ Vertical=�6*   $
��20,4q�6A   $	��350��6O   .+�5\      �� #��[ 6    $��Password��6M   G� 5]       G� PasswordChar$ *��6"   8  2PS.ActivityManagementStudio.Helpers.PasswordHelper   Attach . $��25��5^   �   # [ 5_         Password 5^      �� *Text+$ plain��$ TwoWay=� . 5_      �� 5`      -   5         ��Name$ plain��5`       $y�Hidden=�6|   # [ 6�   ��6/   �� *UserModel.Password+$ TwoWay=� . 6�   5a      �� 5b      $��5��6   $ Vertical=�6'   $
��20,4q�6>   $	��350��6L   .+�5c      *  $Telerik.Windows.Controls.RadExpander  $��Bottom=�6*      
IsExpanded .     ExpandDirection$
 Down=�6Y   #��[ 6p   ��5d      �� 5e      $��Assign security roles��6(   ��5g      �� 5h      ��6'   �� *Roles+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . ��5i   "   �� 5j   &   .R�5k   *   �� ��63   �� *Name+ d� 	IsChecked 6L   �� *	IsChecked+$ TwoWay=�$ PropertyChanged=� . 5l   '   5n      5p      5q      (  "Telerik.Windows.Controls.RadButton  5s      $��6��6$   $��99��61   $
��20,1q�6<   $��Right=�6J   #��[ 5t   <   ��5s   f   �� *
ButtonText+��5t      �� *AddUserCommand+6<   5u      5w      /  )Telerik.Windows.Controls.RadBusyIndicator  5x   
   $��1��6#   $ Windows8 6J      IsIndeterminate .    IsBusy 60   �� *IsBusy+5z      5{      5|      