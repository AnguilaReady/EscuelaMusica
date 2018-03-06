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
    public partial class ProfesorGestion : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        ObservableCollection<Profesor> listaProfesores;
        private CollectionViewSource MiVista;
        private Profesor profesorSeleccionado;
        public ProfesorGestion(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;

            listaProfesores = negocio.GetListaProfesores();
            InitializeComponent();
            MiVista = (System.Windows.Data.CollectionViewSource)this.Resources["lista_Alumnos"];
            MiVista.Source = listaProfesores;
            rbAlta.IsChecked = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            profesorSeleccionado = dataGrid.SelectedItem as Profesor;
            if (profesorSeleccionado != null)
            {
                string profesorImagen = profesorSeleccionado.Imagen;
                var uriSource = new Uri(profesorSeleccionado.Imagen, UriKind.Absolute);
                try
                {
                    imgenProfesorSelecionado.Source = new BitmapImage(uriSource);
                }
                catch (System.IO.DirectoryNotFoundException) { }

                nombreProfesorSelecionado.Text = "Nombre : " + profesorSeleccionado.Nombre;
                apellidosProfesorSelecionado.Text = "Apellidos : " + profesorSeleccionado.Apellidos;
                telefonoProfesorSelecionado.Text = "Telefono : " + profesorSeleccionado.Telefono;
                direccionProfesorSelecionado.Text = "Direccion : " + profesorSeleccionado.Direccion;
                asigauraProfesorSelecionado.Text = "Asginatura : " + profesorSeleccionado.Estudios;

                editarNombre.Text = profesorSeleccionado.Nombre;
                editarApellidos.Text = profesorSeleccionado.Apellidos;
                editarTelefono.Text = profesorSeleccionado.Telefono;
                editarDireccion.Text = profesorSeleccionado.Direccion;
                editarAsignatura.Text = profesorSeleccionado.Estudios;
            }
        }

        private void btnEditarTrasero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                profesorSeleccionado.Nombre = editarNombre.Text;
                profesorSeleccionado.Apellidos = editarApellidos.Text;
                profesorSeleccionado.Telefono = editarTelefono.Text;
                profesorSeleccionado.Direccion = editarDireccion.Text;
                profesorSeleccionado.Estudios = editarAsignatura.Text;
            }
            catch (NullReferenceException) { }


            int modificaciones = negocio.ModificarProfesor(profesorSeleccionado);
            if (modificaciones > 0)
            {
                listaProfesores = negocio.GetListaProfesores();
                MiVista.Source = null;
                MiVista.Source = listaProfesores;
                MandarMensaje("Profesor modificado");
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
            Profesor profesor = (Profesor)e.Item;
            if (profesor != null)
            {
                if (profesor.Activo == true)
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
            Profesor profesor = (Profesor)e.Item;
            if (profesor != null)
            {
                if (profesor.Activo == false)
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
            Profesor profesor = (Profesor)e.Item;
            string nombre = tbNombre.Text;
            ComboBoxItem typeItem = (ComboBoxItem)cmbAsignatura.SelectedItem;
            string asignatura = typeItem.Content.ToString().ToLower();
            Console.WriteLine();

            if (profesor != null)
            {
                if (profesor.Nombre.Contains(nombre))
                {
                    if (asignatura != "")
                    {
                        if (profesor.Estudios == asignatura)
                        {
                            e.Accepted = true;
                        }
                        else
                        {
                            e.Accepted = false;
                        }
                    }
                    else
                    {
                        e.Accepted = true;
                    }
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

        private void cmbAsignatura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MiVista.Filter += new FilterEventHandler(megafiltro);
            }
            catch (NullReferenceException) { }
        }
    }
}
