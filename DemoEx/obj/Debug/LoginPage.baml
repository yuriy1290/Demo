   M S B A M L   `   `   `  ����A  =DemoEx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoExDemoEx  5   	       DemoEx.LoginPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DemoEx     5   	     � Title$  	LoginPage��5   	    � WindowState$ 	Maximized=�6   $	��450��64   $	��800��6A   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��20* �6   �� 5      $
��200* �6   .+�5   
   �� $��0��6   $��Почта:��6!   $��Center=�6/   $��Center=�6L   �� 5   
   -   5         ��Name$ EmailTextBox��5   p   $��
почта��6   $��1��6   $	��150��6,   $��Center=�68   $��Center=�6U   6p   �� 5   
   $��2��6   $��Пароль:��6!   $��Center=�61   $��Center=�6N   G� 5   
   -   5         G�Name$ PasswordBox��5   y    G� Password$ пароль��6   $��3��6(   $	��150��65   $��Center=�6A   $��Center=�6^   6y   �� 5   
   -   5        $��4��5      $"��Авторизоваться��6   $��Center=�68   $��Center=�6U   6p   �� 5   
   -   5        $��5��5      $*��$Зарегистрироваться��6   $��Center=�6<   $��Center=�6Y   6t   5      5      