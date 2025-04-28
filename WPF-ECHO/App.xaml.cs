using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_ECHO.ViewModels;
using CommunityToolkit.WinUI.Notifications;
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
            // ----- INICIO: Control de instancia única -----
            const string mutexName = "ECHO"; // Ponle un nombre único
            bool createdNew;

            _mutex = new Mutex(true, mutexName, out createdNew);

            if (!createdNew)
            {
                Application.Current.Shutdown(); // Cerramos esta nueva instancia
                return;
            }
            // ----- FIN: Control de instancia única -----

            // Toast Notifications - Deja tu código existente tal cual
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Aquí puedes manejar clics si quieres
            };

            ToastNotificationManagerCompat.History.Clear(); // Limpia notificaciones previas

            base.OnStartup(e);
        }
    }
}
