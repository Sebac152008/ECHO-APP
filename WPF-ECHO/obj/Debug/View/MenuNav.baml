   M S B A M L   `   `   `  ����?  ;ECHO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_ECHO.ViewWPF_ECHO.View  5      9!clr-namespace:WPF_ECHO.ViewModelsWPF_ECHO.ViewModels  5          WPF_ECHO.View.MenuNav   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:WPF_ECHO.View     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      1	viewModel!clr-namespace:WPF_ECHO.ViewModels  5      ���#2C3E50  � DataContext  5      '   !WPF_ECHO.ViewModels.MainViewModel  5   
    � 	Resources 5       �� DataType$   WPF_ECHO.ViewModels.InicioView   WPF_ECHO.View.InicioView'   !WPF_ECHO.ViewModels.DestacadoView!   WPF_ECHO.View.DestacadoView$   WPF_ECHO.ViewModels.BuscarView   WPF_ECHO.View.BuscarView&    WPF_ECHO.ViewModels.AcercaDeView 	   WPF_ECHO.View.AcercaDeView��%,  (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)(�� �     5       *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5    
   "  6   .R�5!      	  5"      5#      .��5%      �  � ColumnDefinitions 5&   
   �� 5(      $	��260 �6   �� 5*      $��* �6   .+�5.   
   �� $��0q�6   $��0��6%   ���#2C3E50._�51      ]� ��. .+�53      �� $	��260��6   $��	0 20 0 20q�6%   $	��130��68   
������ $	��Top=�6_   ._�54      �� $��	0 20 0 20q�6   $	��250��6/   $��/Imagenes/ECHOLOGO2.png��6;   $��Uniform=�6\   55      � 58      $	��Top=�6   $��Stretch=�6,    � RowDefinitions 59      �� 5:      $��60 �6(   �� 5<      $��60 �6(   �� 5=      $��60 �6(   �� 5>      $��* �6(   �� 5@      $
��auto �6(   .+�5F      	�  d� 	IsChecked$
 TrueY�6"   $��0��6]      
menuButton#��[  6j   
 � Tag$
 #fff��6�   ��63   �� *ShowInicioViewCommand+.��5G      ��  �� Orientation$ 
Horizontal=�6%   .+�5H      !
  FontAwesome.Sharp.IconImage
  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+     menuButtonIcon#��[ 67   �� 5I      $��Inicio��6(     menuButtonText#��[ 66   5J      5K      	� 5O      $��Center=�6O   $��1��6j   #��[  6w   $
 #fff��6�   ��6"   �� *ShowDestacadoViewCommand+.��5P      �� $ 
Horizontal=�6%   .+�5Q      
  $
 Star=�6+   	 
  IconFont$	 Solid=�67   #��[ 6I   �� 5R      $��	Destacado��6(   #��[ 69   5S      5T      	� 5X      $��Center=�6L   $��2��6g   #��[  6t   $
 #fff��6�   ��6"   �� *ShowBuscarViewCommand+.��5Y      �� $ 
Horizontal=�6%   .+�5Z      
  $ Search=�6+   $	 Solid=�69   #��[ 6K   �� 5[      $��Buscar��6(   #��[ 66   5\      5]      	� 5a      $��4��6"   $��	0 20 0 20q�6W   #��[  6j   $
 #fff��6�   ��6/   �� *ShowAcercaDeCommand+.��5b      �� $ 
Horizontal=�6%   .+�5c      
  $ ExclamationCircle=�6+   #��[ 6D   �� 5d      $��	Acerca de��6(   #��[ 69   5e      5f      5h      5i      5j      �� 5o   
   -   5        
 ��Name$
 mainContent��5o   )   $��1��6   ��6>   �� *CurrentChildView+5q      5s      