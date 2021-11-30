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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TurismoRealDesktopBLL;

namespace TurismoRealDesktop
{
    /// <summary>
    /// Lógica de interacción para Servicios.xaml
    /// </summary>
    public partial class Servicios : UserControl
    {
        public Servicios()
        {
            InitializeComponent();
            CargarDataGrid();
        }

        private void btnGoAddConjunto_Click(object sender, RoutedEventArgs e)
        {
            AddConjunto addConjunto = new AddConjunto();
            addConjunto.ShowDialog();
            CargarDataGrid();
        }

        private void btnGoUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            ConjuntoServicioBLL conjuntoServicioBLL = new ConjuntoServicioBLL();

            ConjuntoServicioBLL objConjuntoBLL = (ConjuntoServicioBLL)dtgConjunto.SelectedItem;

            int id = objConjuntoBLL.Id;

            conjuntoServicioBLL.EliminarConjunto(id);

            MessageBox.Show("Se ha eliminado el registro del conjunto", "Conjunto Eliminado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnServicioTransporte_Click(object sender, RoutedEventArgs e)
        {
            ServicioTransporte servicioTransporte = new ServicioTransporte();
            servicioTransporte.ShowDialog();
            CargarDataGrid();
        }

        private void btnServicioEstacionamiento_Click(object sender, RoutedEventArgs e)
        {
            ServicioEstacionamiento servicioEstacionamiento = new ServicioEstacionamiento();
            servicioEstacionamiento.ShowDialog();
            CargarDataGrid();
        }

        private void btnServicioTour_Click(object sender, RoutedEventArgs e)
        {
            ServicioTour servicioTour = new ServicioTour();
            servicioTour.ShowDialog();
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {

            ConjuntoServicioBLL conjuntoServicioBLL = new ConjuntoServicioBLL();

            List<ConjuntoServicioBLL> listadoConjunto = conjuntoServicioBLL.TraerTodos();

            dtgConjunto.ItemsSource = listadoConjunto;
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }
    }
}
