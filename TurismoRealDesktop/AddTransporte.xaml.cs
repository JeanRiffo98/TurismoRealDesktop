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
    /// Lógica de interacción para AddTransporte.xaml
    /// </summary>
    public partial class AddTransporte : Window
    {
        public AddTransporte()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();

            string lugar;
            string patente;
            string fecha;
            string hora;
            string fechaHora;
            int precio;

            if (cbxRegion.SelectedItem == null || txtPatente.Text == "" || dateFechaCoordinacion.SelectedDate == null || cbxHora.SelectedItem == null || txtPrecio.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos", "Error al ingresar", MessageBoxButton.OK);
            }
            else
            {
                lugar = cbxRegion.Text;
                patente = txtPatente.Text;
                fecha = dateFechaCoordinacion.Text;
                hora = cbxHora.Text;
                fechaHora = fecha + " " + hora;
                precio = int.Parse(txtPrecio.Text);

                vehiculoTransporteBLL.InsertarVehiculo(precio, lugar, patente, fechaHora);

                MessageBox.Show("Se publicó el transporte", "Transporte Publicado", MessageBoxButton.OK);

                this.Close();
            }
        }
    }
}
