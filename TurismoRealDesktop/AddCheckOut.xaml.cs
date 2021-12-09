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
    /// Lógica de interacción para AddCheckIn.xaml
    /// </summary>
    public partial class AddCheckOut : Window
    {
        public AddCheckOut(int idPersona)
        {
            InitializeComponent();
            this.IdPersona = idPersona;
            txtCodigo.Text = "CHKOUT-" + RandomString(8);
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public int IdPersona { get; set; }
        public int IdCheckOut { get; set; }
        public byte[] Firma { get; set; }


        private string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnInsertarCheckOut_Click(object sender, RoutedEventArgs e)
        {
            CheckOutBLL checkOutBLL = new CheckOutBLL();
            List<CheckOutBLL> listCheckOut = new List<CheckOutBLL>();

            string fechaCheckOut = txtFecha.Text;
            int personaID = IdPersona;
            string llaves;

            if (tglLlaves.IsChecked == true)
            {
                llaves = "S";
            }
            else
            {
                llaves = "N";
            }
            string codigo = txtCodigo.Text;

            checkOutBLL.InsertarCheckOut(codigo, Firma, fechaCheckOut, personaID, llaves);

            listCheckOut = checkOutBLL.TraerPorCodigo(codigo);

            IdCheckOut = listCheckOut[0].Id;

            //Desbloquear resto de elementos
            HabilitarElementos();
            //Generar código random que empieza con un prefijo y darselo al textblock que muestra el código
            lblCodigo.Text = "MUL-" + RandomString(8);
        }

        private void btnAñadirMulta_Click(object sender, RoutedEventArgs e)
        {
            MultaBLL multaBLL = new MultaBLL();

            string estado = "Sin pagar";

            if (txtDescripcion.Text == "" || txtCosto.Text == "" || lblCodigo.Text == "")
            {
                MessageBox.Show("Debes ingresar todos los campos", "Error al registrar", MessageBoxButton.OK);
            }
            else
            {
                string descripcion = txtDescripcion.Text;
                int costo = int.Parse(txtCosto.Text);
                int idCheckOut = IdCheckOut;
                string codigo = lblCodigo.Text;

                multaBLL.InsertarMulta(descripcion, costo,idCheckOut,codigo,estado);
                LimpiarElementos();
                CargarDataGrid();
            }
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HabilitarElementos()
        {
            lblCodigo.IsEnabled = true;
            txtDescripcion.IsEnabled = true;
            txtCosto.IsEnabled = true;
            btnAñadirMulta.IsEnabled = true;
            dtgMultas.IsEnabled = true;
            btnPublicar.IsEnabled = true;
        }

        private void LimpiarElementos()
        {
            lblCodigo.Text = "MUL-" + RandomString(8);
            txtDescripcion.Text = "";
            txtCosto.Text = "";
        }

        private void CargarDataGrid()
        {
            MultaBLL multaBLL = new MultaBLL();
            List<MultaBLL> listMulta = new List<MultaBLL>();

            string estado = "Sin pagar";
            int idCheckOut = IdCheckOut;

            listMulta = multaBLL.TraerPorIdCheckOutEstado(idCheckOut, estado);

            dtgMultas.ItemsSource = listMulta;
        }

        private void btnAñadirFirma_Click(object sender, RoutedEventArgs e)
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
            if (result == true)
            {
                byte[] array;
                string filename;

                filename = dlg.FileName;
                array = File.ReadAllBytes(filename);

                Firma = array;
                txtRuta.Text = "Imagen: " + filename;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún archivo o tiene un formato incompatible", "Error con la selección", MessageBoxButton.OK);
            }
        }
    }
}
