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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ECHO.View
{
    /// <summary>
    /// Lógica de interacción para EditarRecordatorioDialog.xaml
    /// </summary>
    public partial class EditarRecordatorioDialog : UserControl
    {
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
            if (string.IsNullOrEmpty(nota) || nota == "Escribe algo...")
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

            if (!esValido)
                return;

            // Si pasa todas las validaciones, cerrar y devolver "true"
            DialogHost.CloseDialogCommand.Execute("true", null);
        }


    }
}
