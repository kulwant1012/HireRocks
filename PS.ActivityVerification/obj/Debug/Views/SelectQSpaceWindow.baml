   M S B A M L   `   `   `  ����  Activity Capture Tool6    0PS.ActivityVerification.Views.SelectQSpaceWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  
  	 5   	   
�������  � Title$  Select QSpace��5   	   $	��400��6   $	��400��6,    � WindowStyle$ 
ToolWindow=�68    � 
ResizeMode$ NoResize=�6Q    � DataContext 5   	   �� *SelectQSpaceModel+   Locator �� Source# [  .��5      � .+�5   
   � $��10q�6    � RowDefinitions 5	      �� 5
      $
��auto �6    �� 5      $��* �6    .+�5      �� $��0��6   $��1��6%   
���  ��$	��Top=�5      ��5   5   �� *ErrorMessage+5      �� 5      $��0��6   $��Select QSpace��6%   
�������$��15(�6L   $��SemiBold"�6Z   $��Bottom=�5      *  $Telerik.Windows.Controls.RadTileList  5      $��1��6"    �� SelectedValuePath$ Id��6U   +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Windows8 5   "   $
��Auto=�5   "    �� PanningMode$ HorizontalFirst=�5   "   	   TilePlaceHolderSide$	 97Q�5   "   ��5   /   �� *AOSQSpaceList+
 �� SelectedValue
 5   "   �� *SelectedQSpace+ �� Mode$ TwoWay=�y�5   "   �� *IsQSpaceListVisible+  BoolToVisibilityConverter �� 	Converter# [  �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      � .+�5      �� $��
Calisto MT)�6D   $��Center=�6\   $��Center=�5   (   $��13(�6E   $
��Wrap=�6S   ��5   (   �� *
QSpaceName+5   S   5      5       5"      �� 5#      $��1��6   
�������$��2q�65   y�5$      �� *IsQSpaceListVisible+ $  BoolToVisibilityReverseConverter# [ $ PropertyChanged=�._�5%      �� $!��No QSpace assigned to you !��6    �� TextAlignment$ Center=�6?   $��Center=�6V   $��15(�5&      5'      5(      /  )Telerik.Windows.Controls.RadBusyIndicator  5*   
      IsIndeterminate . $ Windows8 5+   :      IsBusy 5*   #   �� *IsBusy+$ PropertyChanged=� 5,   #   �� *SelectQSpaceModel+# [  5-      5.      