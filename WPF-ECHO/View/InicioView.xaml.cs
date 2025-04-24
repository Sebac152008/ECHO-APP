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
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using ECHO.View;
using System.Windows.Threading;
using ECHO.ViewModels;

namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para InicioView.xaml
    /// </summary>
    public partial class InicioView : UserControl
    {

        private static readonly string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECHO.db");
        private static readonly string connectionString = $"Data Source={dbPath};";

        private bool animacionEnCurso = false;
        public InicioView()
        {
            InitializeComponent(); // Asegúrate de que esta línea esté primero

            RecordatorioEventAggregator.DestacadoToggled += OnDestacadoToggled;

            this.Loaded += InicioView_Loaded;
        }

        private void InicioView_Loaded(object sender, RoutedEventArgs e)
        {
            // Ya existe PanelRecordatorios, así que no dará null
            PanelRecordatorios.Children.Clear();
            CargarRecordatoriosDesdeBD();
            ActualizarRecordatorios();
        }

        private void OnDestacadoToggled(RecordatorioItem item, bool isDestacado)
        {
            // 1) Quitarlo de su padre actual (si lo tuviera)
            var parent = LogicalTreeHelper.GetParent(item) as Panel;
            if (parent != null)
            {
                parent.Children.Remove(item);
            }

            // 2) Si NO está destacado, volverlo a añadir a InicioView
            if (!isDestacado)
            {
                PanelRecordatorios.Children.Add(item);
            }
            // Si isDestacado == true, no hagas nada aquí:
            // ya ha sido movido a DestacadoView por su propio manejador.
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
            TimeSpan? hora = comboHoraMinuto.SelectedTime?.TimeOfDay;

            bool hayErrores = false;

            // Validación del título
            if (string.IsNullOrEmpty(nota) || nota == "Escribe algo...")
            {
                ErrorTitulo.Visibility = Visibility.Visible;
                ErrorTitulo.Text = "El título no puede quedar vacío.";
                hayErrores = true;
            }
            else
            {
                ErrorTitulo.Visibility = Visibility.Collapsed;
            }

            // Validación de la fecha
            if (fecha == null)
            {
                ErrorFecha.Visibility = Visibility.Visible;
                ErrorFecha.Text = "Por favor selecciona una fecha.";
                hayErrores = true;
            }
            else if (fecha.Value.Date < DateTime.Today)
            {
                ErrorFecha.Visibility = Visibility.Visible;
                ErrorFecha.Text = "La fecha no puede ser anterior al día de hoy.";
                hayErrores = true;
            }
            else
            {
                ErrorFecha.Visibility = Visibility.Collapsed;
            }

            // Validación de la hora
            if (hora == null)
            {
                ErrorHora.Visibility = Visibility.Visible;
                ErrorHora.Text = "Por favor selecciona una hora.";
                hayErrores = true;
            }
            else
            {
                ErrorHora.Visibility = Visibility.Collapsed;
            }

            if (hayErrores)
                return; // Detener el guardado si hay errores

            // ✅ Si llegamos aquí, todo está validado correctamente

            OcultarContenedorAddRecordatorio();

            MostrarRecordatorioGuardado();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Recordatorios (Nota, Fecha, Hora) VALUES (@Nota, @Fecha, @Hora)";
                    SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Nota", nota);
                    insertCommand.Parameters.AddWithValue("@Fecha", fecha.Value.ToString("yyyy-MM-dd"));
                    insertCommand.Parameters.AddWithValue("@Hora", hora.Value.ToString(@"hh\:mm"));

                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        LimpiarCampos();
                        AgregarRecordatorio(nota, fecha.Value.ToShortDateString(), hora.Value.ToString(@"hh\:mm"));
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
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Filtra los recordatorios NO destacados
                    string selectQuery = "SELECT * FROM Recordatorios WHERE Destacado = 0";
                    SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);

                    using (SQLiteDataReader reader = selectCommand.ExecuteReader())
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

                            item.RecordatorioDestacadoEvent += RecordatorioDestacadoDesdeItem;

                            item.DataContext = item;
                            item.EliminarRecordatorio += Recordatorio_EliminarRecordatorio;

                            // Agregarlo a la vista de recordatorios
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
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Recordatorios WHERE ID_Recordatorios = @ID";
                        SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
                        deleteCommand.Parameters.AddWithValue("@ID", recordatorio.ID_Recordatorios);

                        deleteCommand.ExecuteNonQuery();
                    }

                    PanelRecordatorios.Children.Remove(recordatorio);

                    MostrarRecordatorioEliminado();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el recordatorio: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void MostrarRecordatorioGuardado()
        {
            RecordatorioGuardado.Visibility = Visibility.Visible;
            var storyboard = (Storyboard)this.FindResource("MostrarMensaje");
            Storyboard.SetTarget(storyboard, RecordatorioGuardado);
            storyboard.Begin();

            // Ocultarlo automáticamente después de 2 segundos
            Task.Delay(2000).ContinueWith(_ =>
            {
                Dispatcher.Invoke(() =>
                {
                    var ocultar = (Storyboard)this.FindResource("OcultarMensaje");
                    Storyboard.SetTarget(ocultar, RecordatorioGuardado);
                    ocultar.Begin();
                });
            });
        }

        private void RecordatorioDestacadoDesdeItem(object sender, EventArgs e)
        {
            MostrarRecordatorioDestacado();
        }

        public void MostrarRecordatorioEliminado()
        {
            RecordatorioEliminado.Visibility = Visibility.Visible;

            var storyboard = (Storyboard)this.FindResource("MostrarMensaje");
            Storyboard.SetTarget(storyboard, RecordatorioEliminado);
            storyboard.Begin();

            // Ocultar automáticamente después de 2 segundos
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                var hideStoryboard = (Storyboard)this.FindResource("OcultarMensaje");
                Storyboard.SetTarget(hideStoryboard, RecordatorioEliminado);
                hideStoryboard.Begin();
            };
            timer.Start();
        }

        private void MostrarRecordatorioDestacado()
        {
            // Establecer la visibilidad a visible
            RecordatorioDestacado.Visibility = Visibility.Visible;

            // Obtener y comenzar la animación de mostrar mensaje
            Storyboard mostrar = (Storyboard)this.Resources["MostrarMensaje"];
            Storyboard.SetTarget(mostrar, RecordatorioDestacado);
            mostrar.Begin();

            // Iniciar un temporizador para ocultarlo después de unos segundos
            var temporizador = new System.Windows.Threading.DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(2)
            };
            temporizador.Tick += (s, e) =>
            {
                temporizador.Stop();

                Storyboard ocultar = (Storyboard)this.Resources["OcultarMensaje"];
                Storyboard.SetTarget(ocultar, RecordatorioDestacado);
                ocultar.Begin();
            };
            temporizador.Start();
        }



        private void OcultarContenedorAddRecordatorio()
        {
            var storyboard = (Storyboard)this.FindResource("SlideOutToRightAnimation");
            Storyboard.SetTarget(storyboard, ContenedorAddRecordatorio);
            storyboard.Begin();

            // Opcional: ocultarlo completamente después de que termine la animación
            storyboard.Completed += (s, e) =>
            {
                ContenedorAddRecordatorio.Visibility = Visibility.Collapsed;
            };
        }

        // Método para actualizar los recordatorios cuando se regresa a InicioView
        private void ActualizarRecordatorios()
        {
            // Limpiar los recordatorios previos
            PanelRecordatorios.Children.Clear();

            // Ahora, recargar los recordatorios desde la base de datos (separados por destacado o no)
            CargarRecordatoriosDesdeBD();  // Aquí puedes volver a llamar a tu método de carga.
        }


        private void txtNota_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}