// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Espacio de nombres base para funcionalidades fundamentales del sistema, como tipos básicos (int, string, DateTime, etc.)
using System;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Proporciona soporte para operaciones asíncronas, como tareas en segundo plano.
using System.Threading.Tasks;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Contiene clases para trabajar con ventanas y elementos visuales en una aplicación WPF.
using System.Windows;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite el uso de controles de interfaz de usuario como botones, cajas de texto, etc.
using System.Windows.Controls;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Ofrece clases relacionadas con los colores, pinceles, y estilos visuales.
using System.Windows.Media;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite cargar y manipular imágenes en formatos como PNG y JPEG dentro de la interfaz.
using System.Windows.Media.Imaging;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Proporciona conectividad y operaciones con bases de datos SQLite.
using System.Data.SQLite;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa vistas de la aplicación, en este caso probablemente para navegar o mostrar el diálogo `EditarRecordatorioDialog`, etc.
using ECHO.View;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa la clase Path del espacio de nombres System.IO con un alias (`IOPath`) para evitar conflictos con otros "Path" (por ejemplo, `System.Windows.Shapes.Path`).
using IOPath = System.IO.Path;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Permite usar componentes visuales modernos y estilos personalizados del framework Material Design para WPF.
using MaterialDesignThemes.Wpf;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Ofrece soporte para animaciones (por ejemplo, transiciones suaves o efectos visuales).
using System.Windows.Media.Animation;

// La palabra clave "using" se utiliza para importar espacios de nombres (namespaces).
// Un espacio de nombres es un conjunto de clases, funciones y herramientas ya creadas
// que puedes usar en tu código sin tener que escribir su nombre completo.

// Importa recursos personalizados del proyecto, como imágenes, cadenas de texto u otros elementos definidos por el desarrollador.
using ECHO.Recursos;

// La palabra clave "namespace" se utiliza para organizar y agrupar clases relacionadas bajo un mismo nombre lógico.
// Esto ayuda a evitar conflictos de nombres y mejora la organización del código.
// En este caso, el espacio de nombres se llama WPF_ECHO.View y contiene las vistas de la aplicación.
// Aparte el namespace puede ser llamado como el nombre del programa.
namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para MisRecordatoriosVIEW.xaml
    /// </summary>


    // Declaración de una clase parcial llamada "DestacadoView" que hereda de "UserControl".
    // Esta clase representa un control de usuario personalizado dentro de la interfaz WPF,
    // y forma parte de una vista que muestra recordatorios destacados u otra información relevante.
    // Al ser "partial", su definición puede estar dividida en varios archivos, generalmente
    // uno para el código XAML (interfaz) y otro para el code-behind (lógica de comportamiento).
    public partial class DestacadoView : UserControl
    {
        // Campo estático que almacenará una referencia a la instancia actual de la vista DestacadoView
        public static DestacadoView InstanciaActual; // public: accesible desde cualquier parte, static: solo una instancia compartida, DestacadoView: tipo de dato, InstanciaActual: nombre del campo

        // Constructor de la clase DestacadoView, se ejecuta al crear una nueva instancia
        public DestacadoView() // public: accesible desde fuera de la clase, DestacadoView(): constructor sin parámetros
        {
            InitializeComponent(); // Inicializa los componentes definidos en el archivo XAML (controles, bindings, etc.)

            // Obtiene el recurso de animación llamado "VentanaAbrirAnimacion" y lo convierte a tipo Storyboard
            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];
            // Storyboard: tipo de animación en WPF
            // abrirAnim: variable que almacena la animación
            // (Storyboard): convierte el recurso obtenido a tipo Storyboard
            // this.Resources: accede al diccionario de recursos de la vista actual
            // ["VentanaAbrirAnimacion"]: nombre del recurso definido en XAML

            abrirAnim.Begin(this); // Inicia la animación usando la instancia actual como destino

            InstanciaActual = this; // Guarda esta instancia en el campo estático para que pueda ser accedida desde otras partes del programa

            this.Loaded += DestacadoView_Loaded; // Se suscribe al evento Loaded (cuando se carga la vista), y se asigna el método DestacadoView_Loaded como manejador del evento
        }

        // Método público que se puede llamar desde fuera para volver a cargar los recordatorios destacados desde la base de datos
        public void RecargarRecordatorios() // public: accesible desde fuera, void: no retorna nada, RecargarRecordatorios: nombre del método
        {
            CargarRecordatoriosDestacadosDesdeBD(); // Llama a un método (probablemente privado) que obtiene los datos de la base de datos
        }


        // Conexión DB
        private static readonly string connectionString = AppContexto.Instancia.ConexionBD;
        // private: solo accesible dentro de esta clase
        // static: pertenece a la clase, no a una instancia específica
        // readonly: solo se puede asignar una vez (en tiempo de compilación o en el constructor estático)
        // string: tipo de dato que representa texto
        // connectionString: nombre de la variable que contiene la cadena de conexión a la base de datos
        // AppContexto.Instancia.ConexionBD: accede a la propiedad ConexionBD de la instancia singleton AppContexto

        // Método que se ejecuta cuando la imagen de fondo (FondoImagen) termina de cargarse
        private void FondoImagen_Loaded(object sender, RoutedEventArgs e)
        // private: solo accesible dentro de esta clase
        // void: no retorna ningún valor
        // FondoImagen_Loaded: nombre del método que manejará el evento Loaded
        // object sender: objeto que generó el evento
        // RoutedEventArgs e: datos adicionales del evento de WPF
        {
            // Verifica si el recurso llamado "ImagenFondoPrecargada" está presente en los recursos globales de la aplicación
            if (Application.Current.Resources.Contains("ImagenFondoPrecargada"))
            // Application.Current: obtiene la instancia actual de la aplicación
            // .Resources: colección de recursos globales
            // .Contains("..."): verifica si existe una clave específica en los recursos
            {
                // Asigna la imagen precargada como fuente del control FondoImagen
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoPre"];
                // FondoImagen: control de tipo Image definido en el XAML
                // .Source: propiedad que indica la imagen a mostrar
                // (BitmapImage): conversión del recurso al tipo de imagen adecuado
                // Application.Current.Resources["ImagenFondoPre"]: obtiene el recurso de imagen precargada

                // Hace visible el control FondoImagen si estaba oculto
                FondoImagen.Visibility = Visibility.Visible;
                // .Visibility: propiedad que define si el control está visible, oculto o colapsado
                // Visibility.Visible: valor que indica que el control debe mostrarse
            }
        }


        /// <summary>
        /// Carga todos los recordatorios marcados como Destacado = 1
        /// </summary>
        /// 

        // Método que se ejecuta cuando se desmarca un recordatorio desde un item (por ejemplo, se le quita la estrella)
        private void RecordatorioDesmarcadoDesdeItem(object sender, EventArgs e)
        // private: solo accesible dentro de esta clase
        // void: tipo de retorno vacío, es decir, no devuelve ningún valor
        // RecordatorioDesmarcadoDesdeItem: nombre del método (manejador de evento)
        // object sender: referencia al objeto que generó el evento
        // EventArgs e: datos adicionales del evento
        {
            MostrarRecordatorioDesmarcado(); // Llama al método que muestra un mensaje o animación indicando que el recordatorio fue desmarcado
        }

        // Método que muestra una notificación y recarga los recordatorios destacados
        private void MostrarRecordatorioDesmarcado()
        // private: solo accesible dentro de esta clase
        // void: tipo de retorno vacío
        // MostrarRecordatorioDesmarcado: nombre del método
        {
            // Llama a un método para mostrar un mensaje personalizado con un ícono de estrella vacía
            MostrarMensaje("Recordatorio desmarcado", "EstrellaVaciaAmarilla.png");
            // MostrarMensaje: función que probablemente despliega un mensaje flotante o animado al usuario
            // "Recordatorio desmarcado": texto que se muestra al usuario
            // "EstrellaVaciaAmarilla.png": imagen o ícono representativo del estado "desmarcado"

            // Vuelve a cargar los recordatorios destacados desde la base de datos (refresca la lista actual)
            CargarRecordatoriosDestacadosDesdeBD();
            // CargarRecordatoriosDestacadosDesdeBD: método personalizado que recupera de la base de datos todos los recordatorios marcados como destacados
        }

        // Método que se ejecuta automáticamente cuando se carga la vista DestacadoView
        private void DestacadoView_Loaded(object sender, RoutedEventArgs e)
        // private: este método solo puede ser accedido dentro de esta clase
        // void: no retorna ningún valor
        // DestacadoView_Loaded: nombre del método, comúnmente usado para manejar el evento 'Loaded' de un control
        // object sender: el objeto que dispara el evento (en este caso, probablemente la propia vista)
        // RoutedEventArgs e: contiene información sobre el evento de carga (como rutas de evento en la interfaz WPF)
        {
            // Se obtiene el recurso llamado "VentanaAbrirAnimacion" definido en XAML y se convierte a un Storyboard
            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];
            // Storyboard: clase que permite ejecutar animaciones en WPF
            // this.Resources["VentanaAbrirAnimacion"]: busca dentro de los recursos definidos en esta vista (XAML) un storyboard llamado "VentanaAbrirAnimacion"
            // (Storyboard): hace una conversión explícita del recurso encontrado al tipo Storyboard

            abrirAnim.Begin(this);
            // .Begin(this): inicia la animación del storyboard en el contexto de esta vista (this = DestacadoView)

            CargarRecordatoriosDestacadosDesdeBD();
            // Llama al método que carga desde la base de datos todos los recordatorios marcados como "destacados"
            // Esto se hace justo después de que la animación comienza, para mostrar los datos actualizados
        }


        // Método privado que carga los recordatorios marcados como "destacados" desde la base de datos y los muestra en la interfaz
        private void CargarRecordatoriosDestacadosDesdeBD()
        {
            StackPanelContenedor.Children.Clear();
            // StackPanelContenedor: contenedor visual (en la interfaz) que muestra los recordatorios
            // .Children: colección de elementos hijos (recordatorios mostrados)
            // .Clear(): elimina todos los elementos actuales para cargar una lista nueva

            try
            {
                // Se crea y abre una conexión a la base de datos SQLite
                using (var connection = new SQLiteConnection(connectionString))
                // using: asegura que la conexión se cierre y libere correctamente al finalizar
                // SQLiteConnection: clase que representa una conexión con SQLite
                // connectionString: cadena que contiene la ruta/configuración de conexión

                {
                    connection.Open(); // Abre la conexión a la base de datos

                    // Consulta SQL para seleccionar todos los recordatorios marcados como destacados, ordenados del más reciente al más antiguo
                    var selectQuery = "SELECT * FROM Recordatorios WHERE Destacado = 1 ORDER BY ID_Recordatorios DESC";

                    using (var command = new SQLiteCommand(selectQuery, connection))
                    // SQLiteCommand: objeto que representa la consulta a ejecutar
                    // selectQuery: contiene el texto SQL
                    // connection: conexión a usar para ejecutar la consulta

                    using (var reader = command.ExecuteReader())
                    // ExecuteReader(): ejecuta la consulta y devuelve un objeto que permite leer fila por fila
                    {
                        while (reader.Read())
                        // reader.Read(): se mueve a la siguiente fila y retorna true si hay datos
                        {
                            // Se crea un nuevo control personalizado para representar el recordatorio destacado
                            var item = new RecordatorioItem
                            {
                                ID_Recordatorios = Convert.ToInt32(reader["ID_Recordatorios"]),
                                // Convierte el valor del campo ID_Recordatorios a entero
                                Descripcion = reader["Nota"].ToString(),
                                // Obtiene el texto de la nota (descripción del recordatorio)
                                Fecha = reader["Fecha"].ToString(),
                                // Obtiene la fecha como string
                                Hora = reader["Hora"].ToString()
                                // Obtiene la hora como string
                            };

                            // Se suscriben los eventos personalizados del control (acciones del usuario)
                            item.RecordatorioDestacadoEvent += RecordatorioDesmarcadoDesdeItem;
                            // Evento que se dispara cuando el recordatorio es desmarcado (quitado de destacados)

                            item.EliminarRecordatorio += Recordatorio_EliminarRecordatorio;
                            // Evento que se dispara cuando el usuario quiere eliminar el recordatorio

                            item.SetEstaDestacadoDesdeBD(true);
                            // Marca visualmente el recordatorio como "destacado" al cargarlo desde base de datos

                            // Se suscribe a cambios en el estado de destacado (cuando se marca/desmarca)
                            item.DestacadoCambiado += (s, esDestacado) =>
                            {
                                OnDestacadoToggled(item, esDestacado);
                                // Método que maneja el cambio de estado del destacado
                            };

                            // Se suscribe al evento de edición (cuando el usuario hace clic en editar)
                            item.EditarClicked += (s, e) =>
                            {
                                EditarRecordatorio(item);
                                // Método que abre el diálogo para editar el recordatorio
                            };

                            // Finalmente, se inserta el nuevo recordatorio en la interfaz al inicio del contenedor
                            StackPanelContenedor.Children.Insert(0, item);
                            // Insert(0, item): agrega el control en la primera posición del StackPanel para que el más reciente aparezca arriba
                        }
                    }
                }
            }
            // Captura errores específicos de SQLite (por ejemplo, problemas de conexión)
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Error de conexión a la base de datos: {ex.Message}");
                // Muestra un mensaje de error al usuario con el detalle del problema
            }
            // Captura cualquier otro tipo de error general
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar destacados: {ex.Message}");
                // Muestra un mensaje con el error inesperado ocurrido
            }
        }


        // Método privado que muestra un mensaje visual cuando un recordatorio ha sido eliminado
        private void MostrarRecordatorioEliminado()
        {
            // Llama al método MostrarMensaje para mostrar una notificación personalizada
            // "Recordatorio eliminado" es el texto que se mostrará al usuario
            // "eliminar.png" es el nombre del ícono o imagen asociada a la acción de eliminar
            MostrarMensaje("Recordatorio eliminado", "eliminar.png");
        }


        /* Estos son los mensajes que te dicen cuando añadiste o eliminaste y destacaste un recordatorio */

        // Método asincrónico (async) que muestra un mensaje visual animado con texto e ícono
        private async void MostrarMensaje(string texto, string icono)
        {
            // Crear un contenedor visual de tipo Border que encapsula el mensaje
            Border borde = new Border
            {
                Background = (Brush)new BrushConverter().ConvertFromString("#f4f4f4"), // Color de fondo gris claro
                CornerRadius = new CornerRadius(10), // Bordes redondeados
                Margin = new Thickness(0, 15, 0, 0), // Margen superior de 15 píxeles
                Padding = new Thickness(10), // Relleno interno uniforme
                Opacity = 0, // Inicialmente invisible (para animación fade-in)

                // Contenido del borde: un StackPanel con imagen e ícono
                Child = new StackPanel
                {
                    Orientation = Orientation.Horizontal, // Elementos en línea horizontal
                    Children =
            {
                // Imagen del ícono del mensaje (por ejemplo: estrella, papelera, etc.)
                new Image
                {
                    Source = new BitmapImage(new Uri($"pack://application:,,,/Imagenes/{icono}", UriKind.Absolute)), // Ruta del recurso
                    Width = 24, // Ancho de la imagen
                    Height = 24, // Alto de la imagen
                    Margin = new Thickness(0,0,10,0) // Espacio derecho entre la imagen y el texto
                },
                
                // Texto del mensaje
                new TextBlock
                {
                    Text = texto, // El texto que se va a mostrar (por ejemplo, "Recordatorio eliminado")
                    Foreground = Brushes.Black, // Color del texto
                    VerticalAlignment = VerticalAlignment.Center, // Centrado verticalmente
                    FontSize = 14, // Tamaño del texto
                    TextWrapping = TextWrapping.Wrap // Permite que el texto haga salto de línea si es necesario
                }
            }
                }
            };

            // Agregar el borde (mensaje visual) al contenedor StackMensajes
            StackMensajes.Children.Add(borde);

            // Crear animación de entrada (fade-in): de opacidad 0 a 1 en 300 ms
            DoubleAnimation fadeIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(300));
            borde.BeginAnimation(Border.OpacityProperty, fadeIn); // Aplicar animación al borde

            // Esperar 2.5 segundos antes de ocultar el mensaje
            await Task.Delay(2500);

            // Crear animación de salida (fade-out): de opacidad 1 a 0 en 300 ms
            DoubleAnimation fadeOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(300));

            // Cuando termine el fade-out, eliminar el borde del contenedor visual
            fadeOut.Completed += (s, e) => StackMensajes.Children.Remove(borde);

            // Ejecutar la animación de salida
            borde.BeginAnimation(Border.OpacityProperty, fadeOut);
        }


        // Método que se ejecuta cuando se cambia el estado de "destacado" de un recordatorio
        private void OnDestacadoToggled(RecordatorioItem item, bool isDestacado)
        {
            // Verifica si el item ya no está marcado como destacado
            if (!item.IsDestacado) // Si el recordatorio ha sido desmarcado como destacado
            {
                // Elimina el item del panel visual donde se muestran los destacados
                StackPanelContenedor.Children.Remove(item);

                // Dispara un evento global que informa que el recordatorio fue desdestacado
                RecordatorioEventAggregator.OnRecordatorioDesdestacado(item);
            }
        }

        // Método para eliminar un recordatorio de la base de datos usando su ID
        private void EliminarRecordatorioDeBD(int id) // Recibe como parámetro el ID del recordatorio a eliminar
        {
            try // Intentar ejecutar el bloque de código que puede lanzar excepciones
            {
                // Crea una nueva conexión a la base de datos SQLite usando la cadena de conexión definida
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open(); // Abre la conexión con la base de datos

                    // Define la consulta SQL para eliminar un registro con un ID específico
                    string query = "DELETE FROM Recordatorios WHERE ID_Recordatorios = @id";

                    // Crea un comando SQLite con la consulta y la conexión abierta
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // Agrega el parámetro @id al comando con el valor recibido por el método
                        command.Parameters.AddWithValue("@id", id);

                        // Ejecuta la consulta y devuelve la cantidad de filas afectadas (debería ser 1 si se eliminó)
                        int rowsAffected = command.ExecuteNonQuery();

                        // Si no se afectó ninguna fila, significa que no se encontró el recordatorio con ese ID
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show($"No se encontró ningún recordatorio con ID: {id} para eliminar.");
                        }
                    }
                }
            }
            catch (Exception ex) // Captura cualquier excepción que ocurra en el bloque try
            {
                // Muestra un mensaje de error en caso de que ocurra alguna excepción
                MessageBox.Show("Error al eliminar el recordatorio: " + ex.Message);
            }
        }


        // Método asincrónico que se ejecuta cuando se solicita eliminar un recordatorio
        private async void Recordatorio_EliminarRecordatorio(object sender, EventArgs e)
        {
            // Convertimos el objeto sender al tipo RecordatorioItem
            var recordatorio = sender as RecordatorioItem;

            // Si no se pudo convertir (es nulo), salimos del método
            if (recordatorio == null) return;

            // Mostramos un diálogo de confirmación usando MaterialDesign DialogHost
            var dialogResult = await MaterialDesignThemes.Wpf.DialogHost.Show(
                new TextBlock // Mensaje simple por defecto, en caso de que no se use la plantilla visual completa
                {
                    Text = "¿Estás seguro de que deseas eliminar este recordatorio?", // Texto del mensaje
                    TextWrapping = TextWrapping.Wrap, // Que el texto se ajuste a varias líneas si es necesario
                    Margin = new Thickness(20), // Márgenes alrededor del texto
                    Width = 300 // Ancho del cuadro de texto
                },
                "MainDialogHost", // Nombre del host de diálogo definido en el XAML
                (object s, DialogOpenedEventArgs args) => // Evento que ocurre cuando el diálogo se abre
                {
                    // Creamos una interfaz personalizada para el contenido del diálogo
                    var dialogGrid = new StackPanel
                    {
                        Orientation = Orientation.Vertical, // Elementos uno debajo del otro
                        Children =
                        {
                    new TextBlock // Título o mensaje de confirmación
                    {
                        Text = "¿Estás seguro de que deseas eliminar este recordatorio?",
                        FontSize = 16, // Tamaño de fuente
                        TextWrapping = TextWrapping.Wrap,
                        Margin = new Thickness(20, 20, 20, 16) // Márgenes para espaciar el texto
                    },
                    new StackPanel // Contenedor horizontal para los botones
                    {
                        Orientation = Orientation.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Right, // Botones alineados a la derecha
                        Children =
                        {
                            new Button // Botón "Cancelar"
                            {
                                Content = "Cancelar", // Texto del botón
                                Margin = new Thickness(0,0,8,0), // Margen derecho para separación
                                Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff")), // Color del texto
                                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C3E50")), // Color de fondo
                                Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand, // Cierra el diálogo
                                CommandParameter = false // El parámetro devuelto será "false"
                            },
                            new Button // Botón "Eliminar"
                            {
                                Content = "Eliminar",
                                Margin = new Thickness (10,10,10,10), // Margen completo alrededor
                                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0392B")), // Fondo rojo
                                Foreground = Brushes.White, // Texto blanco
                                Command = MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand,
                                CommandParameter = true // El parámetro devuelto será "true"
                            }
                        }
                    }
                        }
                    };

                    // Actualiza el contenido del diálogo con la interfaz personalizada
                    args.Session.UpdateContent(dialogGrid);
                });

            // Si el usuario hizo clic en "Eliminar" (confirmado = true)
            if (dialogResult is bool confirmado && confirmado)
            {
                // Llama al método para eliminar el recordatorio de la base de datos
                EliminarRecordatorioDeBD(recordatorio.ID_Recordatorios);

                // Quita el item eliminado de la interfaz visual (StackPanel)
                StackPanelContenedor.Children.Remove(recordatorio);

                // Muestra un mensaje indicando que el recordatorio fue eliminado
                MostrarRecordatorioEliminado();
            }
        }


        // Método asincrónico que permite editar un recordatorio existente
        private async void EditarRecordatorio(RecordatorioItem recordatorio)
        {
            // Crear una instancia del control de edición de recordatorio (un UserControl que contiene los campos de edición)
            var editarControl = new EditarRecordatorioDialog
            {
                // Asignar el ID actual del recordatorio al diálogo, para saber cuál se está editando
                IdRecordatorio = recordatorio.ID_Recordatorios
            };

            // Asignar el texto de la nota actual al campo de texto del formulario de edición
            editarControl.txtNotaEditar.Text = recordatorio.Descripcion;

            // Convertir la cadena con la fecha (en formato string) a un objeto DateTime
            // y asignarla al control de selección de fecha
            editarControl.fechaEditar.SelectedDate = DateTime.Parse(recordatorio.Fecha);

            // Intentar interpretar la hora del recordatorio (ej. "14:30") como un objeto TimeSpan
            // Esto sirve para validarla y asignarla al control de selección de hora
            if (!TimeSpan.TryParse(recordatorio.Hora, out TimeSpan horaParseada))
            {
                // Si la conversión falla, se muestra un mensaje de error
                MessageBox.Show(
                    "La hora del recordatorio no se pudo interpretar correctamente.", // Texto del mensaje
                    "Error", // Título del cuadro
                    MessageBoxButton.OK, // Botón único de Aceptar
                    MessageBoxImage.Error // Ícono de error
                );
                return; // Salir del método sin continuar
            }

            // Si la hora fue válida, se asigna al control de hora (como una hora del día actual)
            editarControl.horaEditar.SelectedTime = DateTime.Today.Add(horaParseada);

            // Mostrar el diálogo de edición en el host de diálogos principal llamado "MainDialogHost"
            // y esperar (await) hasta que el usuario confirme o cancele
            var resultado = await MaterialDesignThemes.Wpf.DialogHost.Show(editarControl, "MainDialogHost");

            // Si el usuario hizo clic en "Aceptar" o "Guardar" en el diálogo
            // (el valor retornado es el string "true")
            if (resultado is "true")
            {
                // Capturar el nuevo texto ingresado por el usuario
                string nuevaNota = editarControl.txtNotaEditar.Text;

                // Capturar la nueva fecha seleccionada (puede ser nula, por eso es DateTime?)
                DateTime? nuevaFecha = editarControl.fechaEditar.SelectedDate;

                // Capturar la nueva hora seleccionada (puede ser nula, por eso es TimeSpan?)
                TimeSpan? nuevaHora = editarControl.horaEditar.SelectedTime?.TimeOfDay;

                // Validar que todos los valores requeridos sean válidos y no estén vacíos
                if (!string.IsNullOrWhiteSpace(nuevaNota) && nuevaFecha != null && nuevaHora != null)
                {
                    try
                    {
                        // Crear una nueva conexión a la base de datos usando la cadena de conexión definida
                        using (var conn = new SQLiteConnection(connectionString))
                        {
                            // Abrir la conexión con la base de datos SQLite
                            conn.Open();

                            // Crear el comando SQL para actualizar el recordatorio con nuevos datos
                            var cmd = new SQLiteCommand(
                                "UPDATE Recordatorios SET Nota=@nota, Fecha=@fecha, Hora=@hora WHERE ID_Recordatorios=@id",
                                conn
                            );

                            // Asignar los parámetros al comando SQL
                            cmd.Parameters.AddWithValue("@nota", nuevaNota); // nueva nota escrita
                            cmd.Parameters.AddWithValue("@fecha", nuevaFecha.Value.ToString("yyyy-MM-dd")); // formato de fecha internacional
                            cmd.Parameters.AddWithValue("@hora", nuevaHora.Value.ToString(@"hh\:mm")); // formato 24h de la hora
                            cmd.Parameters.AddWithValue("@id", recordatorio.ID_Recordatorios); // ID del recordatorio a actualizar

                            // Ejecutar el comando SQL que actualiza el registro en la base de datos
                            cmd.ExecuteNonQuery();
                        }

                        // Mostrar mensaje animado de éxito al usuario con ícono "comprobado.png"
                        MostrarMensaje("Recordatorio editado", "comprobado.png");

                        // Volver a cargar los recordatorios destacados desde la base de datos
                        // para que se reflejen los cambios en la interfaz
                        CargarRecordatoriosDestacadosDesdeBD();
                    }
                    catch (Exception ex)
                    {
                        // Mostrar mensaje de error si ocurre algún problema durante la actualización
                        MessageBox.Show($"Error al editar: {ex.Message}");
                    }
                }
            }
        }


    }

}
