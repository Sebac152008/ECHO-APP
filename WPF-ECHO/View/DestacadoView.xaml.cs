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
using System.Data.SQLite;
using CommunityToolkit.WinUI.Notifications;
using Microsoft.Data.Sqlite;
using ECHO.View;
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Xml;

namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para MisRecordatoriosVIEW.xaml
    /// </summary>
    public partial class DestacadoView : UserControl
    {

        private DispatcherTimer _notificacionTimer;
        public DestacadoView()
        {
            InitializeComponent();
            RecordatorioEventAggregator.DestacadoToggled += OnDestacadoToggled;
            this.Loaded += DestacadoView_Loaded;
            this.Unloaded += DestacadoView_Unloaded;

            StartNotificacionTimer();  // Inicia el temporizador de notificación

        }

        private static readonly string dbPath =
        System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECHO.db");
        private static readonly string connectionString = $"Data Source={dbPath};";

        private void FondoImagen_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.Contains("ImagenFondoPrecargada"))
            {
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoPre"];
                FondoImagen.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Carga todos los recordatorios marcados como Destacado = 1
        /// </summary>
        /// 

        private void RecordatorioDesmarcadoDesdeItem(object sender, EventArgs e)
        {
            MostrarRecordatorioDesmarcado(); // Animación o mensaje que tengas para esto
        }

        private void MostrarRecordatorioDesmarcado()
        {
            MostrarMensaje("Recordatorio desmarcado", "EstrellaVaciaAmarilla.png");
        }



        private void DestacadoView_Loaded(object sender, RoutedEventArgs e)
        {
            CargarRecordatoriosDestacadosDesdeBD();
        }

        private void CargarRecordatoriosDestacadosDesdeBD()
        {
            StackPanelContenedor.Children.Clear(); // Limpiar cualquier item previo

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var selectQuery = "SELECT * FROM Recordatorios WHERE Destacado = 1"; // Obtener los destacados
                    using (var command = new SQLiteCommand(selectQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new RecordatorioItem
                            {
                                ID_Recordatorios = Convert.ToInt32(reader["ID_Recordatorios"]),
                                Descripcion = reader["Nota"].ToString(),
                                Fecha = reader["Fecha"].ToString(),
                                Hora = reader["Hora"].ToString()
                            };

                            // Suscribir a los eventos necesarios
                            item.RecordatorioDestacadoEvent += RecordatorioDesmarcadoDesdeItem;
                            item.EliminarRecordatorio += Recordatorio_EliminarRecordatorio; // Suscripción al evento de eliminación

                            // Inicializar el estado de destacado
                            item.SetEstaDestacadoDesdeBD(true);

                            // Suscribir al cambio de destacado
                            item.DestacadoCambiado += (s, esDestacado) =>
                            {
                                OnDestacadoToggled(item, esDestacado);
                            };

                            // Añadir a la interfaz de usuario (contenedor de destacados)
                            // Ahora:
                            StackPanelContenedor.Children.Insert(0, item);

                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Error de conexión a la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar destacados: {ex.Message}");
            }
        }



        private void MostrarRecordatorioEliminado()
        {
            MostrarMensaje("Recordatorio eliminado", "eliminar.png");
        }

        /* Estos son los mensajes que te dicen cuando añadiste o eliminaste y destacaste un recordatorio */

        private async void MostrarMensaje(string texto, string icono)
        {
            // Crear contenedor del mensaje
            Border borde = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(44, 62, 80)),
                CornerRadius = new CornerRadius(10),
                Margin = new Thickness(0, 5, 0, 0),
                Padding = new Thickness(10),
                Opacity = 0,
                Child = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Children =
            {
                new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/Imagenes/{icono}", UriKind.Absolute)),
                    Width = 24,
                    Height = 24,
                    Margin = new Thickness(0,0,10,0)
                },
                new TextBlock
                {
                    Text = texto,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 14,
                    TextWrapping = TextWrapping.Wrap
                }
            }
                }
            };

            StackMensajes.Children.Add(borde);

            // Animación de entrada (fade-in)
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            borde.BeginAnimation(Border.OpacityProperty, fadeIn);

            // Esperar 2.5 segundos
            await Task.Delay(2500);

            // Animación de salida (fade-out)
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(300));
            fadeOut.Completed += (s, e) => StackMensajes.Children.Remove(borde);
            borde.BeginAnimation(Border.OpacityProperty, fadeOut);
        }

        private void OnDestacadoToggled(RecordatorioItem item, bool isDestacado)
        {
            if (!item.IsDestacado)
            {
                StackPanelContenedor.Children.Remove(item);
                RecordatorioEventAggregator.OnRecordatorioDesdestacado(item);
            }
        }



        private void EliminarRecordatorioDeBD(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Recordatorios WHERE ID_Recordatorios = @id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            MessageBox.Show($"No se encontró ningún recordatorio con ID: {id} para eliminar.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el recordatorio: " + ex.Message);
            }
        }



        // Método para manejar la eliminación de un recordatorio
        // Método para manejar la eliminación de un recordatorio
        private async void Recordatorio_EliminarRecordatorio(object sender, EventArgs e)
        {
            var recordatorio = sender as RecordatorioItem;
            if (recordatorio == null) return;

            var dialogResult = await MaterialDesignThemes.Wpf.DialogHost.Show(
                new TextBlock
                {
                    Text = "¿Estás seguro de que deseas eliminar este recordatorio?",
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(20),
                    Width = 300
                },
                "MainDialogHost",
                (object s, DialogOpenedEventArgs args) =>
                {
                    var dialogGrid = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Children =
                        {
                    new TextBlock
                    {
                        Text = "¿Estás seguro de que deseas eliminar este recordatorio?",
                        TextWrapping = TextWrapping.Wrap,
                        Margin = new Thickness(20, 20, 20, 16)
                    },
                    new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        Children =
                        {
                            new Button
                            {
                                Content = "Cancelar",
                                Margin = new Thickness(0,0,8,0),
                                Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand,
                                CommandParameter = false
                            },
                            new Button
                            {
                                Content = "Eliminar",
                                Margin = new Thickness (10,10,8,10),
                                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0392B")),
                                Foreground = Brushes.White,
                                Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand,
                                CommandParameter = true
                            }
                        }
                    }
                        }
                    };

                    args.Session.UpdateContent(dialogGrid);
                });

            if (dialogResult is bool confirmado && confirmado)
            {
                EliminarRecordatorioDeBD(recordatorio.ID_Recordatorios);
                StackPanelContenedor.Children.Remove(recordatorio);
                MostrarRecordatorioEliminado();
            }
        }





        private void StartNotificacionTimer()
        {
            _notificacionTimer = new DispatcherTimer();
            _notificacionTimer.Interval = TimeSpan.FromMilliseconds(1);  // Verifica cada 1 milisegundo
            _notificacionTimer.Tick += NotificacionTimer_Tick;
            _notificacionTimer.Start();
        }

        private void NotificacionTimer_Tick(object sender, EventArgs e)
        {
            VerificarRecordatorios();
        }

        private void VerificarRecordatorios()
        {
            try
            {
                var recordatoriosParaEliminar = new List<(int id, string nota)>();

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    var selectQuery = "SELECT * FROM Recordatorios WHERE Destacado = 1";
                    using (var command = new SQLiteCommand(selectQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var fechaRecordatorio = Convert.ToDateTime(reader["Fecha"] + " " + reader["Hora"]);
                            if (fechaRecordatorio <= DateTime.Now)
                            {
                                int id = Convert.ToInt32(reader["ID_Recordatorios"]);
                                string nota = reader["Nota"].ToString();
                                recordatoriosParaEliminar.Add((id, nota));
                            }
                        }
                    }

                    // 🔁 Eliminar después de cerrar el lector
                    foreach (var (id, nota) in recordatoriosParaEliminar)
                    {
                        MostrarNotificacion(nota);
                        EliminarRecordatorioDeBD(id);
                        CargarRecordatoriosDestacadosDesdeBD();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Error de conexión a la base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar recordatorios: {ex.Message}");
            }
        }


        private void MostrarNotificacion(string mensaje)
        {
            new ToastContentBuilder()
                .AddText("Recordatorio")
                .AddText(mensaje)
                .Show(); // Muestra la notificación
        }


        private void DestacadoView_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_notificacionTimer != null)
            {
                _notificacionTimer.Stop();
                _notificacionTimer.Tick -= NotificacionTimer_Tick;
                _notificacionTimer = null;
            }
        }

    }

}
