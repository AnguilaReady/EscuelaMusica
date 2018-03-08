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
using Capa_Clases;
using Capa_Negocio;

namespace EscuelaSanJuan
{

    public partial class InsertarUsuario : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        public InsertarUsuario(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }

        private void insertar_Click(object sender, RoutedEventArgs e)
        {
            int insertar = 0;
            if(tbPass.Text==tbPass_Copy.Text)
            {
               insertar = negocio.insertarUsuario(new Usuario(tbUsuario.Text, tbPass.Text));
            }
            else
            {
                MandarMensaje("Las Contraseñas no son iguales");
            }

            if(insertar>0)
            {
                MandarMensaje("Usuario insertardo");
            }
            
        }

        private void volver_Click(object sender, RoutedEventArgs e)
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
    }
}

