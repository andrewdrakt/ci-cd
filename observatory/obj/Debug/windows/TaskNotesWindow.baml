   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:observatory.windowsobservatory.windows  5   	   )    #observatory.windows.TaskNotesWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:observatory.windows     5   	     � Title$%  Просмотр Заметки��5   	   $	��400��6"   $	��600��6/   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $!��Детали Заметки��6   $��16(�6*   $
��Bold"�68   $��0��6J   $��0,0,0,10q�6W   �� 5   
   $��1��6   .+�5      �� $��ID Заметки:��6   $
��Bold"�6+   �� 5      -   5         ��Name$ 
noteIdText��5      $��0,0,0,10q�6,   �� 5      $��Вложение:��6   $
��Bold"�6)   �� 5      -   5        $ attachmentText��5      $��0,0,0,10q�60   �� 5      $��Загружено:��6   $
��Bold"�6*   �� 5      -   5        $ uploadedText��5      $��0,0,0,10q�6.   �� 5      $��Описание:��6   $
��Bold"�6)   �� 5      -   5        $ descriptionText��5      $
��Wrap=�61   $��0,0,0,10q�6E   �� 5      $��ФИО:��6   $
��Bold"�6$   �� 5      -   5        $ fioText��5      $��0,0,0,10q�6)   5      5      5      