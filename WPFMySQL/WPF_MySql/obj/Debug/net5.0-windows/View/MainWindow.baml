   M S B A M L   `   `   `  ����D  @WPF_MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WPF_MySql.ViewWPF_MySql.View  5   	       WPF_MySql.View.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WPF_MySql.View     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��70 �6   �� 5      $��25 �6   .+�5   
   �� $��0��6    �� SelectedItem 6"   �� *SelectedTabItem+.@�5      �� -   5        $��	PersonTab��5      ��5      �� 5      $��People��6    $��14(�6.   6>    � ContextMenu 5      �� 5      .@�5      m� $ ��Редактировать��6#    m� Command 6:   �� *OpenEditPersonWindow+m� 5      $��Удалить��6#    64   �� *DeletePersonWindow+5      .��5      �� -   5         ��Name$ ViewAllPersons��5      ��63   �� *	AllPeople+ 5      �� *SelectedPerson+ �� View 5      �� 5      .P�5      �� $
��Name��6-    �� DisplayMemberBinding 5    -   ��  �� Path$
 Name��� 5!      $��Phone��6-    5"   -   �� $ Phone�5#      5%      5&      �� 5(      -   5        $��SettingsTab��5(      ��5)      �� 5*      $��Settings��6    $��14(�60   6@   5,      5-      �� 5/   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��Center=�50      .+�51      �� $��Новая персона��6   $��14(�6U   $��40��6c   $	��100��6o   ��6-   �� *OpenAddPersonWindow+6o   52      �� 53   
   $��2��6   
���W�.�.@�54      �� $,��&Связь с базой данных:��6   
�������
���W�.�$��14(�6e   �� 55      -   5        
 ��Name$
 ViewStatusBar��55      
�������
���W�.�$��12(�6�   $��15��6�   $��20��6�   $��Center=�6�   ��6/   �� *StateConnectionToDb+6�   5;      5>      5?      