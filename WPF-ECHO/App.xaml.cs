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
using System.Threading; // <-- Asegúrate de agregar esto

namespace WPF_ECHO
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static Mutex _mutex; // <-- Agrega esta línea

        protected override void OnStartup(StartupEventArgs e)
        {
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

            // ----- Control de instancia única -----
            const string mutexName = "ECHO";
            bool createdNew;
            _mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                Application.Current.Shutdown();
                return;
            }

            // ----- Toast Notifications -----
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Aquí puedes manejar los clics si quieres
            };

            ToastNotificationManagerCompat.History.Clear();

            // Llamar solo una vez al base
            base.OnStartup(e);
        }

    }
}
