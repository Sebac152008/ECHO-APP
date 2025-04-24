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
using ECHO.ViewModels;
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
            RecordatorioDestacado.Visibility = Visibility.Visible;

            var storyboard = (Storyboard)this.FindResource("MostrarMensaje");
            Storyboard.SetTarget(storyboard, RecordatorioDestacado);
            storyboard.Begin();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                var ocultar = (Storyboard)this.FindResource("OcultarMensaje");
                Storyboard.SetTarget(ocultar, RecordatorioDestacado);
                ocultar.Begin();
            };
            timer.Start();
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
            // Hacer visible el mensaje de eliminación
            RecordatorioEliminado.Visibility = Visibility.Visible;

            // Obtener la animación definida en XAML para mostrar el mensaje
            var sb = (Storyboard)Resources["MostrarMensaje"];
            Storyboard.SetTarget(sb, RecordatorioEliminado);
            sb.Begin();

            // Temporizador para ocultar el mensaje después de 2 segundos
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                var hide = (Storyboard)Resources["OcultarMensaje"];
                Storyboard.SetTarget(hide, RecordatorioEliminado);
                hide.Begin();
            };
            timer.Start();
        }




        private void OnDestacadoToggled(RecordatorioItem item, bool isDestacado)
        {
            // 1) Quitarlo de su padre actual
            var parent = LogicalTreeHelper.GetParent(item) as  Panel;
            if (parent != null)
            {
                parent.Children.Remove(item);
            }

            // 2) Si está destacado, añadirlo a DestacadoView
            if (isDestacado)
            {
                StackPanelContenedor.Children.Insert(0, item);
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
        private void Recordatorio_EliminarRecordatorio(object sender, EventArgs e)
        {
            // Convierte el sender a un RecordatorioItem
            var item = sender as RecordatorioItem;

            // Si el item es null (por alguna razón), salimos
            if (item == null)
                return;

            // Mostrar un cuadro de mensaje de confirmación para eliminar
            var resultado = System.Windows.MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este recordatorio?",
                "Confirmar eliminación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            // Si el usuario confirma, eliminamos el recordatorio
            if (resultado == MessageBoxResult.Yes)
            {
                // Eliminar el recordatorio de la base de datos
                EliminarRecordatorioDeBD(item.ID_Recordatorios);

                // Quitar el item de la interfaz de usuario (de la lista de destacados)
                StackPanelContenedor.Children.Remove(item);

                // Mostrar una animación de "recordatorio eliminado"
                MostrarRecordatorioEliminado();
            }
        }



        private void StartNotificacionTimer()
        {
            _notificacionTimer = new DispatcherTimer();
            _notificacionTimer.Interval = TimeSpan.FromMinutes(1);  // Verifica cada minuto
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
        }


    }

}
