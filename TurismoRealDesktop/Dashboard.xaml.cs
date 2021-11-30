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
using System.Windows.Shapes;

namespace TurismoRealDesktop
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            //CargarTema();
        }

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Departamentos());
        }

        private void btnDepartamentos_Click(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Departamentos());
        }

        private void btnReservas_Click(object sender, RoutedEventArgs e)
        {

            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Reservas());
        }

        private void btnPersonas_Click(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Persona());
        }

        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {

            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Servicios());
        }

        private void btnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Departamentos());
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnTemaOscuro_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletteHelper.SetTheme(theme);
        }

        private void CargarTema()
        {
            //ITheme theme = paletteHelper.GetTheme();
            //if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            //{

            //    btnDepartamentos.Foreground = new SolidColorBrush(Colors.White);
            //    btnReservas.Foreground = new SolidColorBrush(Colors.White);
            //    btnPersonas.Foreground = new SolidColorBrush(Colors.White);
            //    btnServicios.Foreground = new SolidColorBrush(Colors.White);
            //    btnTemaOscuro.Foreground = new SolidColorBrush(Colors.White);
            //    btnConfiguracion.Foreground = new SolidColorBrush(Colors.White);
            //    btnSalir.Foreground = new SolidColorBrush(Colors.White);
            //}
            //else
            //{

            //    btnDepartamentos.Foreground = new SolidColorBrush(Colors.Black);
            //    btnReservas.Foreground = new SolidColorBrush(Colors.Black);
            //    btnPersonas.Foreground = new SolidColorBrush(Colors.Black);
            //    btnServicios.Foreground = new SolidColorBrush(Colors.Black);
            //    btnTemaOscuro.Foreground = new SolidColorBrush(Colors.Black);
            //    btnConfiguracion.Foreground = new SolidColorBrush(Colors.Black);
            //    btnSalir.Foreground = new SolidColorBrush(Colors.Black);

            //}
        }
    }
}
