   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:observatory.windowsobservatory.windows  5      -    'observatory.windows.SeniorViewEmployees   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:observatory.windows     5        N� Title$  SeniorViewEmployees��5	      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $
��1.5* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��2��6   $)��#Список сотрудников��6(   $��20(�5      $
��Bold"�6"   $��0,0,0,10q�64   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ employeesDG��5      $��1��5      $��0��6       
IsReadOnly .    SelectionMode$ Single=�5      $��0,0,10,0q�5      �� 5    
   $��1��6   $��1��6"    �� Orientation$ Vertical=�5!      $��Stretch=�5"      .+�5$      �� $��ФИО:��6   �� 5%      -   5         ��Name$	 fio��5%      $
��Auto��6#   $��0,0,0,10q�60   �� 5'      $��Логин:��6   �� 5(      -   5        $ login��5(      $
��Auto��6%   $��0,0,0,10q�62   �� 5*      -   5         ��Name$ passwordAllowed��5*      $��Пароль��60   $��0,0,0,5q�5+      5-      G� 5/      -   5        	 G�Name$	 password��5/      $
��Auto��50      {�.  $��0,0,0,10q�52      �� 54      $��Отдел:��6   �� 55      -   5        
 ��Name$
 departmentBox��55      $
��Auto��6.   $��0,0,0,10q�6;   �� 57      $��	Роль:��6   �� 58      -   5        $
 roleBox��58      $
��Auto��6(   $��0,0,0,20q�65   �� 5:      -   5         ��Name$ editBtn��5:      $#��Изменить данные��6&   $��0,0,0,10q�5<      �� 5>      -	   5        $ 	deleteBtn��5>      $��Удалить��6(   5?      5@      5B      5C      