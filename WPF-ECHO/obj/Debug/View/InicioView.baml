   M S B A M L   `   `   `  ����?  ;ECHO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WPF_ECHO.ViewWPF_ECHO.View  5          WPF_ECHO.View.InicioView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      'localclr-namespace:WPF_ECHO.View  5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5	         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      ���#000  MaterialDesignFont#���  5       � 	Resources 5        MostrarMensaje �� TargetProperty g� Duration R� KeyTime  System.Windows.Visibility   Visible R� Value W� From		 W� To  OcultarMensaje
 g� 	BeginTime   	Collapsed  SlideInFromRightAnimation W� EasingFunction.  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  SlideOutToRightAnimation  VentanaAbrirAnimacion��%�  &	       &	 �     &	 �    &	 �    &	 �    �� 5   
   .��5      T� $ 
Visibility�6,   $ 0:0:0D�6S   ..�5      i� $ 0:0:0��6)   # Z 69   5      W� 5      $ Opacity�6   $ 0X�6B   $	 1X�6K   $ 0:0:0.3D�6R   5      �� 5   
   .��5      W� $ Opacity�6   $ 1X�6B   $	 0X�6K   $ 0:0:0.3D�6R   T� 5      $ 
Visibility�6,   $
 0:0:0.3X�6S   ..�5       i� $ 0:0:0��6)   # Z 69   5!      5"      �� 5%   
   .��5&      W� $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�6   $ 0X�6m   $	 0X�6v   $ 0:0:0.4D�6}    5'        5(      $ EaseOut=�6    5*      W� 5+      $ Opacity�6   $ 0X�6B   $	 1X�6K   $ 0:0:0.4D�6R   5,      �� 5.   
   .��5/      W� $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�6   $ 0X�6m   $	 0X�6v   $ 0:0:0.4D�6}    50        51      $ EaseIn=�6    53      W� 54      $ Opacity�6   $ 1X�6B   $	 0X�6K   $ 0:0:0.4D�6R   55      �� 59   
   .��5;      W� $ Opacity�6   $ 0X�5<      $	 1X�6'   $ 0:0:0.4D�6.   W� 5?      $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�6   $ 30X�5@      $	 0X�6(   $ 0:0:0.4D�6/   5A      5D      .��5G      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ MainDialogHost��5G          
Identifier$ MainDialogHost��68   .��5I   
   �  J� RenderTransformOrigin$ 0.5,0.5&�6   .+�5K      �� -   5         ��Name$ FondoImagen��5K      $��UniformToFill=�6E    J� Opacity$	 0.6Q�6]   � 5M      .+�5O      �  � RowDefinitions 5Q      �� 5R      $
��auto �6(   �� 5S      $��* �6(   .+�5X      � $��0��6   $
��auto��6(   $	��Top=�66   .+�5Y      ��  # MaterialDesignElevationShadow24 J� Effect# [ 6!   ._�5Z      �� -   5         ��Name$ btnAbrirContenedor��5Z   %   $��
0 30 60 20q�6A    � Cursor$
 Hand��6U   $��Right=�5[   %   $	��Top=�6A   $��55��6Y   .��5\   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5]   &   �� $��Crear recordatorio��60   $��18(�6J   $��Center=�6X   $��	20 0 20 0q�6s   ���#fff6�   !  FontAwesome.Sharp.IconImage  5^   &   �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ PenToSquare=�63   $��0 0 20 0q�6F   $��Center=�6X   $��30��6s      
Foreground �#fff6~   5_   #   ��5`   "   �� 5a   &    �� 
TargetType" ��66   .R�5b   *   ��  ��Name$ ButtonHover��6W   ���#2C3E50 �� CornerRadius$ 5��6F   ._�5c   .   �� $��Center=�6?   $��Center=�6\   5d   +    �� Triggers 5e   *   P� 5f   .    P� Property �@J�IsMouseOver P� Value . . �5g   2   ��   �� 
TargetName$  ButtonHover��69   ! �� Property! � ��" �� Value" �#34495E6h   5h   /   5j   '   5l      5m      � 5p      $
��Left=�6   $��Center=�6:   $��
30 20 0 30q�6U   .+�5q      �� $ Vertical=�6)   .+�5r   "   �� $��30 0 0 0q�6-   $ 
Horizontal=�6?   .+�5t   &   �� $��Inicio��60   ���#fff$��	ExtraBold"�6P   $��40(�6g   5v   #   �� 5x   "   -   5        # ��Name$# txtFechaActual��5x   ,   $��20(�6D   ���#fff$��Center=�6d   $��30 5 0 0q�6�   5y      5z      5{      �� 5~      $��1��6#   $��Disabled=�60   $
��Auto=�6Y   .��5�      �� -   5        $ ��Name$$ PanelRecordatorios��5�   %   5�      5�      5�      �� 5�      -   5        $$ StackMensajes��5�      $	��Top=�64   $	��220��6L   $��10q�6X   $ Vertical=�6d   �� 5�      -   5        $ ContenedorAddRecordatorio��5�       # MaterialDesignElevationShadow16# [ 5�      $	��350��5�      ���#f4f4f4$ 0��5�      $��0q�5�      $��Right=�5�      $	��Top=�5�      $y�	Collapsed=�5�      ��5�      �� *ActualHeight+% �� RelativeSource% �� & �� AncestorType$& WindowL�z�5�      T� 5�      ._�5�      �� $��Disabled=�6#   $
��Auto=�6L   .��5�      �� $��10q�6%   .+�5�      �� -   5        $��35��5�   <   $��35��6G   $��Right=�6S   $��
0 10 10 10q�6o   $
 Hand��6�   ' � ToolTip$' Cerrar��6�   ��5�   "   �� 5�   &   " ��66   .R�5�   *   �� $ border��6V   ���#fff$	 100��6C   ._�5�   .   �� $	��✕��68   $��18(�6A   $
��Bold"�6O   ���#2C3E50$��Center=�6v   $��Center=�6�   5�   +    5�   *   P� 5�   .    �@J�IsMouseOver . . �5�   2   �� $  border��69   ! � ��" �#e0e0e06c   �� 5�   2   $  border��69   ! �@J�Effect" 5�   6   3  -System.Windows.Media.Effects.DropShadowEffect  5�   :   (   
BlurRadius$( 8Q�6K   )   ShadowDepth$) 2Q�6Z   *   Color$* Black��6j   +   Opacity$	+ 0.2Q�6x   5�   3   5�   /   P� 5�   .    � �� . . �5�   2   �� $  border��69   ! � ��" �#cfcfcf6c   5�   /   5�   '   5�      �� 5�      $��Nuevo recordatorio��6(   $��26(�6B   $
��Bold"�6P   ���#2C3E50$��Center=�6w   $
��0 20q�6�   �� 5�      $ Vertical=�6)   $��Center=�6@   $
��0 20q�6]   .+�5�   "   �� $��Titulo:��6,   $��19(�6;   $��10 0 0 5q�6I   �� 5�   "   -	   5        $# ErrorTitulo��5�   w   $��15(�6,   $��10 5 0 5q�6:   $y�	Collapsed=�6L   $
��Wrap=�6c   
���  ��$��Error��6�   �� 5�   "   ���#2C3E50, �� Padding$
, 0 20q�6>   $	��255��6M   $��4q�6Y   $ 10��6m   ._�5�   &   �� -
   5        - ��Name$- txtNota��5�   .   ���#fff)	  #MaterialDesignThemes.Wpf.HintAssist. 	  Hint$. Escribe algo...��6Q   / �� TextWrapping$
/ Wrap=�6�   0 �� 	MaxLength$0 50��6�   $��15(�6�   ���#2C3E50$��0q�6�   $	��230��6�   5�   #   5�      �� 5�      $ Vertical=�6)   $��Center=�6@   $��20 20q�6]   .+�5�   "   �� $��19(�6,   $��	10 0 0 10q�6:   $��Fecha:��6M   �� 5�   "   -   5        $# 
ErrorFecha��5�   ,   $
��Wrap=�6@   $��15(�6T   
���  ��$y�	Collapsed=�6s   $��0 3 0 10q�6�   $��Error��6�   �� 5�   "   $	��255��6)   $ 10��65   ���#2C3E50$��2q�6]   $, 10q�6q   ���#fff._�5�   &   (
  "System.Windows.Controls.DatePicker
  -   5        1 
 Name$1 fechaPicker��5�   y   $. Seleccione el calendario��61   $��15(�6k   $��0q�6�   |�.  6�   5�   #   5�      �� 5�      $ Vertical=�6)   $��Center=�6@   $��20 20q�6]   .+�5�   "   �� $��19(�6,   $��Hora:��6:   $��	10 0 0 10q�6G   �� 5�   "   -   5        $# 	ErrorHora��5�   @   $
��Wrap=�6,   $��15(�6S   $y�	Collapsed=�6a   $��	10 0 0 10q�6x   $��Error��6�   
���  ��6�   �� 5�   "   $, 10q�6)   ���#2C3E50$��2q�6L   $ 10��6`   $	��255��6r   ._�5�   &   � .+�5�   *   )  #MaterialDesignThemes.Wpf.TimePicker  -   5        2  Name$2 comboHoraMinuto��5�   �   $��0q�6D   $. Seleccione el reloj��6X   $��15(�6�   3   	Is24Hours3 . 6�   5�   '   5�   #   5�      �� 5�      -   5        $��	0 20 0 90q�5�   >   $
 Hand��6Q   $	��255��6_   $��40��6k   $��18(�6w   
�������$��Center=�6�   .��5�   "   �� $��Center=�6-   $ 
Horizontal=�6J   .+�5�   &   �� $��Guardar recordatorio��60   $��Center=�6L   
�������$��16(�6z   5�   #   ��5�   "   �� 5�   &   " ��66   .R�5�   *   �� $ ButtonBorder��6X   $ 10��61   ���#274C77._�5�   .   �� $��Center=�6?   $��Center=�6\   $
 Hand��6w   5�   +    5�   *   P� 5�   .    �@J�IsMouseOver . . �5�   2   �� $  ButtonBorder��69   ! � ��" �#1B263B6i   5�   /   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      