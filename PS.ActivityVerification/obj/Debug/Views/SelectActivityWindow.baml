   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7eHclr-namespace:Telerik.Windows.Controls;assembly=Telerik.Windows.ControlsTelerik.Windows.Controls 5   	   k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7pQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45GalaSoft.MvvmLight.Command 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	    Activity Capture Tool8   2PS.ActivityVerification.Views.SelectActivityWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q	 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation      	 \
 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation 
   5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
    5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 
    5   	   ]controlsHclr-namespace:Telerik.Windows.Controls;assembly=Telerik.Windows.Controls 
    5   	   fcommandsQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45 
    5   	   6sys&clr-namespace:System;assembly=mscorlib 
    5	   	     � Title$  My Activities��5   	   $	��700��6   $	��600��6,    � Icon$ /Images/PSLogo.png��5	   <    � 
ResizeMode$ NoResize=�5
   	    � DataContext 5   	   �� *NotifyIconModel+   Locator �� Source# [  .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5      /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand . 	   Command	 6&   �� *CloseCommand+6G   5      .��5      �  6   �� *SelectActivityModel+# [  
 �� UpdateSourceTrigger$
 PropertyChanged=�.+�5   
   �� $��/Images/Background.jpg��6   $��UniformToFill=�60   � 5   
    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��40 �6    �� 5      $��* �6    .+�5      �� 
�������$��0��60   ��6=   �� *ErrorMessage+y�6[   �� *IsErrorReturned+  BoolToVisibilityConverter �� 	Converter# [ $
 PropertyChanged=��� 5      $��1��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   .+�5      �� $��My Current Activities��6   
�������$��4q�6Q   $��Center=�6\   �� 5      $��Change QSpace��6   
������ 
�������$��4q�6a   
������ ��6�   �� *SwitchQSpaceCommand+�� 5       $��Settings��6   
������ 
�������$��4q�6\   
������ 6g   5!      �� 5#      $��2��6   $��Disabled=�6(   $��Center=�6Q   .��5$      �� y�6   �� *IsActivityListVisible+# [ $
 PropertyChanged=�._�5%      �� $ Vertical=�6!   .+�5&      *  $Telerik.Windows.Controls.RadTileList   �� SelectedValuePath$ ActivityUserId��6S   }�.     CanUserSelect .  �� PanningMode$ VerticalFirst=�5'   t      TilePlaceHolderSide$	 220Q�5(   &   ��5&   .   �� *ActivityList+ �� SelectedValue 5'   &   �� *SelectedActivityId+ �� Mode$ TwoWay=���5)      �� 5*   "   .R�5+   &   � ��6+   �� *IsActivityViewed+  BoolToColorConverter# [ $
 PropertyChanged=�.+�5,   *   � $��5q�6/   ���#D7D7D7$	��220��6O   $	��320��6\    5-   .   �� 5.   2   $
��Auto �6@   �� 5/   2   $
��Auto �6@   �� 50   2   $
��Auto �6@   �� 51   2   $
��Auto �6@   �� 52   2   $
��Auto �6@   .+�55   .   � $��0��63    � ColumnDefinitions 56   2   �� 57   6   �� 58   6   .+�5;   2   �� $ 
Horizontal=�6=   $��0��6V   .+�5<   6   �� $
��#505��6@   $��20(�6L   $��5q�6Z   
���   �6e   �� 5=   6   $��20��6=   $��50��6I   
���k���$��Learn��6l   
���k���y�6�   �� *LearnButtonVisibility+# [ $
 PropertyChanged=�5>   3   �� 5@   2   $��1��6<   $��EA Code:��6L   $��5q�6\   $
��Left=�6g   
����  �6�   �� 5A   2   $��1��6<   $��#12456325879��6L   $��5q�6`   $��Right=�6k   
���   �6�   5B   /   �� 5D   .   $��1��69   $ Vertical=�6F   .+�5E   2   �� $��16(�6Z   
��� � ���6<   �� *ActivityName+6h   �� 5F   2   
���   �$��9(�6r   ��6<   �� *ActivityToolNames+6r   5G   /   (  "Telerik.Windows.Controls.RadButton  5H   .   $��2��6@   $��24��6M   $��90��6Y   $��Right=�6d   $��Finish��6�   ��6�   �� *)'SelectActivityModel.SubmitOutputCommand+# [  ��6�   �� �� 5I   .   $��3��69   $ 
Horizontal=�6F   .+�5J   2   �  � Minimum$ 0Q�6>    � Maximum$	 100Q�6J   $	��180��6~   $��5��6�    � Value 6X   �� *ActivityPercentDone+5L   3   �� 5N   2   $��30(�6a   
��� � �$��10,0,0,0q�6�   $��70��6�    �� TextAlignment$ Right=�6�   ��6<   �� *ActivityPercentDone+6�   �� 5O   2   $��%��6<   $��Center=�6E   
���   �6`   �� 5P   2   
�������$��40��6O   $��40��6[    �� CornerRadius$ 5��6f   $
��10,0q�6w   ._�5Q   6   �� $ Vertical=�6A   .+�5R   :   �� $��Priority��6D   
�������6T   �� 5S   :   $��20(�6^   $��Center=�6l   $
��Bold"�6�   
���  ����6D   �� *
Sequence+6�   5T   7   5U   3   5V   /   �� 5X   .   $��4��65   $ 5��6j   $��50��6{   $��Center=�6�   ��6B   �� *BottomPanelcolor+._�5Y   2   �  5Z   6   �� 5[   :   �� 5\   :   .+�5^   6   �� $��0��6@   $��18(�6P   $
��Left=�6�   $��3q�6�   $��Center=�6�   
��� � ���6^   �� *ActivityCurrentStatus+6�   �� 5�   6   $��1��6A   $ Vertical=�6Q   $��Right=�6h   $��2q�6�   .+�5�   :   �� $ 
Horizontal=�6E   $��Right=�6^   .+�5�   >   �� $��$��6H   $��12(�6Q   
���   �6_   �� 5�   >   $��15.71��6H   $��12(�6U   
���   �6c   5�   ;   �� 5�   :   $��Unverified Income��6D   $��9(�6]   
���   �6j   5�   7   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�       � 	Resources 5�      ��%X   (��       5�   !   *,*SystemParameters.VerticalScrollBarWidthKey+)X�6   5Q�6b   5�      5�      �� 5�      $��2��6   y�6"   �� *IsActivityListVisible+ $  BoolToVisibilityReverseConverter# [ $
 PropertyChanged=�._�5�      �� $M��GNo Activity created for selected QSpace
 try selecting different QSpace��6   $ Center=�6o   $��Center=�6�   $��15(�6�   $
��Wrap=�6�   
�������6�   5�      5�      5�      5�      