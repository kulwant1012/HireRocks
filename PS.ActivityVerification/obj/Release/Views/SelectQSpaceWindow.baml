   M S B A M L   `   `   `  ����   Activity Capture Tool6    0PS.ActivityVerification.Views.SelectQSpaceWindow   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R	 NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml  
  	 
�������  � Title$  Select QSpace��$	��400��$	��400�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=� � DataContext �� *SelectQSpaceModel+   Locator �� Source# [  .��� .+�� $��10q� � RowDefinitions �� $
��auto ��� $��* �.+��� $��0��$��1��
���  ��$	��Top=����� *ErrorMessage+�� $��0��$��Select QSpace��
�������$��15(�$��SemiBold"�$��Bottom=�*  $Telerik.Windows.Controls.RadTileList  $��1�� �� SelectedValuePath$ Id��+  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Windows8 $
��Auto=� �� PanningMode$ HorizontalFirst=�	   TilePlaceHolderSide$	 97Q����� *AOSQSpaceList+
 �� SelectedValue
 �� *SelectedQSpace+ �� Mode$ TwoWay=�y��� *IsQSpaceListVisible+  BoolToVisibilityConverter �� 	Converter# [  �� UpdateSourceTrigger$ PropertyChanged=����� .R�� .+��� $��
Calisto MT)�$��Center=�$��Center=�$��13(�$
��Wrap=����� *
QSpaceName+�� $��1��
�������$��2q�y��� *IsQSpaceListVisible+ $  BoolToVisibilityReverseConverter# [ $ PropertyChanged=�._��� $!��No QSpace assigned to you !�� �� TextAlignment$ Center=�$��Center=�$��15(�/  )Telerik.Windows.Controls.RadBusyIndicator     IsIndeterminate . $ Windows8    IsBusy �� *IsBusy+$ PropertyChanged=� �� *SelectQSpaceModel+# [  