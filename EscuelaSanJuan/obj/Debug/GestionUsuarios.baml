   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	   $    EscuelaSanJuan.GestionUsuarios   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ GestionUsuarios��5   	   $��459.857��6!   $	��501��62    � 	Resources 5        lista_Alumnos �� Source��%&   &	       �� 5   
    67   �� 5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $
��Left=�5      $��	24,30,0,0q�5      $	��242��5         AutoGenerateColumns .  	 �� AlternationCount$	 1��5      
   SelectionMode$
 Single=�5          SelectionUnit$ FullRow=�5!         CanUserResizeRows .     
IsReadOnly .  $	��272��5$      $	��Top=�5%      ��5   %   ��  �� Source# [    Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6G      Header$ Nombre��6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Usuarios�6Q     5(      $ * 6C   $ PassWord��6M    6%   �� $
 Pass�6M   5*      &   MaterialDesignThemes.Wpf.Flipper  5-   
   $��
292,30,0,0q�5.      $	��Top=�5/      $
��Left=�50      $	��272��51      $	��180��6      FrontContent 55      � 56      $
��Auto��6   $
��Auto��6%    � RowDefinitions 57      �� 58      $	��160 �6(   �� 59      $
��auto �6(   .+�5;      (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryLight=�6/   $��Stretch=�6C   .��5<      �� -   5         ��Name$ imgenEmpleadoSelecionado��5<       $	��160��6B   $	��120��6N   $!��imagenesPersonas/avatar.png��6[    J� Clip 5=      @� 5>   "    @� RadiusX$ 60Q�62    @� RadiusY$ 60Q�6?    @� Center$ 83.5,60&�6L   5@      5A      �� 5B      $��1��6!   $��Center=�6.   .+�5C      �� 6&   �� 5D      -   5         ��Name$ usuarioSelecionado��5D   $   $
��Left=�6@   $��0 4 0 4q�6[   6n   �� 5E      -   5        $ passSelecionado��5E   $   $
��Left=�6=   $��0 4 0 4q�6X   6k   �� 5F      -   5         ��Name$ editarEmpleado��5F   !     MaterialDesignFlatButton#��[ 69      FlipCommand#��Z 5G   !   $��0 15 0 0q�5H   !   $��Center=�5I   !   .��6?   EDITAR6G   5K      5L         BackContent 5O      � 5P      $
��Auto��6   $
��Auto��6%    5Q      �� 5R      $
��Auto �6(   �� 5S      $��* �6(   .+�5U        $ Accent=�6/   $��6q�6=   .��5V      ��   �� Orientation$  
Horizontal=�6%   .+�5W      �� -   5         & "MaterialDesignToolForegroundButton#��[ 5W   %   #��Z 5X   !   $
��Left=�5Y   !   .��5Z   "   '	  !MaterialDesignThemes.Wpf.PackIcon	  �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]! 
  Kind$! 	ArrowLeft=�6:   $��Right=�6K   5[      �� 5\      $��8 0 0 0q�6(   $��Center=�69   EDITAR USUARIO6d   5]      5^      � 5_      $��0 50 0 0q�6   $��Center=�6.   $	��Top=�6K   $	��172��6c    5`      �� 5a      .+�5c      �� -   5        " ��Name$" 
editarPass��5c   "   $��1��66   )  #MaterialDesignThemes.Wpf.HintAssist#   Hint$# Password��6C   $   
IsFloating$ . $��0 12 0 0q�6�   5d      5e      5g      '  !MaterialDesignThemes.Wpf.Snackbar  5h   
   -	   5        %  Name$% Snackbar��5h   O   $��2��6a   &   MessageQueue& 6"   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  6a   �� 5i   
   -
   5        $ volver��5i      $��Volver��6!   $
��Left=�62   $��210,324,0,0q�6M   $	��Top=�6b   $��75��6z   6�   5j      5k      