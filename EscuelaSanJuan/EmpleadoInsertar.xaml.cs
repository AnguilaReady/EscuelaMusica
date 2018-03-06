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

namespace EscuelaSanJuan
{
    
    public partial class EmpeladoInsertar : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;
        private String filePath;

        public object Bitmap { get; private set; }
        public EmpeladoInsertar(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            filePath = "";
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            //Si todos los campos necesarios estan rellenos  seguimos con la insercion
            if (tbDni.Text != "" && tbNombre.Text != "" && tbApellidos.Text != "" && tbTelefono.Text != ""
                && tbDireccion.Text != "" && dpFechaNacimiento.Text != "" && dpFechaAlta.Text != "")
            {
                //Si el filepath esta vacio es por que no quiere hacer una foto y ponemos la del avatar
                if (filePath == "")
                {
                    filePath = @"C:\Users\Portatil\Documents\GitHub\EscuelaSanJuan\EscuelaSanJuan\imagenesPersonas\avatar.png";
                }
                else
                {
                    //Si el filepath esta lleno es por que quiere insertar una foto
                    try
                    {
                        filePath += tbDni.Text + ".jpg";
                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imagen2.Source));
                        using (FileStream stream = new FileStream(filePath, FileMode.Create))
                            encoder.Save(stream);
                    }
                    catch (System.ArgumentNullException)
                    {
                        filePath = @"C:\Users\Portatil\Documents\GitHub\EscuelaSanJuan\EscuelaSanJuan\imagenesPersonas\avatar.png";
                    }
                }

                int inserciones = negocio.insertarEmpleado(new Empleado(tbDni.Text.ToLower(),
                    tbNombre.Text.ToLower(),
                    tbApellidos.Text.ToLower(),
                    dpFechaNacimiento.SelectedDate.Value.Date,
                    dpFechaAlta.SelectedDate.Value.Date,
                    tbTelefono.Text.ToLower(),
                    tbDireccion.Text.ToLower(),
                    filePath,
                    true));

                if (inserciones > 0)
                {
                    tbDni.Text = "";
                    tbNombre.Text = "";
                    tbApellidos.Text = "";
                    //Reiniciamos el dataPicker de la fecha del nacimiento
                    dpFechaNacimiento.SelectedDate = null;
                    dpFechaNacimiento.DisplayDate = DateTime.Today;
                    //Reiniciamos el dataPicker de la fecha del alta
                    dpFechaAlta.SelectedDate = null;
                    dpFechaAlta.DisplayDate = DateTime.Today;
                    tbTelefono.Text = "";
                    tbDireccion.Text = "";
                    filePath = "";
                    imagen2.Source = null;

                    MandarMensaje("Empelado Insertado");
                }
                else
                {
                    MandarMensaje("El Empleado ya existe");
                }
            }
            else
            {
                //Salta en el caso de que falte algun dato necesario
                if (tbDni.Text == "")
                {
                    MandarMensaje("Inserte el Dni porfavor");
                    tbDni.Focus();
                }
                else if (tbNombre.Text == "")
                {
                    MandarMensaje("Inserte el Nombre porfavor");
                    tbNombre.Focus();
                }
                else if (tbApellidos.Text == "")
                {
                    MandarMensaje("Inserte el Apellido porfavor");
                    tbApellidos.Focus();
                }
                else if (tbTelefono.Text == "")
                {
                    MandarMensaje("Inserte el Telefono porfavor");
                    tbTelefono.Focus();
                }
                else if (tbDireccion.Text == "")
                {
                    MandarMensaje("Inserte la Direccion porfavor");
                    tbDireccion.Focus();
                }
                else if (dpFechaNacimiento.Text == "")
                {
                    MandarMensaje("Inserte la Fecha de nacimiento porfavor");
                    dpFechaNacimiento.Focus();
                }
                else if (dpFechaAlta.Text == "")
                {
                    MandarMensaje("Inserte la Fecha de alta porfavor");
                    dpFechaAlta.Focus();
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            menuPrincipal.IsEnabled = true;
        }

        //Cuando le damos al boton de hacer arrancar la webcam
        private void encenderCamara_Click(object sender, RoutedEventArgs e)
        {
            if (webcam != null)
            {
                cam = new VideoCaptureDevice(webcam[0].MonikerString);
                cam.NewFrame += cam_NewFrame;
                cam.Start();
            }
            else
            {
                MandarMensaje("No se ha encontrado WebCam");
            }
        }

        //cuando le damos al boton de hacer una foto
        private void tomarFoto_Click(object sender, RoutedEventArgs e)
        {
            if (cam.IsRunning)
            {
                filePath = @"C:\Users\Portatil\Documents\GitHub\EscuelaSanJuan\EscuelaSanJuan\imagenesPersonas\";
                cam.Stop();
            }
        }

        //Metodo necesario para encender la webcam y relacionado con encenderCamara_Click
        public void cam_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            BitmapImage bi;
            using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
            {
                bi = ToBitmapImage(bitmap);
            }
            bi.Freeze();
            Dispatcher.BeginInvoke(new ThreadStart(delegate { imagen2.Source = bi; }));
        }

        //Metodo necesario para encender la webcam y relacionado con encenderCamara_Click
        public BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            return bi;
        }

        //Mensaje de error
        public void MandarMensaje(String mensaje)
        {
            var messageQueue = Snackbar.MessageQueue;
            var message = mensaje;
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }
    }
}
