using ECHO.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECHO.ViewModels
{
    public static class RecordatorioEventAggregator
    {
        /// <summary>
        /// Se dispara cuando un RecordatorioItem cambia su estado Destacado.
        /// </summary>
        public static event Action<RecordatorioItem, bool> DestacadoToggled;

        public static void RaiseDestacadoToggled(RecordatorioItem item, bool isDestacado)
            => DestacadoToggled?.Invoke(item, isDestacado);
    }
}
