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
    /// Lógica de interacción para AddObjeto.xaml
    /// </summary>
    public partial class AddObjeto : Window
    {
        public AddObjeto(int idDepto, string titulo)
        {
            InitializeComponent();
            this.IdDepto = idDepto;
            this.Titulo = titulo;
            lblTitulo.Text = this.Titulo;
            txtFechaIngreso.Text = fechaIngreso;
        }

        public int IdDepto { get; set; }
        public string Titulo { get; set; }

        public string fechaIngreso = DateTime.Now.ToString("dd/MM/yyyy");

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            InventarioBLL inventarioBLL = new InventarioBLL();


            string nombre;
            string descripcion;
            string codigo;
            int cantidad;
            int costoIndividual;
            int idDepto = this.IdDepto;

            if(txtNombre.Text == "" || txtDescripcion.Text == "" || txtCodigo.Text == "" || txtCantidad.Text == "" || txtCostoUnidad.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos", "Error al registrar", MessageBoxButton.OK);
            }
            else
            {
                nombre = txtNombre.Text;
                descripcion = txtDescripcion.Text;
                codigo = txtCodigo.Text;
                cantidad = int.Parse(txtCantidad.Text);
                costoIndividual = int.Parse(txtCostoUnidad.Text);
                int costoTotal = int.Parse(txtCostoTotal.Text);
                inventarioBLL.InsertarObjeto(nombre, descripcion, codigo, cantidad, fechaIngreso, costoIndividual, costoTotal, idDepto);
            }

            MessageBox.Show("Se ha registrado un nuevo objeto en el inventario de este departamento", "Objeto registrado", MessageBoxButton.OK);
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CalcularTotal()
        {

            if(txtCantidad.Text == "" && txtCostoUnidad.Text == "")
            {
                txtCostoTotal.Text = "0";
            }
            else if (txtCantidad.Text != "" && txtCostoUnidad.Text == "")
            {
                txtCostoTotal.Text = txtCantidad.Text;
            }
            else if (txtCantidad.Text == "" && txtCostoUnidad.Text != "")
            {
                txtCostoTotal.Text = txtCostoUnidad.Text;
            }
            else if (txtCantidad.Text != "" && txtCostoUnidad.Text != "")
            {
                int cantidad = int.Parse(txtCantidad.Text);
                int costoUnidad = int.Parse(txtCostoUnidad.Text);
                txtCostoTotal.Text = (cantidad * costoUnidad).ToString();
            }
            
        }

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularTotal();
        }

        private void txtCostoUnidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalcularTotal();
        }
    }
}
