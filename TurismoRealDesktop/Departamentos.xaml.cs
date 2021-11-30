using MaterialDesignThemes.Wpf;
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
using Oracle.ManagedDataAccess.Client;
using System.Data;
using TurismoRealDesktopBLL;

namespace TurismoRealDesktop
{
    /// <summary>
    /// Lógica de interacción para Departamentos.xaml
    /// </summary>
    public partial class Departamentos : UserControl
    {
        public Departamentos()
        {
            InitializeComponent();
            //CargarTema();
            CargarDataGrid();
        }


        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void btnGoAddDepartamento_Click(object sender, RoutedEventArgs e)
        {
            AddDepartamento addDepartamento = new AddDepartamento();
            addDepartamento.ShowDialog();
            CargarDataGrid();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL departamentoBLL = new DepartamentoBLL();

            DepartamentoBLL objDepartamentoBLL = (DepartamentoBLL)dtgDeptos.SelectedItem;

            int id = objDepartamentoBLL.Id;
            int habitaciones = objDepartamentoBLL.Habitaciones;
            int baños = objDepartamentoBLL.Baños;
            string wifi = objDepartamentoBLL.Wifi;
            int precioNoche = objDepartamentoBLL.PrecioNoche;
            string fechaPublicacion = objDepartamentoBLL.FechaPublicacion;
            string fechaAdquisicion = objDepartamentoBLL.FechaAdquisicion;
            string disponibilidad = objDepartamentoBLL.Disponibilidad;
            string titulo = objDepartamentoBLL.Titulo;
            string television = objDepartamentoBLL.Television;
            string descripcion = objDepartamentoBLL.Descripcion;
            int cantPersonasMax = objDepartamentoBLL.CantPersonasMax;
            string direccion = objDepartamentoBLL.Direccion;
            int nroDepto = objDepartamentoBLL.NroDepto;
            int cantCamas = objDepartamentoBLL.CantCamas;
            string zonaDepto = objDepartamentoBLL.ZonaDepto;

            departamentoBLL.ActualizarDepartamento(id,habitaciones,baños,wifi,precioNoche,fechaPublicacion,fechaAdquisicion,disponibilidad,titulo,television,descripcion,cantPersonasMax,direccion,nroDepto,cantCamas,zonaDepto);


            MessageBox.Show("Se han actualizado los cambios en el departamento", "Departamento actualizado", MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL departamentoBLL = new DepartamentoBLL();

            DepartamentoBLL objDepartamentoBLL = (DepartamentoBLL)dtgDeptos.SelectedItem;

            int id = objDepartamentoBLL.Id;

            departamentoBLL.EliminarDepartamento(id);

            MessageBox.Show("Se ha eliminado el registro del departamento","Departamento Eliminado",MessageBoxButton.OK);

            CargarDataGrid();
        }

        private void CargarTema()
        {
            //ITheme theme = paletteHelper.GetTheme();
            //if (theme.GetBaseTheme() == BaseTheme.Dark)
            //{

            //    btnBuscar.Foreground = new SolidColorBrush(Colors.White);
            //    btnGoAddDepartamento.Foreground = new SolidColorBrush(Colors.White);
            //    btnUpdate.Foreground = new SolidColorBrush(Colors.White);
            //    btnDelete.Foreground = new SolidColorBrush(Colors.White);
            //    btnGoImagen.Foreground = new SolidColorBrush(Colors.White);
            //    btnGoMantencion.Foreground = new SolidColorBrush(Colors.White);
            //    btnGoInventory.Foreground = new SolidColorBrush(Colors.White);
            //    btnGoBalance.Foreground = new SolidColorBrush(Colors.White);
            //    txtNombreDepto.Background = new SolidColorBrush(Colors.White);
            //    dtgDeptos.Background = new SolidColorBrush(Colors.White);
            //}
            //else
            //{
            //    btnBuscar.Foreground = new SolidColorBrush(Colors.Black);
            //    btnGoAddDepartamento.Foreground = new SolidColorBrush(Colors.Black);
            //    btnUpdate.Foreground = new SolidColorBrush(Colors.Black);
            //    btnDelete.Foreground = new SolidColorBrush(Colors.Black);
            //    btnGoImagen.Foreground = new SolidColorBrush(Colors.Black);
            //    btnGoMantencion.Foreground = new SolidColorBrush(Colors.Black);
            //    btnGoInventory.Foreground = new SolidColorBrush(Colors.Black);
            //    btnGoBalance.Foreground = new SolidColorBrush(Colors.Black);
            //    txtNombreDepto.Background = new SolidColorBrush(Colors.Black);
            //    txtNombreDepto.Foreground = new SolidColorBrush(Colors.White);
            //    dtgDeptos.Background = new SolidColorBrush(Colors.Black);
            //    dtgDeptos.Foreground = new SolidColorBrush(Colors.White);
            //    dtgDeptos.RowBackground = new SolidColorBrush(Colors.White);

            //}
        }

        private void CargarDataGrid()
        {

            DepartamentoBLL departamentoBLL = new DepartamentoBLL();

            List<DepartamentoBLL> listadoDepartamentos = departamentoBLL.TraerTodos();

            dtgDeptos.ItemsSource = listadoDepartamentos;
        }

        private void btnLoadAll_Click(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
        }

        private void btnGoImagen_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL objDepartamentoBLL = (DepartamentoBLL)dtgDeptos.SelectedItem;

            int id = objDepartamentoBLL.Id;
            string titulo = objDepartamentoBLL.Titulo;

            ImgDepartamento imgDepartamento = new ImgDepartamento(id, titulo);
            imgDepartamento.ShowDialog();
        }

        private void btnGoMantencion_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL objDepartamentoBLL = (DepartamentoBLL)dtgDeptos.SelectedItem;

            int idDepto = objDepartamentoBLL.Id;
            string titulo = objDepartamentoBLL.Titulo;

            Mantenciones mantenciones = new Mantenciones(idDepto,titulo);
            mantenciones.ShowDialog();
        }

        private void btnGoInventory_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL objDepartamentoBLL = (DepartamentoBLL)dtgDeptos.SelectedItem;

            int idDepto = objDepartamentoBLL.Id;
            string titulo = objDepartamentoBLL.Titulo;

            Inventario inventario = new Inventario(idDepto, titulo);
            inventario.ShowDialog();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            DepartamentoBLL departamentoBLL = new DepartamentoBLL();

            List<DepartamentoBLL> listadoDepartamento = departamentoBLL.TraerPorTitulo(txtNombreDepto.Text);

            dtgDeptos.ItemsSource = listadoDepartamento;
        }
    }
}
