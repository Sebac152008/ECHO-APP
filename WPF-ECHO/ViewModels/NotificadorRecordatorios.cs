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

                var idsParaEliminar = new List<int>();

                string query = "SELECT * FROM Recordatorios";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fechaHora = Convert.ToDateTime(reader["Fecha"] + " " + reader["Hora"]);
                        TimeSpan diferencia = DateTime.Now - fechaHora;
                        int id = Convert.ToInt32(reader["ID_Recordatorios"]);

                        if (diferencia.TotalMinutes >= 1)
                        {
                            idsParaEliminar.Add(id); // eliminar sin notificar
                        }
                        else if (fechaHora <= DateTime.Now)
                        {
                            string nota = reader["Nota"].ToString();
                            MostrarNotificacion(nota);
                            idsParaEliminar.Add(id);
                        }
                    }
                }

                foreach (var id in idsParaEliminar)
                {
                    var deleteQuery = "DELETE FROM Recordatorios WHERE ID_Recordatorios = @id";
                    using (var deleteCommand = new SQLiteCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@id", id);
                        deleteCommand.ExecuteNonQuery();
                    }
                }
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al verificar recordatorios: {ex.Message}");
        }
    }

    private void MostrarNotificacion(string mensaje)
    {
        _mediaPlayer.Open(new Uri("C:\\Users\\Sebastian Cuevas\\Desktop\\ECHO-APP\\WPF-ECHO\\Sonidos\\alarma.mp3", UriKind.Absolute));
        _mediaPlayer.Play();

        Task.Delay(25000).ContinueWith(_ =>
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                _mediaPlayer.Stop();
            });
        });

        new ToastContentBuilder()
            .AddArgument("action", "abrir") // ← esto captura clic en cualquier parte del toast
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
            if (argumentos.Contains("action"))
            {
                string accion = argumentos["action"];

                if (accion == "detenerSonido" || accion == "abrir")
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        _mediaPlayer.Stop();
                    });
                }
            }
        };
    }


}