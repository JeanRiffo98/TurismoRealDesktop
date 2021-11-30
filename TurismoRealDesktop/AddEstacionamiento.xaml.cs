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
using TurismoRealDesktopBLL;

namespace TurismoRealDesktop
{
    /// <summary>
    /// Lógica de interacción para AddEstacionamiento.xaml
    /// </summary>
    public partial class AddEstacionamiento : Window
    {
        public AddEstacionamiento()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();

            string codigo = txtCodigo.Text;
            string zona = cbxRegion.Text;
            int piso = int.Parse(cbxPiso.Text);
            int precio = int.Parse(txtPrecio.Text);

            estacionamientoBLL.InsertarEstacionamiento(codigo,zona,piso,precio);

            MessageBox.Show("Se ha registrado el estacionamiento", "Estacionamiento Registrado", MessageBoxButton.OK);

            this.Close();
        }
    }
}
