   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:observatory.windowsobservatory.windows  5   	   .    (observatory.windows.CheifDepartmentPanel   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:observatory.windows     5   	     � Title$  CheifDepartmentPanel��5   	   $	��650��6&   $	��800��63   .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $
��Auto �6   .+�5   
   o� $��3��6   $��Stretch=�6   $
��Left=�68   .@�5      �� -   5        $��programmExitBtn��5   ,   ���	#FFD60000$��
Выход��6C   6S   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ taskDG��5      $��0��6#   $��10q�60      AutoGenerateColumns .     SelectionMode$ Single=�5   '   $��2��5         
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *	id_task+6M     5      $ Название��6%   $ * 6P   	 67   �� *name+6P     5      $ Описание��6%   $ 2* 6W   	 67   �� *descriprion+6W     5      $ Дедлайн��6%   $ * 6S   	 66   �� *
deadline+6S     5      $ Приоритет��6%   $
 Auto 6U   	 68   �� *
priority+6U   4  .System.Windows.Controls.DataGridCheckBoxColumn  5       $ Выполнено��6)   $
 Auto 6[   	 6<   �� *
check_task+6[   5"      �� 5$   
   $��
Отчёт��6   $��2��6"   $��10q�6/   .��5%      �  5&      �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$   �� 5)      $��* �6$   �� 5*      $
��Auto �6$   .+�5,      �� $��Вложение:��6   $��0��6,   $��	0,0,685,0q�69   �� 5-      -   5        
 ��Name$
 
attachment��5-      $��0��6.   $��75,0,0,0q�6;   �� 50      $��Описание:��6   $��2��6,   $��	0,0,685,0q�69   $��2��6L   �� 51      -   5        $
 description��51      $��2��6/    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6Q   $��75,0,0,0q�6e   $��2��6w   52      53      �� 55   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�56      �� -   5        $%��Прикрепить отчет��56      $	��150��60   $��5q�6<   6G   �� 57      -   5         ��Name$ 
editReport��57      $+��%Редактировать отчет��6)   $	��150��6G   $��5q�6S   6^   �� 58      -   5        $+��%Просмотреть заметки��58      $	��150��63   $��5q�6?   6J   59      5:      5;      