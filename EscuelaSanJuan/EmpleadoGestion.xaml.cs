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
using System.Collections.ObjectModel;

namespace EscuelaSanJuan
{
    public partial class EmpleadoGestion : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        ObservableCollection<Empleado> listaEmpleado;
        private CollectionViewSource MiVista;
        private Empleado empleadoSeleccionado;
        public EmpleadoGestion(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;

            negocio.borrarListaEmpleados();
            negocio.leerEmpleados();
            listaEmpleado = negocio.GetListaEmpleados();
            InitializeComponent();
            MiVista = (System.Windows.Data.CollectionViewSource)this.Resources["lista_Alumnos"];
            MiVista.Source = listaEmpleado;
            rbAlta.IsChecked = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empleadoSeleccionado = dataGrid.SelectedItem as Empleado;
            if (empleadoSeleccionado != null)
            {
                string empleadoImagen = empleadoSeleccionado.Imagen;
                var uriSource = new Uri(empleadoSeleccionado.Imagen, UriKind.Absolute);
                try
                {
                    imgenEmpleadoSelecionado.Source = new BitmapImage(uriSource);
                }
                catch (System.IO.DirectoryNotFoundException) { }

                nombreEmpleadoSelecionado.Text = "Nombre : " + empleadoSeleccionado.Nombre;
                apellidosEmpleadoSelecionado.Text = "Apellidos : " + empleadoSeleccionado.Apellidos;
                telefonoEmpleadoSelecionado.Text = "Telefono : " + empleadoSeleccionado.Telefono;
                direccionEmpleadoSelecionado.Text = "Direccion : " + empleadoSeleccionado.Direccion;

                editarNombre.Text = empleadoSeleccionado.Nombre;
                editarApellidos.Text = empleadoSeleccionado.Apellidos;
                editarTelefono.Text = empleadoSeleccionado.Telefono;
                editarDireccion.Text = empleadoSeleccionado.Direccion;
            }
        }

        private void btnEditarTrasero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                empleadoSeleccionado.Nombre = editarNombre.Text;
                empleadoSeleccionado.Apellidos = editarApellidos.Text;
                empleadoSeleccionado.Telefono = editarTelefono.Text;
                empleadoSeleccionado.Direccion = editarDireccion.Text;
            }
            catch (NullReferenceException) { }


            int modificaciones = negocio.ModificarEmpleado(empleadoSeleccionado);
            if (modificaciones > 0)
            {
                listaEmpleado = negocio.GetListaEmpleados();
                MiVista.Source = null;
                MiVista.Source = listaEmpleado;
                MandarMensaje("Empleado modificado");
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

        private void FiltrarActivos(object sender, FilterEventArgs e)
        {
            Empleado empleado = (Empleado)e.Item;
            if (empleado != null)
            {
                if (empleado.Activo == true)
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void FiltrarBorrados(object sender, FilterEventArgs e)
        {
            Empleado empleado = (Empleado)e.Item;
            if (empleado != null)
            {
                if (empleado.Activo == false)
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        public void megafiltro(object sender, FilterEventArgs e)
        {
            Empleado empleado = (Empleado)e.Item;
            string nombre = tbNombre.Text;

            if (empleado != null)
            {
                if (empleado.Nombre.Contains(nombre))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void rbAlta_Checked(object sender, RoutedEventArgs e)
        {
            MiVista.Filter += new FilterEventHandler(FiltrarActivos);
        }

        private void rbBaja_Checked(object sender, RoutedEventArgs e)
        {
            MiVista.Filter += new FilterEventHandler(FiltrarBorrados);
        }

        private void tbNombre_KeyUp(object sender, KeyEventArgs e)
        {
            MiVista.Filter += new FilterEventHandler(megafiltro);
        }
    }
}
