   M S B A M L   `   `   `  ����   Activity management system<    6PS.ActivityManagementStudio.View.AddUpdateQSpaceWindow   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\	 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
   	   � WindowState$  	Maximized=� � Title �� *WindowTitle+ � DataContext �� *QSpaceViewModel+   Locator �� Source# [   � 	Resources   TextBoxErrorTemplate �� 
TargetType �� ElementName �� Path��%�   &	       �� " ��.R��� .+��� $	��Top=�$��Right=�$��5,0,0,0q�
���  ������ $ 	MyAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent��� 
���  ��$��1q�._��� $��	MyAdorner��.���    TitleTextBlockStyle �� 
TargetType	 �� Property
 �� Value  TitleEditTextBoxStyle  RadButtonStyle(  "Telerik.Windows.Controls.RadButton+  %Telerik.Windows.Controls.StyleManager-  'Telerik.Windows.Controls.ThemeConverter  RadComboboxStyle,  &Telerik.Windows.Controls.RadDatePicker��%u  &	       &	 c     &	 �     &	     �� " ��.��� 	 � ��$
 13(��� 	 � ��$
 Segoe UI Regular)��� 	 � ��
 �#2e2e2e�� " ��.��� 	 � ��$
 15(��� 	 � ��$
 Segoe UI Regular)��� 	 � ��

 �   ��� 	 � ��$	
 300���� 	 � ��$
 25���� "  .��� 	 �@ Theme$
 Windows8 �� "  .��� 	 �@ Theme$
 Windows8  � RowDefinitions �� $��40 ��� .+��� $��0��
���  ��$��Right=����� *	Message+� $��1��$	��420��$	��500��.+��� $��Center=�$��20q�.+�� $��Center=� �� $
��Auto ��� $
��Auto �.+��� $��0��$��QSpace Information��$��15(�$��	20,20,0,0q����#2e2e2e$��Segoe UI)�$��Normal"�� $��1�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��70 �.+��� $��0�� �� Orientation$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� #��[ $��QSpace Name����  =� ErrorTemplate# [ #��[ ���� *QSpaceModel.QSpaceName+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . �� $��1��$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� #��[ $��QSpace Type���� # [ #��[ ���� *QSpaceModel.QSpaceType+$ TwoWay=� . �� $��2��$ Vertical=�$��	20,10,0,0q�$
��Left=�.+��� $��Description��#��[ �� #��[ $	��400��$��60�� �� TextWrapping$
 Wrap=����� *QSpaceModel.Description+$ TwoWay=��� $��3��$ 
Horizontal=�$��	20,10,0,0q�.+��� $ Vertical=�$	��200��.+��� $��
Start Date��#��[   # [ #��[ 0  *Telerik.Windows.Controls.RadDateTimePicker   SelectedDate �� *QSpaceModel.StartDate+$ TwoWay=� . �� $ Vertical=�$��20,0,0,0q�$	��200��.+��� $��Due Date��#��[   # [ #��[  �� *QSpaceModel.DueDate+$ TwoWay=� .   $��5q�$��	0,0,20,20q�$��Right=�#��[ $��Bottom=�$��4������ *
ButtonText+���� *AddUpdateQSpaceCommand+/  )Telerik.Windows.Controls.RadBusyIndicator  $��1��   Theme$ Windows8    IsIndeterminate .    IsBusy �� *IsBusy+