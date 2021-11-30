using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para AddReserva.xaml
    /// </summary>
    public partial class AddReserva : Window
    {
        public AddReserva()
        {
            InitializeComponent();
            txtFechaReserva.Text = DateTime.Now.ToString("dd-MM-yyyy");
            CargarDataGridPersona();
            CargarDataGridConjunto();
            CargarDataGridDepartamento();
        }

        private void btnGuardarReserva_Click(object sender, RoutedEventArgs e)
        {
            //Preparar datos de Reserva
            ReservaBLL reservaBLL = new ReservaBLL();
            PersonaBLL objpersonaBLL = (PersonaBLL)dtgListPersona.SelectedItem;
            DepartamentoBLL objdepartamentoBLL = (DepartamentoBLL)dtgListDepto.SelectedItem;
            ConjuntoServicioBLL objConjuntoBLL = (ConjuntoServicioBLL)dtgListConjunto.SelectedItem;
            
            string codigo;
            int precio;
            string fechaEntrada;
            string fechaSalida;
            string fechaReserva = txtFechaReserva.Text;
            int idPersona;
            int idConjunto;
            int idDepto;

            if(txtCodigo.Text == "" || dtFechaEntrada.Text == "" || dtFechaSalida.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos", "Error al registrar", MessageBoxButton.OK);
            }
            else
            {
                codigo = txtCodigo.Text;
                fechaEntrada = dtFechaEntrada.Text;
                fechaSalida = dtFechaSalida.Text;
                DateTime dateFechaSalida = DateTime.ParseExact(fechaSalida, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                DateTime dateEntrada = DateTime.ParseExact(fechaEntrada, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                int cantNoches = (dateFechaSalida - dateEntrada).Days;
                int valorTotal = (cantNoches * objdepartamentoBLL.PrecioNoche) + objConjuntoBLL.Total;
                double porcentaje = 0.2;
                precio = Convert.ToInt32(Math.Round(valorTotal*porcentaje));
                idPersona = objpersonaBLL.Id;
                idConjunto = objConjuntoBLL.Id;
                idDepto = objdepartamentoBLL.Id;

                reservaBLL.InsertarReserva(codigo, precio, fechaReserva, cantNoches, fechaEntrada, fechaSalida, idPersona, idConjunto, idDepto);

                MessageBox.Show("Reserva registrada exitosamente", "Reserva Creada", MessageBoxButton.OK);
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBuscarConjunto_Click(object sender, RoutedEventArgs e)
        {
            ConjuntoServicioBLL conjuntoServicioBLL = new ConjuntoServicioBLL();
            List<ConjuntoServicioBLL> listConjunto = new List<ConjuntoServicioBLL>();

            string nombre = txtNombreConjunto.Text;

            listConjunto = conjuntoServicioBLL.TraerPorNombre(nombre);

            dtgListConjunto.ItemsSource = listConjunto;
        }

        private void btnBuscarPersona_Click(object sender, RoutedEventArgs e)
        {
            PersonaBLL personaBLL = new PersonaBLL();
            List<PersonaBLL> listPersona = new List<PersonaBLL>();

            string rut = txtRutPersona.Text;

            listPersona = personaBLL.TraerPorRut(rut);

            dtgListPersona.ItemsSource = listPersona;
        }

        private void btnBuscarTituloDepto_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL departamentoBLL = new DepartamentoBLL();
            List<DepartamentoBLL> listDepartamento = new List<DepartamentoBLL>();

            string titulo = txtBuscarDepto.Text;
            listDepartamento = departamentoBLL.TraerPorTitulo(titulo);

            dtgListDepto.ItemsSource = listDepartamento;
        }

        private void btnGoAddPersona_Click(object sender, RoutedEventArgs e)
        {
            AddPersona addPersona = new AddPersona();
            addPersona.ShowDialog();
            CargarDataGridPersona();
            CargarDataGridConjunto();
            CargarDataGridDepartamento();
        }
        private void CargarDataGridPersona()
        {
            PersonaBLL personaBLL = new PersonaBLL();

            List<PersonaBLL> listadoPersona = personaBLL.TraerTodos();

            dtgListPersona.ItemsSource = listadoPersona;
        }
        private void CargarDataGridConjunto()
        {
            ConjuntoServicioBLL conjuntoServicioBLL = new ConjuntoServicioBLL();

            List<ConjuntoServicioBLL> listadoConjunto = conjuntoServicioBLL.TraerTodos();

            dtgListConjunto.ItemsSource = listadoConjunto;
        }
        private void CargarDataGridDepartamento()
        {
            DepartamentoBLL departamentoBLL = new DepartamentoBLL();

            List<DepartamentoBLL> listadoDeptos = departamentoBLL.TraerTodos();

            dtgListDepto.ItemsSource = listadoDeptos;
        }
    }
}
