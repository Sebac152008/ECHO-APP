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

        }

        private static readonly string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECHO.db");
        private static readonly string connectionString = $"Data Source={dbPath};";

        private void txtBuscarRecordatorio_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filtro = QuitarAcentos(txtBuscarRecordatorio.Text.Trim().ToLower());

            // Limpia el contenedor antes de mostrar resultados nuevos
            StackResultados.Children.Clear();

            if (string.IsNullOrEmpty(filtro) || filtro == "buscar recordatorio...")
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

                                // Resaltar coincidencias en la Descripción visual (si usas un TextBlock dentro del template)
                                // Acceder al TextBlock "TxtNota" definido en RecordatorioItem.xaml
                                var textBlock = item.FindName("TxtNota") as TextBlock;

                                if (textBlock != null)
                                {
                                    AplicarResaltadoEnTextBlock(textBlock, item.Descripcion, filtro);
                                }


                                // Opcional: manejar eventos como eliminar o destacar
                                item.EliminarRecordatorio += (s, ev) => StackResultados.Children.Remove(item);

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

    }
}
