   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:observatory.windowsobservatory.windows  5   	   /    )observatory.windows.SciencePersonnelPanel   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:observatory.windows     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  SciencePersonnelPanel��5	   	   $	��600��6'   $	��800��64   .��5
      �  � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   o� $��Stretch=�6   $
��Left=�6+   .@�5      �� -   5        $��programmExitBtn��5   ,   ���	#FFD60000$��
Выход��6C   6S   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ taskDG��5      $��1��6#   $��
10,10,10,5q�60      
IsReadOnly .    SelectionMode$ Single=�5   %      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *	id_task+6M     5      $ Название��6%   $ * 6P   	 67   �� *name+6P     5      $ Описание��6%   $ 2* 6W   	 67   �� *descriprion+6W     5      $ Начало��6%   $ * 6O   	 65   �� *issue+6O     5      $ 
Конец��6%   $ * 6Q   	 64   �� *
deadline+6Q     5       $ Приоритет��6%   $
 Auto 6U   	 68   �� *
priority+6U     5!      $ Вложение��6%   $
 Auto 6V   	 67   �� *
attachment+6V     5"      $ Статус��6%   $
 0.5* 6T   	 65   �� *
check_task+6T     5#      $ 
Отчёт��6%   $
 Auto 6R   	 64   �� *	report_id+6R   5&      �� 5'   
   $��1��6   $��10q�6!   $��Stretch=�6-   $��Bottom=�6K   $��1��6f   �� 5(   
   $��Заметки��6   $��2��6$   $��
10,5,10,10q�61   .��5)      �  5*      �� 5+      $��* �6$   �� 5,      $
��Auto �6$   �� 5-      $
��Auto �6$   
 � ColumnDefinitions
 5/      �� 50      $��* �6'   �� 51      $��* �6'   .+�53        -   5        $ notesDG��53   /   $��2��6   $��0��6@   $��0,0,0,5q�6M    . $ Single=�54   -    .   56        57      $ ID��6-   $
 Auto 6U   	 69   �� *	id_note+6U     58      $ Вложение��6-   $ * 6^   	 6?   �� *
attachment+6^     59      $ Загружено��6-   $ * 6]   	 6@   �� *
uploaded+6]     5:      $ Описание��6-   $ 2* 6_   	 6?   �� *description+6_     5;      $ ФИО��6-   $ * 6R   	 6:   �� *fio+6R     5<      $ Номер задачи��6-   $ * 6_   	 6C   �� *	task_id+6_   5>      �� 5?      -   5         ��Name$ attachmentUrl��5?   )   $��2��6   $��Stretch=�6@   $��Bottom=�6^    �� TextWrapping$
 Wrap=�6y   $��Вложение��6�   �� 5@      -   5        $ description��5@   '   $��1��6   $��Stretch=�6<   $
 Wrap=�6Z   $��Описание��6n   $	��Top=�6~   �� 5A      -   5         ��Name$ addNote��5A   n   $��1��6   $%��Добавить заметку��6)   $��2��6E   $��Stretch=�6R   $��Right=�6   6�   �� 5B      -   5        $ viewNoteButton��5B   )   $��1��6   $+��%Просмотреть заметку��6A   $��1��5C      $��Right=�6   {�.  5D   .   5F      5G      5J      5K      