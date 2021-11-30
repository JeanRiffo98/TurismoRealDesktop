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
    /// Lógica de interacción para Inventario.xaml
    /// </summary>
    public partial class Inventario : Window
    {
        public Inventario(int idDepto, string titulo)
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
            InventarioBLL inventarioBLL = new InventarioBLL();

            List<InventarioBLL> listadoInventario = inventarioBLL.TraerPorIdDepto(IdDepto);

            lblTituloDepto.Text = Titulo;
            dtgObjetos.ItemsSource = listadoInventario;
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }

        private void btnAddObjeto_Click(object sender, RoutedEventArgs e)
        {
            AddObjeto addObjeto = new AddObjeto(IdDepto,Titulo);
            addObjeto.ShowDialog();
            CargarDataGrid();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            InventarioBLL inventarioBLL = new InventarioBLL();
            InventarioBLL objInventarioBLL = (InventarioBLL)dtgObjetos.SelectedItem;

            int id = objInventarioBLL.Id;
            string nombre = objInventarioBLL.Nombre;
            string descripcion = objInventarioBLL.Descripcion;
            string codigo = objInventarioBLL.Codigo;
            int cantidad = objInventarioBLL.Cantidad;
            string fechaIngreso = objInventarioBLL.FechaIngreso;
            int costoIndividual = objInventarioBLL.CostoIndividual;
            int costoTotal = cantidad*costoIndividual;
            int idDepto = IdDepto;

            inventarioBLL.ActualizarObjeto(id,nombre, descripcion, codigo, cantidad, fechaIngreso, costoIndividual, costoTotal, idDepto);

            MessageBox.Show("Se han actualizado los datos del objeto en el inventario de este departamento", "Objeto actualizado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            InventarioBLL inventarioBLL = new InventarioBLL();
            InventarioBLL objInventarioBLL = (InventarioBLL)dtgObjetos.SelectedItem;

            int id = objInventarioBLL.Id;

            inventarioBLL.EliminarObjeto(id);

            MessageBox.Show("Se ha eliminado el objeto del inventario de este departamento", "Objeto eliminado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            InventarioBLL inventarioBLL = new InventarioBLL();

            List<InventarioBLL> listadoInventario = inventarioBLL.TraerPorNombre(txtNombreObjeto.Text);

            dtgObjetos.ItemsSource = listadoInventario;
        }
    }
}
