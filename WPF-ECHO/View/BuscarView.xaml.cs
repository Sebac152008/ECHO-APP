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
    /// Lógica de interacción para BuscarView.xaml
    /// </summary>
    public partial class BuscarView : UserControl
    {
        public BuscarView()
        {
            InitializeComponent();
        }

        private void txtBuscarRecordatorio_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtBuscarRecordatorio.Text == "Buscar recordatorio...")
            {
                txtBuscarRecordatorio.Text = "";
                txtBuscarRecordatorio.Foreground = Brushes.White;
            }
        }

        private void txtBuscarRecordatorio_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtBuscarRecordatorio.Text == "")
            {
                txtBuscarRecordatorio.Text = "Buscar recordatorio...";
                txtBuscarRecordatorio.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#A2AAB2"));
            }
        }
    }
}
