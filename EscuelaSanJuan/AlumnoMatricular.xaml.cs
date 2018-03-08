using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Capa_Clases;
using Capa_Negocio;

namespace EscuelaSanJuan
{
    /// <summary>
    /// Lógica de interacción para AlumnoMatricular.xaml
    /// </summary>
    public partial class AlumnoMatricular : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        private ObservableCollection<Alumno> listaAlumnos;
        private CollectionViewSource MiVista;
        private Alumno alumnoSeleccionado;

        public AlumnoMatricular(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;
            negocio.borrarListaAlumnos();
            negocio.leerAlumnos();
            listaAlumnos = negocio.GetListaAlumnos();
            InitializeComponent();
            MiVista = (System.Windows.Data.CollectionViewSource)this.Resources["lista_Alumnos"];
            MiVista.Source = listaAlumnos;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            alumnoSeleccionado = dataGrid.SelectedItem as Alumno;
            if (alumnoSeleccionado != null)
            {
                string alumnoImagen = alumnoSeleccionado.Imagen;
                var uriSource = new Uri(alumnoSeleccionado.Imagen, UriKind.Absolute);
                try
                {
                    imgenAlumnoSelecionado.Source = new BitmapImage(uriSource);
                }
                catch (System.IO.DirectoryNotFoundException) { }

                nombreAlumnoSelecionado.Text = "Nombre : " + alumnoSeleccionado.Nombre;
                apellidosAlumnoSelecionado.Text = "Apellidos : " + alumnoSeleccionado.Apellidos;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            menuPrincipal.IsEnabled = true;
        }

        public void MandarMensaje(String mensaje)
        {
            var messageQueue = Snackbar.MessageQueue;
            var message = mensaje;
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }

        public void megafiltro(object sender, FilterEventArgs e)
        {
            Alumno profesor = (Alumno)e.Item;
            string nombre = tbNombre.Text;

            if (profesor != null)
            {
                if (profesor.Nombre.Contains(nombre))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void tbNombre_KeyUp(object sender, KeyEventArgs e)
        {
            MiVista.Filter += new FilterEventHandler(megafiltro);
        }

        private void btnEditarTrasero_Click(object sender, RoutedEventArgs e)
        {
            int insertar = negocio.insertarMatricula(new Matriculado(
                alumnoSeleccionado.Dni,
                cmbAsignatura.Text.ToLower(),
                Convert.ToInt32(cmbAnoCurso.Text.ToLower())));

            if (insertar > 0)
            {
                MandarMensaje("Alumno matriculado");
            }
            else
            {
                MandarMensaje("El Alumno ya esta inscrito a esa asignatura");
            }
        }
    }
}
