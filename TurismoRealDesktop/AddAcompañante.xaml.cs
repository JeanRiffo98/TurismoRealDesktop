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
    /// Lógica de interacción para AddAcompañante.xaml
    /// </summary>
    public partial class AddAcompañante : Window
    {
        public AddAcompañante(int idReserva)
        {
            InitializeComponent();
            this.IdReserva = idReserva;
        }

        public int IdReserva { get; set; }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            AcompañanteBLL acompañanteBLL1 = new AcompañanteBLL();
            AcompañanteBLL acompañanteBLL2 = new AcompañanteBLL();
            AcompañanteBLL acompañanteBLL3 = new AcompañanteBLL();
            AcompañanteBLL acompañanteBLL4 = new AcompañanteBLL();
            AcompañanteBLL acompañanteBLL5 = new AcompañanteBLL();

            if (txtRut1.Text != "" && txtNombres1.Text != "" && txtApellidos1.Text != "")
            {
                string rut = txtRut1.Text;
                string nombres = txtNombres1.Text;
                string apellidos = txtApellidos1.Text;

                acompañanteBLL1.InsertarAcompañante(rut, nombres, apellidos, IdReserva);

                if (listBox2.Visibility == Visibility.Visible && txtRut2.Text != "" && txtNombres2.Text != "" && txtApellidos2.Text != "")
                {
                    string rut2 = txtRut2.Text;
                    string nombres2 = txtNombres2.Text;
                    string apellidos2 = txtApellidos2.Text;

                    acompañanteBLL2.InsertarAcompañante(rut2, nombres2, apellidos2, IdReserva);

                    if (listBox3.Visibility == Visibility.Visible && txtRut3.Text != "" && txtNombres3.Text != "" && txtApellidos3.Text != "")
                    {
                        string rut3 = txtRut3.Text;
                        string nombres3 = txtNombres3.Text;
                        string apellidos3 = txtApellidos3.Text;

                        acompañanteBLL3.InsertarAcompañante(rut3, nombres3, apellidos3, IdReserva);

                        if (listBox4.Visibility == Visibility.Visible && txtRut4.Text != "" && txtNombres4.Text != "" && txtApellidos4.Text != "")
                        {
                            string rut4 = txtRut4.Text;
                            string nombres4 = txtNombres4.Text;
                            string apellidos4 = txtApellidos4.Text;

                            acompañanteBLL4.InsertarAcompañante(rut4, nombres4, apellidos4, IdReserva);

                            if (listBox5.Visibility == Visibility.Visible && txtRut5.Text != "" && txtNombres5.Text != "" && txtApellidos5.Text != "")
                            {
                                string rut5 = txtRut5.Text;
                                string nombres5 = txtNombres5.Text;
                                string apellidos5 = txtApellidos5.Text;

                                acompañanteBLL5.InsertarAcompañante(rut5, nombres5, apellidos5, IdReserva);
                            }
                        }
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Debes ingresar todos los campos", "Error al registrar", MessageBoxButton.OK);
            }
        }

        private void btnOneMore1_Click(object sender, RoutedEventArgs e)
        {
            listBox2.Visibility = Visibility.Visible;
        }

        private void btnOneMore2_Click(object sender, RoutedEventArgs e)
        {

            listBox3.Visibility = Visibility.Visible;
        }

        private void btnOneMore3_Click(object sender, RoutedEventArgs e)
        {
            listBox4.Visibility = Visibility.Visible;
        }

        private void btnOneMore4_Click(object sender, RoutedEventArgs e)
        {
            listBox5.Visibility = Visibility.Visible;
        }
    }
}
