   M S B A M L   `   `   `  ����G  CCarsRent.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CarsRent.WPF.PagesCarsRent.WPF.Pages  5      !    CarsRent.WPF.Pages.ListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CarsRent.WPF.Pages     5        N� Title$  ListPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��32* �6   �� 5      $	��18* �6   �� 5      $	��18* �6   �� 5      $	��32* �6    � RowDefinitions 5   
   �� 5      $	��70* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   .+�5   
   �� -   5         ��Name$ spItems��5      $��0��6&   $��0��63   $��4��6C   �� 5   
   -   5         ��Name$ btnAdd��5      $��Добавить��6!   $��0��64   $��2��6D   6Q   �� 5   
   -   5        $ 	btnChange��5      $��Изменить��6$   $��1��67   $��2��6G   $��2��6[   6h   �� 5   
   -   5        $ 	btnDelete��5      $��Удалить��6$   $��3��66   $��2��6F   6S   �� 5   
   -   5        $ btnBack��5      $��
Назад��6"   $��0��62   $��1��6B   6O   �� 5   
   -   5        $ 
btnForward��5      $��Вперед��6%   $��3��66   $��1��6F   6S   �� 5    
   -   5         ��Name$ tbxPageNumber��5       $��1��6)   $��2��62   $��1��6B   $
��30px(�6O    �� TextAlignment$ Center=�6_   $��Center=�6v   $��25, 0q�6�   �� 5!   
   -   5        $ btnGoToPage��5!      $��Перейти��6&   $��1��68   $��1��6H   6U   5"      5#      