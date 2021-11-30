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
    /// Lógica de interacción para ServicioTour.xaml
    /// </summary>
    public partial class ServicioTour : Window
    {
        public ServicioTour()
        {
            InitializeComponent();
            CargarDataGrid();
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }

        private void btnGoTour_Click(object sender, RoutedEventArgs e)
        {
            AddTour addTour = new AddTour();
            addTour.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TourBLL tourBLL = new TourBLL();
            TourBLL objTour = (TourBLL)dtgTour.SelectedItem;

            int id = objTour.Id;
            int precio = objTour.Precio;
            string lugar = objTour.Lugar;
            string fechaHora = objTour.FechaHora;

            tourBLL.ActualizarTour(id,precio, lugar, fechaHora);

            MessageBox.Show("Se han actualizado los datos del tour", "Tour actualizado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TourBLL tourBLL = new TourBLL();
            TourBLL objTour = (TourBLL)dtgTour.SelectedItem;

            int id = objTour.Id;

            tourBLL.EliminarTour(id);

            MessageBox.Show("Se ha eliminado el tour", "Tour eliminado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void cbxZona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TourBLL tourBLL = new TourBLL();

            string region = cbxZona.Text;

            List<TourBLL> listadoTour = tourBLL.TraerPorLugar(region);
            dtgTour.ItemsSource = listadoTour;
        }

        private void CargarDataGrid()
        {
            TourBLL tourBLL = new TourBLL();

            List<TourBLL> listadoTour = tourBLL.TraerTodos();

            dtgTour.ItemsSource = listadoTour;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
