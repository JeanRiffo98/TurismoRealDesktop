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
    /// Lógica de interacción para ServicioEstacionamiento.xaml
    /// </summary>
    public partial class ServicioEstacionamiento : Window
    {
        public ServicioEstacionamiento()
        {
            InitializeComponent();
        }

        private void btnGoEstacionamiento_Click(object sender, RoutedEventArgs e)
        {
            AddEstacionamiento addEstacionamiento = new AddEstacionamiento();
            addEstacionamiento.ShowDialog();
        }

        private void cbxZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();

            string region = cbxZona.Text;

            List<EstacionamientoBLL> listadoEstacionamiento = estacionamientoBLL.TraerPorZona(region);
            dtgEstacionamientos.ItemsSource = listadoEstacionamiento;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();
            EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgEstacionamientos.SelectedItem;

            int id = objEstacionamiento.Id;
            string codigo = objEstacionamiento.Codigo;
            string zona = objEstacionamiento.Zona;
            int piso = objEstacionamiento.Piso;
            int precio = objEstacionamiento.Precio;

            estacionamientoBLL.ActualizarEstacionamiento(id, codigo, zona, piso, precio);

            MessageBox.Show("Se han actualizado los datos del estacionamiento", "Estacionamiento actualizado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();
            EstacionamientoBLL objEstacionamiento = (EstacionamientoBLL)dtgEstacionamientos.SelectedItem;

            int id = objEstacionamiento.Id;

            estacionamientoBLL.EliminarEstacionamiento(id);

            MessageBox.Show("Se ha eliminado el estacionamiento", "Estacionamiento eliminado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            EstacionamientoBLL estacionamientoBLL = new EstacionamientoBLL();

            List<EstacionamientoBLL> listadoEstacionamiento = estacionamientoBLL.TraerTodos();

            dtgEstacionamientos.ItemsSource = listadoEstacionamiento;
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
