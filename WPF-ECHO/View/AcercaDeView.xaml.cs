// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// La palabra clave "namespace" se utiliza para organizar y agrupar clases relacionadas bajo un mismo nombre lógico.
// Esto ayuda a evitar conflictos de nombres y mejora la organización del código.
// En este caso, el espacio de nombres se llama WPF_ECHO.View y contiene las vistas de la aplicación.
// Aparte el namespace puede ser llamado como el nombre del programa.
namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para AcercaDeView.xaml
    /// </summary>


    // Declaración parcial de la clase AcercaDeView que hereda de UserControl.
    // Representa una vista o componente visual reutilizable dentro de la aplicación,
    // típicamente usada para mostrar información "Acerca de" o detalles de la app.
    public partial class AcercaDeView : UserControl
    {
        // Constructor de la clase AcercaDeView, se ejecuta al crear la instancia de esta vista.
        public AcercaDeView()
        {
            // Inicializa los componentes definidos en el XAML asociado a esta vista.
            InitializeComponent();

            // Obtiene la animación 'VentanaAbrirAnimacion' definida en los recursos de esta vista.
            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];

            // Inicia la animación para la apertura o aparición de la vista.
            abrirAnim.Begin(this);

            // Se suscribe al evento Loaded, que se dispara cuando la vista termina de cargarse.
            // Asigna el manejador AcercaDeView_Loaded1 para ejecutar código adicional tras la carga.
            this.Loaded += AcercaDeView_Loaded1;
        }

        // Evento que se ejecuta cuando la vista ha terminado de cargarse en la interfaz.
        private void AcercaDeView_Loaded1(object sender, RoutedEventArgs e)
        {
            // Vuelve a obtener la animación 'VentanaAbrirAnimacion' de los recursos.
            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];

            // Reproduce nuevamente la animación para asegurar que se vea al cargar la vista.
            abrirAnim.Begin(this);
        }


        // Este método se ejecuta cuando la imagen (control Image) ha terminado de cargarse en la interfaz.
        // Su propósito es establecer la imagen de fondo para la vista "AcercaDe" si está disponible en los recursos globales.
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            // Verifica si el diccionario de recursos globales de la aplicación contiene una imagen con la clave "ImagenFondoAcerca".
            // Esto permite cambiar dinámicamente el fondo sin hardcodear la ruta ni el recurso.
            if (Application.Current.Resources.Contains("ImagenFondoAcerca"))
            {
                // Recupera el recurso de imagen desde la colección global, lo convierte a BitmapImage y lo asigna como fuente para el control FondoImagen.
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoAcerca"];

                // Cambia la visibilidad del control para asegurarse que la imagen se muestre en la interfaz.
                FondoImagen.Visibility = Visibility.Visible;
            }
            // Si no existe el recurso, no se realiza ninguna acción para evitar errores o que la interfaz muestre un fondo vacío.
        }

        // Método manejador para el evento RequestNavigate de un Hyperlink en WPF.
        // Su función es abrir la URL asociada en el navegador web predeterminado cuando el usuario hace clic en el enlace.
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // Utiliza ProcessStartInfo con UseShellExecute=true para abrir la URL usando el navegador predeterminado del sistema operativo.
            // Esto es importante porque UseShellExecute habilita que el proceso se inicie con el shell del SO, permitiendo abrir enlaces HTTP.
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });

            // Marca el evento como manejado para que WPF no procese la navegación adicionalmente ni lance errores.
            e.Handled = true;
        }


    }
}
