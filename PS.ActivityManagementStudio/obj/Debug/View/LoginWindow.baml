   M S B A M L   `   `   `  ����U  QActivity management system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:PS.ActivityManagementStudio.Helpers#PS.ActivityManagementStudio.Helpers  5   	   2    ,PS.ActivityManagementStudio.View.LoginWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\	 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
   	 5   	   ?w1clr-namespace:PS.ActivityManagementStudio.Helpers 
   	 5   	     � WindowStartupLocation$  CenterScreen=�5   	   
������� � WindowState$ 	Maximized=�6F    � Title$ Login��5   	    � DataContext 5   	   �� *
LoginModel+   Locator �� Source# [   � 	Resources 5	        TextBoxErrorTemplate �� 
TargetType �� ElementName �� Path��%V  &	       �� 5
   
   " ��67   .R�5      �� .+�5      �� $	��Top=�6   $��Right=�64   $��5,0,0,0q�5      
���  ����5      �� $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�5      �� 5      
���  ��$��1q�6+   ._�5      �� $��	MyAdorner��60   6D   5      5      5      5      .��5      �  5   
     Windows8Theme+  %Telerik.Windows.Controls.StyleManager	 �� Property
 �� Value-  'Telerik.Windows.Controls.ThemeConverter  TextBoxStyle �� 
TargetType  TextBlockStyle��%�  &	       &	 J     &	     �� 5      .�5      �� 	 �@ Theme$
 Windows8 6?   5      �� 5      " ��6)   .�5      �� 	 � ��$
 15(�6-   �� 5       	 � ��$
 Segoe UI Regular)�6/   �� 5!      	 � ��

 �   �6/   �� 5"      	 � ��$
 22��6+   5#      �� 5%      " ��6+   .�5&      �� 	 � ��$
 13(�6-   �� 5'      	 � ��$
 Segoe UI Regular)�6/   �� 5(      	 � ��
 �#2e2e2e6/   �� 5)      	 � ��$
 Center=�66   5*      5+      .+�5-   
   � $	��200��6   $	��350��6   $��Center=�6(   $��Center=�6C    � RowDefinitions 5.      �� 5/      �� 50      �� 51      .+�54      �� $��0��6   $��1��6%   $	��Top=�6N   
���  ����65   �� *	Message+6f   �� 55      $��0��6   $��1��6%   $*��$Please enter your login and password��65   $��Center=�6a   $
��Bold"�6|   $��20q�6�   � 57      $��1��6    58      �� 59      �� 5:       � ColumnDefinitions 5=      �� 5>      $��20 �6'   �� 5?      $��80 �6'   �� 5@      .+�5C      �� $��0��6   $��1��6%   $��Login:��65   �� 5D      $��0��66   $��2��6C   $	��250��6S   $��30��6_   
�������$��2q�6�   ��6   �� *
User.Login+6�   �� 5G      $��1��6   $��1��6%   $��	Password:��65   �� 5H      $��1��6   $��2��6*   .+�5I      G�  G� PasswordChar$ *��6"   $	��250��63   $��30��6?   8   2PS.ActivityManagementStudio.Helpers.PasswordHelper   Attach . 
�������$��2q�5J   V      Password 5K      �� *Text+$ plain�� �� Mode$ TwoWay=��� 5N      -   5         ��Name$ plain��5N   ;   $��2(�6     J� Opacity$	 0.1Q�6-   ��6J   �� *User.Password+$ TwoWay=�5O      5P      (  "Telerik.Windows.Controls.RadButton  5R      -   5        $��Login��5R       $��Login��6-   $��2��6=   $��1��6J   $��30��6Z   $	��100��6f   #��[ 6�   ��6r   �� *LoginCommand+6�   5S      /  )Telerik.Windows.Controls.RadBusyIndicator  5U   
      Theme$ Windows8 6=      IsIndeterminate .    IsBusy 6#   �� *IsBusy+5W      5X      5Y      