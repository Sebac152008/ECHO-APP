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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using ECHO.View;

namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para InicioView.xaml
    /// </summary>
    public partial class InicioView : UserControl
    {

        string connectionString = "Server=DESKTOP-IF8RULA\\SQLEXPRESS;Database=ECHO;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        private bool animacionEnCurso = false;
        public InicioView()
        {
            InitializeComponent();
            ContenedorAddRecordatorio.Visibility = Visibility.Collapsed;
            CargarRecordatoriosDesdeBD();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (animacionEnCurso)
                return; // Si ya está animando, no hace nada

            animacionEnCurso = true;

            if (ContenedorAddRecordatorio.Visibility != Visibility.Visible)
            {
                // Mostrar el panel con animación de entrada
                ContenedorAddRecordatorio.Visibility = Visibility.Visible;

                var slideIn = (Storyboard)FindResource("SlideInFromRightAnimation");
                slideIn.Begin(ContenedorAddRecordatorio);

                // Esperar duración de la animación (600ms)
                await Task.Delay(600);
            }
            else
            {
                var slideOut = (Storyboard)FindResource("SlideOutToRightAnimation");
                slideOut.Completed += (s, ev) =>
                {
                    ContenedorAddRecordatorio.Visibility = Visibility.Collapsed;
                };
                slideOut.Begin(ContenedorAddRecordatorio);

                // Esperar también duración de la animación
                await Task.Delay(600);
            }

            animacionEnCurso = false;
        }

        private void txtNota_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNota.Text == "Escribe algo...")
            {
                txtNota.Text = "";
                txtNota.Foreground = Brushes.White;
            }
        }

        private void txtNota_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNota.Text == "")
            {
                txtNota.Text = "Escribe algo...";
                txtNota.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2AAB2"));
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null && boton.Tag is UIElement contenedor)
            {
                PanelRecordatorios.Children.Remove(contenedor);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nota = txtNota.Text.Trim();
            DateTime? fecha = fechaPicker.SelectedDate;

            var horaSeleccionada = comboHoraMinuto.SelectedTime;

            if (horaSeleccionada == null)
            {
                MessageBox.Show("Por favor selecciona una hora.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string hora = horaSeleccionada.Value.ToString("hh:mm tt"); //Guardando la hora en la base de datos

            // Validar datos
            if (string.IsNullOrEmpty(nota) || nota == "Escribe algo..." || fecha == null || comboHoraMinuto.SelectedTime == null)
            {
                MessageBox.Show("Por favor completa todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (fecha.Value.Date < DateTime.Today)
            {
                MessageBox.Show("La fecha no puede ser anterior al día de hoy.", "Fecha inválida",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insertar el recordatorio en la base de datos
                    string insertQuery = "INSERT INTO Recordatorios (Nota, Fecha, Hora) VALUES (@Nota, @Fecha, @Hora)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Nota", nota);
                    insertCommand.Parameters.AddWithValue("@Fecha", fecha.Value);
                    insertCommand.Parameters.AddWithValue("@Hora", hora);

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        // Limpiar campos
                        LimpiarCampos();

                        // Agregar el recordatorio a la UI sin recargar todos los datos
                        AgregarRecordatorio(nota, fecha.Value.ToShortDateString(), hora);

                        // O si prefieres recargar todos los recordatorios desde la BD
                        // CargarRecordatoriosDesdeBD();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el recordatorio.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el recordatorio: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void LimpiarCampos() // Aqui limpiamos los datos despues de ser enviados
        {
            txtNota.Text = "Escribe algo...";
            txtNota.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2AAB2"));
            fechaPicker.SelectedDate = null;
            comboHoraMinuto.SelectedTime = null; // Desmarca cualquier selección
        }

        private void CargarRecordatoriosDesdeBD()
        {
            PanelRecordatorios.Children.Clear();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT * FROM Recordatorios";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new RecordatorioItem
                            {
                                ID_Recordatorios = Convert.ToInt32(reader["ID_Recordatorios"]),
                                Descripcion = reader["Nota"].ToString(),
                                Fecha = ((DateTime)reader["Fecha"]).ToShortDateString(),
                                Hora = ((TimeSpan)reader["Hora"]).ToString(@"hh\:mm")
                            };

                            item.DataContext = item;

                            item.EliminarRecordatorio += Recordatorio_EliminarRecordatorio;

                            PanelRecordatorios.Children.Add(item);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al acceder a la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Agregar un nuevo recordatorio al PanelRecordatorios
        private void AgregarRecordatorio(string descripcion, string fecha, string hora)
        {
            var nuevoRecordatorio = new RecordatorioItem
            {
                Descripcion = descripcion,
                Fecha = fecha,
                Hora = hora
            };

            nuevoRecordatorio.DataContext = nuevoRecordatorio;

            // Suscribirse al evento de eliminación
            nuevoRecordatorio.EliminarRecordatorio += Recordatorio_EliminarRecordatorio;

            PanelRecordatorios.Children.Add(nuevoRecordatorio);
        }


        // Manejar el evento de eliminación
        private void Recordatorio_EliminarRecordatorio(object sender, EventArgs e)
        {
            var recordatorio = sender as RecordatorioItem;
            if (recordatorio != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Recordatorios WHERE ID_Recordatorios = @ID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@ID", recordatorio.ID_Recordatorios);

                        deleteCommand.ExecuteNonQuery();
                    }

                    PanelRecordatorios.Children.Remove(recordatorio);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el recordatorio: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void txtNota_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}