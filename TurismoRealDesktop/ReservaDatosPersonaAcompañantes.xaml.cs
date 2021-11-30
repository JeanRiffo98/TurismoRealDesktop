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
    /// Lógica de interacción para ReservaDatosPersonaAcompañantes.xaml
    /// </summary>
    public partial class ReservaDatosPersonaAcompañantes : Window
    {
        public ReservaDatosPersonaAcompañantes(int idReserva, int idPersona)
        {
            InitializeComponent();

            this.IdReserva = idReserva;
            this.IdPersona = idPersona;

            CargarDatosPersona();
            CargarDatosAcompañante();
        }

        public int IdReserva { get; set; }
        public int IdPersona { get; set; }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CargarDatosPersona()
        {
            PersonaBLL personaBLL = new PersonaBLL();

            List<PersonaBLL> objPersonaBLL = personaBLL.TraerPorId(this.IdPersona);

            lblRutPersona.Text = objPersonaBLL[0].Rut;
            lblNombresPersona.Text = objPersonaBLL[0].Nombres;
            lblApellidosPersona.Text = objPersonaBLL[0].Apellidos;
            lblTelefonoPersona.Text = objPersonaBLL[0].Telefono;
            lblCorreoPersona.Text = objPersonaBLL[0].Correo;
        }

        private void CargarDatosAcompañante()
        {
            AcompañanteBLL acompañanteBLL = new AcompañanteBLL();

            List<AcompañanteBLL> listadoAcompañantes = acompañanteBLL.TraerPorIdReserva(IdReserva);

            dtgAcompañantes.ItemsSource = listadoAcompañantes;
        }
    }
}
