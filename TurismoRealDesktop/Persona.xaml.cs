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
using TurismoRealDesktopBLL;

namespace TurismoRealDesktop
{
    /// <summary>
    /// Lógica de interacción para Persona.xaml
    /// </summary>
    public partial class Persona : UserControl
    {
        public Persona()
        {
            InitializeComponent();
            CargarDataGrid();
        }

        private void btnGoAddPersona_Click(object sender, RoutedEventArgs e)
        {
            AddPersona addPersonaBLL = new AddPersona();
            addPersonaBLL.ShowDialog();
            CargarDataGrid();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonaBLL personaBLL = new PersonaBLL();
            PersonaBLL objPersonaBLL = (PersonaBLL)dtgPersona.SelectedItem;

            string rut = objPersonaBLL.Rut;

            personaBLL.EliminarCliente(rut);
            CargarDataGrid();
        }

        private void CargarDataGrid()
        {
            PersonaBLL personaBLL = new PersonaBLL();

            List<PersonaBLL> listadoPersona = personaBLL.TraerTodos();

            dtgPersona.ItemsSource = listadoPersona;
        }

        private void btnGoAddCheckIn_Click(object sender, RoutedEventArgs e)
        {
            AddCheckIn addCheckIn = new AddCheckIn();
            addCheckIn.ShowDialog();
        }

        private void btnGoAddCheckOut_Click(object sender, RoutedEventArgs e)
        {
            PersonaBLL objPersona = (PersonaBLL)dtgPersona.SelectedItem;

            AddCheckOut addCheckOut = new AddCheckOut(objPersona.Id);
            addCheckOut.ShowDialog();
        }
    }
}
