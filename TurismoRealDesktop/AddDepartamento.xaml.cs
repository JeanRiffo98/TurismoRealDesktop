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
    /// Lógica de interacción para AddDepartamento.xaml
    /// </summary>
    public partial class AddDepartamento : Window
    {
        public AddDepartamento()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL departamentoBLL = new DepartamentoBLL();

            int habitaciones;
            int baños;
            string wifi;
            int precioNoche;
            string fechaPublicacion = DateTime.Now.ToString("dd/MM/yyyy");
            string fechaAdquisicion;
            string disponibilidad;
            string titulo;
            string television;
            string descripcion;
            int cantPersonasMax;
            string direccion;
            int nroDepto;
            int cantCamas;
            string zonaDepto;

            if (cbxHabitaciones.SelectedItem == null || cbxBaños.SelectedItem == null || tglWifi.IsChecked == null || txtPrecio.Text == "" || dateFechaAdquisicion.SelectedDate == null || tglDisponibilidad.IsChecked == null || txtTitulo.Text == "" || tglTelevision.IsChecked == null || txtDescripcion.Text == "" || txtDireccion.Text == "" || txtNroDepto.Text == "" || cbxCantCamas.SelectedItem == null || cbxZonaDepto.SelectedItem == null)
            {
                MessageBox.Show("Debes ingresar todos los campos","Error al registrar",MessageBoxButton.OK);
            }
            else
            {
                habitaciones = int.Parse(cbxHabitaciones.Text);
                baños = int.Parse(cbxBaños.Text);
                if(tglWifi.IsChecked == true)
                {
                    wifi = "S";
                }
                else
                {
                    wifi = "N";
                }

                precioNoche = int.Parse(txtPrecio.Text);
                fechaAdquisicion = dateFechaAdquisicion.Text;

                if (tglDisponibilidad.IsChecked == true)
                {
                    disponibilidad = "S";
                }
                else
                {
                    disponibilidad = "N";
                }

                titulo = txtTitulo.Text;

                if (tglTelevision.IsChecked == true)
                {
                    television = "S";
                }
                else
                {
                    television = "N";
                }

                descripcion = txtDescripcion.Text;
                cantPersonasMax = int.Parse(cbxMaxPersonas.Text);
                direccion = txtDireccion.Text;
                nroDepto = int.Parse(txtNroDepto.Text);
                cantCamas = int.Parse(cbxCantCamas.Text);
                zonaDepto = cbxZonaDepto.Text;

                departamentoBLL.InsertarDepartamento(habitaciones, baños, wifi, precioNoche, fechaPublicacion, fechaAdquisicion, disponibilidad, titulo,descripcion, television, cantPersonasMax, direccion, nroDepto, cantCamas, zonaDepto);

                MessageBox.Show("Se publicó el departamento ingresado","Departamento Publicado",MessageBoxButton.OK);
                
                this.Close();
            }

        }
    }
}
