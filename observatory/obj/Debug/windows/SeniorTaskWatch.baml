   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:observatory.windowsobservatory.windows  5      )    #observatory.windows.SeniorTaskWatch   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:observatory.windows     5        N� Title$  SeniorTaskWatch��5	      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $
��1.5* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $%��Мониторинг задач��6(   $��20(�5      $
��Bold"�6"   $��0,0,0,10q�64   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ tasksDG��5      $��1��5      $��0��6       
IsReadOnly .    SelectionMode$ Single=�5      $��0,0,10,0q�5      5      �� 5!   
   $��1��6   $��1��6"    �� Orientation$ Vertical=�62   $��Stretch=�6I   .+�5#      �� $��Приоритет:��6   �� 5$      -   5         ��Name$ priorityBox��5$      $
��Auto��6,   $��0,0,0,10q�69   �� 5&      $"��Дата окончания:��6   (  "System.Windows.Controls.DatePicker  5'      -   5          Name$ endDatePicker��5'      $
��Auto��6h   $��0,0,0,10q�6u   �� 5)      $)��#Ссылка на вложение:��6   �� 5*      -   5        	 ��Name$	 attachmentUrl��5*      $
��Auto��6-   $��0,0,0,10q�6:   �� 5,      -   5        
 ��Name$
 isCompleted��5,      $��Выполнение��6,   $��0,0,0,10q�6A    d� 	IsChecked$ FalseY�6S   6�   �� 5.      -   5         ��Name$ editTaskBtn��5.      $��Изменить��6*   $��0,0,0,10q�50      �� 52      -   5        $ 
viewReport��52      $%��Посмотреть отчёт��6)   $��0,0,0,10q�54      �� 56      -   5        $ viewAllNotes��56      $)��#Посмотреть заметки��6+   57      58      5:      5;      