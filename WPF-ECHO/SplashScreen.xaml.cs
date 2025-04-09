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
using System.Windows.Threading;

namespace WPF_ECHO
{
    /// <summary>
    /// Lógica de interacción para SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();


            // Inicia el splash screen al cargar la ventana
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(3) // Duración del splash screen
            };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                ShowMainContent(); // Mostrar el contenido principal
            };
            timer.Start();
        }


        private void ShowMainContent()
        {
            SplashGrid.Visibility = Visibility.Collapsed;  // Ocultar Splash Screen
            MainContent.Content = new View.MenuNav();       // Cargar MenuNav en MainContent
            MainContent.Visibility = Visibility.Visible;
        }

    }
}
