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
    /// Lógica de interacción para AcercaDeView.xaml
    /// </summary>
    public partial class AcercaDeView : UserControl
    {
        public AcercaDeView()
        {
            InitializeComponent();
            this.Loaded += AcercaDeView_Loaded1;
        }

        private void AcercaDeView_Loaded1(object sender, RoutedEventArgs e)
        {
            Storyboard abrirAnim = (Storyboard)this.Resources["VentanaAbrirAnimacion"];
            abrirAnim.Begin(this);
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.Contains("ImagenFondoAcerca"))
            {
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoAcerca"];
                FondoImagen.Visibility = Visibility.Visible;
            }
        }
    }
}
