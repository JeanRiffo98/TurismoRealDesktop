using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para ImgDepartamento.xaml
    /// </summary>
    public partial class ImgDepartamento : Window
    {
        public ImgDepartamento(int id, string titulo)
        {
            InitializeComponent();
            this.IdDepto = id;
            txtBlockTitulo.Text = titulo;

            //CargarDataGrid();

        }

        public int IdDepto { get; set; }
        public string Titulo { get; set; }

        private void btnAddImg_Click(object sender, RoutedEventArgs e)
        {
            //Create open FileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            //DefaultExtension
            dlg.DefaultExt = ".png";
            //ExtensionOptions
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

            //Display OpenFileDialog
            Nullable<bool> result = dlg.ShowDialog();

            //Insert image
            if(result == true)
            {
                ImagenBLL imagenBLL = new ImagenBLL();

                byte[] array;
                string filename;

                filename = dlg.FileName;
                array = File.ReadAllBytes(filename);

                imagenBLL.InsertarImagen(array,this.IdDepto);
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún archivo o tiene un formato incompatible", "Error con la selección", MessageBoxButton.OK);
            }
        }

        private void CargarDataGrid()
        {
            //ImagenBLL imagenBLL = new ImagenBLL();

            //List<ImagenBLL> listadoImagenes = imagenBLL.TraerTodas();

            //byte[] imagen = imagenBLL.Imagen;

            //MemoryStream ms = new MemoryStream(imagen);
            //Image image =

            //if (listadoImagenes.Count <= 0)
            //{
            //    MessageBox.Show("Sin registros");
            //}
            //else
            //{
            //    dtgImagenes.ItemsSource = listadoImagenes;
            //}
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDeleteImg_Click(object sender, RoutedEventArgs e)
        {

            ImagenBLL imagenBLL = new ImagenBLL();

            ImagenBLL objImagenBLL = (ImagenBLL)dtgImagenes.SelectedItem;

            int id = objImagenBLL.Id;

            imagenBLL.EliminarImagen(id);

            MessageBox.Show("Se ha eliminado el registro de la imagen", "Imagen Eliminada", MessageBoxButton.OK);
        }
    }
}
