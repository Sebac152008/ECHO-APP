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
using IOPath = System.IO.Path;
using System.Windows.Threading;
using System.IO;
using MaterialDesignThemes.Wpf;

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

            RecordatorioEventAggregator.RecordatorioDesdestacado += OnRecordatorioDesdestacado;

            this.Loaded += InicioView_Loaded;

            // Inicializar dbPath dentro del constructor

        }

        private void FondoImagen_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.Contains("ImagenFondoPrecargada"))
            {
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoPrecargada"];
                FondoImagen.Visibility = Visibility.Visible;
            }
        }


        private void InicioView_Loaded(object sender, RoutedEventArgs e)
        {
            // Ya existe PanelRecordatorios, así que no dará null
            PanelRecordatorios.Children.Clear();
            CargarRecordatoriosDesdeBD();
            ActualizarRecordatorios();
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

            CargarRecordatoriosDesdeBD();
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
    }
}