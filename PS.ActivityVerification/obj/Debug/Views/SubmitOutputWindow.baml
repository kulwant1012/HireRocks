   M S B A M L   `   `   `  ����  Activity Capture Tool6    0PS.ActivityVerification.Views.SubmitOutputWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.RibbonView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.Docking, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f	 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	     � Title$  SubmitOutputWindow��5   	   $	��600��6$   $	��500��61   .��5      � -   5         �Name$
 Main��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��2q�6   $��1��6     �� Orientation$ Vertical=�6-   .+�5      �� $��What is done:��6   2 	 ,Telerik.Windows.Controls.RadWatermarkTextBox  5      $	��200��6*   ��5   *   �� *
WhatIsDone+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�5      �� 5   
   $��2��6   $��2q�6"   $ Vertical=�6-   .+�5      ( 	 "Telerik.Windows.Controls.RadButton  $��Center=�6    $��Upload attachment��6=   $	��130��5   B   ��6    �� *UplaodCommand+6B   �� 5      -   5         J� 	AllowDrop . $��0,5,0,0q�5   @   $��60��5      $
��Auto=�6#   $
��Auto=�5      ��5   Q   �� *Attachments+��5      �� 5       .R�5!      �� $ 
Horizontal=�6%   .+�5"      �� ��6(   �� *Name+  5#      $��Remove��60   $��2q�6_   ��6A   �� ��5$   0   �� *%#DataContext.RemoveAttachmentCommand+ �� ElementName$
 Main��5%      5&      5(      5)      �� 5+   
   $��2q�6   $��3��6    $ Vertical=�6-   .+�5,      �� $��TFS or Sharepoint link:��6     5-      ��6*   �� *	TfsPath+$ PropertyChanged=�$ TwoWay=�5.      �� 50   
   $��2q�6   $��4��6    $ 
Horizontal=�6-   .+�51      �� $��Mail To:��6     52      $	��200��6*   ��53   *   �� *	EmailTo+$ PropertyChanged=�$ TwoWay=�54      �� 56   
   $��2q�6   $��5��6    $ 
Horizontal=�6-   .+�57      �� $��Mail CC:��6     58      $	��200��6*   ��59   *   �� *	EmailCC+$ PropertyChanged=�$ TwoWay=�5:        5<   
   $��2q�6   $��6��6L   $��Center=�6Y   $��
Send Email��5=      ��5<   '   �� *SendEmailCommand+5=      5>      5?      