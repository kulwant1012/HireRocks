   M S B A M L   `   `   `  ����   Activity Capture Tool6    0PS.ActivityVerification.Views.SubmitOutputWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f	 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
   � Title$  SubmitOutputWindow��$	��600��$	��500��.��� -    �Name$
 Main�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��2q�$��1�� �� Orientation$ Vertical=�.+��� $��What is done:��2 	 ,Telerik.Windows.Controls.RadWatermarkTextBox  $	��200������ *
WhatIsDone+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� $��2��$��2q�$ Vertical=�.+�( 	 "Telerik.Windows.Controls.RadButton  $��Center=�$��Upload attachment��$	��130������ *UplaodCommand+�� -    J� 	AllowDrop . $��0,5,0,0q�$��60��$
��Auto=�$
��Auto=����� *Attachments+���� .R��� $ 
Horizontal=�.+��� ���� *Name+  $��Remove��$��2q����� ���� *%#DataContext.RemoveAttachmentCommand+ �� ElementName$
 Main���� $��2q�$��3��$ Vertical=�.+��� $��TFS or Sharepoint link:��  ���� *	TfsPath+$ PropertyChanged=�$ TwoWay=��� $��2q�$��4��$ 
Horizontal=�.+��� $��Mail To:��  $	��200������ *	EmailTo+$ PropertyChanged=�$ TwoWay=��� $��2q�$��5��$ 
Horizontal=�.+��� $��Mail CC:��  $	��200������ *	EmailCC+$ PropertyChanged=�$ TwoWay=�  $��2q�$��6��$��Center=�$��
Send Email������ *SendEmailCommand+