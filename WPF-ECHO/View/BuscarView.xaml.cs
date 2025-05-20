using ECHO.View;
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
using System.Data.SQLite;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Animation;
using ECHO.Recursos;

namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para BuscarView.xaml
    /// </summary>
    public partial class BuscarView : UserControl
    {
        public BuscarView()
        {
            InitializeComponent();

            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];
            abrirAnim.Begin(this);

            this.Loaded += BuscarView_Loaded;
        }

        private void BuscarView_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];
            abrirAnim.Begin(this);
        }

        //Conexion de DATABASE
        private static readonly string connectionString = AppContexto.Instancia.ConexionBD;

        private void txtBuscarRecordatorio_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = QuitarAcentos(txtBuscarRecordatorio.Text.Trim().ToLower());

            // Limpia el contenedor antes de mostrar resultados nuevos
            StackResultados.Children.Clear();

            if (string.IsNullOrEmpty(filtro))
                return;

            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Recordatorios WHERE LOWER(Nota) LIKE @filtro";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@filtro", $"%{filtro}%");

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

                                // Aplicar visual si está destacado
                                bool esDestacado = Convert.ToInt32(reader["Destacado"]) == 1;
                                item.SetEstaDestacadoDesdeBD(esDestacado);

                                // Resaltar coincidencias en la Descripción visual (si usas un TextBlock dentro del template)
                                var textBlock = item.FindName("TxtNota") as TextBlock;

                                if (textBlock != null)
                                {
                                    AplicarResaltadoEnTextBlock(textBlock, item.Descripcion, filtro);
                                }

                                // Eliminar recordatorio
                                item.EliminarRecordatorio += async (s, ev) =>
                                {
                                    var resultado = await MostrarDialogoEliminacion();
                                    if (resultado)
                                    {
                                        EliminarRecordatorioDeBD(item.ID_Recordatorios);
                                        StackResultados.Children.Remove(item);
                                        MostrarMensaje("Recordatorio eliminado", "eliminar.png");
                                    }
                                };

                                // Editar recordatorio
                                item.EditarClicked += async (s, args) =>
                                {
                                    await EditarRecordatorio(item);
                                };

                                // ▶️ Al hacer clic en la estrella se dispara DestacadoCambiado con el nuevo estado
                                item.DestacadoCambiado += (s, isDestacado) =>
                                {
                                    try
                                    {
                                        using (var conn = new SQLiteConnection(connectionString))
                                        {
                                            conn.Open();
                                            // Guarda el nuevo valor (1 si isDestacado==true, 0 si false)
                                            var cmd = new SQLiteCommand(
                                                "UPDATE Recordatorios SET Destacado = @dest WHERE ID_Recordatorios = @id",
                                                conn);
                                            cmd.Parameters.AddWithValue("@dest", isDestacado ? 1 : 0);
                                            cmd.Parameters.AddWithValue("@id", item.ID_Recordatorios);
                                            cmd.ExecuteNonQuery();
                                        }

                                        // Actualiza visualmente la estrella
                                        item.SetEstaDestacadoDesdeBD(isDestacado);

                                        // Mensaje tipo toast
                                        MostrarMensaje(
                                            isDestacado ? "Recordatorio destacado" : "Recordatorio desmarcado",
                                            isDestacado ? "EstrellaRellenada.png" : "EstrellaVaciaAmarilla.png"
                                        );

                                        // Refrescar la vista de Destacados
                                        DestacadoView.InstanciaActual?.RecargarRecordatorios();

                                        // Opcional: refrescar la búsqueda para que desaparezca si se “desmarcó”
                                        txtBuscarRecordatorio_TextChanged(null, null);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error al cambiar destacado: " + ex.Message);
                                    }
                                };


                                StackResultados.Children.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar: {ex.Message}");
            }
        }


        private void AplicarResaltadoEnTextBlock(TextBlock textBlock, string textoOriginal, string filtro)
        {
            textBlock.Text = string.Empty;
            textBlock.Inlines.Clear();

            string textoSinAcentos = QuitarAcentos(textoOriginal.ToLower());
            int index = textoSinAcentos.IndexOf(filtro);

            if (index >= 0)
            {
                string antes = textoOriginal.Substring(0, index);
                string match = textoOriginal.Substring(index, filtro.Length);
                string despues = textoOriginal.Substring(index + filtro.Length);

                // Texto antes de la coincidencia (gris)
                textBlock.Inlines.Add(new Run(antes)
                {
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F8C8D"))
                });

                // Coincidencia
                textBlock.Inlines.Add(new Run(match)
                {
                    FontWeight = FontWeights.Bold,
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C3E50"))
                });

                // Texto después (gris)
                textBlock.Inlines.Add(new Run(despues)
                {
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F8C8D"))
                });
            }
            else
            {
                // Si no hay coincidencia, mostrar todo en gris
                textBlock.Inlines.Add(new Run(textoOriginal)
                {
                    Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F8C8D"))
                });
            }
        }


        private string QuitarAcentos(string texto)
        {
            var normalizado = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var c in normalizado)
            {
                var unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {

            if (Application.Current.Resources.Contains("ImagenFondo"))
            {
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondo"];
                FondoImagen.Visibility = Visibility.Visible;
            }

        }

        private async Task EditarRecordatorio(RecordatorioItem recordatorio)
        {
            var editarControl = new EditarRecordatorioDialog();

            editarControl.txtNotaEditar.Text = recordatorio.Descripcion;
            editarControl.fechaEditar.SelectedDate = DateTime.Parse(recordatorio.Fecha);
            editarControl.horaEditar.SelectedTime = DateTime.Today + TimeSpan.Parse(recordatorio.Hora);

            var resultado = await MaterialDesignThemes.Wpf.DialogHost.Show(editarControl, "MainDialogHost");

            if (resultado is "true")
            {
                string nuevaNota = editarControl.txtNotaEditar.Text;
                DateTime? nuevaFecha = editarControl.fechaEditar.SelectedDate;
                TimeSpan? nuevaHora = editarControl.horaEditar.SelectedTime?.TimeOfDay;

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
                        txtBuscarRecordatorio_TextChanged(null, null); // Refrescar búsqueda
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar: {ex.Message}");
                    }
                }
            }
        }

        private async Task<bool> MostrarDialogoEliminacion()
        {
            var resultado = await MaterialDesignThemes.Wpf.DialogHost.Show(
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
                                Margin = new Thickness(0,20,0,20),
                                Foreground = Brushes.White,
                                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C3E50")),
                                Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand,
                                CommandParameter = false
                            },
                            new Button
                            {
                                Content = "Eliminar",
                                Margin = new Thickness (20,20,20,20),
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

            return resultado is bool confirmado && confirmado;
        }

        private void EliminarRecordatorioDeBD(int id)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("DELETE FROM Recordatorios WHERE ID_Recordatorios = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private async void MostrarMensaje(string texto, string icono)
        {
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

            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            borde.BeginAnimation(Border.OpacityProperty, fadeIn);

            await Task.Delay(2500);

            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(300));
            fadeOut.Completed += (s, e) => StackMensajes.Children.Remove(borde);
            borde.BeginAnimation(Border.OpacityProperty, fadeOut);
        }



    }
}
