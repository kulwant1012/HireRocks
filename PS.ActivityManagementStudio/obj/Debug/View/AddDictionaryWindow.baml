   M S B A M L   `   `   `  ����U  QActivity management system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:PS.ActivityManagementStudio.Helpers#PS.ActivityManagementStudio.Helpers  5   	   :    4PS.ActivityManagementStudio.View.AddDictionaryWindow   5   	   l hTelerik.Windows.Controls.Input, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7o kTelerik.Windows.Controls.GridView, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7b ^Telerik.Windows.Data, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7x tTelerik.Windows.Controls.DataVisualization, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7f bTelerik.Windows.Controls, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7q mTelerik.Windows.Controls.Navigation, Version=2013.3.1204.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Itelerik1http://schemas.telerik.com/2008/xaml/presentation       W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\	 XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation   	 5   	   R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
   	 5   	   ?w1clr-namespace:PS.ActivityManagementStudio.Helpers 
   	 5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowState$ 	Maximized=�6/   
������� � Title$ Add Dictionary��5   	    � DataContext 5   	   �� *DictionaryModel+   Locator �� Source# [  .��5	      � -   5         �Name$
 Main��5	      .+�5
   
   �� $��Center=�6   .+�5      �� $��5,5,0,5q�6   $��1q�6&   
�������$	��200��6M   $	��350��6Z   ._�5      � $	��320��6   $��Center=�6#   $	��200��6>   $��Center=�6K    � RowDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� $��0��6    $��1��6-   $	��Top=�6V   
���  ��$��20��6   ��6=   �� *	Message+6   �� 5      $��0��6    $��1��6-   $��Add Dictionary��6=   $��Center=�6S   $
��Bold"�6n   $��20q�6�   � 5      $��1��6   $��Right=�6(   $	��320��6D    5      �� 5      �� 5       � ColumnDefinitions 5      �� 5      $��* �6/   �� 5      $	��100 �6/   �� 5      $	��200 �6/   .+�5!      � $��1��6   $��2��63   5"      �� 5$      $��0��6    $��1��6-   $��Dictionary Name:��6=   �� 5%      $��0��6Y   $��2��6f   $��30��6v   
�������$��2q�6�   ��6"   �� *'%KeywordDictionaryModel.DictionaryName+6�   �� 5&      $��1��6    $��1��6-   $��	Key Word:��6=   �� 5'      $��2��6"   $��2��6/   $��30��6?   
�������$��2q�6}   ��6K   �� *	Keyword+6�   5(      �� 5)      $��2��6!   $��1��6.    �� Orientation$ 
Horizontal=�6>   $��Right=�6W   .+�5*      (  "Telerik.Windows.Controls.RadButton  -   5        $��
AddKeyWord��5*   ,   $��Add Keyword��6?   $��30��6U   $	��100��6a   ��6m   �� *AddKeywordCommand+6�     5+      -   5        $��AddDictionary��5+   ,   $��Add Dictionary��6A   $��30��6[   $	��100��6g   ��6s   �� *AddUpdateDictionaryCommand+6�   5,      5-      5.      �� 5/      $��5,0,0,5q�6   $��1q�6&   
�������$	��200��6M   $	��350��6Z   ._�50      � $	��350��6   $	��200��6#   .+�52      *  $Telerik.Windows.Controls.RadExpander  $��List of Keywords��6*   	   
IsExpanded	 . 
   ExpandDirection$

 Down=�6V   
�������$��1q�6�   .��53      �� $ Vertical=�6%   .+�54      �� $
��Bold"�6_   ��6(   �� *'%KeywordDictionaryModel.DictionaryName+6_   �� 55      -   5         ��Name$ listDictionary��55   '   $��0q�6z   $
��Auto=�6�   $	��335��6�   $	��165��6�   ��6?   �� *$"KeywordDictionaryModel.keywordList+ �� SelectedIndex 56      �� *KeywordIndex+ �� Mode$ TwoWay=� �� SelectedItem 6P   �� *	Keyword+$ TwoWay=�57      58      59      5:      5;      5<      5>      5?      