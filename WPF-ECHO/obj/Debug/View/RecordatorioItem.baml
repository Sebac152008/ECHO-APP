   M S B A M L   `   `   `  ����?  ;ECHO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ECHO.View	ECHO.View  5           ECHO.View.RecordatorioItem   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      #localclr-namespace:ECHO.View  5      .��5
      �� $��50 20 50 20q�6   
�������  �� CornerRadius$  10��65    �� Padding$ 15q�6G   ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� .+�5      �� -   5         ��Name$ TxtNota��5      ���#2C3E50$��18(�6�   $
��Bold"�6�   $
��Wrap=�6�   ��6-   �� *Descripcion+ �� RelativeSource ��  �� AncestorType$ UserControlL�6�   �� 5       �� Orientation$ 
Horizontal=�6   $��0 5 0 0q�66   .+�5      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$ Calendar=�6#   $��15��63   $��0 10 0 0q�6>      
Foreground �#2C3E506P   �� 5      $��16(�6q   ���#2C3E50$��5,10,0,0q�6�   ��6    �� *Fecha+ �� $ UserControlL�6�     5      $ Circle=�6#   $��5��61   	   IconFont$	 Solid=�6;    �#2C3E50$��
10,10,10,0q�6a     5      $ Clock=�6#    �#2C3E50$��15��6E   $��	0 10 0 -1q�6P   �� 5      $��16(�6p   ���#2C3E50$��5,10,0,0q�6�   ��6    �� *Hora+ �� $ UserControlL�6�   5      5      �� 5      $��1��6   $ 
Horizontal=�6)   $	��Top=�6B   $��10,0,0,0q�6Z   .+�5      �� -   5        
 ��Name$
 btnDestacado��5      $��0,0,10,0q�6/   $��35��6A   $��35��6L   
������  � ToolTip$ Marcar como destacado��5   &   .��5       �� -   5         ��Name$ imgDestacado��5       $)��#/Imagenes/EstrellaVaciaAmarilla.png��62   $��25��6_   ��5!      �� 5"       �� 
TargetType" ��6*   .R�5#      ��  � Cursor$
 Hand��6%   ���#fff$  40��5$   +   ._�5%   "   �� $��Center=�63   $��Center=�5&   '   5'      5(      5*      �� 5,      -   5        $
 	btnEditar��5,      $��35��6,   $��35��67   
������ $��0q�5-   	   $ Editar recordatorio��6   .��5/        $	 Pen=�6#    �#26263B$��20��6C   ��50      �� 51      " ��6*   .R�52      �� $
 Hand��6%   ���#fff$  40��6E   ._�53   "   �� $��Center=�63   $��Center=�6P   54      55      57      �� 5:      -   5        $
 	btnBorrar��5:      $��35��6,   $��35��67   
������ $��0q�5;      $ Eliminar recordatorio��6!   .��5=        $ Trash=�6#    �#26263B$��20��6E   ��5>      �� 5?      " ��6*   .R�5@      �� $
 Hand��6%   ���#fff$  40��5A   +   ._�5B   "   �� $��Center=�63   $��Center=�5C   '   5D      5E      5G      5H      5J      5K      5L      