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
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Resources.Contains("ImagenFondoPrecargada"))
            {
                FondoImagen.Source = (BitmapImage)Application.Current.Resources["ImagenFondoPrecargada"];
                FondoImagen.Visibility = Visibility.Visible;
            }
        }
    }
}
