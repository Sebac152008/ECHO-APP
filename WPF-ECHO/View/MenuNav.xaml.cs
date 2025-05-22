// -------- ESPACIOS DE NOMBRES O LIBRERIAS --------
// Se importan las bibliotecas necesarias para el funcionamiento del programa.
using System; // Proporciona tipos fundamentales y funcionalidades básicas del sistema.
using System.Collections.Generic; // Permite el uso de colecciones como listas y diccionarios.
using System.Linq; // Contiene métodos para trabajar con consultas y manipulación de datos.
using System.Text; // Proporciona clases para el manejo de texto y codificación.
using System.Threading.Tasks; // Habilita operaciones asincrónicas y programación basada en tareas.
using System.Windows; // Espacio de nombres principal para aplicaciones WPF.
using System.Windows.Controls; // Contiene controles de usuario como botones, cajas de texto y más.
using System.Windows.Data; // Facilita la vinculación de datos entre la interfaz y la lógica.
using System.Windows.Documents; // Maneja elementos relacionados con documentos de texto.
using System.Windows.Input; // Define eventos y métodos para la interacción del usuario, como clics y teclas.
using System.Windows.Media; // Proporciona herramientas para gráficos, colores y efectos visuales.
using System.Windows.Media.Imaging; // Permite trabajar con imágenes en WPF.
using System.Windows.Shapes; // Contiene primitivas gráficas como rectángulos y círculos.
using WPF_ECHO.ViewModels; // Importa los modelos de vista definidos en el proyecto WPF_ECHO.

// La palabra clave "namespace" se utiliza para organizar y agrupar clases relacionadas bajo un mismo nombre lógico.
// Esto ayuda a evitar conflictos de nombres y mejora la organización del código.
// En este caso, el espacio de nombres se llama WPF_ECHO.View y contiene las vistas de la aplicación.
// Aparte el namespace puede ser llamado como el nombre del programa.
namespace WPF_ECHO.View
{
    /// <summary>
    /// Clase que define la lógica de interacción para la pantalla de navegación del menú.
    /// </summary>
    public partial class MenuNav : UserControl
    {
        // -------- EXPLICACIÓN DE 'public', 'partial' y 'class' --------
        // 'public' indica que la clase es accesible desde cualquier parte del código.
        // Esto significa que otras clases pueden instanciar y utilizar 'MenuNav' sin restricciones.

        // 'partial' señala que esta clase puede estar dividida en múltiples archivos.
        // En este caso, la lógica de la interfaz gráfica de 'MenuNav' puede estar definida en un archivo XAML asociado.

        // 'class' define que 'MenuNav' es una clase, es decir, una estructura que contiene propiedades y métodos
        // para representar un objeto en la aplicación.

        // -------- CONSTRUCTOR DE LA CLASE --------
        public MenuNav()
        {
            // Inicializa los componentes de la interfaz gráfica.
            // 'InitializeComponent()' carga los elementos definidos en el archivo XAML correspondiente.
            InitializeComponent();
        }
    }
}