using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace WPF_ECHO
{
    public partial class SplashScreen : Window
    {
        private DispatcherTimer timer;
        private double maxWidth = 580; // ancho máximo de la barra (ajusta si es necesario)

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Iniciar temporizador
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1); // velocidad de animación
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ProgressBar.Width < maxWidth)
            {
                ProgressBar.Width += 2.5; // incremento suave
            }
            else
            {
                timer.Stop();
                MostrarContenidoPrincipalConFade();
            }
        }

        private void MostrarContenidoPrincipalConFade()
        {
            SplashScree.Visibility = Visibility.Collapsed;

            // Mostrar contenido principal
            MainContent.Content = new View.MenuNav();
            MainContent.Visibility = Visibility.Visible;

            // Animar opacidad (fade in)
            DoubleAnimation fade = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(1)
            };
            MainContent.BeginAnimation(OpacityProperty, fade);
        }
    }
}
