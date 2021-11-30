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
    /// Lógica de interacción para AddConjunto.xaml
    /// </summary>
    public partial class AddConjunto : Window
    {
        public AddConjunto()
        {
            InitializeComponent();
            CargarDataGridVehiculos();
            CargarDataGridEstacionamientos();
            CargarDataGridTour();
            CalcularTotal();
        }

        private void cbxZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();

            string regionTransporte = cbxZona.Text;

            List<VehiculoTransporteBLL> listadoVehiculo = vehiculoTransporteBLL.TraerPorLugar(regionTransporte);
            dtgListTransporte.ItemsSource = listadoVehiculo;

            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();

            string regionEstacionamiento = cbxZona.Text;

            List<EstacionamientoBLL> listadoEstacionamiento = estacionamientoBLL.TraerPorZona(regionEstacionamiento);
            dtgListEstacionamiento.ItemsSource = listadoEstacionamiento;

            TourBLL tourBLL = new TourBLL();

            string regionTour = cbxZona.Text;

            List<TourBLL> listadoTour = tourBLL.TraerPorLugar(regionTour);
            dtgListTour.ItemsSource = listadoTour;
        }

        private void btnGoAddTransporte_Click(object sender, RoutedEventArgs e)
        {
            AddTransporte addTransporte = new AddTransporte();
            addTransporte.ShowDialog();
            CargarDataGridVehiculos();
        }

        private void btnGoAddEstacionamiento_Click(object sender, RoutedEventArgs e)
        {
            AddEstacionamiento addEstacionamiento = new AddEstacionamiento();
            addEstacionamiento.ShowDialog();
            CargarDataGridEstacionamientos();
        }

        private void btnGoAddTour_Click(object sender, RoutedEventArgs e)
        {
            AddTour addTour = new AddTour();
            addTour.ShowDialog();
            CargarDataGridTour();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            ConjuntoServicioBLL conjuntoServicioBLL = new ConjuntoServicioBLL();
            VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgListTransporte.SelectedItem;
            EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgListEstacionamiento.SelectedItem;
            TourBLL objTour = (TourBLL)dtgListTour.SelectedItem;

            if (txtNombre.Text == "" || txtCodigo.Text == "" || txtTotal.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos","Error al registrar",MessageBoxButton.OK);
            }
            else
            {
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                int total = int.Parse(txtTotal.Text);
                int idVehiculo = objVehiculo.Id;
                int idEstacionamiento = objEstacionamiento.Id;
                int idTour = objTour.Id;

                conjuntoServicioBLL.InsertarConjunto(codigo,nombre,total,idVehiculo,idEstacionamiento,idTour);

                MessageBox.Show("Conjunto registrado", "Registro exitoso", MessageBoxButton.OK);
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CargarDataGridVehiculos()
        {
            VehiculoTransporteBLL vehiculoTransporteBLL = new VehiculoTransporteBLL();

            List<VehiculoTransporteBLL> listadoVehiculo = vehiculoTransporteBLL.TraerTodos();

            dtgListTransporte.ItemsSource = listadoVehiculo;
        }

        private void CargarDataGridEstacionamientos()
        {
            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();

            List<EstacionamientoBLL> listadoEstacionamiento = estacionamientoBLL.TraerTodos();

            dtgListEstacionamiento.ItemsSource = listadoEstacionamiento;
        }

        private void CargarDataGridTour()
        {
            TourBLL tourBLL = new TourBLL();

            List<TourBLL> listadoTour = tourBLL.TraerTodos();

            dtgListTour.ItemsSource = listadoTour;
        }

        private void CalcularTotal()
        {
            if(dtgListEstacionamiento.SelectedItem == null && dtgListTour.SelectedItem == null && dtgListTransporte.SelectedItem == null)
            {
                txtTotal.Text = "0";
            }
            else if (dtgListEstacionamiento.SelectedItem != null && dtgListTour.SelectedItem == null && dtgListTransporte.SelectedItem == null)
            {
                EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgListEstacionamiento.SelectedItem;
                txtTotal.Text = objEstacionamiento.Precio.ToString();
            }
            else if (dtgListEstacionamiento.SelectedItem != null && dtgListTour.SelectedItem != null && dtgListTransporte.SelectedItem == null)
            {
                EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgListEstacionamiento.SelectedItem;
                TourBLL objTour = (TourBLL)dtgListTour.SelectedItem;

                int precio = objEstacionamiento.Precio + objTour.Precio;

                txtTotal.Text = precio.ToString();
            }
            else if (dtgListEstacionamiento.SelectedItem != null && dtgListTour.SelectedItem != null && dtgListTransporte.SelectedItem != null)
            {
                EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgListEstacionamiento.SelectedItem;
                TourBLL objTour = (TourBLL)dtgListTour.SelectedItem;
                VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgListTransporte.SelectedItem;

                int precio = objEstacionamiento.Precio + objTour.Precio + objVehiculo.Precio;

                txtTotal.Text = precio.ToString();
            }
            else if (dtgListEstacionamiento.SelectedItem == null && dtgListTour.SelectedItem != null && dtgListTransporte.SelectedItem == null)
            {
                TourBLL objTour = (TourBLL)dtgListTour.SelectedItem;
                txtTotal.Text = objTour.Precio.ToString();
            }
            else if (dtgListEstacionamiento.SelectedItem == null && dtgListTour.SelectedItem != null && dtgListTransporte.SelectedItem != null)
            {
                TourBLL objTour = (TourBLL)dtgListTour.SelectedItem;
                VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgListTransporte.SelectedItem;

                int precio = objTour.Precio + objVehiculo.Precio;

                txtTotal.Text = precio.ToString();
            }
            else if (dtgListEstacionamiento.SelectedItem != null && dtgListTour.SelectedItem == null && dtgListTransporte.SelectedItem != null)
            {
                EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgListEstacionamiento.SelectedItem;
                VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgListTransporte.SelectedItem;

                int precio = objEstacionamiento.Precio + objVehiculo.Precio;

                txtTotal.Text = precio.ToString();
            }
            else if (dtgListEstacionamiento.SelectedItem == null && dtgListTour.SelectedItem == null && dtgListTransporte.SelectedItem != null)
            {
                VehiculoTransporteBLL objVehiculo = (VehiculoTransporteBLL)dtgListTransporte.SelectedItem;

                txtTotal.Text = objVehiculo.Precio.ToString();
            }
        }

        private void dtgListTransporte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void dtgListEstacionamiento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void dtgListTour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CalcularTotal();
        }
    }
}
