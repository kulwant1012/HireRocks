   M S B A M L   `   `   `  ����  Activity management system7    1PS.ActivityManagementStudio.View.DictionaryWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f	 bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q
 mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation     	 
 5   	     � Title$  Dictionaries��5   	    � WindowState$ 	Maximized=�6    � DataContext 5   	   �� *DictionaryModel+   Locator �� Source# [  .��5      � -   5         �Name$
 Main��5       � 	Resources 5   
     TitleTextBlockStyleHeading �� 
TargetType �� Property �� Value  TitleTextBlockStyleContent  RadButtonStyle+ 	 %Telerik.Windows.Controls.StyleManager- 	 'Telerik.Windows.Controls.ThemeConverter��%�  &	       &	 �     &	 h    �� 5	      " ��67   .�5
      ��  � ��$ 13(�6-   �� 5       � ��$ Segoe UI Regular)�6/   �� 5       � �� �#2e2e2e6/   5      �� 5      " ��67   .�5      ��  � ��$ 15(�6-   �� 5       � ��$ Segoe UI Regular)�6/   �� 5       � ��
 ��  �6/   �� 5       � ��$ 25��6+   5      �� 5      .�5      ��  �@ Theme$ Windows8 6?   5      5      	 � RowDefinitions	 5   
   �� 5      $��80 �6   �� 5      .+�5    
   ( 	 "Telerik.Windows.Controls.RadButton  $��0��6   $	��120��6)   $
��20,1q�65   $��Right=�6C   $��Bottom=�6_   $��Add Dictionary��6z   #��[ 5!   w   ��6-   �� *&$DataContext.OpenAddDictionaryCommand+
 �� ElementName$

 Main��6w   * 
 $Telerik.Windows.Controls.RadTileView  5#   
   -   5          Name$ radTileView��5#      $��1��63   $   PreservePositionWhenMaximized .    IsSelectionEnabled .    MinimizedColumnWidth$	 150 �5$   "      MinimizedRowHeight$	 150 �6=      IsAutoScrollingEnabled .    	RowHeight$	 200 �5%   "      ColumnWidth$	 200 �62   $��10q�6D      Theme$ Windows8 6P   ��5#   @   �� *KeywordDictionaryList+��5'      �� 5(      .R�5)      � .+�5*      ��  �� Orientation$ Vertical=�6%   .+�5+      �� ��6(   �� *DictionaryName+5,      5-      5.         ContentTemplate 50      �� 51      .R�52      5 	 /Telerik.Windows.Controls.RadFluidContentControl  -   5           
TransitionD 	 >Telerik.Windows.Controls.TransitionControl.TransitionConverter$ PerspectiveRotation 52   5      LargeContent 53      �� 54      $��Center=�6)   $��20q�6D   .+�55   "   � 	 56   &   �� 57   *   $
��Auto �68   �� 58   *   $
��Auto �68   �� 59   *   $
��Auto �68   �� 5:   *   $
��Auto �68   �� 5;   *   $��70 �68   .+�5=   &   �� $��0��61   $ Vertical=�6>   $��	20,10,0,0q�6U   $
��Left=�6h   .+�5>   *   �� #��[ 64   $��Dictionary Name��6h   �� 5?   *   #��[ 6a   ��64   �� *DictionaryName+ �� Mode$ TwoWay=�6a   5@   '   �� 5B   &   $��3��61   $ 
Horizontal=�6>   .+�5D   *   �� $ Vertical=�65   $��20q�6L   $
��1070��6X   .+�5E   .   �� $��Keywords��68   #��[ 6H   �� 5F   .   $
��Auto=�6[   $
��auto��6�   $	��300��6�   ��67   �� *keywordList+6�   5G   +   5H   '     5J   &   $	��130��68   $��40��6D   $��	0,0,20,20q�6P   $��Right=�6c   $��Edit Dictionary��6   $��Bottom=�5K   �   $��4��6�   #��[ 5L   N   ��5K   =   �� *)'DataContext.OpenUpdateDictionaryCommand+$

 Main����5L   1   �� 6N   5M   #   5N      ��5P      � 5Q      $ contentGrid��6#   .+�5S   "   �� $��Center=�6-   .+�5T   &   �� $ 
Horizontal=�62   $
��Left=�6K   .+�5U   *   �� #��[ 64   $��Dictionary Name��6h   �� 5V   *   #��[ 6a   ��64   �� *DictionaryName+$ TwoWay=�6a   5W   '   �� 5Y   &   $ Vertical=�61   .+�5Z   *   �� $
��Auto=�6W   $��10q�6�   $
��auto��6�   $	��100��6�   ��63   �� *keywordList+6�   5[   '   5]   #   5`      5b      5d      5h      5j      5k      