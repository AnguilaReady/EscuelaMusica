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
        int notaGlobalAlumno;
        public AlumnoNotas(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;

            negocio.borrarListaNotasAlumnos();
            negocio.leerNotasAlumnos();
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
            Console.WriteLine();
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
            string nombre = tbNombre.Text.ToLower();
            ComboBoxItem typeItem = (ComboBoxItem)cmbAsignatura.SelectedItem;
            string asignatura = typeItem.Content.ToString().ToLower();
            ComboBoxItem typeItem2 = (ComboBoxItem)cmbAnoCurso.SelectedItem;
            string numero = typeItem2.Content.ToString();
            Console.WriteLine();

            if (alumno != null)
            {
                if (alumno.Nombre.ToLower().Contains(nombre))
                {
                    if (asignatura != "")
                    {
                        if(alumno.Asignatura.Trim().ToLower()==asignatura)
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

        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridRow dgr = e.Row;
            TextBox t = e.EditingElement as TextBox;
            DataGridColumn dgc = e.Column;
   
            string columnaModificada = dgc.Header.ToString();
            int dato= Convert.ToInt32(t.Text.ToString());

            if (columnaModificada == "1º")
            {
                if(dato<0 || dato>10)
                {
                    MandarMensaje("La nota tiene que estar entre 0 y 10");
                }
                else
                {
                    int notaGlobalAlumno = (dato + alumnoSeleccionado.Segundotrimestre + alumnoSeleccionado.Tercertrimestre) / 3;
                    int insercion1 = negocio.updatePrimerTrimestre(dato, alumnoSeleccionado);
                    int insercion2 = negocio.updateNotaGlobal(notaGlobalAlumno, alumnoSeleccionado);
                    if (insercion1 > 0 && insercion2 > 0)
                    {
                        MandarMensaje("Nota Guardada");
                    }
                }
                
                
            }
            if (columnaModificada == "2º")
            {
                if (dato < 0 || dato > 10)
                {
                    MandarMensaje("La nota tiene que estar entre 0 y 10");
                }
                else
                {
                    int notaGlobalAlumno = (alumnoSeleccionado.Primertrimestre + dato + alumnoSeleccionado.Tercertrimestre) / 3;
                    int insercion1 = negocio.updateSegundoTrimestre(dato, alumnoSeleccionado);
                    int insercion2 = negocio.updateNotaGlobal(notaGlobalAlumno, alumnoSeleccionado);
                    if (insercion1 > 0 && insercion2 > 0)
                    {
                        MandarMensaje("Nota Guardada");
                    }
                }
                
            }
            if (columnaModificada == "3º")
            {
                if (dato < 0 || dato > 10)
                {
                    MandarMensaje("La nota tiene que estar entre 0 y 10");
                }
                else
                {
                    int notaGlobalAlumno = (alumnoSeleccionado.Primertrimestre + alumnoSeleccionado.Segundotrimestre + dato) / 3;
                    int insercion1 = negocio.updateTercerTrimestre(dato, alumnoSeleccionado);
                    int insercion2 = negocio.updateNotaGlobal(notaGlobalAlumno, alumnoSeleccionado);
                    if (insercion1 > 0 && insercion2 > 0)
                    {
                        MandarMensaje("Nota Guardada");
                    }
                }
            }
            
            negocio.borrarListaNotasAlumnos();
            negocio.leerNotasAlumnos();
            listaNotasAlumno = negocio.GetListaNotasAlumnos();
            MiVista.Source = null;
            MiVista.Source = listaNotasAlumno;
        }

        private void dataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            alumnoSeleccionado = dataGrid.SelectedItem as Alumno_Notas;
        }
    }
}
