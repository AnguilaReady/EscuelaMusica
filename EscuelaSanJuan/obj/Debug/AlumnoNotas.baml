   M S B A M L   `   `   `  ����I  EEscuelaSanJuan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:EscuelaSanJuanEscuelaSanJuan  5   	        EscuelaSanJuan.AlumnoNotas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:EscuelaSanJuan     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ AlumnoNotas��5   	   $��608.714��6   $��903.857��6.    � 	Resources 5        lista_Alumnos �� Source��%&   &	       �� 5   
    67   �� 5      .��5      � .+�5   
   �� -   5         ��Name$ tbNombre��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Filtrar por Nombre��6$    % !MaterialDesignFloatingHintTextBox#��[ 6X   	 J� RenderTransformOrigin$	 	0.506,0.4&�6�   $��34,28,578,0q�6�   $��38��6�   $	��Top=�6�   6�   �� 5   
   -   5        
 ��Name$
 cmbAsignatura��5      $ Filtrar por Asignatura��6*    �� 
IsEditable .   & "MaterialDesignFloatingHintComboBox#��[ 6u   $��344,26,350,0q�6�   $	��Top=�6�   $��40��6�   .@�5      �� $�� ��6    �� 
IsSelected . 6&   �� 5      $��Piano��6   �� 5      $��Violin��6   �� 5      $��Saxofon��6   �� 5      $��	Clarinete��6   5       �� 5!   
   -   5        $
 cmbAnoCurso��5!      $ Filtrar por Curso��6(    .  #��[ 6n   $��588,26,130,0q�6�   $	��Top=�6�   $��40��6�   .@�5"      �� $�� ��6    . 6&   �� 5#      $��1��6   �� 5$      $��2��6   �� 5%      $��3��6   �� 5&      $��4��6   �� 5'      $��5��6   5(      &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ dataGrid��5)      $
��Left=�6c   $��	20,90,0,0q�6~   $	��860��6�      AutoGenerateColumns .   �� AlternationCount$ 1��5*         SelectionMode$ Single=�6&      SelectionUnit$ FullRow=�6=      CanUserResizeRows .  $	��379��5+   X   $	��Top=�6e   ��5)   %   ��  �� Source# [    Columns 5,      4  .System.Windows.Controls.DataGridTemplateColumn  5-      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header 5.      �� 5/      $��Imagen��6%      CellTemplate 51      �� 52      .R�53      �� $��64��6C   $��48��6N   ��6$   ��  �� Path$ Imagen� J� Clip 54   "   @� 55   &    @� RadiusX$ 24Q�66    @� RadiusY$ 24Q�6C    @� Center$ 32,24&�6P   57      58      5:      0  *System.Windows.Controls.DataGridTextColumn  5;      $ * 6E   $ Nombre��6O      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $ Nombre�6_     5<      $
 1.5* 6H   $ Apellido��6U    .  6%   �� $ 	Apellidos�6g     5=      $ * 6I   $ 
Asignatura��6S    .  6%   �� $ 
Asignatura�6g     5>      $ * 6G   $ Curso��6Q    .  6%   �� $ AnoCurso�6`     5?      $
 0.5* 6N   $	 1º��6[    6%   �� $ Primertrimestre�6[     5@      $
 0.5* 6O   $	 2º��6\    6%   �� $ Segundotrimestre�6\     5A      $
 0.5* 6N   $	 3º��6[    6%   �� $ Tercertrimestre�6[     5B      $ * 6I   $ Media��6S    .  6%   �� $ 
Notaglobal�6b   5E      �� 5F   
   -   5        $��Volver��5F      $
��Left=�6"   $��405,490,0,0q�6=   $	��Top=�6R   $��75��6j   6u   '	  !MaterialDesignThemes.Wpf.Snackbar	  5G   
   -   5         	 Name$ Snackbar��5G   O   $��2��6a   $��160,0q�6u     	  MessageQueue  6"   4
  .MaterialDesignThemes.Wpf.MessageQueueExtension
  6u   5H      5I      