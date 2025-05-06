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
using WPF_ECHO.ViewModels;
using IOPath = System.IO.Path;
using System.Windows.Threading;
using System.IO;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls.Primitives;
using CommunityToolkit.WinUI.Notifications;
using System.Globalization;

namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para InicioView.xaml
    /// </summary>
    public partial class InicioView : UserControl
    {

        public static InicioView InstanciaActual;

        //Conexion DB

        private static readonly string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECHO.db");
        private static readonly string connectionString = $"Data Source={dbPath};";


        private bool animacionEnCurso = false;
        public InicioView()
        {
            InitializeComponent(); // Asegúrate de que esta línea esté primero

            InstanciaActual = this;

            RecordatorioEventAggregator.RecordatorioDesdestacado += OnRecordatorioDesdestacado;

            this.Loaded += InicioView_Loaded;

            this.Loaded += (s, e) =>
            {
                if (comboHoraMinuto.Template.FindName("PART_Popup", comboHoraMinuto) is Popup popup)
                {
                    popup.Placement = PlacementMode.Bottom;
                    popup.PlacementTarget = comboHoraMinuto;

                    popup.CustomPopupPlacementCallback = (popupSize, targetSize, offset) =>
                    {
                        // Ajusta la posición Y para que el Popup aparezca ligeramente más arriba o abajo
                        Point point = new Point(0, targetSize.Height + 5); // +5 es un pequeño margen
                        return new[] { new CustomPopupPlacement(point, PopupPrimaryAxis.Horizontal) };
                    };
                }
            };
            // Inicializar dbPath dentro del constructor

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();


        }

        public void RecargarRecordatorios()
        {
            CargarRecordatoriosDesdeBD();
        }

        private void FondoImagen_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.Contains("ImagenFondoPrecargada"))
            {
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoPrecargada"];
                FondoImagen.Visibility = Visibility.Visible;
            }
        }

        DispatcherTimer timer;

        private void InicioView_Loaded(object sender, RoutedEventArgs e)
        {
            // Ya existe PanelRecordatorios, así que no dará null
            PanelRecordatorios.Children.Clear();
            CargarRecordatoriosDesdeBD();
            ActualizarRecordatorios();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime ahora = DateTime.Now;
            txtFechaActual.Text = ahora.ToString("dddd, dd MMMM yyyy", new CultureInfo("es-ES"));
        }

        private void OnRecordatorioDesdestacado(RecordatorioItem item)
        {
            var parent = LogicalTreeHelper.GetParent(item) as Panel;
            if (parent != null)
            {
                parent.Children.Remove(item);  // Lo quitas del contenedor anterior
            }

            PanelRecordatorios.Children.Add(item); // Ahora sí, lo agregas al nuevo
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

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;

            if (boton != null && boton.Tag is UIElement contenedor)
            {
                PanelRecordatorios.Children.Remove(contenedor);
            }
        }


        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nota = txtNota.Text.Trim();
            DateTime? fecha = fechaPicker.SelectedDate;
            TimeSpan? hora = comboHoraMinuto.SelectedTime?.TimeOfDay;

            bool esValido = true;

            // Validación del título
            if (string.IsNullOrEmpty(nota))
            {
                ErrorTitulo.Visibility = Visibility.Visible;
                ErrorTitulo.Text = "El título no puede quedar vacío.";
                esValido = false;
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
                esValido = false;
            }
            else if (fecha.Value.Date < DateTime.Today)
            {
                ErrorFecha.Visibility = Visibility.Visible;
                ErrorFecha.Text = "La fecha no puede ser anterior al día de hoy.";
                esValido = false;
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
                esValido = false;
            }
            else if (fecha.HasValue && fecha.Value.Date == DateTime.Today && hora.Value < DateTime.Now.TimeOfDay)
            {
                ErrorHora.Visibility = Visibility.Visible;
                ErrorHora.Text = "La hora seleccionada no puede ser anterior a la hora actual.";
                esValido = false;
            }
            else
            {
                ErrorHora.Visibility = Visibility.Collapsed;
            }

            // 🚫 Detener si hubo errores de validación básica
            if (!esValido)
                return;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // 🔍 Validación de duplicado de fecha y hora
                    string checkQuery = "SELECT COUNT(*) FROM Recordatorios WHERE Fecha = @Fecha AND Hora = @Hora";
                    SQLiteCommand checkCommand = new SQLiteCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Fecha", fecha.Value.ToString("yyyy-MM-dd"));
                    checkCommand.Parameters.AddWithValue("@Hora", hora.Value.ToString(@"hh\:mm"));

                    long existe = (long)checkCommand.ExecuteScalar();
                    if (existe > 0)
                    {
                        ErrorHora.Visibility = Visibility.Visible;
                        ErrorHora.Text = "Ya existe un recordatorio para esa hora.";
                        return;
                    }

                    // Inserción
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
                        MostrarRecordatorioGuardado();
                        CargarRecordatoriosDesdeBD();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el recordatorio.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            await OcultarContenedorAddRecordatorio();
        }






        private void LimpiarCampos() // Aqui limpiamos los datos despues de ser enviados
        {
            txtNota.Text = "";
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
                    string selectQuery = "SELECT * FROM Recordatorios WHERE Destacado = 0 ORDER BY ID_Recordatorios DESC";
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
                            item.EliminarRecordatorio += Recordatorio_EliminarRecordatorio;
                            item.DataContext = item;

                            // Asignar evento de edición (solo si implementaste el evento EditarClicked en RecordatorioItem)
                            item.EditarClicked += (s, e) =>
                            {
                                EditarRecordatorio(item); // Asegúrate de tener este método implementado
                            };

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

        private async void EditarRecordatorio(RecordatorioItem recordatorio)
        {

            var editarControl = new EditarRecordatorioDialog
            {
                IdRecordatorio = recordatorio.ID_Recordatorios
            };

            // Rellenar con los datos actuales
            editarControl.txtNotaEditar.Text = recordatorio.Descripcion;
            editarControl.fechaEditar.SelectedDate = DateTime.Parse(recordatorio.Fecha);
            TimeSpan hora = TimeSpan.Parse(recordatorio.Hora);  // Convierte el string a TimeSpan
            editarControl.horaEditar.SelectedTime = DateTime.Today.Add(hora);  // Suma el TimeSpan a DateTime.Today

            var resultado = await DialogHost.Show(editarControl, "MainDialogHost");

            if (resultado is "true")
            {
                // Obtener valores editados
                string nuevaNota = editarControl.txtNotaEditar.Text;
                DateTime? nuevaFecha = editarControl.fechaEditar.SelectedDate;
                TimeSpan? nuevaHora = editarControl.horaEditar.SelectedTime?.TimeOfDay;

                // Validaciones básicas (puedes mejorar)
                if (!string.IsNullOrWhiteSpace(nuevaNota) && nuevaFecha != null && nuevaHora != null)
                {
                    try
                    {
                        using (var conn = new SQLiteConnection(connectionString))
                        {
                            conn.Open();
                            var cmd = new SQLiteCommand("UPDATE Recordatorios SET Nota=@nota, Fecha=@fecha, Hora=@hora WHERE ID_Recordatorios=@id", conn);
                            cmd.Parameters.AddWithValue("@nota", nuevaNota);
                            cmd.Parameters.AddWithValue("@fecha", nuevaFecha.Value.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@hora", nuevaHora.Value.ToString(@"hh\:mm"));
                            cmd.Parameters.AddWithValue("@id", recordatorio.ID_Recordatorios);
                            cmd.ExecuteNonQuery();
                        }

                        MostrarMensaje("Recordatorio editado", "comprobado.png");
                        ActualizarRecordatorios();
                        CargarRecordatoriosDesdeBD();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar: {ex.Message}");
                    }
                }
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
                        FontSize = 16,
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
                                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff")),
                                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C3E50")),
                                Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand,
                                CommandParameter = false
                            },
                            new Button
                            {
                                Content = "Eliminar",
                                Margin = new Thickness (10,10,10,10),
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
            MostrarMensaje("Recordatorio añadido", "comprobado.png");
        }

        private void RecordatorioDestacadoDesdeItem(object sender, EventArgs e)
        {
            var item = sender as RecordatorioItem;
            if (item == null) return;

            // Actualizar en BD
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE Recordatorios SET Destacado = 1 WHERE ID_Recordatorios = @id";
                    using (var command = new SQLiteCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", item.ID_Recordatorios);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al destacar el recordatorio: {ex.Message}");
                return;
            }

            // Lanzar evento para que lo escuche DestacadoView
            RecordatorioEventAggregator.RaiseDestacadoToggled(item, true);

            // Mostrar el mensaje visual
            MostrarRecordatorioDestacado();
        }


        public void MostrarRecordatorioEliminado()
        {
            MostrarMensaje("Recordatorio eliminado", "eliminar.png");
        }

        private void MostrarRecordatorioDestacado()
        {
            MostrarMensaje("Recordatorio destacado", "EstrellaRellenada.png");

            CargarRecordatoriosDesdeBD();

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

        private async Task OcultarContenedorAddRecordatorio()
        {
            animacionEnCurso = true;

            var slideOut = (Storyboard)FindResource("SlideOutToRightAnimation");
            slideOut.Completed += (s, ev) =>
            {
                ContenedorAddRecordatorio.Visibility = Visibility.Collapsed;
            };
            slideOut.Begin(ContenedorAddRecordatorio);

            // Esperar también duración de la animación
            await Task.Delay(600);

            btnAbrirContenedor.IsEnabled = true;

            animacionEnCurso = false;
        }




        // Método para actualizar los recordatorios cuando se regresa a InicioView
        private void ActualizarRecordatorios()
        {
            CargarRecordatoriosDesdeBD();

            // Limpiar los recordatorios previos
            PanelRecordatorios.Children.Clear();

            // Ahora, recargar los recordatorios desde la base de datos (separados por destacado o no)
            CargarRecordatoriosDesdeBD();  // Aquí puedes volver a llamar a tu método de carga.
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button_Click(sender, e);
        }
    }
}