   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	   %    EscuelaSanJuan.ProfesorInsertar   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ ProfesorInsertar��5   	   $	��560��6"   $	��614��6/   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��303* �6   �� 5      $
��303* �6   .+�5   
   �� -   5         ��Name$ tbDni��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$	 Dni��6!    % !MaterialDesignFloatingHintTextBox#��[ 6F    J� RenderTransformOrigin$ 	0.506,0.4&�6�   $��36,149,24,0q�6�   $��39��6�   $	��Top=�6�   �� 5   
   -   5        $ tbNombre��5      $ Nombre��6$   #��[ 6L   $ 	0.506,0.4&�6�   $��36,193,24,0q�6�   $��38��6�   $	��Top=�6�   �� 5   
   -   5        $ tbApellidos��5      $ 	Apellidos��6'   #��[ 6R   $ 	0.506,0.4&�6�   $��36,236,24,0q�6�   $��38��6�   $	��Top=�6�   �� 5   
   -   5        $ 
tbTelefono��5      $ Telefono��6&   #��[ 6P   $ 	0.506,0.4&�6�   $��36,279,24,0q�6�   $��38��6�   $	��Top=�6�   �� 5   
   -   5        $ tbDireccion��5      $ 	Direccion��6'   #��[ 6R   $ 	0.506,0.4&�6�   $��36,322,24,0q�6�   $��38��6�   $	��Top=�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 dpFechaNacimiento��5      $ Fecha de Nacimiento��60    ( $MaterialDesignFloatingHintDatePicker#��[ 6e   $��29,191,38,0q�6�   $��37��6�   $	��Top=�6�   $��1��6�     5   
   -   5        $	 dpFechaAlta��5      $ Fecha de Alta��6*   #��[ 6Y   $��29,244,38,0q�6�   $��38��6�   $	��Top=�6�   $��1��6�   �� 5    
   -	   5        
 ��Name$
 cmbAsignatura��5       $ Asignatura a inscribir��6*    �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 6u   $��29,297,120,0q�6�   $	��Top=�6�   $��40��6�   $��1��6�   .@�5!      ��  �� 
IsSelected . .��6-   Piano5#      �� 5$      .��6   Violin5&      �� 5'      .��6   	saxofon5)      �� 5*      .��6   	Clarinete5,      5-      �� 5.   
   -
   5         ��Name$ btnInsertar��5.      $��Insertar��6&   $
��Left=�69   $��184,429,0,0q�6T   $	��Top=�6i   $��84��6�   6�   �� 5/   
   -   5        $ btnCancelar��5/      $��Cancelar��6&   $
��Left=�69   $��
29,429,0,0q�6T   $	��Top=�6h   $��90��6�   $��1��6�   �� 50   
   -   5         ��Name$ imagenAlumno��50      $!��imagenesPersonas/avatar.png��6&   $
��Left=�6K   $	��120��6f   $��
250,48,0,0q�6s   $	��Top=�6�   $	��120��6�   $��2��6�   �� 51   
   -   5        $ imagen2��51      $
��Left=�6!   $	��160��6<   $	��120��6H   $��
222,26,0,0q�6U   $	��Top=�6i   $��2��6�    J� Clip 52      @� 53       @� RadiusX$ 60Q�6"    @� RadiusY$ 60Q�6/    @� Center$ 83.5,60&�6<   55      �� 56   
   -   5        $ encenderCamara��56      ���#b39ddb � ToolTip$2 ,MaterialDesignFloatingActionMiniAccentButton��6>   $��189,74,74,419q�6u   $��0,0,0,0q�6�   $
��Auto��6�   .��57      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$! ArrowRightDropCircleOutline=�6&   $��24��6I   $��24��6U   58      �� 59   
   -   5        $ 	tomarFoto��59      ���#b39ddb$2 ,MaterialDesignFloatingActionMiniAccentButton��6:   $��81,74,184,419q�6q   $��0,0,0,0q�6�   $
��Auto��6�   $��1��6�   .��5:        $ 
CameraIris=�6&   $��24��68   $��24��6D   5;      '  !MaterialDesignThemes.Wpf.Snackbar  5<   
   -   5          Name$ Snackbar��5<   O   $��2��6a   $��160,0q�6u      MessageQueue 6"   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6u   5=      5>      