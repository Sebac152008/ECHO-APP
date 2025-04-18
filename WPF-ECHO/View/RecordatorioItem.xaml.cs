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

namespace ECHO.View
{
    /// <summary>
    /// Lógica de interacción para RecordatorioItem.xaml
    /// </summary>
    public partial class RecordatorioItem : UserControl
    {

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

        public RecordatorioItem()
        {
            InitializeComponent();
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
        private void btnCorazon_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var img = btn.Content as Image;

            // Alterna entre el icono vacío y el relleno del corazón
            var uri = img.Source.ToString().Contains("vacio")
                ? "/Imagenes/corazon-rellenado.png"
                : "/Imagenes/corazon-vacio.png";

            img.Source = new BitmapImage(new Uri(uri, UriKind.Relative));

            // Aquí podrías actualizar la base de datos o el modelo para reflejar el cambio
        }

        // Método para mostrar el formulario de agregar recordatorio con animación


        public static readonly DependencyProperty ID_RecordatoriosProperty =
            DependencyProperty.Register(nameof(ID_Recordatorios), typeof(int), typeof(RecordatorioItem));

        public int ID_Recordatorios
        {
            get => (int)GetValue(ID_RecordatoriosProperty);
            set => SetValue(ID_RecordatoriosProperty, value);
        }


    }

}
