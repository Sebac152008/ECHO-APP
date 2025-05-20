using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WPF_ECHO.View;

namespace ECHO.Recursos
{
    public sealed class AppContexto
    {
        private static readonly Lazy<AppContexto> _instancia =
            new Lazy<AppContexto>(() => new AppContexto());

        public static AppContexto Instancia => _instancia.Value;

        public string ConexionBD { get; private set; }

        private AppContexto()
        {

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ECHO.db");
            ConexionBD = $"Data Source={dbPath};";
        }

    }

}
