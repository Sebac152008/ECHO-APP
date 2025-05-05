using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_ECHO.ViewModels;
using CommunityToolkit.WinUI.Notifications;
using System.Windows.Media.Imaging;
using System.Threading;


namespace WPF_ECHO
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static Mutex _mutex; // <-- Agrega esta línea

        private NotificadorRecordatorios _notificador;

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            _notificador = new NotificadorRecordatorios();
            _notificador.Iniciar();

            // ----- Precargar imagen -----
            Uri uri = new Uri("pack://application:,,,/Imagenes/paulius-dragunas-Nhs0sLAn1Is-unsplash.jpg");
            BitmapImage precargada = new BitmapImage();
            precargada.BeginInit();
            precargada.CacheOption = BitmapCacheOption.OnLoad;
            precargada.UriSource = uri;
            precargada.EndInit();
            Application.Current.Resources["ImagenFondoPrecargada"] = precargada;

            // Precargar imagen de fondo destacado

            Uri uro = new Uri("pack://application:,,,/Imagenes/thomas-grams-QPlTXC8RMc0-unsplash.jpg");
            BitmapImage pre = new BitmapImage();
            pre.BeginInit(); // <- usar el objeto correcto
            pre.CacheOption = BitmapCacheOption.OnLoad;
            pre.UriSource = uro;
            pre.EndInit();
            Application.Current.Resources["ImagenFondoPre"] = pre;

            Uri urq = new Uri("pack://application:,,,/Imagenes/daniel-dorfer-dy50JugmL_g-unsplash.jpg");
            BitmapImage preca = new BitmapImage();
            preca.BeginInit(); // <- usar el objeto correcto
            preca.CacheOption = BitmapCacheOption.OnLoad;
            preca.UriSource = urq;
            preca.EndInit();
            Application.Current.Resources["ImagenFondo"] = preca;

            Uri urw = new Uri("pack://application:,,,/Imagenes/tim-mossholder-hF8nQraErwA-unsplash.jpg");
            BitmapImage preca_acerca = new BitmapImage();
            preca_acerca.BeginInit(); // <- usar el objeto correcto
            preca_acerca.CacheOption = BitmapCacheOption.OnLoad;
            preca_acerca.UriSource = urw;
            preca_acerca.EndInit();
            Application.Current.Resources["ImagenFondoAcerca"] = preca_acerca;

            // ----- Control de instancia única -----
            const string mutexName = "ECHO";
            bool createdNew;
            _mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                Application.Current.Shutdown();
                return;
            }
        }

    }
}
