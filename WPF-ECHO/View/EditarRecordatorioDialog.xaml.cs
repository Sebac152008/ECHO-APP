// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa los componentes de Material Design para WPF (botones, estilos, diálogos, etc.).
using MaterialDesignThemes.Wpf;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Espacio de nombres básico de .NET que incluye tipos fundamentales (como DateTime, Math, etc.).
using System;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Proporciona estructuras de datos como listas, diccionarios, colas, etc.
using System.Collections.Generic;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite usar métodos LINQ para consultas sobre colecciones (por ejemplo: .Where(), .Select()).
using System.Linq;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Espacio para manejo de cadenas de texto, conversiones y codificación.
using System.Text;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Contiene funcionalidades para ejecutar tareas en segundo plano y trabajar con asincronía (async/await).
using System.Threading.Tasks;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Espacio principal para aplicaciones WPF. Incluye clases como `Application`, `Window`, etc.
using System.Windows;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Controles básicos de interfaz de usuario como `Button`, `TextBox`, `Grid`, etc.
using System.Windows.Controls;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite hacer enlaces de datos (data binding) entre la UI y el código (MVVM, etc.).
using System.Windows.Data;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite agregar elementos visuales dentro de documentos (como `FlowDocument` o `TextBlock`).
using System.Windows.Documents;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Espacio para manejar entradas del usuario, como teclado, mouse, gestos, etc.
using System.Windows.Input;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Para trabajar con colores, pinceles, degradados, y otros elementos visuales.
using System.Windows.Media;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa las clases necesarias para conectarse y trabajar con bases de datos SQLite (System.Data.SQLite).
using System.Data.SQLite;

// Otra biblioteca de SQLite (Microsoft.Data.Sqlite), útil para proyectos .NET Core o .NET 5/6+.
// Tener ambas puede ser redundante o causar conflicto si no se usa con cuidado.
using Microsoft.Data.Sqlite;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite cargar y mostrar imágenes como BitmapImage en la UI.
using System.Windows.Media.Imaging;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Soporte para navegación entre páginas (por ejemplo, con el control `Frame` y páginas WPF).
using System.Windows.Navigation;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Para trabajar con formas visuales básicas como `Rectangle`, `Ellipse`, `Line`, etc.
using System.Windows.Shapes;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa el espacio de nombres del proyecto actual (WPF_ECHO), probablemente para acceder a clases de la app.
using WPF_ECHO;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa el espacio de nombres 'Recursos' dentro del proyecto ECHO, posiblemente con imágenes, estilos o utilidades.
using ECHO.Recursos;

// La palabra clave "namespace" se utiliza para organizar y agrupar clases relacionadas bajo un mismo nombre lógico.
// Esto ayuda a evitar conflictos de nombres y mejora la organización del código.
// En este caso, el espacio de nombres se llama WPF_ECHO.View y contiene las vistas de la aplicación.
// Aparte el namespace puede ser llamado como el nombre del programa.
namespace ECHO.View
{
    /// <summary>
    /// Lógica de interacción para EditarRecordatorioDialog.xaml
    /// </summary>
    public partial class EditarRecordatorioDialog : UserControl
    {
        // Cadena de conexión a la base de datos SQLite.
        // Se obtiene desde una propiedad estática del contexto global de la aplicación (singleton).
        // Esto permite que toda la aplicación use la misma conexión configurada.
        private static readonly string connectionString = AppContexto.Instancia.ConexionBD;

        // Propiedad pública para almacenar el ID del recordatorio que se va a editar.
        // Esta propiedad se utiliza para saber qué registro modificar en la base de datos.
        public int IdRecordatorio { get; set; }

        // Constructor de la clase EditarRecordatorioDialog.
        // Inicializa los componentes visuales definidos en el archivo XAML asociado.
        public EditarRecordatorioDialog()
        {
            // InitializeComponent() Inicializa los componentes definidos en el archivo XAML vinculado a esta clase,
            // asegurando que los elementos de la interfaz gráfica estén disponibles y listos para su uso.
            InitializeComponent(); // Llama al método que carga los elementos visuales y su configuración desde el archivo XAML.

        }


        // 'void' indica que el método no devuelve ningún valor.
        // Está marcado como 'private', por lo que solo puede ser accedido desde esta clase.
        // 'object sender' representa el objeto (el botón) que generó el evento.
        // 'RoutedEventArgs e' contiene información adicional sobre el evento de clic.
        // Método que se ejecuta cuando el usuario hace clic en el botón "Guardar".
        // Este evento valida los datos ingresados (nota, fecha y hora), y si todo es correcto, actualiza el recordatorio en la base de datos.
        private void BtnGuardar_Click(object sender, RoutedEventArgs e)

        {
            // Se obtiene el texto ingresado por el usuario en el campo de nota y se elimina cualquier espacio en blanco al inicio o final.
            string nota = txtNotaEditar.Text.Trim();

            // Se obtiene la fecha seleccionada por el usuario en el control de calendario.
            // Puede ser null si el usuario no ha seleccionado ninguna fecha.
            DateTime? fecha = fechaEditar.SelectedDate;

            // Se obtiene la hora seleccionada en el control de hora personalizada (posiblemente con formato AM/PM).
            // También puede ser null si el usuario no ha seleccionado hora.
            TimeSpan? hora = horaEditar.SelectedTime?.TimeOfDay;

            // Variable booleana que indica si todos los campos del formulario son válidos.
            // Se inicializa en true y se marcará como false si alguna validación falla.
            bool esValido = true;

            // Verifica si la nota está vacía o no fue ingresada.
            if (string.IsNullOrEmpty(nota))
            {
                //ErrorTitulo es un bloque de texto se utiliza para mostrar el error de la Titulo.
                //Visibility se utiliza para mostrar y ocultar el bloque de texto, en este caso lo muestra
                // Muestra un mensaje de error visual al usuario debajo del campo Nota.
                ErrorTituloEdit.Visibility = Visibility.Visible;
                ErrorTituloEdit.Text = "El título no puede quedar vacío.";

                // Marca como inválido el formulario.
                esValido = false;
            }
            else
            {
                // Si el campo es válido, se oculta el mensaje de error.
                ErrorTituloEdit.Visibility = Visibility.Collapsed;
            }

            // Si no se ha seleccionado ninguna fecha.
            if (fecha == null)
            {
                //ErrorFecha es un bloque de texto se utiliza para mostrar el error de la fecha.
                //Visibility se utiliza para mostrar y ocultar el bloque de texto, en este caso lo muestra
                ErrorFechaEdit.Visibility = Visibility.Visible;
                ErrorFechaEdit.Text = "Por favor selecciona una fecha.";
                esValido = false;
            }
            // Si la fecha seleccionada es anterior al día actual, se invalida.
            else if (fecha.Value.Date < DateTime.Today)
            {
                //ErrorFecha es un bloque de texto se utiliza para mostrar el error de la fecha.
                //Visibility se utiliza para mostrar y ocultar el bloque de texto, en este caso lo muestra
                ErrorFechaEdit.Visibility = Visibility.Visible;
                ErrorFechaEdit.Text = "La fecha no puede ser anterior al día de hoy.";
                esValido = false;
            }
            else
            {
                // Si la fecha es válida, se oculta cualquier mensaje de error anterior.
                ErrorFechaEdit.Visibility = Visibility.Collapsed;
            }

            // Si el usuario no seleccionó ninguna hora.
            if (hora == null)
            {
                //ErrorHora es un bloque de texto se utiliza para mostrar el error de la hora.
                //Visibility se utiliza para mostrar y ocultar el bloque de texto, en este caso lo muestra
                ErrorHoraEdit.Visibility = Visibility.Visible;
                ErrorHoraEdit.Text = "Por favor selecciona una hora.";
                esValido = false;
            }
            // Si la fecha es hoy y la hora ingresada es anterior a la hora actual del sistema.
            else if (fecha.HasValue && fecha.Value.Date == DateTime.Today && hora.Value < DateTime.Now.TimeOfDay)
            {
                //ErrorHora es un bloque de texto se utiliza para mostrar el error de la hora.
                //Visibility se utiliza para mostrar y ocultar el bloque de texto, en este caso lo muestra
                ErrorHoraEdit.Visibility = Visibility.Visible;
                ErrorHoraEdit.Text = "La hora seleccionada no puede ser anterior a la hora actual.";
                esValido = false;
            }
            else
            {
                // Si la hora es válida, se oculta cualquier mensaje de error anterior.
                ErrorHoraEdit.Visibility = Visibility.Collapsed;
            }

            // Si alguna de las validaciones anteriores ha fallado (esValido = false),
            // se detiene la ejecución del método y no se continúa con el guardado del recordatorio.
            if (!esValido)
                return;

            // Validación: ¿ya existe otro recordatorio con la misma fecha y hora?
            try
            {
                // Se crea y abre una nueva conexión a la base de datos SQLite usando la cadena de conexión configurada previamente.
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Consulta SQL que cuenta cuántos recordatorios existen con la misma fecha y hora,
                    // excluyendo el recordatorio que se está editando (ID_Recordatorios != @id).
                    var command = new SQLiteCommand(
                        "SELECT COUNT(*) FROM Recordatorios WHERE Fecha = @fecha AND Hora = @hora AND ID_Recordatorios != @id",
                        connection
                    );

                    // Se agregan los parámetros a la consulta para evitar inyecciones SQL y asegurar el filtrado correcto.
                    command.Parameters.AddWithValue("@fecha", fecha.Value.ToString("yyyy-MM-dd"));   // Fecha en formato ISO (yyyy-MM-dd)
                    command.Parameters.AddWithValue("@hora", hora.Value.ToString(@"hh\:mm"));        // Hora en formato de 24h (hh:mm)
                    command.Parameters.AddWithValue("@id", IdRecordatorio);                          // ID del recordatorio actual (para excluirlo)

                    // Se ejecuta la consulta y se obtiene el número de coincidencias.
                    long count = (long)command.ExecuteScalar();

                    // Si ya existe otro recordatorio con la misma fecha y hora (es decir, count > 0), se muestra un error.
                    if (count > 0)
                    {
                        ErrorHoraEdit.Visibility = Visibility.Visible;
                        ErrorHoraEdit.Text = "Ya existe un recordatorio para esa hora.";
                        return; // Se cancela el proceso de actualización.
                    }

                    // Si no hay conflicto, se prepara el comando SQL para actualizar el recordatorio actual.
                    var updateCmd = new SQLiteCommand(
                        "UPDATE Recordatorios SET Nota = @nota, Fecha = @fecha, Hora = @hora WHERE ID_Recordatorios = @id",
                        connection
                    );

                    // Se asignan los nuevos valores a actualizar: nota, fecha y hora.
                    updateCmd.Parameters.AddWithValue("@nota", nota); // Titulo del recordatorio
                    updateCmd.Parameters.AddWithValue("@fecha", fecha.Value.ToString("yyyy-MM-dd")); // Fecha en formato ISO (yyyy-MM-dd)
                    updateCmd.Parameters.AddWithValue("@hora", hora.Value.ToString(@"hh\:mm")); // Hora en formato de 24h (hh:mm)
                    updateCmd.Parameters.AddWithValue("@id", IdRecordatorio);    // ID del recordatorio actual (para excluirlo)

                    // Se ejecuta la actualización en la base de datos.
                    updateCmd.ExecuteNonQuery();
                }
            }

            // Captura cualquier excepción que pueda ocurrir durante la conexión, consulta o actualización en la base de datos.
            catch (Exception ex)
            {
                // Muestra un mensaje de error al usuario con el detalle del problema ocurrido.
                // Esto puede incluir errores de conexión, errores SQL o fallos inesperados.
                MessageBox.Show(
                    $"Ocurrió un error al actualizar el recordatorio:\n{ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                // Se interrumpe el flujo del método para evitar continuar con la ejecución posterior.
                return;
            }

            // Si todas las validaciones fueron exitosas y no hubo errores,
            // se cierra el diálogo indicando que la operación fue completada correctamente.
            // El parámetro "true" puede ser utilizado por el diálogo padre para saber que se debe refrescar la vista u otros datos.
            DialogHost.CloseDialogCommand.Execute("true", null);

        }



    }
}
