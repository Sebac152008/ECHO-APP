using ECHO.View;
using System;

public static class RecordatorioEventAggregator
{
    /// <summary>
    /// Se dispara cuando un RecordatorioItem cambia su estado Destacado.
    /// </summary>
    public static event Action<RecordatorioItem> RecordatorioDesdestacado;

    public static event Action<RecordatorioItem, bool> DestacadoToggled; 

    public static void OnRecordatorioDesdestacado(RecordatorioItem item)
    {
        RecordatorioDesdestacado?.Invoke(item);
    }

    public static void RaiseDestacadoToggled(RecordatorioItem item, bool isDestacado)
    {
        DestacadoToggled?.Invoke(item, isDestacado);
    }
}
