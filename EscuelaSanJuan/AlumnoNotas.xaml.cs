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
using AForge.Video.DirectShow;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Threading;
using System.Threading;
using Microsoft.Win32;
using Capa_Negocio;
using Capa_Clases;
using System.Collections.ObjectModel;

namespace EscuelaSanJuan
{
    
    public partial class AlumnoNotas : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        ObservableCollection<Alumno_Notas> listaNotasAlumno;
        private CollectionViewSource MiVista;
        private Alumno_Notas alumnoSeleccionado;
        public AlumnoNotas(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;

            negocio.borrarListaAlumnos();
            negocio.leerAlumnos();
            listaNotasAlumno = negocio.GetListaNotasAlumnos();
            InitializeComponent();
            MiVista = (System.Windows.Data.CollectionViewSource)this.Resources["lista_Alumnos"];
            MiVista.Source = listaNotasAlumno;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*alumnoSeleccionado = dataGrid.SelectedItem as Alumno_Notas;
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
                telefonoAlumnoSelecionado.Text = "Telefono : " + alumnoSeleccionado.Telefono;
                direccionAlumnoSelecionado.Text = "Direccion : " + alumnoSeleccionado.Direccion;
                tutorAlumnoSelecionado.Text = "Tutor : " + alumnoSeleccionado.PersonaContacto;


                editarNombre.Text = alumnoSeleccionado.Nombre;
                editarApellidos.Text = alumnoSeleccionado.Apellidos;
                editarTelefono.Text = alumnoSeleccionado.Telefono;
                editarDireccion.Text = alumnoSeleccionado.Direccion;
            }*/
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
            Alumno_Notas alumno = (Alumno_Notas)e.Item;
            string nombre = tbNombre.Text;
            ComboBoxItem typeItem = (ComboBoxItem)cmbAsignatura.SelectedItem;
            string asignatura = typeItem.Content.ToString();
            ComboBoxItem typeItem2 = (ComboBoxItem)cmbAnoCurso.SelectedItem;
            string numero = typeItem2.Content.ToString();
            Console.WriteLine();

            if (alumno != null)
            {
                if (alumno.Nombre.Contains(nombre))
                {
                    if (asignatura != "")
                    {
                        if(alumno.Asignatura.Trim()==asignatura)
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
                    }
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
