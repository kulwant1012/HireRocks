   M S B A M L   `   `   `  ����P  LActivity Capture Tool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:PS.ActivityVerification.HelpersPS.ActivityVerification.Helpers  5   	   /    )PS.ActivityVerification.Views.LoginWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  
  	 5   	   ;w-clr-namespace:PS.ActivityVerification.Helpers  
  	 5   	     � WindowStartupLocation$  CenterScreen=�5   	   
������� � Title$ Login��5   	   $	��250��6   $	��400��6$    � 
ResizeMode$ NoResize=�60    � DataContext 5   	   �� *
LoginModel+   Locator �� Source# [  .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��1��6!   $	��Top=�6O   
���  ����61   �� *ErrorMessage+6g   �� 5   
   $��0��6   $��1��6!   $*��$Please enter your login and password��61   $��Center=�6]   $
��Bold"�5      $��20q�6&   � 5   
   $��1��6   $��1��6    5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $��20 �6#   �� 5      $��80 �6#   �� 5      .+�5       �� $��0��6   $��1��6!   $��Login:��61   �� 5!      $��0��62   $��2��6?   $	��250��6O   $��30��6[   
�������$��2q�5"   /   ��5!      �� *
User.Login+5"   /   �� 5#      $��1��6   $��1��6!   $��	Password:��61   �� 5$      $��1��6   $��2��6&   .+�5%      G�  G� PasswordChar$ *��6   $	��250��6/   $��30��6;   4   .PS.ActivityVerification.Helpers.PasswordHelper   Attach . 
�������$��2q�5&   V   	   Password	 5'      �� *Text+
 �� ElementName$
 plain�� �� Mode$ TwoWay=��� 5(      -   5         ��Name$ plain��5(   7   $��2(�6    J� Opacity$	 0.1Q�6)   ��6F   �� *User.Password+$ TwoWay=�5)      5*      (  "Telerik.Windows.Controls.RadButton  5,   
   -   5        $��Login��5,      $��Login��6)   $��2��69   $��1��6F   $��30��6V   $	��100��6b   +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Windows8 5-   =   ��6   �� *LoginCommand+6=   /  )Telerik.Windows.Controls.RadBusyIndicator  5/   
   $��0��6#   $��3��60   $ Windows8 6[      IsIndeterminate .    IsBusy 6A   �� *IsBusy+51      52      53      