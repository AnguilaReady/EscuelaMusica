   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	   "    EscuelaSanJuan.AlumnoGestion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ AlumnoGestion��5   	   $��608.714��6   $��837.857��60    � 	Resources 5        lista_Alumnos �� Source��%&   &	       �� 5   
    67   �� 5      .��5      � .+�5   
   	� -   5         	�Name$ rbAlta��5      $��Alumnos dado de Alta��6&   $
��Left=�6E   $��	37,29,0,0q�6`   $	��Top=�6s   6�   	� 5   
   -   5        $ rbBaja��5      $��Alumnos dados de baja��6&   $
��Left=�6F   $��	37,55,0,0q�6a   $	��Top=�6t   6�   �� 5   
   -   5         ��Name$ tbNombre��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Filtrar por Nombre��6$    % !MaterialDesignFloatingHintTextBox#��[ 6X   
 J� RenderTransformOrigin$
 	0.506,0.4&�6�   $��231,19,381,0q�6�   $��38��6�   $	��Top=�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�6c   $��	20,90,0,0q�6~   $	��517��6�      AutoGenerateColumns .   �� AlternationCount$ 1��5         SelectionMode$ Single=�6&      SelectionUnit$ FullRow=�6=      CanUserResizeRows .     
IsReadOnly . $	��365��5   j   $	��Top=�6w   ��5   %   ��  �� Source# [    Columns 5       4  .System.Windows.Controls.DataGridTemplateColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header 5"      �� 5#      $��Imagen��6%      CellTemplate 5%      �� 5&      .R�5'      �� $��64��6C   $��48��6N   ��6$   ��  �� Path$ Imagen� J� Clip 5(   "   @� 5)   &    @� RadiusX$ 24Q�66    @� RadiusY$ 24Q�6C    @� Center$ 32,24&�6P   5+      5,      5.      0  *System.Windows.Controls.DataGridTextColumn  5/      $ * 6E   $ Nombre��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ Nombre�6O     50      $ 2* 6H   $ Apellido��6S    6%   �� $ 	Apellidos�6S   52      &	   MaterialDesignThemes.Wpf.Flipper	  55   
   $��560,90,23,0q�6!   $	��Top=�66   $��Stretch=�6N   $	��365��6l    	  FrontContent 57      � 58      $
��Auto��6   $
��Auto��6%    � RowDefinitions 59      �� 5:      $	��160 �6(   �� 5;      $
��auto �6(   .+�5=      (
  "MaterialDesignThemes.Wpf.ColorZone
   
  Mode$ PrimaryLight=�6/   $��Stretch=�6C   .��5>      �� -   5          ��Name$  imgenAlumnoSelecionado��5>       $	��160��6@   $	��120��6L    5?      @� 5@   "   $ 60Q�62   $ 60Q�6?   $ 83.5,60&�6L   5B      5C      �� 5D      $��1��6!   $��Center=�6.   .+�5E      �� 6&   �� 5F      -   5        ! ��Name$! nombreAlumnoSelecionado��5F   $   $
��Left=�6E   $��0 4 0 4q�6`   6s   �� 5G      -   5        $ ! apellidosAlumnoSelecionado��5G   $   $
��Left=�6H   $��0 4 0 4q�6c   6v   �� 5H      -	   5        $! telefonoAlumnoSelecionado��5H   $   $
��Left=�6G   $��0 4 0 4q�6b   6u   �� 5I      -
   5        $ ! direccionAlumnoSelecionado��5I   $   $
��Left=�6H   $��0 4 0 4q�6c   6v   �� 5J      -   5        $! tutorAlumnoSelecionado��5J   $   $
��Left=�6D   $��0 4 0 4q�6_   6r   �� 5K      -   5        " ��Name$" editarAlumno��5K   !     MaterialDesignFlatButton#��[ 67   # 	  FlipCommand#��Z# 5L   !   $��0 15 0 0q�5M   !   $��Center=�5N   !   .��6?   EDITAR6G   5P      5Q      $ 	  BackContent$ 5T      � 5U      $
��Auto��6   $
��Auto��6%    5V      �� 5W      $
��Auto �6(   �� 5X      $��* �6(   .+�5Z      
  $ Accent=�6/   $��6q�6=   .��5[      �� % �� Orientation$% 
Horizontal=�6%   .+�5\      �� -   5         & "MaterialDesignToolForegroundButton#��[ 5\   %   #��Z# 5]   !   $
��Left=�5^   !   .��5_   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]&   Kind$& 	ArrowLeft=�6:   $��Right=�6K   5`      �� 5a      $��8 0 0 0q�6(   $��Center=�69   EDITAR ALUMNO6c   5b      5c      � 5d      $��0 50 0 0q�6   $��Center=�6.   $	��Top=�6K   $	��172��6c    5e      �� 5f      �� 5g      �� 5h      �� 5i      �� 5j      �� 5k      .+�5m      �� -   5        $ editarNombre��5m   "   $	 Nombre��68   '   
IsFloating' . $��0 12 0 0q�6�   �� 5n      -   5        $ editarApellidos��5n   "   $��1��6;   $	 	Apellidos��6H   ' . $��0 12 0 0q�6�   �� 5o      -   5        $ editarTelefono��5o   "   $��2��6:   $	 Telefono��6G   ' . $��0 12 0 0q�6�   �� 5p      -   5        $ editarDireccion��5p   "   $��3��6;   $	 	Direccion��6H   ' . $��0 12 0 0q�6�   5q      5r      5t      �� 5u   
   -   5        $��Volver��5u      $
��Left=�6"   $��390,486,0,0q�6=   $	��Top=�6R   $��75��6j   6u   '  !MaterialDesignThemes.Wpf.Snackbar  5v   
   -   5        (  Name$( Snackbar��5v   O   $��2��6a   $��160,0q�6u   )   MessageQueue) 6"   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6u   5w      5x      