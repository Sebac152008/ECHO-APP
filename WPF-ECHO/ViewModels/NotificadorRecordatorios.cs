using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using CommunityToolkit.WinUI.Notifications;

public class NotificadorRecordatorios
{
    private DispatcherTimer _timer;
    private MediaPlayer _mediaPlayer = new MediaPlayer();
    private string connectionString;

    private static readonly string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECHO.db");

    public NotificadorRecordatorios()
    {
        connectionString = $"Data Source={dbPath};";

        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1)
        };
        _timer.Tick += VerificarRecordatorios;
    }

    public void Iniciar() => _timer.Start();
    public void Detener() => _timer.Stop();

    private void VerificarRecordatorios(object sender, EventArgs e)
    {
        var recordatoriosParaEliminar = new List<Tuple<int, string>>();

        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Recordatorios";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fechaHora = Convert.ToDateTime(reader["Fecha"] + " " + reader["Hora"]);
                        if (fechaHora <= DateTime.Now)
                        {
                            int id = Convert.ToInt32(reader["ID_Recordatorios"]);
                            string nota = reader["Nota"].ToString();
                            recordatoriosParaEliminar.Add(Tuple.Create(id, nota));
                        }
                    }
                }
            }

            foreach (var item in recordatoriosParaEliminar)
            {
                MostrarNotificacion(item.Item2);
                EliminarDeBD(item.Item1);

                // Recargar vistas
                Application.Current.Dispatcher.Invoke(() =>
                {
                    WPF_ECHO.View.InicioView.InstanciaActual?.RecargarRecordatorios();
                    WPF_ECHO.View.DestacadoView.InstanciaActual?.RecargarRecordatorios();
                });
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al verificar recordatorios: {ex.Message}");
        }
    }

    private void EliminarDeBD(int id)
    {
        try
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Recordatorios WHERE ID_Recordatorios = @id";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar recordatorio: {ex.Message}");
        }
    }

    private void MostrarNotificacion(string mensaje)
    {
        _mediaPlayer.Open(new Uri("C:\\Users\\Sebastian Cuevas\\Desktop\\ECHO-APP\\WPF-ECHO\\Sonidos\\alarma.mp3"));
        _mediaPlayer.Play();

        Task.Delay(25000).ContinueWith(_ =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _mediaPlayer.Stop();
            });
        });

        new ToastContentBuilder()
            .AddText(mensaje)
            .SetToastDuration(ToastDuration.Long)
            .AddButton(new ToastButton()
                .SetContent("Detener")
                .AddArgument("action", "detenerSonido")
                .SetBackgroundActivation())
            .Show();

        ToastNotificationManagerCompat.OnActivated += args =>
        {
            var argumentos = ToastArguments.Parse(args.Argument);
            if (argumentos.Contains("action") && argumentos["action"] == "detenerSonido")
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    _mediaPlayer.Stop();
                });
            }
        };
    }
}