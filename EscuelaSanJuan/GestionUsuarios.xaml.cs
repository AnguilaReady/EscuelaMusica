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

    public partial class GestionUsuarios : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        ObservableCollection<Usuario> listaUsuario;
        private CollectionViewSource MiVista;
        private Usuario usuarioSeleccionado;
        public GestionUsuarios(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;

            listaUsuario = negocio.GetListaUsuarios();
            InitializeComponent();
            MiVista = (System.Windows.Data.CollectionViewSource)this.Resources["lista_Alumnos"];
            MiVista.Source = listaUsuario;
            MiVista.Filter += new FilterEventHandler(Filtrar);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usuarioSeleccionado = dataGrid.SelectedItem as Usuario;
            if (usuarioSeleccionado != null)
            {
                usuarioSelecionado.Text = "Usuario : " + usuarioSeleccionado.Usuarios;
                passSelecionado.Text = "PassWord : " + usuarioSeleccionado.Pass;

                editarPass.Text = usuarioSeleccionado.Pass;
            }
        }

        private void btnEditarTrasero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                usuarioSeleccionado.Pass = editarPass.Text;
            }
            catch (NullReferenceException) { }


            int modificaciones = negocio.ModificarUsuarios(usuarioSeleccionado);
            if (modificaciones > 0)
            {
                listaUsuario = negocio.GetListaUsuarios();
                MiVista.Source = null;
                MiVista.Source = listaUsuario;
                MandarMensaje("Usuario modificado");
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

        private void Filtrar(object sender, FilterEventArgs e)
        {
            Usuario empleado = (Usuario)e.Item;
            if (empleado != null)
            {
                e.Accepted = true;
            }
        }
        private void volver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            menuPrincipal.IsEnabled = true;
        }
    }
}
