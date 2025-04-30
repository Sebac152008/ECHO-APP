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
using System.IO;
using IOPath = System.IO.Path;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace ECHO.View
{
    /// <summary>
    /// Lógica de interacción para RecordatorioItem.xaml
    /// </summary>
    /// 


    public partial class RecordatorioItem : UserControl
    {

        private bool estaDestacado = false;

        public bool IsDestacado { get; private set; } // o public set si quieres permitir cambiarlo externamente


        public event EventHandler RecordatorioDestacadoEvent;


        public bool EsDestacado => estaDestacado;

        public event EventHandler<bool> DestacadoCambiado;

        public event EventHandler<int> CambiarVisibilidadDesdeDestacado;


        public static readonly DependencyProperty DescripcionProperty =
            DependencyProperty.Register(nameof(Descripcion), typeof(string), typeof(RecordatorioItem));

        public static readonly DependencyProperty FechaProperty =
            DependencyProperty.Register(nameof(Fecha), typeof(string), typeof(RecordatorioItem));

        public static readonly DependencyProperty HoraProperty =
            DependencyProperty.Register(nameof(Hora), typeof(string), typeof(RecordatorioItem));

        public string Descripcion
        {
            get => (string)GetValue(DescripcionProperty);
            set => SetValue(DescripcionProperty, value);
        }

        public string Fecha
        {
            get => (string)GetValue(FechaProperty);
            set => SetValue(FechaProperty, value);
        }

        public string Hora
        {
            get => (string)GetValue(HoraProperty);
            set => SetValue(HoraProperty, value);
        }

        string dbPath;

        public RecordatorioItem()
        {
            InitializeComponent();


            // Obtener la ruta de la carpeta "Roaming" del usuario
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Crear la ruta completa de la carpeta "EchoApp"
            string echoAppFolderPath = IOPath.Combine(appDataPath, "EchoApp");

            // Verificar si la carpeta no existe
            if (!Directory.Exists(echoAppFolderPath))
            {
                // Si no existe, la crea
                Directory.CreateDirectory(echoAppFolderPath);
            }

            // Ruta de la base de datos
            dbPath = System.IO.Path.Combine(echoAppFolderPath, "ECHO.db");

            // Aquí es donde puedes usar dbPath para interactuar con tu base de datos
            // Ejemplo de abrir la conexión con SQLite
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={dbPath};"))
                {
                    connection.Open();
                    // Puedes realizar operaciones sobre la base de datos aquí
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        // Método para el corazón (Favorito)

        // Crear un evento para notificar que se quiere eliminar el recordatorio
        public event EventHandler EliminarRecordatorio;

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            // Disparar el evento para que el contenedor lo maneje
            EliminarRecordatorio?.Invoke(this, EventArgs.Empty);

        }

        // Método para el corazón (Favorito)
        private void btnDestacado_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var img = btn.Content as Image;

            estaDestacado = !estaDestacado;
            IsDestacado = estaDestacado; // <- AGREGA ESTO

            if (estaDestacado)
            {
                btnDestacado.ToolTip = "Desmarcar recordatorio";
            }
            if (!estaDestacado)
            {
                btnDestacado.ToolTip = "Marcar como destacado";
            }

            var uri = estaDestacado
                ? "/Imagenes/EstrellaRellenada.png"
                : "/Imagenes/EstrellaVaciaAmarilla.png";

            img.Source = new BitmapImage(new Uri(uri, UriKind.Relative));

            // Guardar el estado en la base de datos
            try
            {
                using (var connection = new SQLiteConnection("Data Source=ECHO.db;"))
                {
                    connection.Open();
                    string update = "UPDATE Recordatorios SET Destacado = @Destacado WHERE ID_Recordatorios = @ID";
                    var command = new SQLiteCommand(update, connection);
                    command.Parameters.AddWithValue("@Destacado", estaDestacado ? 1 : 0);
                    command.Parameters.AddWithValue("@ID", ID_Recordatorios);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar destacado: {ex.Message}");
            }

            RecordatorioDestacadoEvent?.Invoke(this, EventArgs.Empty);

            RecordatorioEventAggregator.RaiseDestacadoToggled(this, estaDestacado);

            CambiarVisibilidadDesdeDestacado?.Invoke(this, ID_Recordatorios);
            // Aquí puedes guardar el estado si lo necesitas
        }


        // Método para mostrar el formulario de agregar recordatorio con animación


        public static readonly DependencyProperty ID_RecordatoriosProperty =
            DependencyProperty.Register(nameof(ID_Recordatorios), typeof(int), typeof(RecordatorioItem));

        public int ID_Recordatorios
        {
            get => (int)GetValue(ID_RecordatoriosProperty);
            set => SetValue(ID_RecordatoriosProperty, value);
        }

        public void SetEstaDestacadoDesdeBD(bool valor)
        {
            estaDestacado = valor;
            IsDestacado = valor; // <- AGREGA ESTO

            if (estaDestacado)
            {
                btnDestacado.ToolTip = "Desmarcar recordatorio";
            }
            if (!estaDestacado)
            {
                btnDestacado.ToolTip = "Marcar como destacado";
            }

            var uri = estaDestacado
                ? "/Imagenes/EstrellaRellenada.png"
                : "/Imagenes/EstrellaVaciaAmarilla.png";

            // Después de cambiar estaDestacado y guardar en BD...
            imgDestacado.Source = new BitmapImage(new Uri(uri, UriKind.Relative));
            // Y lanzas el evento:
            DestacadoCambiado?.Invoke(this, estaDestacado);

        }


    }

}
