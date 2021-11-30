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
    /// Lógica de interacción para Reservas.xaml
    /// </summary>
    public partial class Reservas : UserControl
    {
        public Reservas()
        {
            InitializeComponent();
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            ReservaBLL reservaBLL = new ReservaBLL();

            List<ReservaBLL> listadoReserva = reservaBLL.TraerTodos();
            dtgReservas.ItemsSource = listadoReserva;
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }

        private void btnGoAddReserva_Click(object sender, RoutedEventArgs e)
        {
            AddReserva addReserva = new AddReserva();
            addReserva.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            ReservaBLL reservaBLL = new ReservaBLL();
            ReservaBLL objReservaBLL = (ReservaBLL)dtgReservas.SelectedItem;

            int id = objReservaBLL.Id;
            string codigo = objReservaBLL.Codigo;
            int precio = objReservaBLL.Precio;
            string fechaReserva = objReservaBLL.FechaReserva;
            int cantNoches = objReservaBLL.CantNoches;
            string fechaEntrada = objReservaBLL.FechaEntrada;
            string fechaSalida = objReservaBLL.FechaSalida;
            int idPersona = objReservaBLL.IdPersona;
            int idConjunto = objReservaBLL.IdConjunto;
            int idDepto = objReservaBLL.IdDepto;

            reservaBLL.ActualizarReserva(id, codigo, precio, fechaReserva, cantNoches, fechaEntrada, fechaSalida, idPersona,idConjunto,idDepto);

            MessageBox.Show("Se han actualizado los datos de la reserva", "Reserva actualizada", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ReservaBLL reservaBLL = new ReservaBLL();
            ReservaBLL objReservaBLL = (ReservaBLL)dtgReservas.SelectedItem;

            int id = objReservaBLL.Id;

            reservaBLL.EliminarReserva(id);

            MessageBox.Show("Se ha eliminado la reserva", "Reserva eliminado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnShowPersona_Click(object sender, RoutedEventArgs e)
        {
            ReservaBLL objReservaBLL = (ReservaBLL)dtgReservas.SelectedItem;

            int idReserva = objReservaBLL.Id;
            int idPersona = objReservaBLL.IdPersona;

            ReservaDatosPersonaAcompañantes reservaDatosPersonaAcompañantes = new ReservaDatosPersonaAcompañantes(idReserva,idPersona);
            reservaDatosPersonaAcompañantes.ShowDialog();
            
        }

        private void txtCodigoReserva_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReservaBLL reservaBLL = new ReservaBLL();

            List<ReservaBLL> listadoReserva = reservaBLL.TraerPorCodigo(txtCodigoReserva.Text);

            dtgReservas.ItemsSource = listadoReserva;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ReservaBLL reservaBLL = new ReservaBLL();

            List<ReservaBLL> listadoReserva = reservaBLL.TraerPorCodigo(txtCodigoReserva.Text);

            dtgReservas.ItemsSource = listadoReserva;
        }

        private void btnAddAcompañante_Click(object sender, RoutedEventArgs e)
        {
            ReservaBLL objReservaBLL = (ReservaBLL)dtgReservas.SelectedItem;

            int id = objReservaBLL.Id;

            AddAcompañante addAcompañante = new AddAcompañante(id);
            addAcompañante.ShowDialog();

        }
    }
}
