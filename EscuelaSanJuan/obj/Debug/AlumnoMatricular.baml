   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	   %    EscuelaSanJuan.AlumnoMatricular   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ AlumnoMatricular��5   	   $��628.714��6"   $��767.857��63    � 	Resources 5        lista_Alumnos �� Source��%&   &	       �� 5   
    67   �� 5      .��5      � .+�5   
   �� -   5         ��Name$ tbNombre��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Filtrar por Nombre��6$    % !MaterialDesignFloatingHintTextBox#��[ 6X   	 J� RenderTransformOrigin$	 	0.506,0.4&�6�   $��43,13,491,0q�6�   $��38��6�   $	��Top=�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 dataGrid��5      $
��Left=�6c   $��	43,75,0,0q�6~   $	��401��6�      AutoGenerateColumns .   �� AlternationCount$ 1��5         SelectionMode$ Single=�6&      SelectionUnit$ FullRow=�6=      CanUserResizeRows .     
IsReadOnly . $	��365��5   j   $	��Top=�6w   ��5   %   ��  �� Source# [    Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5       ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header 5!      �� 5"      $��Imagen��6%      CellTemplate 5$      �� 5%      .R�5&      �� $��64��6C   $��48��6N   ��6$   ��  �� Path$ Imagen� J� Clip 5'   "   @� 5(   &    @� RadiusX$ 24Q�66    @� RadiusY$ 24Q�6C    @� Center$ 32,24&�6P   5*      5+      5-      0  *System.Windows.Controls.DataGridTextColumn  5.      $ * 6E   $ Nombre��6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ Nombre�6O     5/      $ 2* 6H   $ Apellido��6S    6%   �� $ 	Apellidos�6S   51      &	   MaterialDesignThemes.Wpf.Flipper	  54   
   $��
472,75,0,0q�6!   $	��Top=�65   $
��Left=�6M   $	��365��6h   $	��249��6u    	  FrontContent 56      � 57      $
��Auto��6   $
��Auto��6%    � RowDefinitions 58      �� 59      $	��160 �6(   �� 5:      $
��auto �6(   .+�5<      (
  "MaterialDesignThemes.Wpf.ColorZone
   
  Mode$ PrimaryLight=�6/   $��Stretch=�6C   .��5=      �� -   5         ��Name$ imgenAlumnoSelecionado��5=       $	��160��6@   $	��120��6L    5>      @� 5?   "   $ 60Q�62   $ 60Q�6?   $ 83.5,60&�6L   5A      5B      �� 5C      $��1��6!   $��Center=�6.   .+�5D      �� 6&   �� 5E      -   5          ��Name$  nombreAlumnoSelecionado��5E   $   $
��Left=�6E   $��0 4 0 4q�6`   6s   �� 5F      -   5        $   apellidosAlumnoSelecionado��5F   $   $
��Left=�6H   $��0 4 0 4q�6c   6v   �� 5G      -   5        ! ��Name$! editarAlumno��5G   !     MaterialDesignFlatButton#��[ 67   " 	  FlipCommand#��Z" 5H   !   $��0 15 0 0q�5I   !   $��Center=�5J   !   .��6?   EDITAR6G   5L      5M      # 	  BackContent# 5P      � 5Q      $
��Auto��6   $
��Auto��6%    5R      �� 5S      $
��Auto �6(   �� 5T      $��* �6(   .+�5V      
  $ Accent=�6/   $��6q�6=   .��5W      �� $ �� Orientation$$ 
Horizontal=�6%   .+�5X      �� -   5         & "MaterialDesignToolForegroundButton#��[ 5X   %   #��Z" 5Y   !   $
��Left=�5Z   !   .��5[   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]%   Kind$% 	ArrowLeft=�6:   $��Right=�6K   5\      �� 5]      $��8 0 0 0q�6(   $��Center=�69   MATRICULAR ALUMNO6g   5^      5_      � 5`      $��0 50 0 0q�6   $��Center=�6.   $	��Top=�6K   $	��172��6c    5a      �� 5b      �� 5c      �� 5d      �� 5e      �� 5f      �� 5g      .+�5j      �� -	   5        & ��Name$& cmbAsignatura��5j   #   $��1��6:   $ 
Asignatura��6G   ' �� 
IsEditable' .   & "MaterialDesignFloatingHintComboBox#��[ 6�   $��0,10,0,0q�6�   $
��Left=�6�   $��40��6�   $	��172��6�   .@�5k      �� $��Piano��6+   ( �� 
IsSelected( . 6;   �� 5l      $��Violin��6+   �� 5m      $��Saxofon��6+   �� 5n      $��	Clarinete��6+   5o      �� 5p      -
   5        $& cmbAnoCurso��5p   #   $��2��68   $ 
Asignatura��6E   ' .  #��[ 6�   $��0,10,0,0q�6�   $
��Left=�6�   $��40��6�   $	��172��6�   .@�5q      �� $��1��6+   ( . 67   �� 5r      $��2��6+   �� 5s      $��3��6+   �� 5t      $��4��6+   �� 5u      $��5��6+   5v      5w      5x      5z      �� 5{   
   -   5        $��Volver��5{      $
��Left=�6"   $��330,474,0,0q�6=   $	��Top=�6R   $��75��6j   6u   '  !MaterialDesignThemes.Wpf.Snackbar  5|   
   -   5        )  Name$) Snackbar��5|   O   $��2��6a   $��160,0q�6u   *   MessageQueue* 6"   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6u   5}      5~      