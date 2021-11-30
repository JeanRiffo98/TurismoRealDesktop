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
    /// Lógica de interacción para Mantenciones.xaml
    /// </summary>
    public partial class Mantenciones : Window
    {
        public Mantenciones(int idDepto, string titulo)
        {
            InitializeComponent();
            this.IdDepto = idDepto;
            this.Titulo = titulo;
            CargarDataGrid();
        }

        public int IdDepto { get; set; }
        public string Titulo { get; set; }

        private void CargarDataGrid()
        {
            MantencionBLL mantencionBLL = new MantencionBLL();

            List<MantencionBLL> listadoMantenciones = mantencionBLL.TraerPorIdDepto(IdDepto);

            lblTituloDepto.Text = Titulo;
            dtgMantenciones.ItemsSource = listadoMantenciones;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }

        private void btnAddMantencion_Click(object sender, RoutedEventArgs e)
        {
            AddMantencion addMantencion = new AddMantencion(IdDepto,Titulo);
            addMantencion.ShowDialog();
            CargarDataGrid();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MantencionBLL mantencionBLL = new MantencionBLL();
            MantencionBLL objMantencionBLL = (MantencionBLL)dtgMantenciones.SelectedItem;

            int id = objMantencionBLL.Id;
            string enMantencion = objMantencionBLL.EnMantencion;
            string codigo = objMantencionBLL.Codigo;
            string descripcion = objMantencionBLL.Descripcion;
            string fechaInicio = objMantencionBLL.FechaInicio;
            string fechaFin = objMantencionBLL.FechaFin;
            int costo = objMantencionBLL.Costo;
            int idDepto = IdDepto;

            mantencionBLL.ActualizarMantencion(id, enMantencion, codigo, descripcion, fechaInicio, fechaFin, costo, idDepto);

            MessageBox.Show("Se ha actualizado el registro de mantención para este departamento", "Mantencion actualizada", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MantencionBLL mantencionBLL = new MantencionBLL();
            MantencionBLL objMantencionBLL = (MantencionBLL)dtgMantenciones.SelectedItem;

            int id = objMantencionBLL.Id;

            mantencionBLL.EliminarMantencion(id);

            MessageBox.Show("Se ha eliminado el registro de mantención para este departamento", "Mantencion eliminada", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void txtCodigoMantencion_TextChanged(object sender, TextChangedEventArgs e)
        {
            MantencionBLL mantencionBLL = new MantencionBLL();

            string codigo = txtCodigoMantencion.Text;

            List<MantencionBLL> listadoMantenciones = mantencionBLL.TraerPorCodigo(codigo);

            dtgMantenciones.ItemsSource = listadoMantenciones;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

            MantencionBLL mantencionBLL = new MantencionBLL();

            List<MantencionBLL> listadoMantencion = mantencionBLL.TraerPorCodigo(txtCodigoMantencion.Text);

            dtgMantenciones.ItemsSource = listadoMantencion;
        }
    }
}
