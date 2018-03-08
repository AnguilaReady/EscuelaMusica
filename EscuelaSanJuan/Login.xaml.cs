using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Capa_Negocio;
using Capa_Clases;
using System.Collections.ObjectModel;

namespace EscuelaSanJuan
{
    public partial class Login : Window
    {
        private Negocio negocio;
        private int count = 1;
        private ObservableCollection<Usuario> lista;
        public Login()
        {
            negocio = new Negocio();
            lista = negocio.GetListaUsuarios();
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsuario.Text == "")
            {
                MandarMensaje("El Usuario no puede estar vacio");
                //lblError.Content = "El Usuario no puede estar vacio";
            }

            else if (tbPass.Password.ToString() == "")
            {
                MandarMensaje("El PassWord no puede estar vacio");
                //lblError.Content = "El PassWord no puede estar vacio";
            }
 
            if(tbPass.Password.ToString() != "" && tbUsuario.Text != "")
            {
                foreach (Usuario u in lista)
                {
                    if (tbUsuario.Text == u.Usuarios && tbPass.Password.ToString() == u.Pass)
                    {
                        tbUsuario.Text = "";
                        tbPass.Password = "";
                        MenuPrincipal w = new MenuPrincipal(negocio, u);
                        this.Hide();
                        w.Show();
                    }
                }

                MandarMensaje("Lo has intentado " + count + " de 3");
                //lblError.Content = "Lo has intentado " + count + " de 3";
                count++;

                if (count == 4)
                {
                    this.Close();
                }
            }
        }

        public void MandarMensaje(String mensaje)
        {
            var messageQueue = Snackbar.MessageQueue;
            var message = mensaje;
            Task.Factory.StartNew(() => messageQueue.Enqueue(message));
        }
    }
}
