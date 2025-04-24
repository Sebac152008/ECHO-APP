using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_ECHO.ViewModels;
using CommunityToolkit.WinUI.Notifications;

namespace WPF_ECHO
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // Establece el AppId para que los Toasts funcionen fuera de un paquete UWP
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                // Aquí puedes manejar clics si quieres
            };

            ToastNotificationManagerCompat.History.Clear(); // Limpia notificaciones previas

            base.OnStartup(e);
        }

    }
}
