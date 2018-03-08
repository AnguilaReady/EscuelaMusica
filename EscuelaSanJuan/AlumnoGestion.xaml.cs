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
    public partial class AlumnoGestion : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        ObservableCollection<Alumno> listaAlumnos;
        private CollectionViewSource MiVista;
        private Alumno alumnoSeleccionado;
        public AlumnoGestion(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;

            negocio.borrarListaAlumnos();
            negocio.leerAlumnos();
            listaAlumnos = negocio.GetListaAlumnos();
            InitializeComponent();
            MiVista = (System.Windows.Data.CollectionViewSource)this.Resources["lista_Alumnos"];
            MiVista.Source = listaAlumnos;
            rbAlta.IsChecked = true;
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
                
                nombreAlumnoSelecionado.Text = "Nombre : "+alumnoSeleccionado.Nombre;
                apellidosAlumnoSelecionado.Text = "Apellidos : " + alumnoSeleccionado.Apellidos;
                telefonoAlumnoSelecionado.Text = "Telefono : " + alumnoSeleccionado.Telefono;
                direccionAlumnoSelecionado.Text = "Direccion : " + alumnoSeleccionado.Direccion;
                tutorAlumnoSelecionado.Text = "Tutor : " + alumnoSeleccionado.PersonaContacto;


                editarNombre.Text = alumnoSeleccionado.Nombre;
                editarApellidos.Text = alumnoSeleccionado.Apellidos;
                editarTelefono.Text = alumnoSeleccionado.Telefono;
                editarDireccion.Text = alumnoSeleccionado.Direccion;
            }
        }

        private void btnEditarTrasero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                alumnoSeleccionado.Nombre = editarNombre.Text;
                alumnoSeleccionado.Apellidos = editarApellidos.Text;
                alumnoSeleccionado.Telefono = editarTelefono.Text;
                alumnoSeleccionado.Direccion = editarDireccion.Text;

            }
            catch (NullReferenceException) { }
            

            int modificaciones = negocio.ModificarAlumno(alumnoSeleccionado);
            if(modificaciones>0)
            {
                listaAlumnos = negocio.GetListaAlumnos();
                MiVista.Source = null;
                MiVista.Source = listaAlumnos;
                MandarMensaje("Alumno modificado");
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
            Alumno alumno = (Alumno)e.Item;
            if (alumno != null)
            {
                if (alumno.Activo == true)
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
            Alumno alumno = (Alumno)e.Item;
            if (alumno != null)
            {
                if (alumno.Activo == false)
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
            Alumno alumno = (Alumno)e.Item;
            string nombre = tbNombre.Text;
            /*ComboBoxItem typeItem = (ComboBoxItem)cmbAsignatura.SelectedItem;
            string asignatura = typeItem.Content.ToString();
            ComboBoxItem typeItem2 = (ComboBoxItem)cmbAnoCurso.SelectedItem;
            string numero = typeItem2.Content.ToString();
            Console.WriteLine();*/

            if (alumno != null)
            {
                if (alumno.Nombre.Contains(nombre))
                {
                    e.Accepted = true;
                    /*if (asignatura != "")
                    {
                        if(alumno.Estudios==asignatura)
                        {
                            if(numero != "")
                            {
                                if(alumno.AnoCurso == Convert.ToInt32(numero) )
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
                    else
                    {
                        e.Accepted = true;
                    }*/
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

        private void cmbAnoCurso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MiVista.Filter += new FilterEventHandler(megafiltro);
            }
            catch (NullReferenceException) { }

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
