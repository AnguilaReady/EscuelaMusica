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

namespace EscuelaSanJuan
{
    /// <summary>
    /// Lógica de interacción para GestionUsuarios.xaml
    /// </summary>
    public partial class GestionUsuarios : Window
    {
        Negocio negocio;
        private MenuPrincipal menuPrincipal;
        public GestionUsuarios(Negocio negocio, MenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            this.negocio = negocio;
            this.menuPrincipal = menuPrincipal;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            menuPrincipal.IsEnabled = true;
        }
    }
}
