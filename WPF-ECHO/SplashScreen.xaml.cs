using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WPF_ECHO
{
    public partial class SplashScreen : Window
    {
        private DispatcherTimer timer;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            FadeOutSplash();
        }

        private void FadeOutSplash()
        {
            DoubleAnimation fadeOut = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            fadeOut.Completed += (s, e) =>
            {
                SplashImage.Visibility = Visibility.Collapsed;

                MainContent.Content = new View.MenuNav();
                MainContent.Visibility = Visibility.Visible;

                DoubleAnimation fadeIn = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromSeconds(1)
                };

                MainContent.BeginAnimation(OpacityProperty, fadeIn);
            };

            SplashImage.BeginAnimation(OpacityProperty, fadeOut);
        }

    }
}
