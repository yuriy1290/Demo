   M S B A M L   `   `   `  ����A  =DemoEx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoExDemoEx  5   	       DemoEx.RegistrationPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DemoEx     5   	     � Title$  RegistrationPage��5   	    � WindowState$ 	Maximized=�6"   $	��450��6:   $	��800��6G   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��10* �6   �� 5      $
��200* �6   .+�5   
   �� $��0��6   $��Фамилия:��6!   $��Center=�61   $��Center=�6N   �� 5   
   -   5         ��Name$ LastNameTextBox��5   t   $��1��6   $	��150��6   $��Center=�6+   $��Center=�6H   $��0,5,0,5q�6c   6t   �� 5   
   $��2��6   $��Имя:��6!   $��Center=�6.   $��Center=�6K   �� 5   
   -   5        $ FirstNameTextBox��5   t   $��3��6   $	��150��6   $��Center=�6+   $��Center=�6H   $��0,5,0,5q�6c   6t   �� 5   
   $��4��6   $��Почта:��6!   $��Center=�60   $��Center=�6M   �� 5   
   -   5        $ EmailTextBox��5   t   $��5��6   $	��150��6   $��Center=�6+   $��Center=�6H   $��0,5,0,5q�6c   6t   �� 5!   
   $��6��6   $��Пароль:��6!   $��Center=�61   $��Center=�6N   G� 5"   
   -   5         G�Name$ PasswordBox��5"   x   $��7��6   $	��150��6#   $��Center=�6/   $��Center=�6L   $��0,5,0,5q�6g   6x   �� 5$   
   -   5        $��8��5$      $*��$Зарегистрироваться��6   $��Center=�6;   $��Center=�6X   $��0,10,0,5q�6s   6�   �� 5&   
   -   5        $��9��5&      $"��Авторизоваться��6   $��Center=�67   $��Center=�6T   6o   5'      5(      