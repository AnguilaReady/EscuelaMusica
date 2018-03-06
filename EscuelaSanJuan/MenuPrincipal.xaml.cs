using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Capa_Negocio;
using Capa_Clases;

namespace EscuelaSanJuan
{
    public partial class MenuPrincipal : Window
    {
        private Negocio negocio;
        private Usuario usuario;
        public MenuPrincipal(Negocio negocio,Usuario usuario)
        {
            InitializeComponent();
            this.negocio = negocio;
            this.usuario = usuario;
            if(usuario.Usuarios=="admin")
            {
                gestion.Visibility= Visibility.Visible;
            }
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void insertarAlumno_Click(object sender, RoutedEventArgs e)
        {
            AlumnoInsertar ventana = new AlumnoInsertar(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void gestionarAlumno_Click(object sender, RoutedEventArgs e)
        {
            AlumnoGestion ventana = new AlumnoGestion(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void insertarProfesor_Click(object sender, RoutedEventArgs e)
        {
            ProfesorInsertar ventana = new ProfesorInsertar(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void gestionarProfesor_Click(object sender, RoutedEventArgs e)
        {
            ProfesorGestion ventana = new ProfesorGestion(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void insertarEmpelado_Click(object sender, RoutedEventArgs e)
        {
            EmpeladoInsertar ventana = new EmpeladoInsertar(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void gestionarEmpelado_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoGestion ventana = new EmpleadoGestion(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        
        private void insertarUsuario_Click(object sender, RoutedEventArgs e)
        {
            InsertarUsuario ventana = new InsertarUsuario(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void gestionarUsuario_Click(object sender, RoutedEventArgs e)
        {
            GestionUsuarios ventana = new GestionUsuarios(negocio, this);
            this.IsEnabled = false;
            ventana.Show();
        }

        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
