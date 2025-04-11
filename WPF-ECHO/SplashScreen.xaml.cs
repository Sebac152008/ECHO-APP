using System;
using System.Windows;
using System.Windows.Threading;

namespace WPF_ECHO
{
    public partial class SplashScreen : Window
    {
        private DispatcherTimer timer;

        public SplashScreen()
        {
            InitializeComponent();

            // Configurar e iniciar el temporizador
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3); // tiempo que dura la pantalla de carga
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); // Detener el temporizador

            // Mostrar la ventana principal
            ShowMainContent();

            // Cerrar el splash screen
        }

        private void ShowMainContent()
        {
            SplashGrid.Visibility = Visibility.Collapsed;
            MainContent.Content = new View.MenuNav();     // Cargar MenuNav en MainContent
            MainContent.Visibility = Visibility.Visible;
        }
    }
}