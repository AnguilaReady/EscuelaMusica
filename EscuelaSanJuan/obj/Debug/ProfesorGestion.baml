   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	   $    EscuelaSanJuan.ProfesorGestion   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ ProfesorGestion��5   	   $��608.714��6!   $��837.857��62    � 	Resources 5        lista_Alumnos �� Source��%&   &	       �� 5   
    67   �� 5      .��5      � .+�5   
   	� -   5         	�Name$ rbAlta��5      $��Profesores dados de Alta��6&   $
��Left=�6I   $��	37,29,0,0q�6d   $	��Top=�6w   6�   	� 5   
   -   5        $ rbBaja��5      $��Profesores dados de Baja��6&   $
��Left=�6I   $��	37,55,0,0q�6d   $	��Top=�6w   6�   �� 5   
   -   5         ��Name$ tbNombre��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Filtrar por Nombre��6$    % !MaterialDesignFloatingHintTextBox#��[ 6X   
 J� RenderTransformOrigin$
 	0.506,0.4&�6�   $��231,19,381,0q�6�   $��38��6�   $	��Top=�6�   6�   �� 5   
   -   5         ��Name$ cmbAsignatura��5      $	 Filtrar por Asignatura��6*    �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 6u   $��482,17,154,0q�6�   $	��Top=�6�   $��40��6�   .@�5      �� $�� ��6    �� 
IsSelected . 6&   �� 5      $��Piano��6   �� 5      $��Violin��6   �� 5       $��saxofon��6   �� 5!      $��	Clarinete��6   5"      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ dataGrid��5$      $
��Left=�6c   $��	20,90,0,0q�6~   $	��517��6�      AutoGenerateColumns .   �� AlternationCount$ 1��5%         SelectionMode$ Single=�6&      SelectionUnit$ FullRow=�6=      CanUserResizeRows .     
IsReadOnly . $	��365��5&   j   $	��Top=�6w   ��5$   %   ��  �� Source# [    Columns 5'      4  .System.Windows.Controls.DataGridTemplateColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header 5)      �� 5*      $��Imagen��6%      CellTemplate 5,      �� 5-      .R�5.      �� $��64��6C   $��48��6N   ��6$   ��  �� Path$ Imagen� J� Clip 5/   "   @� 50   &    @� RadiusX$ 24Q�66    @� RadiusY$ 24Q�6C    @� Center$ 32,24&�6P   52      53      55      0  *System.Windows.Controls.DataGridTextColumn  56      $ * 6E   $ Nombre��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ Nombre�6O     57      $ 2* 6H   $ Apellido��6S    6%   �� $ 	Apellidos�6S   59      &	   MaterialDesignThemes.Wpf.Flipper	  5<   
   $��560,90,23,0q�6!   $	��Top=�66   $��Stretch=�6N   $	��365��6l     	  FrontContent  5>      � 5?      $
��Auto��6   $
��Auto��6%   ! � RowDefinitions! 5@      �� 5A      $	��160 �6(   �� 5B      $
��auto �6(   .+�5D      (
  "MaterialDesignThemes.Wpf.ColorZone
  " 
  Mode$" PrimaryLight=�6/   $��Stretch=�6C   .��5E      �� -   5        # ��Name$# imgenProfesorSelecionado��5E       $	��160��6B   $	��120��6N    5F      @� 5G   "   $ 60Q�62   $ 60Q�6?   $ 83.5,60&�6L   5I      5J      �� 5K      $��1��6!   $��Center=�6.   .+�5L      �� 6&   �� 5M      -   5        $ ��Name$$ nombreProfesorSelecionado��5M   $   $
��Left=�6G   $��0 4 0 4q�6b   6u   �� 5N      -	   5        $"$ apellidosProfesorSelecionado��5N   $   $
��Left=�6J   $��0 4 0 4q�6e   6x   �� 5O      -
   5        $!$ telefonoProfesorSelecionado��5O   $   $
��Left=�6I   $��0 4 0 4q�6d   6w   �� 5P      -   5        $"$ direccionProfesorSelecionado��5P   $   $
��Left=�6J   $��0 4 0 4q�6e   6x   �� 5Q      -   5        $!$ asigauraProfesorSelecionado��5Q   $   $
��Left=�6I   $��0 4 0 4q�6d   6w   �� 5R      -   5        % ��Name$% editarProfesor��5R   !     MaterialDesignFlatButton#��[ 69   & 	  FlipCommand#��Z& 5S   !   $��0 15 0 0q�5T   !   $��Center=�5U   !   .��6?   EDITAR6G   5W      5X      ' 	  BackContent' 5[      � 5\      $
��Auto��6   $
��Auto��6%   ! 5]      �� 5^      $
��Auto �6(   �� 5_      $��* �6(   .+�5a      
  $" Accent=�6/   $��6q�6=   .��5b      �� ( �� Orientation$( 
Horizontal=�6%   .+�5c      �� -   5         & "MaterialDesignToolForegroundButton#��[ 5c   %   #��Z& 5d   !   $
��Left=�5e   !   .��5f   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]])   Kind$) 	ArrowLeft=�6:   $��Right=�6K   5g      �� 5h      $��8 0 0 0q�6(   $��Center=�69   EDITAR PROFESOR6e   5i      5j      � 5k      $��0 50 0 0q�6   $��Center=�6.   $	��Top=�6K   $	��172��6c   ! 5l      �� 5m      �� 5n      �� 5o      �� 5p      �� 5q      �� 5r      .+�5t      �� -   5        $ editarNombre��5t   "   $	 Nombre��68   *   
IsFloating* . $��0 12 0 0q�6�   �� 5u      -   5        $ editarApellidos��5u   "   $��1��6;   $	 	Apellidos��6H   * . $��0 12 0 0q�6�   �� 5v      -   5        $ editarTelefono��5v   "   $��2��6:   $	 Telefono��6G   * . $��0 12 0 0q�6�   �� 5w      -   5        $ editarDireccion��5w   "   $��3��6;   $	 	Direccion��6H   * . $��0 12 0 0q�6�   �� 5x      -   5        $ cmbAsignatura2��5x   #   $��4��6;   $	 
Asignatura��6H    .  #��[ 6�   $��0,10,0,0q�6�   $
��Left=�6�   $��40��6�   $	��172��6�   .@�5y      �� $��Piano��6+    . 6;   �� 5z      $��Violin��6+   �� 5{      $��Saxofon��6+   �� 5|      $��	Clarinete��6+   5}      5~      5      5�      �� 5�   
   -   5        $��Volver��5�      $
��Left=�6"   $��390,486,0,0q�6=   $	��Top=�6R   $��75��6j   6u   '  !MaterialDesignThemes.Wpf.Snackbar  5�   
   -   5        +  Name$+ Snackbar��5�   O   $��2��6a   $��160,0q�6u   ,   MessageQueue, 6"   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6u   5�      5�      