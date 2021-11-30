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
    /// Lógica de interacción para ServicioTransporte.xaml
    /// </summary>
    public partial class ServicioTransporte : Window
    {
        public ServicioTransporte()
        {
            InitializeComponent();
            CargarDataGrid();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGoAddTransporte_Click(object sender, RoutedEventArgs e)
        {
            AddTransporte addTransporte = new AddTransporte();
            addTransporte.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();
            VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgTransportes.SelectedItem;

            int id = objVehiculo.Id;
            int precio = objVehiculo.Precio;
            string lugar = objVehiculo.LugarCoordinacion;
            string patente = objVehiculo.Patente;
            string fechaHora = objVehiculo.FechaHora;

            vehiculoTransporteBLL.ActualizarVehiculo(id,precio,lugar,patente,fechaHora);


            MessageBox.Show("Se han actualizado los datos del transporte", "Transporte actualizado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();
            VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgTransportes.SelectedItem;

            int id = objVehiculo.Id;

            vehiculoTransporteBLL.EliminarVehiculo(id);


            MessageBox.Show("Se ha eliminado el transporte", "Transporte eliminado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();

            List<VehiculoTransporteBLL> listadoVehiculo = vehiculoTransporteBLL.TraerTodos();

            dtgTransportes.ItemsSource = listadoVehiculo;
        }

        private void cbxZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();

            string region = cbxZona.Text;

            List<VehiculoTransporteBLL> listadoVehiculo = vehiculoTransporteBLL.TraerPorLugar(region);
            dtgTransportes.ItemsSource = listadoVehiculo;
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }
    }
}
