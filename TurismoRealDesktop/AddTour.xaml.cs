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
    /// Lógica de interacción para AddTour.xaml
    /// </summary>
    public partial class AddTour : Window
    {
        public AddTour()
        {
            InitializeComponent();
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            TourBLL tourBLL = new TourBLL();

            if(txtPrecio.Text == "" || cbxRegion.SelectedItem == null || cbxHora.SelectedItem == null || dateFechaCoordinacion.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos","Error al registrar",MessageBoxButton.OK);
            }
            else
            {
                int precio = int.Parse(txtPrecio.Text);
                string lugar = cbxRegion.Text;
                string fecha = dateFechaCoordinacion.Text;
                string hora = cbxHora.Text;
                string fechaHora = fecha + " " + hora;

                tourBLL.InsertarTour(precio, lugar, fechaHora);
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
