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
    /// Lógica de interacción para AddPersona.xaml
    /// </summary>
    public partial class AddPersona : Window
    {
        public AddPersona()
        {
            InitializeComponent();
        }

        private string RandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            int lengthParam = 15;


            PersonaBLL personaBLL = new PersonaBLL();

            string rut = txtRut.Text;
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string telefono = "+56 9 " + txtTelefono.Text;
            string correo = txtCorreo.Text;

            personaBLL.InsertarPersona(rut, nombres, apellidos, telefono, correo, RandomString(lengthParam));

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
