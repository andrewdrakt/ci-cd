   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:observatory.windowsobservatory.windows  5      #    observatory.windows.SeniorReg   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:observatory.windows     5        N� Title$  	SeniorReg��5
       � DataContext 5      ��  �� RelativeSource �� *Self+.��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.2* �6   6.   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $
��0.7* �6   6,   �� 5      $
��0.7* �6   6,   �� 5      $
��0.7* �6   6,   �� 5      $
��0.4* �6   6,   .+�5   
   �� -   5         ��Name$ 	nameInput��5      $��15(�6%   $��Stretch=�63   $��2��6S    �� TextWrapping$
 Wrap=�6g   $��Bottom=�6|   �� 5   
   -   5        $ 
loginInput��5      $��15(�6&   $��Stretch=�64   $��2��6R   $��1��6f   $
 Wrap=�6s   $��Bottom=�6�   G� 5   
   -   5         G�Name$ passwordInput��5      $��15(�6-   $��2��6;   $��2��6O   $��Stretch=�6\   $��Bottom=�6z   �� 5   
   -   5         ��Name$ registrationBtn��5      $��Регистрация��6*   $��Center=�6@   $��3��6]   $��Center=�6j   6�   �� 5    
   -   5        	 ��Name$	 departmentBox��5       $��Stretch=�6*   $��2��6H   $��3��6\   $��Bottom=�6l   �� 5!   
   -   5        $	 roleBox��5!      $��Stretch=�6$   $��1��6B   $��3��6O   $��2��6_   $��Bottom=�6s   �� 5"   
   $
��Bold"�6   $��15(�6"   $��ФИО��60   $
��Left=�6>   $��0��6Y   $��Center=�6f   �� 5#   
   $
��Bold"�6   $��15(�6"   $��Логин (почта)��60   $
��Left=�6H   $��1��6c   $��Center=�6p   �� 5$   
   $
��Bold"�6   $��15(�6"   $��Пароль��60   $
��Left=�6A   $��2��6\   $��Center=�6i   �� 5%   
   $
��Bold"�6   $��15(�6"   $��
Отдел��60   $��Right=�6@   $��0��6\   $��4��6i   $��Center=�6y   �� 5&   
   $
��Bold"�6   $��15(�6"   $��Роль��60   $��Right=�6?   $��1��6[   $��4��6h   $��Center=�6x   5'      5(      