   M S B A M L   `   `   `  ����D  @methodist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:methodist	methodist  5          methodist.TeachersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:methodist     5        N� Title$  TeachersPage��5	      .��5      � .+�5   
   �� -   5        $	��175��5      $��Добавить��6   $��Light"�60   $	��Top=�6C   $��45��6[   $
��Left=�6g   $��20,35,20,20q�6�   6�   �� 5   
   -   5        $	��175��5      $��Удалить��6   $��Light"�6/   $	��Top=�6B   $��45��6Z   $
��Left=�6f   $��20,95,20,20q�6�   6�   �� 5   
   -   5        $	��175��5      $)��#Просмотр Дисциплин��6   $��Light"�6:   $	��Top=�6M   $��45��6e   $
��Left=�6q   $��20,155,20,20q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ TeacherGrid��5   %      
IsReadOnly .    AutoGenerateColumns .  
�������$��Stretch=�6i   $��Right=�6�   $	��500��6�   $��30q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Преподаватель��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
fullName+6B   5      5      5      