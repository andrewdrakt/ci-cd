   M S B A M L   `   `   `  ����F  Bobservatory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:observatoryobservatory  5   	       observatory.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:observatory     5   	     � Title$  
MainWindow��5
   	   $	��450��6   $	��800��6)   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      $
��0.3* �6   6,   �� 5      $
��0.4* �6   6,   �� 5      $
��0.3* �6   6,   �� 5      $
��0.4* �6   6,   �� 5      6   .+�5   
   �� -   5         ��Name$ authText��5      $ ��Вход в аккаунт��6&   $��1��6=   $��1��6M   $��Center=�6Z   $��40(�6w   $��3��6�   $��Arial Black)�6�   �� 5    
   -   5        $ 	loginView��5       $��
Почта��6'   $��1��65   $��2��6E   $
��Left=�6R   $��25(�6m   $��Arial Black)�6{   �� 5!   
   -   5         ��Name$ 	authLogin��5!      $��25(�6%   $��3��63   $��1��6G   $��3��6W   �� 5#   
   -   5        $ passwordView��5#      $��Пароль��6*   $��1��69   $��4��6I   $
��Left=�6V   $��25(�6q   $��Arial Black)�6   G� 5$   
   -   5         G�Name$ authPassword��5$      $��25(�6,   $��1��6:   $��3��6J   $��5��6^   �� 5%   
   -   5         ��Name$ authBtn��5%      $��6��6#   $��2��60   $��Center=�6@   $��Center=�6]   $��
Войти��6x   $��25(�6�   $��Arial Black)�6�    "  MaterialDesignPaperLightButton#��[  5'       � ToolTip$3 -Resource name: MaterialDesignPaperLightButton��5(      {�5&      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+	 �� AncestorType$	 WindowL�5(   G   5)      5*      