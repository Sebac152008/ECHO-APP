using MaterialDesignThemes.Wpf;
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
using System.Data.SQLite;
using Microsoft.Data.Sqlite;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_ECHO;
using ECHO.Recursos;

namespace ECHO.View
{
    /// <summary>
    /// Lógica de interacción para EditarRecordatorioDialog.xaml
    /// </summary>
    public partial class EditarRecordatorioDialog : UserControl
    {
        private static readonly string connectionString = AppContexto.Instancia.ConexionBD;

        public int IdRecordatorio { get; set; }

        public EditarRecordatorioDialog()
        {
            InitializeComponent();
        }


        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string nota = txtNotaEditar.Text.Trim();
            DateTime? fecha = fechaEditar.SelectedDate;
            TimeSpan? hora = horaEditar.SelectedTime?.TimeOfDay;

            bool esValido = true;

            // Validación del título
            if (string.IsNullOrEmpty(nota))
            {
                ErrorTituloEdit.Visibility = Visibility.Visible;
                ErrorTituloEdit.Text = "El título no puede quedar vacío.";
                esValido = false;
            }
            else
            {
                ErrorTituloEdit.Visibility = Visibility.Collapsed;
            }

            // Validación de la fecha
            if (fecha == null)
            {
                ErrorFechaEdit.Visibility = Visibility.Visible;
                ErrorFechaEdit.Text = "Por favor selecciona una fecha.";
                esValido = false;
            }
            else if (fecha.Value.Date < DateTime.Today)
            {
                ErrorFechaEdit.Visibility = Visibility.Visible;
                ErrorFechaEdit.Text = "La fecha no puede ser anterior al día de hoy.";
                esValido = false;
            }
            else
            {
                ErrorFechaEdit.Visibility = Visibility.Collapsed;
            }

            // Validación de la hora
            if (hora == null)
            {
                ErrorHoraEdit.Visibility = Visibility.Visible;
                ErrorHoraEdit.Text = "Por favor selecciona una hora.";
                esValido = false;
            }
            else if (fecha.HasValue && fecha.Value.Date == DateTime.Today && hora.Value < DateTime.Now.TimeOfDay)
            {
                ErrorHoraEdit.Visibility = Visibility.Visible;
                ErrorHoraEdit.Text = "La hora seleccionada no puede ser anterior a la hora actual.";
                esValido = false;
            }
            else
            {
                ErrorHoraEdit.Visibility = Visibility.Collapsed;
            }

            // Detener si hubo errores
            if (!esValido)
                return;

            // Validación: ¿ya existe otro recordatorio con la misma fecha y hora?
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {

                    connection.Open();

                    var command = new SQLiteCommand("SELECT COUNT(*) FROM Recordatorios WHERE Fecha = @fecha AND Hora = @hora AND ID_Recordatorios != @id", connection);
                    command.Parameters.AddWithValue("@fecha", fecha.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@hora", hora.Value.ToString(@"hh\:mm"));
                    command.Parameters.AddWithValue("@id", IdRecordatorio);

                    long count = (long)command.ExecuteScalar();

                    if (count > 0)
                    {
                        ErrorHoraEdit.Visibility = Visibility.Visible;
                        ErrorHoraEdit.Text = "Ya existe un recordatorio para esa hora.";
                        return;
                    }

                    // Código para actualizar el recordatorio
                    var updateCmd = new SQLiteCommand("UPDATE Recordatorios SET Nota = @nota, Fecha = @fecha, Hora = @hora WHERE ID_Recordatorios = @id", connection);
                    updateCmd.Parameters.AddWithValue("@nota", nota);
                    updateCmd.Parameters.AddWithValue("@fecha", fecha.Value.ToString("yyyy-MM-dd"));
                    updateCmd.Parameters.AddWithValue("@hora", hora.Value.ToString(@"hh\:mm"));
                    updateCmd.Parameters.AddWithValue("@id", IdRecordatorio);

                    updateCmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al actualizar el recordatorio:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Si pasa todas las validaciones, cerrar y devolver "true"
            DialogHost.CloseDialogCommand.Execute("true", null);
        }



    }
}
