   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	   $    EscuelaSanJuan.EmpleadoGestion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ EmpleadoGestion��5   	   $��608.714��6!   $��837.857��62    � 	Resources 5        lista_Alumnos �� Source��%&   &	       �� 5   
    67   �� 5      .��5      � .+�5   
   	� -   5         	�Name$ rbAlta��5      $��Empleados dados de Alta��6&   $
��Left=�6H   $��	37,29,0,0q�6c   $	��Top=�6v   6�   	� 5   
   -   5        $ rbBaja��5      $��Empleados dados de Baja��6&   $
��Left=�6H   $��	37,55,0,0q�6c   $	��Top=�6v   6�   �� 5   
   -   5         ��Name$ tbNombre��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Filtrar por Nombre��6$    % !MaterialDesignFloatingHintTextBox#��[ 6X   
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
  Mode$ PrimaryLight=�6/   $��Stretch=�6C   .��5>      �� -   5          ��Name$  imgenEmpleadoSelecionado��5>       $	��160��6B   $	��120��6N    5?      @� 5@   "   $ 60Q�62   $ 60Q�6?   $ 83.5,60&�6L   5B      5C      �� 5D      $��1��6!   $��Center=�6.   .+�5E      �� 6&   �� 5F      -   5        ! ��Name$! nombreEmpleadoSelecionado��5F   $   $
��Left=�6G   $��0 4 0 4q�6b   6u   �� 5G      -   5        $"! apellidosEmpleadoSelecionado��5G   $   $
��Left=�6J   $��0 4 0 4q�6e   6x   �� 5H      -	   5        $!! telefonoEmpleadoSelecionado��5H   $   $
��Left=�6I   $��0 4 0 4q�6d   6w   �� 5I      -
   5        $"! direccionEmpleadoSelecionado��5I   $   $
��Left=�6J   $��0 4 0 4q�6e   6x   �� 5J      -   5        " ��Name$" editarEmpleado��5J   !     MaterialDesignFlatButton#��[ 69   # 	  FlipCommand#��Z# 5K   !   $��0 15 0 0q�5L   !   $��Center=�5M   !   .��6?   EDITAR6G   5O      5P      $ 	  BackContent$ 5S      � 5T      $
��Auto��6   $
��Auto��6%    5U      �� 5V      $
��Auto �6(   �� 5W      $��* �6(   .+�5Y      
  $ Accent=�6/   $��6q�6=   .��5Z      �� % �� Orientation$% 
Horizontal=�6%   .+�5[      �� -   5         & "MaterialDesignToolForegroundButton#��[ 5[   %   #��Z# 5\   !   $
��Left=�5]   !   .��5^   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]&   Kind$& 	ArrowLeft=�6:   $��Right=�6K   5_      �� 5`      $��8 0 0 0q�6(   $��Center=�69   EDITAR EMPLEADO6e   5a      5b      � 5c      $��0 50 0 0q�6   $��Center=�6.   $	��Top=�6K   $	��172��6c    5d      �� 5e      �� 5f      �� 5g      �� 5h      .+�5j      �� -   5        $ editarNombre��5j   "   $	 Nombre��68   '   
IsFloating' . $��0 12 0 0q�6�   �� 5k      -   5        $ editarApellidos��5k   "   $��1��6;   $	 	Apellidos��6H   ' . $��0 12 0 0q�6�   �� 5l      -   5        $ editarTelefono��5l   "   $��2��6:   $	 Telefono��6G   ' . $��0 12 0 0q�6�   �� 5m      -   5        $ editarDireccion��5m   "   $��3��6;   $	 	Direccion��6H   ' . $��0 12 0 0q�6�   5n      5o      5q      �� 5r   
   -   5        $��Volver��5r      $
��Left=�6"   $��390,486,0,0q�6=   $	��Top=�6R   $��75��6j   6u   '  !MaterialDesignThemes.Wpf.Snackbar  5s   
   -   5        (  Name$( Snackbar��5s   O   $��2��6a   $��160,0q�6u   )   MessageQueue) 6"   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6u   5t      5u      