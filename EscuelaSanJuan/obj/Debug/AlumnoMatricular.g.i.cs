﻿#pragma checksum "..\..\AlumnoMatricular.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AD44F60020E88EFEB267C16C0498C394B5992E33"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using EscuelaSanJuan;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EscuelaSanJuan {
    
    
    /// <summary>
    /// AlumnoMatricular
    /// </summary>
    public partial class AlumnoMatricular : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNombre;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgenAlumnoSelecionado;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock nombreAlumnoSelecionado;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock apellidosAlumnoSelecionado;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editarAlumno;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbAsignatura;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbAnoCurso;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\AlumnoMatricular.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Snackbar Snackbar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EscuelaSanJuan;component/alumnomatricular.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AlumnoMatricular.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\AlumnoMatricular.xaml"
            ((EscuelaSanJuan.AlumnoMatricular)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\AlumnoMatricular.xaml"
            this.tbNombre.KeyUp += new System.Windows.Input.KeyEventHandler(this.tbNombre_KeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 30 "..\..\AlumnoMatricular.xaml"
            this.dataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgenAlumnoSelecionado = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.nombreAlumnoSelecionado = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.apellidosAlumnoSelecionado = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.editarAlumno = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            
            #line 90 "..\..\AlumnoMatricular.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEditarTrasero_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cmbAsignatura = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.cmbAnoCurso = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 123 "..\..\AlumnoMatricular.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Snackbar = ((MaterialDesignThemes.Wpf.Snackbar)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

