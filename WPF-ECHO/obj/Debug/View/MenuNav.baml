   M S B A M L   `   `   `  ����?  ;ECHO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_ECHO.ViewWPF_ECHO.View  5      9!clr-namespace:WPF_ECHO.ViewModelsWPF_ECHO.ViewModels  5          WPF_ECHO.View.MenuNav   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:WPF_ECHO.View     5      7	viewModel!clr-namespace:WPF_ECHO.ViewModels     5        � DataContext  5      '   !WPF_ECHO.ViewModels.MainViewModel  5   
    � 	Resources 5       �� DataType$   WPF_ECHO.ViewModels.InicioView   WPF_ECHO.View.InicioView&    WPF_ECHO.ViewModels.AcercaDeView    WPF_ECHO.View.AcercaDeView��%�   (��       5      *, +)(�� 2     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5!   
   �� $��0q�6   $��0��6%   ���#2C3E50._�5$      ]� ��. .+�5&      �� $	��249��6   $	��130��6%   ���#1B263B$	��Top=�6G   ._�5'      �� $��	0 20 0 20q�6   $	��250��6/   $��/Imagenes/ECHOLOGO2.png��6;   $��Uniform=�6\   5(      � 5+      $	��Top=�6   $��Stretch=�6,    � RowDefinitions 5,      �� 5-      $
��Auto �6(   �� 5/      $��* �6(   �� 51      $
��Auto �6(   .+�56      �� $��0��6    � Cursor$
 Hand��6*   $��0 30 0 0q�68   $	��230��6J   $��50��6V   $��18(�6b   $��Sans Serif Collection)�6p   
�������$��Center=�6�   ��6�   �� *ShowInicioViewCommand+.��58      �� $	��180��6%   $
��Left=�61    �� Orientation$ 
Horizontal=�6L   .+�59      �� $��Center=�6$   $��/Imagenes/home.png��6?   $��25��6[   $��0 0 0 0q�6f   �� 5:      $��Center=�6(   $��Inicio��6C   $��20 0 0 0q�6Q   
�������$��16(�6v   5;      ��5=      �� 5>       �� 
TargetType" ��6.   .R�5?   "   ��  ��Name$ ButtonBorder��6P   	 �� CornerRadius$	 10��6)   ���#1B263B._�5@   &   �� $��Center=�67   $��Center=�6T   $
 Hand��6o   5A   #   
 �� Triggers
 5B   "   P� 5C   &    P� Property �@J�IsMouseOver P� Value . . �5D   *   ��  �� 
TargetName$ ButtonBorder��61    �� Property � �� �� Value �#274C776a   5E   '   5G      5I      �� 5M      $��1��6   $��0 35 0 0q�6*   $
 Hand��6<   $	��230��6J   $��50��6V   $��18(�6b   $��Sans Serif Collection)�6p   
�������$	��Top=�6�   $��Center=�6�   .��5O      �� $��Center=�6%   $ 
Horizontal=�6B   .+�5P      �� $��Center=�6$   $��/Imagenes/love.png��6?   $��25��6[   $��-5 0 0 0q�6f   �� 5Q      $��Mis recordatorios��6(   $��Center=�6A   $��20 0 0 0q�6\   
�������$��16(�6�   5R      ��5T      �� 5U      " ��6.   .R�5V   "   �� $ ButtonBorder��6P   $	 10��6)   ���#1B263B._�5W   &   �� $��Center=�67   $��Center=�6T   $
 Hand��6o   5X   #   
 5Y   "   P� 5Z   &    �@J�IsMouseOver . . �5[   *   �� $ ButtonBorder��61    � �� �#274C776a   5\   '   5^      5a      �� 5d      $��2��6   $
 Hand��6*   $	��230��68   $��50��6D   $��18(�6P   $��Sans Serif Collection)�6^   
�������$��Center=�6�   $��	0 20 0 20q�6�   ��6�   �� *ShowAcercaDeCommand+.��5f      �� $	��170��6%   $
��Left=�61   $ 
Horizontal=�6L   .+�5g      �� $��Center=�6$   $��/Imagenes/AcercaDe.png��6?   $��25��6_   $��0 0 0 0q�6j   �� 5h      $��	Acerca de��6(   $��Center=�69   $��20 0 0 0q�6T   
�������$��16(�6y   5i      ��5k      �� 5l      " ��6.   .R�5m   "   �� $ ButtonBorder��6P   $	 10��6)   ���#2A5069._�5n   &   �� $��Center=�67   $��Center=�6T   $
 Hand��6o   5o   #   
 5p   "   P� 5q   &    �@J�IsMouseOver . . �5r   *   �� $ ButtonBorder��61    � �� �#3A6F916a   5s   '   5u      5w      5x      5y      5z      �� 5   
   -   5         ��Name$ mainContent��5      $��1��6S   ��6.   �� *CurrentChildView+6S   5�      5�      