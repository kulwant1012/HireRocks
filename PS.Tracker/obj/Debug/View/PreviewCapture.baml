   M S B A M L   `   `   `  ����  
PS.Tracker$    PS.Tracker.View.PreviewCapture   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Preview Capture!��5   	   $	��700��6"   $	��800��6/    � WindowStyle$ 
ToolWindow=�5   	    � 
ResizeMode$ NoResize=�6"    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��5q�6    � RowDefinitions 5   
   �� 5	      $	��460 �6   �� 5
      .+�5   
   �� $	��460��6   $	��780��6$   $
��Auto=�60   $
��Auto=�6b   .��5      �� ��6   �� *ScreenCaptureFullImage+5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��550 �6#   �� 5      .+�5      �� $
��Auto=�6   $��0��6K   .��5      �� 
�������$��1q�61   ._�5      �� .+�5      �� $��Keyboard Capture��6$    �� Padding$ 5,0,0,5q�6<   �� 5      $
��Wrap=�6E   $ 5,0,0,5q�6Y   ��6$   �� *KeyboardCapture+6Y   5      5      5      �� 5      $	��160��6   $	��Top=�6(   $
��Auto=�6@   $��1��6p   .��5      �� 
�������$��0,1,1,1q�61   ._�5      �� .+�5      �� $��Mouse Capture��6$   $ 5,0,0,5q�69   �� 5       $
��Wrap=�6B   $ 5q�6V   ��6$   �� *MouseCapture+6V   5!      5"      5#      �� 5$      $��1��6   $��41��6%   $��Bottom=�61   
�������$��0,0,1,1q�6d   ._�5%      ��  �� Orientation$ 
Horizontal=�6   .+�5&      �� $��Time burned��6    $��5,10,0,0q�63   $��Center=�6E   �� 5'      $��5,10,0,0q�6<   $��Center=�6N   $
��Bold"�6i   ��6    �� *
TimeBurned+6i   �� 5(      $
��Sec.��6    $��3,10,0,0q�6,   $��Center=�6>   5)      5*      5+      5,      5-      