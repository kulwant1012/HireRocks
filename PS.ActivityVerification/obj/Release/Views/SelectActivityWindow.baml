   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7eHclr-namespace:Telerik.Windows.Controls;assembly=Telerik.Windows.ControlsTelerik.Windows.Controls k gGalaSoft.MvvmLight.Extras.WPF45, Version=4.1.26.28981, Culture=neutral, PublicKeyToken=0e27b6f8be9b2ef7pQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45GalaSoft.MvvmLight.Command O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  Activity Capture Tool8   2PS.ActivityVerification.Views.SelectActivityWindow   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q	 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation      	 \
 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation 
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
    ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity 
    ]controlsHclr-namespace:Telerik.Windows.Controls;assembly=Telerik.Windows.Controls 
    fcommandsQclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF45 
    6sys&clr-namespace:System;assembly=mscorlib 
      � Title$  My Activities��$	��700��$	��600�� � Icon$ /Images/PSLogo.png�� � 
ResizeMode$ NoResize=� � DataContext �� *NotifyIconModel+   Locator �� Source# [  .   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ Closing��.   (System.Windows.Interactivity.TriggerBase   Actions. /  )GalaSoft.MvvmLight.Command.EventToCommand     PassEventArgsToCommand . 	   Command	 �� *CloseCommand+.���  �� *SelectActivityModel+# [  
 �� UpdateSourceTrigger$
 PropertyChanged=�.+��� $��/Images/Background.jpg��$��UniformToFill=��  � RowDefinitions �� $
��auto ��� $��40 ��� $��* �.+��� 
�������$��0������ *ErrorMessage+y��� *IsErrorReturned+  BoolToVisibilityConverter �� 	Converter# [ $
 PropertyChanged=��� $��1�� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��My Current Activities��
�������$��4q�$��Center=��� $��Change QSpace��
������ 
�������$��4q�
������ ���� *SwitchQSpaceCommand+�� $��Settings��
������ 
�������$��4q�
������ �� $��2��$��Disabled=�$��Center=�.���� y��� *IsActivityListVisible+# [ $
 PropertyChanged=�._��� $ Vertical=�.+�*  $Telerik.Windows.Controls.RadTileList   �� SelectedValuePath$ ActivityUserId��}�.     CanUserSelect .  �� PanningMode$ VerticalFirst=�   TilePlaceHolderSide$	 220Q����� *ActivityList+ �� SelectedValue �� *SelectedActivityId+ �� Mode$ TwoWay=����� .R�� ���� *IsActivityViewed+  BoolToColorConverter# [ $
 PropertyChanged=�.+�� $��5q����#D7D7D7$	��220��$	��320�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� �� .+��� $ 
Horizontal=�$��0��.+��� $
��#505��$��20(�$��5q�
���   ��� $��20��$��50��
���k���$��Learn��
���k���y��� *LearnButtonVisibility+# [ $
 PropertyChanged=��� $��1��$��EA Code:��$��5q�$
��Left=�
����  ��� $��1��$��#12456325879��$��5q�$��Right=�
���   ��� $��1��$ Vertical=�.+��� $��16(�
��� � ����� *ActivityName+�� 
���   �$��9(����� *ActivityToolNames+(  "Telerik.Windows.Controls.RadButton  $��2��$��24��$��90��$��Right=�$��Finish������ *)'SelectActivityModel.SubmitOutputCommand+# [  ���� �� $��3��$ 
Horizontal=�.+��  � Minimum$ 0Q� � Maximum$	 100Q�$	��180��$��5�� � Value �� *ActivityPercentDone+�� $��30(�
��� � �$��10,0,0,0q�$��70�� �� TextAlignment$ Right=����� *ActivityPercentDone+�� $��%��$��Center=�
���   ��� 
�������$��40��$��40�� �� CornerRadius$ 5��$
��10,0q�._��� $ Vertical=�.+��� $��Priority��
��������� $��20(�$��Center=�$
��Bold"�
���  ������ *
Sequence+�� $��4��$ 5��$��50��$��Center=����� *BottomPanelcolor+._��  �� �� .+��� $��0��$��18(�$
��Left=�$��3q�$��Center=�
��� � ����� *ActivityCurrentStatus+�� $��1��$ Vertical=�$��Right=�$��2q�.+��� $ 
Horizontal=�$��Right=�.+��� $��$��$��12(�
���   ��� $��15.71��$��12(�
���   ��� $��Unverified Income��$��9(�
���   � � 	Resources ��%E   (��       *,*SystemParameters.VerticalScrollBarWidthKey+)X�5Q��� $��2��y��� *IsActivityListVisible+ $  BoolToVisibilityReverseConverter# [ $
 PropertyChanged=�._��� $M��GNo Activity created for selected QSpace
 try selecting different QSpace��$ Center=�$��Center=�$��15(�$
��Wrap=�
�������