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

namespace WPF_ECHO.View
{
    /// <summary>
    /// Lógica de interacción para InicioView.xaml
    /// </summary>
    public partial class InicioView : UserControl
    {
        private bool animacionEnCurso = false;
        public InicioView()
        {
            InitializeComponent();
            ContenedorAddRecordatorio.Visibility = Visibility.Collapsed;

            for (int i = 0; i < 24; i++)
            {
                comboHoras.Items.Add(i.ToString("D2")); // Agrega 00 a 23
            }
            for (int i = 0; i < 59; i++)
            {
                comboMin.Items.Add(i.ToString("D2")); // Agrega 00 a 59
            }

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (animacionEnCurso)
                return; // Si ya está animando, no hace nada

            animacionEnCurso = true;

            if (ContenedorAddRecordatorio.Visibility != Visibility.Visible)
            {
                // Mostrar el panel con animación de entrada
                ContenedorAddRecordatorio.Visibility = Visibility.Visible;

                var slideIn = (Storyboard)FindResource("SlideInFromRightAnimation");
                slideIn.Begin(ContenedorAddRecordatorio);

                // Esperar duración de la animación (600ms)
                await Task.Delay(600);
            }
            else
            {
                var slideOut = (Storyboard)FindResource("SlideOutToRightAnimation");
                slideOut.Completed += (s, ev) =>
                {
                    ContenedorAddRecordatorio.Visibility = Visibility.Collapsed;
                };
                slideOut.Begin(ContenedorAddRecordatorio);

                // Esperar también duración de la animación
                await Task.Delay(600);
            }

            animacionEnCurso = false;
        }

        private void txtNota_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNota.Text == "Escribe algo...")
            {
                txtNota.Text = "";
                txtNota.Foreground = Brushes.White;
            }
        }

        private void txtNota_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNota.Text == "")
            {
                txtNota.Text = "Escribe algo...";
                txtNota.Foreground = Brushes.White;
            }
        }


    }
}
