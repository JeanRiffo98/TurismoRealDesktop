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
    /// Lógica de interacción para AddMantencion.xaml
    /// </summary>
    public partial class AddMantencion : Window
    {
        public AddMantencion(int idDepto, string titulo)
        {
            InitializeComponent();
            this.IdDepto = idDepto;
            this.Titulo = titulo;
            lblTituloDepto.Text = this.Titulo;
        }

        public int IdDepto { get; set; }
        public string Titulo { get; set; }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MantencionBLL mantencionBLL = new MantencionBLL();

            string enMantencion;
            string codigo;
            string descripcion;
            string fechaInicio;
            string fechaFin;
            int costo;
            int idDepto = IdDepto;

            if(btnActiva.IsChecked == null || txtDescripcion.Text == "" || dtFechaInicio.SelectedDate == null || dtFechaFin.SelectedDate == null || txtCosto.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos", "Error al registrar", MessageBoxButton.OK);
            }
            else
            {
                if (btnActiva.IsChecked == true)
                {
                    enMantencion = "S";
                }
                else
                {
                    enMantencion = "N";
                }

                codigo = txtCodigo.Text;
                descripcion = txtDescripcion.Text;
                fechaInicio = dtFechaInicio.Text;
                fechaFin = dtFechaFin.Text;
                costo = int.Parse(txtCosto.Text);

                mantencionBLL.InsertarMantencion(enMantencion, codigo, descripcion, fechaInicio, fechaFin, costo, idDepto);

                MessageBox.Show("Se ha registrado una nueva mantención para este departamento", "Mantencion registrada", MessageBoxButton.OK);
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
