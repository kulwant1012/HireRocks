   M S B A M L   `   `   `  ����E  APS.Tracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PS.Tracker.ViewModelPS.Tracker.ViewModel  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null3   -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon   TaskbarIcon     
IconSource    ToolTipText � ContextMenu m� CommandParameter m� Command  SimpleButton �� 
TargetType(  "Telerik.Windows.Controls.RadButton �� BasedOn �� Property �� Value  SimpleButtonFocusVisual  NormalBrush  NormalBorderBrush	 �� 
TargetType
 �Name ��Name �� Padding �� Triggers P� Property P� Value  DefaultedBorderBrush �� 
TargetName  PressedBorderBrush  DisabledBorderBrush  DisabledForegroundBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    Ctelerik1http://schemas.telerik.com/2008/xaml/presentation    5      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )tb http://www.hardcodet.net/taskbar  5      ,local"clr-namespace:PS.Tracker.ViewModel  5      %�  &	        &	 q       5      $+  %pack://application:,,,/Images/Red.ico��6)   $ 
PS Tracker��6\    5   
   �� 5	      .@�5
      m� $  ��6�   ��6   �� *SuspendButtonText+{�6@   �� *IsSuspendButtonEnabled+ 6m   �� *SuspendResumeTaskCommand+6�   �� 5      m� 5      $
��Exit��6    6)   �� *ExitApplicationCommand+5      5      �� 5      "  6!    6I   Z� .�5   
   ��  � ��$ 30��6#   �� 5   
    � ��$ 30��6"   �� 5   
    �@�FocusVisualStyle# �  6-   �� 5   
    � ��# �  6'   �� 5   
    � ��# �  6(   �� 5   
    � �� 5      �� 5      "	 ��6"   .R�5      � $

 Grid��6   .+�5      �� $ Border��6!   #��z��61   #��z��6[   #��z��6�   # z��6�   �� 5      #��z��6+   #��z��6n   #��z��6�   ��. 6�   5       5!      P� 5"       �@J�IsKeyboardFocused . . �5#      �� # �  6<   $ Border��6k    � ��5$      P� 5%       � �� . . �5&      �� # �  6<   $ Border��6i    � ��5'      P� 5(       � {� . 67   P� 5)       � {� .  . �5*      �� # �  6<   $ Border��6j    � ���� 5+      # �  6;    � ��5,      5.      50      51      52      