   M S B A M L   `   `   `  ����?  ;ECHO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:ECHO.View	ECHO.View  5      (    "ECHO.View.EditarRecordatorioDialog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      c _MaterialDesignThemes.MahApps, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.2.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      %localclr-namespace:ECHO.View   5      .��5      � $	��300��6   $��20q�6     � RowDefinitions  5	   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� .+�5      �� $��Editar recordatorio��6   $
��23.2(�63   $
��Bold"�6C   $��Center=�6U   $��	0 10 0 20q�6r   5      �� 5   
   $��1��6   .+�5      �� $��Título��6   $��20(�6&   $
��Bold"�64   �� 5      -   5         ��Name$ txtNotaEditar��5      $��15(�5      $��0,10,0,5q�5       �� 	MaxLength$ 50��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Nota��5      �� 5      -   5         ��Name$ ErrorTituloEdit��5      $��14(�5      
���  ��$y�	Collapsed=�5       $��Error en el título��5!      $��0 10 0 0q�5"      �� 5%      $��Fecha��6   $��0,20,0,0q�6%   $��20(�67   $
��Bold"�6E   (  "System.Windows.Controls.DatePicker  5&      -   5          Name$ fechaEditar��5&      $��15(�5'      |�.  $ Seleccione el calendario��5)      $��0,10,0,5q�5*      �� 5+      -   5        $ ErrorFechaEdit��5+      $��14(�5,      
���  ��$y�	Collapsed=�5.      $��Error en la fecha��5/      $��0 10 0 0q�50      �� 53      $
��Hora��6   $��0,20,0,0q�6$   $��20(�66   $
��Bold"�6D   )  #MaterialDesignThemes.Wpf.TimePicker  54      -   5          Name$ 
horaEditar��54   (   $��15(�55   (   $ Seleccione el reloj��56   (   $��0,10,0,5q�57   (      	Is24Hours . 58   (   �� 59      -   5        $ ErrorHoraEdit��59      $
��Wrap=�5:      $��14(�5;      
���  ��$y�	Collapsed=�5=      $��Error en la hora��5>      $��0 10 0 0q�5?      �� 5B       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,20,0,0q�6N   .+�5C      �� $��Cancelar��6   ���#2C3E50
�������$��0,0,10,0q�5F      )  #MaterialDesignThemes.Wpf.DialogHost	   CloseDialogCommand#��Z	 5G      $��false��5H      �� 5J      -   5        $��Guardar��5J      ���#27AE60
�������5M      5N      5P      5Q      5R      